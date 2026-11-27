using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Öğrenci_Yurt_sistemi
{
    public partial class FrmOgrKayit : Form
    {

        public FrmOgrKayit()
        {
            InitializeComponent();

        }
        Clsconnection bgl = new Clsconnection();

        private void FrmOgrKayit_Load(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

        }

        private void FrmOgrKayıt_Load_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = bgl.Baglanti())
                {
                    //Bölümleri Comboboxa çekme
                    using (SqlCommand komut = new SqlCommand("Select BolumAd From Bolumler", con))
                    using (SqlDataReader oku = komut.ExecuteReader())
                    {
                        while (oku.Read())
                        {
                            CmbBolum.Items.Add(oku[0].ToString());
                        }
                    }

                    //Odaları Comboboxa çekme
                    using (SqlCommand komut2 = new SqlCommand("Select OdaNo From Odalar where OdaKapasite != OdaAktif", con))
                    using (SqlDataReader oku2 = komut2.ExecuteReader())
                    {
                        while (oku2.Read())
                        {
                            CmbOdaNo.Items.Add(oku2[0].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bölüm/oda listesi yüklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            // >>> ZORUNLU ALAN KONTROLLERİ BAŞLANGICI <<<
            if (string.IsNullOrWhiteSpace(TxtOgrAd.Text) ||
                string.IsNullOrWhiteSpace(TxtOgrSoyad.Text) ||
                string.IsNullOrWhiteSpace(TxtMail.Text) ||
                string.IsNullOrWhiteSpace(TxtVeliAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(RchAdres.Text))
            {
                MessageBox.Show("Lütfen tüm metin alanlarını doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!MskTC.MaskFull || !MskOgrTelefon.MaskFull || !MskDogum.MaskFull || !MskVeliTelefon.MaskFull)
            {
                MessageBox.Show("Lütfen TC, Telefon ve Doğum Tarihi alanlarını eksiksiz doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CmbBolum.SelectedIndex == -1 || CmbOdaNo.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Bölüm ve Oda seçimi yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // >>> ZORUNLU ALAN KONTROLLERİ BİTİŞİ <<<

            //Öğrenci Kayıt İşlemi
            try
            {
                using (SqlConnection con = bgl.Baglanti())
                {
                    // Kayıt + yeni Ogrid'i aynı komutta al (SCOPE_IDENTITY trigger'dan etkilenmez)
                    using (SqlCommand komutkaydet = new SqlCommand("insert into Ogrenci (OgrAd,OgrSoyad,OgrTc,OgrTelefon,OgrDogum,OgrBolum,OgrMail,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11); SELECT CAST(SCOPE_IDENTITY() AS int);", con))
                    {
                        komutkaydet.Parameters.AddWithValue("@p1", TxtOgrAd.Text);
                        komutkaydet.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text);
                        komutkaydet.Parameters.AddWithValue("@p3", MskTC.Text);
                        komutkaydet.Parameters.AddWithValue("@p4", MskOgrTelefon.Text);
                        komutkaydet.Parameters.AddWithValue("@p5", MskDogum.Text);
                        komutkaydet.Parameters.AddWithValue("@p6", CmbBolum.Text);
                        komutkaydet.Parameters.AddWithValue("@p7", TxtMail.Text);
                        komutkaydet.Parameters.AddWithValue("@p8", CmbOdaNo.Text);
                        komutkaydet.Parameters.AddWithValue("@p9", TxtVeliAdSoyad.Text);
                        komutkaydet.Parameters.AddWithValue("@p10", MskVeliTelefon.Text);
                        komutkaydet.Parameters.AddWithValue("@p11", RchAdres.Text);
                        label11.Text = komutkaydet.ExecuteScalar().ToString();
                    }

                    // Borç kaydı burada EKLENMEZ: veritabanındaki trg_OgrenciBorcOlustur trigger'ı
                    // öğrenci eklenince Borclar'a varsayılan (9000) tutarla tek satır açar.

                    //Öğrenci oda kontenjanını arttırma
                    using (SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 where OdaNo=@p1", con))
                    {
                        komutoda.Parameters.AddWithValue("@p1", CmbOdaNo.Text);
                        komutoda.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Kayıt Başarılı Bir Şekilde Gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception)

            {
                MessageBox.Show("Kayıt Sırasında Bir Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void CmbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}