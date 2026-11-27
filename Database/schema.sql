/* =====================================================================
   Öğrenci Yurt Sistemi - Veritabanı ŞEMASI (yalnızca yapı, veri yok)
   Hedef: SQL Server 2016+ / LocalDB
   Kullanım: SSMS'te veya
     sqlcmd -S "(localdb)\MSSQLLocalDB" -E -i Database\schema.sql
   Ardından isteğe bağlı: Database\seed.sql (uydurma örnek veri)
   ===================================================================== */

IF DB_ID(N'Ogrenci_Yurt_Sistemi') IS NULL
    CREATE DATABASE [Ogrenci_Yurt_Sistemi] COLLATE Turkish_CI_AI;
GO
USE [Ogrenci_Yurt_Sistemi];
GO

/* ---------- Bölümler ---------- */
CREATE TABLE dbo.Bolumler (
    Bolumid   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Bolumler PRIMARY KEY,
    BolumAd   NVARCHAR(50)      NOT NULL CONSTRAINT UQ_Bolumler_BolumAd UNIQUE
);
GO

/* ---------- Odalar ---------- */
CREATE TABLE dbo.Odalar (
    Odaid        INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Odalar PRIMARY KEY,
    OdaNo        NVARCHAR(10)      NOT NULL CONSTRAINT UQ_Odalar_OdaNo UNIQUE,
    OdaKapasite  TINYINT           NOT NULL,
    OdaAktif     TINYINT           NOT NULL CONSTRAINT DF_Odalar_OdaAktif DEFAULT (0),
    OdaDurumu    BIT               NOT NULL CONSTRAINT DF_Odalar_OdaDurumu DEFAULT (1),
    CONSTRAINT CK_Odalar_Kapasite CHECK (OdaKapasite > 0),
    CONSTRAINT CK_Odalar_Aktif    CHECK (OdaAktif >= 0 AND OdaAktif <= OdaKapasite)
);
GO

/* ---------- Öğrenci ----------
   Not: Uygulama bölümü ve odayı ADI/NUMARASI ile sakladığı için
   yabancı anahtarlar Bolumler.BolumAd ve Odalar.OdaNo (UNIQUE) sütunlarına bağlanır.
   Bölüm adı değişirse ON UPDATE CASCADE ile öğrenci kaydı da güncellenir. */
CREATE TABLE dbo.Ogrenci (
    Ogrid           INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Ogrenci PRIMARY KEY,
    OgrAd           NVARCHAR(30)  NOT NULL,
    OgrSoyad        NVARCHAR(30)  NOT NULL,
    OgrTc           CHAR(11)      NOT NULL CONSTRAINT UQ_Ogrenci_OgrTc UNIQUE,
    OgrTelefon      NVARCHAR(20)  NULL,
    OgrDogum        NVARCHAR(10)  NULL,   -- uygulama "gg.aa.yyyy" metni gönderiyor (bkz. README / kalan riskler)
    OgrBolum        NVARCHAR(50)  NULL,
    OgrMail         NVARCHAR(100) NULL,
    OgrOdaNo        NVARCHAR(10)  NULL,
    OgrVeliAdSoyad  NVARCHAR(60)  NULL,
    OgrVeliTelefon  NVARCHAR(20)  NULL,
    OgrVeliAdres    NVARCHAR(250) NULL,
    CONSTRAINT CK_Ogrenci_OgrTc CHECK (OgrTc NOT LIKE '%[^0-9]%'),
    CONSTRAINT FK_Ogrenci_Bolumler FOREIGN KEY (OgrBolum)
        REFERENCES dbo.Bolumler (BolumAd) ON UPDATE CASCADE,
    CONSTRAINT FK_Ogrenci_Odalar FOREIGN KEY (OgrOdaNo)
        REFERENCES dbo.Odalar (OdaNo) ON UPDATE CASCADE
);
GO
CREATE INDEX IX_Ogrenci_OgrBolum ON dbo.Ogrenci (OgrBolum);
CREATE INDEX IX_Ogrenci_OgrOdaNo ON dbo.Ogrenci (OgrOdaNo);
GO

