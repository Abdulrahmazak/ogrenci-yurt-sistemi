using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Öğrenci_Yurt_sistemi
{
    /// <summary>
    /// Veritabanı bağlantısı. Bağlantı dizesi koda gömülü DEĞİLDİR:
    ///  1) App.Local.config içindeki "OgrenciYurtConnectionString" anahtarı (varsa, yerel geçersiz kılma)
    ///  2) App.config içindeki connectionStrings girdisi (varsayılan: LocalDB)
    /// Baglanti() her çağrıldığında YENİ ve AÇIK bir bağlantı döndürür;
    /// çağıran taraf mutlaka "using" ile kapatmalıdır.
    /// </summary>
    public class Clsconnection
    {
        public const string LocalOverrideKey = "OgrenciYurtConnectionString";
        private const string ConnectionStringName =
            "Öğrenci_Yurt_sistemi.Properties.Settings.Ogrenci_Yurt_SistemiConnectionString";

        public static string ConnectionString
        {
            get
            {
                string yerel = ConfigurationManager.AppSettings[LocalOverrideKey];
                if (!string.IsNullOrWhiteSpace(yerel))
                    return yerel;

                ConnectionStringSettings ayar = ConfigurationManager.ConnectionStrings[ConnectionStringName];
                if (ayar == null || string.IsNullOrWhiteSpace(ayar.ConnectionString))
                    throw new ConfigurationErrorsException(
                        "Bağlantı dizesi bulunamadı. App.config veya App.Local.config dosyasını kontrol edin.");
                return ayar.ConnectionString;
            }
        }

        public SqlConnection Baglanti()
        {
            SqlConnection baglan = new SqlConnection(ConnectionString);
            baglan.Open();
            return baglan;
        }
    }
}
