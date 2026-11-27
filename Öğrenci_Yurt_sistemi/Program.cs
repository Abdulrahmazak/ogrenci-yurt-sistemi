using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Öğrenci_Yurt_sistemi
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tasarımcı (TableAdapter) bağlantıları da aynı kaynaktan beslensin:
            // App.Local.config ile verilen yerel bağlantı dizesi tüm uygulamada geçerli olur.
            try
            {
                Properties.Settings.Default["Ogrenci_Yurt_SistemiConnectionString"] = Clsconnection.ConnectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yapılandırma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmAdminGiris ());
        }
    }
}
