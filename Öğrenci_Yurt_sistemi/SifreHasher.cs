using System;
using System.Security.Cryptography;

namespace Öğrenci_Yurt_sistemi
{
    /// <summary>
    /// Yönetici şifreleri için PBKDF2-HMAC-SHA256 hash'leme.
    /// Saklama biçimi: "PBKDF2-SHA256$iterasyon$tuzBase64$hashBase64"
    /// </summary>
    public static class SifreHasher
    {
        private const string Onek = "PBKDF2-SHA256";
        private const int Iterasyon = 100000;
        private const int TuzUzunlugu = 16;
        private const int HashUzunlugu = 32;

        public static string Hashle(string sifre)
        {
            if (sifre == null) throw new ArgumentNullException(nameof(sifre));

            byte[] tuz = new byte[TuzUzunlugu];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(tuz);
            }

            byte[] hash = Turet(sifre, tuz, Iterasyon, HashUzunlugu);
            return string.Join("$", Onek, Iterasyon.ToString(), Convert.ToBase64String(tuz), Convert.ToBase64String(hash));
        }

        /// <summary>Kayıt yeni (hash'li) biçimde mi?</summary>
        public static bool HashliMi(string kayitli)
        {
            return kayitli != null && kayitli.StartsWith(Onek + "$", StringComparison.Ordinal);
        }

        public static bool Dogrula(string sifre, string kayitli)
        {
            if (sifre == null || string.IsNullOrEmpty(kayitli)) return false;

            // Yalnızca hash'li kayıtlar kabul edilir; düz metin kayıt hiçbir şifreyle doğrulanmaz.
            if (!HashliMi(kayitli)) return false;

            string[] parca = kayitli.Split('$');
            if (parca.Length != 4) return false;

            int iterasyon;
            if (!int.TryParse(parca[1], out iterasyon) || iterasyon < 1) return false;

            byte[] tuz, beklenen;
            try
            {
                tuz = Convert.FromBase64String(parca[2]);
                beklenen = Convert.FromBase64String(parca[3]);
            }
            catch (FormatException)
            {
                return false;
            }

            if (beklenen.Length == 0) return false;

            byte[] gercek = Turet(sifre, tuz, iterasyon, beklenen.Length);
            return SabitZamanliEsit(gercek, beklenen);
        }

        private static byte[] Turet(string sifre, byte[] tuz, int iterasyon, int uzunluk)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(sifre, tuz, iterasyon, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(uzunluk);
            }
        }

        private static bool SabitZamanliEsit(byte[] a, byte[] b)
        {
            if (a == null || b == null) return false;
            int fark = a.Length ^ b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                fark |= a[i] ^ b[i];
            return fark == 0;
        }
    }
}
