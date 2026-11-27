using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Öğrenci_Yurt_sistemi
{
    public partial class FrmOgrDuzenle1 : Form
    {
        public Action ListeyiYenile { get; set; }
        public FrmOgrDuzenle1()

        {
            InitializeComponent();
            try
            {
                BolumListele();
                OdalarListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bölüm/oda listesi yüklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void BolumListele()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = bgl.Baglanti())
            using (SqlDataAdapter da = new SqlDataAdapter("Select Bolumid, BolumAd From Bolumler", con))
            {
                da.Fill(dt);
            }

            CmbBolum.DataSource = dt;
            CmbBolum.DisplayMember = "BolumAd";
            CmbBolum.ValueMember = "Bolumid";
        }

        void OdalarListele()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = bgl.Baglanti())
            using (SqlDataAdapter da = new SqlDataAdapter("Select Odaid, OdaNo From Odalar", con))
            {
                da.Fill(dt);
            }
            CmbOdaNo.DataSource = dt;
            CmbOdaNo.DisplayMember = "OdaNo";
            CmbOdaNo.ValueMember = "Odaid";
        }

        public string id, ad, soyad , TC, telefon , dogum, bolum, mail, odano, veliadsoyad, velitelefon, adres  ;

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //Öğrenci silme işemi
            DialogResult onay = MessageBox.Show(
           "Öğrenciyi silmek istediğinize emin misiniz?", "Onay",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = bgl.Baglanti())
                {
                    using (SqlCommand komut = new SqlCommand("Delete From Ogrenci where Ogrid=@p1", con))
                    {
                        komut.Parameters.AddWithValue("@p1", TxtOgrid.Text);
                        komut.ExecuteNonQuery();
                    }

                    //Oda kontenjanını azlatma işlemi
                    using (SqlCommand komut2 = new SqlCommand("update Odalar set OdaAktif=OdaAktif-1 where OdaNo=@p1", con))
                    {
                        komut2.Parameters.AddWithValue("@p1", CmbOdaNo.Text);
                        komut2.ExecuteNonQuery();
                    }
                }
                ListeyiYenile?.Invoke();
                MessageBox.Show("Öğrenci Silindi");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme İşlemi Başarısız: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Clsconnection bgl = new Clsconnection();
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show(
           "Öğrenci Bilgisini güncellemek istediğinize emin misiniz?", "Onay",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = bgl.Baglanti())
                using (SqlCommand komut = new SqlCommand("update Ogrenci set OgrAd=@p2, OgrSoyad=@p3, OgrTc=@p4, OgrTelefon=@p5, OgrDogum=@p6, OgrBolum=@p7, OgrMail=@p8, OgrOdaNo=@p9, OgrVeliAdSoyad=@p10, OgrVeliTelefon=@p11, OgrVeliAdres=@p12 where Ogrid=@p1", con))
                {
                    komut.Parameters.AddWithValue("@p1", TxtOgrid.Text);
                    komut.Parameters.AddWithValue("@p2", TxtOgrAd.Text);
                    komut.Parameters.AddWithValue("@p3", TxtOgrSoyad.Text);
                    komut.Parameters.AddWithValue("@p4", MskTC.Text);
                    komut.Parameters.AddWithValue("@p5", MskOgrTelefon.Text);
                    komut.Parameters.AddWithValue("@p6", MskDogum.Text);
                    komut.Parameters.AddWithValue("@p7", CmbBolum.Text);
                    komut.Parameters.AddWithValue("@p8", TxtMail.Text);
                    komut.Parameters.AddWithValue("@p9", CmbOdaNo.Text);
                    komut.Parameters.AddWithValue("@p10", TxtVeliAdSoyad.Text);
                    komut.Parameters.AddWithValue("@p11", MskVeliTelefon.Text);
                    komut.Parameters.AddWithValue("@p12", RchAdres.Text);
                    komut.ExecuteNonQuery();
                }
                ListeyiYenile?.Invoke();
                MessageBox.Show("Güncelleme İşlemi Başarılı");
                this.Close();
            }
            catch (Exception ex)
            {
                // Önceden burada "throw;" vardı ve uygulama çöküyordu.
                MessageBox.Show("Güncelleme İşlemi Başarısız: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmOgrDuzenle1_Load(object sender, EventArgs e)
        {
            TxtOgrid.Text = id;
            TxtOgrAd.Text = ad;
            TxtOgrSoyad.Text = soyad;
            MskTC.Text = TC;
            MskOgrTelefon.Text = telefon;
            MskDogum.Text = dogum;
            CmbBolum.Text = bolum;
            TxtMail.Text = mail;
            CmbOdaNo.Text = odano;
            TxtVeliAdSoyad.Text = veliadsoyad;
            MskVeliTelefon.Text = velitelefon;
            RchAdres.Text = adres;
        }
    }
}