/* ---------- Borçlar (öğrenci başına TEK satır) ---------- */
CREATE TABLE dbo.Borclar (
    Borcid           INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Borclar PRIMARY KEY,
    Ogrid            INT  NOT NULL CONSTRAINT UQ_Borclar_Ogrid UNIQUE,
    OgrKalanBorc     INT  NOT NULL CONSTRAINT DF_Borclar_OgrKalanBorc DEFAULT (9000),
    BorcOdemeTarihi  DATE NULL,
    CONSTRAINT CK_Borclar_Kalan CHECK (OgrKalanBorc >= 0),
    CONSTRAINT FK_Borclar_Ogrenci FOREIGN KEY (Ogrid)
        REFERENCES dbo.Ogrenci (Ogrid) ON DELETE CASCADE
);
GO

/* ---------- Personel ---------- */
CREATE TABLE dbo.Personel (
    Personelid       INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Personel PRIMARY KEY,
    PersonelAd       NVARCHAR(50)  NOT NULL,
    PersonelSoyad    NVARCHAR(50)  NOT NULL,
    PersonelTelefon  NVARCHAR(20)  NULL,
    PersonelMail     NVARCHAR(50)  NULL,   -- uzunluklar FrmPersonel'in DataSet'iyle uyumlu tutuldu
    PersonelGorev    NVARCHAR(30)  NOT NULL,
    PersonelMaas     DECIMAL(10,2) NULL CONSTRAINT CK_Personel_Maas CHECK (PersonelMaas >= 0)
);
GO

/* ---------- Yöneticiler ----------
   YoneticiSifre: PBKDF2-SHA256 hash'i ("PBKDF2-SHA256$iterasyon$tuz$hash").
   Düz metin şifre SAKLANMAZ. */
CREATE TABLE dbo.Admin (
    Yoneticiid            INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Admin PRIMARY KEY,
    YoneticiAd            NVARCHAR(20)  NOT NULL,   -- uzunluklar FrmYoneticislemleri'nin DataSet'iyle uyumlu
    YoneticiSoyad         NVARCHAR(20)  NOT NULL,
    YoneticiTelefon       NVARCHAR(20)  NULL,
    YoneticiMail          NVARCHAR(50)  NULL,
    YoneticiKullaniciAdi  NVARCHAR(50)  NOT NULL CONSTRAINT UQ_Admin_KullaniciAdi UNIQUE,
    YoneticiSifre         NVARCHAR(255) NOT NULL
);
GO

/* ---------- Giderler ---------- */
CREATE TABLE dbo.Gider (
    Odemeid      INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Gider PRIMARY KEY,
    Elektrik     INT  NOT NULL CONSTRAINT DF_Gider_Elektrik DEFAULT (0),
    Su           INT  NOT NULL CONSTRAINT DF_Gider_Su       DEFAULT (0),
    Dogalgaz     INT  NOT NULL CONSTRAINT DF_Gider_Dogalgaz DEFAULT (0),
    internet     INT  NOT NULL CONSTRAINT DF_Gider_internet DEFAULT (0),
    Gida         INT  NOT NULL CONSTRAINT DF_Gider_Gida     DEFAULT (0),
    Personel     INT  NOT NULL CONSTRAINT DF_Gider_Personel DEFAULT (0),
    Diger        INT  NOT NULL CONSTRAINT DF_Gider_Diger    DEFAULT (0),
    OdemeTarihi  DATE NOT NULL
);
GO

/* ---------- Kasa (gelir/gider hareketleri) ---------- */
CREATE TABLE dbo.Kasa (
    Kasaid       INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Kasa PRIMARY KEY,
    OdemeMiktar  DECIMAL(10,2) NOT NULL,
    Tip          NVARCHAR(10)  NOT NULL CONSTRAINT CK_Kasa_Tip CHECK (Tip IN (N'Gelir', N'Gider')),
    Tarih        DATE          NOT NULL,
    Kategori     NVARCHAR(150) NULL
);
GO
CREATE INDEX IX_Kasa_Tarih ON dbo.Kasa (Tarih) INCLUDE (Tip, OdemeMiktar);
GO

/* ---------- Trigger: yeni öğrenciye otomatik borç kaydı ----------
   Borç tutarı tek yerde tanımlıdır: DF_Borclar_OgrKalanBorc (9000).
   Uygulama Borclar tablosuna ayrıca kayıt EKLEMEZ. */
CREATE TRIGGER dbo.trg_OgrenciBorcOlustur
ON dbo.Ogrenci
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Borclar (Ogrid)
    SELECT i.Ogrid
    FROM inserted AS i
    WHERE NOT EXISTS (SELECT 1 FROM dbo.Borclar b WHERE b.Ogrid = i.Ogrid);
END;
GO
