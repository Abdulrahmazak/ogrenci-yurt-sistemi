# Öğrenci Yurt Yönetim Sistemi

C# Windows Forms ve SQL Server ile geliştirilmiş bir öğrenci yurdu yönetim uygulaması.
2026 yılında Mühendislik Tasarımı dersi kapsamında hazırlanmıştır.

## Özellikler

- Yönetici girişi (şifreler PBKDF2-SHA256 ile hash'lenerek saklanır)
- Öğrenci kaydı, listeleme, düzenleme ve silme
- Bölüm ve oda yönetimi (oda doluluk takibi)
- Öğrenci borç / taksit ödemeleri
- Yurt giderleri (elektrik, su, doğalgaz, internet, gıda, personel, diğer)
- Aylık kasa raporu ve gelir/gider grafiği
- Personel ve yönetici işlemleri

## Gereksinimler

- Windows 10/11
- .NET Framework 4.7.2
- Visual Studio 2022 veya üzeri (".NET masaüstü geliştirme" iş yükü)
- SQL Server 2016+ veya **SQL Server Express LocalDB** (Visual Studio ile gelir)

## Kurulum

### 1. Veritabanını oluşturun

SSMS'te `Database/schema.sql` dosyasını açıp çalıştırın. İsterseniz ardından
`Database/seed.sql` dosyasını çalıştırarak **uydurma** örnek verileri ekleyin.

Komut satırından (LocalDB için):

```bat
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -f 65001 -i Database\schema.sql
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -f 65001 -i Database\seed.sql
```

> `-f 65001`, Türkçe karakterlerin doğru aktarılması içindir.

### 2. Bağlantı ayarı

Varsayılan bağlantı `App.config` içindedir ve LocalDB'yi kullanır:

```
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ogrenci_Yurt_Sistemi;Integrated Security=True
```

Farklı bir SQL Server kullanıyorsanız `App.config` dosyasını **değiştirmeyin**. Bunun yerine:

1. `Öğrenci_Yurt_sistemi/App.Local.config.example` dosyasını aynı klasöre
   `App.Local.config` adıyla kopyalayın.
2. İçindeki `Data Source` değerini kendi sunucunuza göre düzenleyin
   (ör. `.`, `.\SQLEXPRESS`).

`App.Local.config` dosyası `.gitignore`'dadır, repoya girmez. Derleme sırasında çıktı
klasörüne kopyalanır ve App.config'teki bağlantıyı geçersiz kılar.

### 3. Çalıştırma

1. `Öğrenci_Yurt_sistemi.slnx` dosyasını Visual Studio ile açın.
2. NuGet paketleri ilk derlemede otomatik geri yüklenir (gerekirse: çözüme sağ tık → *Restore NuGet Packages*).
3. **F5** ile çalıştırın.

### Örnek giriş (yalnızca `seed.sql` kullandıysanız)

| Kullanıcı adı | Şifre       |
|---------------|-------------|
| `admin`       | `Admin123!` |

İlk girişten sonra **Yönetici İşlemleri** ekranından şifreyi değiştirin.

## Proje yapısı

```
Database/
  schema.sql            Tablolar, PK/FK/UNIQUE kısıtları, indeksler, trigger
  seed.sql              Uydurma örnek veri
Öğrenci_Yurt_sistemi/
  Clsconnection.cs      Bağlantı (App.config / App.Local.config'ten okunur)
  SifreHasher.cs        PBKDF2 şifre hash'leme ve doğrulama
  Frm*.cs               Formlar
```

## Notlar

- Yeni öğrenci eklendiğinde borç kaydı veritabanındaki `trg_OgrenciBorcOlustur` trigger'ı
  tarafından otomatik açılır. Varsayılan borç tutarı tek yerde tanımlıdır:
  `Borclar.OgrKalanBorc DEFAULT (9000)`.
- Gerçek kişisel veri (TC, telefon, adres) içeren veritabanı dosyalarını veya yedeklerini
  (`.mdf`, `.ldf`, `.bak`) repoya eklemeyin.

## Lisans

[MIT](LICENSE)
