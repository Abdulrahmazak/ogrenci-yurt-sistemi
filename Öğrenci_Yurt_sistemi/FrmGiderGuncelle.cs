using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Öğrenci_Yurt_sistemi
{
    public partial class FrmGiderGuncelle : Form
    {
        public Action ListeyiYenile { get; set; }
        public FrmGiderGuncelle()
        {
            InitializeComponent();
        }
        

        private void FrmGiderGuncelle_Load(object sender, EventArgs e)
        {
            TxtGiderid.Text = id;
            TxtElektrik.Text = elektrik;
            TxtSu.Text = su;
            TxtDogalgaz.Text = dogalgaz;
            Txtinternet.Text = internet;
            TxtGida.Text = gida;
            TxtPersonel.Text = personel;
            TxtDiger.Text = diger;

            if (!string.IsNullOrEmpty(OdemeTarihi))
            {
                dateOdemeTarihi.Value = Convert.ToDateTime(OdemeTarihi);
            }
        }
        public string id, elektrik, su, dogalgaz, internet, gida, personel, diger,OdemeTarihi;
        Clsconnection bgl = new Clsconnection();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult onay = MessageBox.Show(
           "Gider Bilgisini güncellemek istediğinize emin misiniz?", "Onay",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay != DialogResult.Yes) return;

                using (SqlConnection con = bgl.Baglanti())
                using (SqlCommand komut = new SqlCommand("update Gider set Elektrik=@p2, Su=@p3, Dogalgaz=@p4, internet=@p5, Gida=@p6, Personel=@p7, Diger=@p8, OdemeTarihi=@p9 where Odemeid=@p1", con))
                {
                    komut.Parameters.AddWithValue("@p1", TxtGiderid.Text);
                    komut.Parameters.AddWithValue("@p2", TxtElektrik.Text);
                    komut.Parameters.AddWithValue("@p3", TxtSu.Text);
                    komut.Parameters.AddWithValue("@p4", TxtDogalgaz.Text);
                    komut.Parameters.AddWithValue("@p5", Txtinternet.Text);
                    komut.Parameters.AddWithValue("@p6", TxtGida.Text);
                    komut.Parameters.AddWithValue("@p7", TxtPersonel.Text);
                    komut.Parameters.AddWithValue("@p8", TxtDiger.Text);
                    komut.Parameters.AddWithValue("@p9", dateOdemeTarihi.Value.Date);
                    komut.ExecuteNonQuery();
                }
                ListeyiYenile?.Invoke();
                MessageBox.Show("Gider bilgileri güncellendi.");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Gider bilgileri güncellenirken bir hata oluştu. Lütfen tekrar deneyin.");
            }
        }
    }
}
