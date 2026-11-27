/* =====================================================================
   Öğrenci Yurt Sistemi - ÖRNEK VERİ (tamamen UYDURMA)
   Buradaki kişiler, TC numaraları, telefonlar ve e-postalar gerçek değildir.
   Önce schema.sql çalıştırılmalıdır.

   Örnek yönetici girişi:
     Kullanıcı adı : admin
     Şifre         : Admin123!
   >>> İlk girişten sonra Yönetici İşlemleri ekranından şifreyi değiştirin. <<<
   ===================================================================== */
USE [Ogrenci_Yurt_Sistemi];
GO
SET NOCOUNT ON;

INSERT INTO dbo.Bolumler (BolumAd) VALUES
    (N'Bilgisayar Mühendisliği'),
    (N'Elektrik-Elektronik Mühendisliği'),
    (N'İşletme'),
    (N'Hukuk');

INSERT INTO dbo.Odalar (OdaNo, OdaKapasite, OdaAktif, OdaDurumu) VALUES
    (N'101', 2, 0, 1),
    (N'102', 3, 0, 1),
    (N'201', 4, 0, 1),
    (N'202', 2, 0, 1);

-- Öğrenciler (trg_OgrenciBorcOlustur her biri için 9000 TL borç satırı açar)
INSERT INTO dbo.Ogrenci (OgrAd, OgrSoyad, OgrTc, OgrTelefon, OgrDogum, OgrBolum, OgrMail, OgrOdaNo, OgrVeliAdSoyad, OgrVeliTelefon, OgrVeliAdres) VALUES
    (N'Ali',    N'Örnek',   '10000000001', N'(555) 000-0001', N'01.01.2004', N'Bilgisayar Mühendisliği',          N'ali.ornek@example.com',    N'101', N'Veli Örnek',   N'(555) 100-0001', N'Örnek Mah. Deneme Sk. No:1, Örnekşehir'),
    (N'Ayşe',   N'Deneme',  '10000000002', N'(555) 000-0002', N'15.03.2003', N'İşletme',                          N'ayse.deneme@example.com',  N'101', N'Fatma Deneme', N'(555) 100-0002', N'Test Cad. No:2, Örnekşehir'),
    (N'Mehmet', N'Test',    '10000000003', N'(555) 000-0003', N'22.07.2005', N'Elektrik-Elektronik Mühendisliği', N'mehmet.test@example.com',  N'102', N'Hasan Test',   N'(555) 100-0003', N'Sahte Sk. No:3, Örnekşehir'),
    (N'Zeynep', N'Kurgu',   '10000000004', N'(555) 000-0004', N'09.11.2004', N'Hukuk',                            N'zeynep.kurgu@example.com', N'201', N'Ahmet Kurgu',  N'(555) 100-0004', N'Hayal Bulvarı No:4, Örnekşehir');

-- Oda doluluklarını öğrenci sayısıyla eşitle
UPDATE o SET OdaAktif = x.n
FROM dbo.Odalar o
JOIN (SELECT OgrOdaNo, COUNT(*) n FROM dbo.Ogrenci GROUP BY OgrOdaNo) x ON x.OgrOdaNo = o.OdaNo;

-- Bir öğrenci kısmi ödeme yapmış olsun (Kasa'ya gelir olarak da işlenir)
UPDATE dbo.Borclar SET OgrKalanBorc = 6000, BorcOdemeTarihi = '2026-01-15'
WHERE Ogrid = (SELECT Ogrid FROM dbo.Ogrenci WHERE OgrTc = '10000000001');

INSERT INTO dbo.Kasa (OdemeMiktar, Tip, Tarih, Kategori) VALUES
    (3000.00, N'Gelir', '2026-01-15', N'Öğrenci Taksit Ödemesi (Ali Örnek)');

INSERT INTO dbo.Personel (PersonelAd, PersonelSoyad, PersonelTelefon, PersonelMail, PersonelGorev, PersonelMaas) VALUES
    (N'Kemal', N'Örnekoğlu', N'(555) 200-0001', N'kemal@example.com', N'Güvenlik',  25000.00),
    (N'Elif',  N'Denemeci',  N'(555) 200-0002', N'elif@example.com',  N'Temizlik',  22000.00);

INSERT INTO dbo.Gider (Elektrik, Su, Dogalgaz, internet, Gida, Personel, Diger, OdemeTarihi) VALUES
    (4500, 1200, 6000, 800, 15000, 47000, 500, '2026-01-31');

INSERT INTO dbo.Kasa (OdemeMiktar, Tip, Tarih, Kategori) VALUES
    (75000.00, N'Gider', '2026-01-31', N'Sabit Yurt Giderleri');

-- Örnek yönetici: admin / Admin123!  (PBKDF2-SHA256 hash'i, düz metin değil)
INSERT INTO dbo.Admin (YoneticiAd, YoneticiSoyad, YoneticiTelefon, YoneticiMail, YoneticiKullaniciAdi, YoneticiSifre) VALUES
    (N'Örnek', N'Yönetici', N'(555) 300-0001', N'admin@example.com', N'admin',
     N'PBKDF2-SHA256$100000$KN5QwylyY/GbotX5M4ohXA==$lU8MqyjsYj9effYzgU/ODKNeXCk6yRqweus7NnpUTWQ=');
GO
