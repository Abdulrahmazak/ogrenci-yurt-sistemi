using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Öğrenci_Yurt_sistemi
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }
        void OpenForm()
        {
            Application.Run(new FrmAnaSayfa());
        }
        Clsconnection bgl = new Clsconnection();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {

        }

        private void TxtKullaniciAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            bool girisBasarili = false;
            try
            {
                // Şifre SQL'de karşılaştırılmaz: kayıtlı hash okunur, uygulamada doğrulanır.
                using (SqlConnection con = bgl.Baglanti())
                using (SqlCommand komut = new SqlCommand("Select YoneticiSifre From Admin where YoneticiKullaniciAdi=@p1", con))
                {
                    komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
                    using (SqlDataReader dr = komut.ExecuteReader())
                    {
                        while (dr.Read() && !girisBasarili)
                        {
                            string kayitli = dr.IsDBNull(0) ? null : dr.GetString(0);
                            girisBasarili = SifreHasher.Dogrula(TxtSifre.Text, kayitli);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlanılamadı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (girisBasarili)
            {
                //FrmAnaSayfa fr = new FrmAnaSayfa();
                //fr.girisYapanAdminAdi = TxtKullaniciAd.Text;
                //fr.Show();
                this.Close();
                Thread th = new Thread(OpenForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre");
                TxtSifre.Clear();
                TxtKullaniciAd.Focus();
            }

        }

        private void FrmAdminGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
