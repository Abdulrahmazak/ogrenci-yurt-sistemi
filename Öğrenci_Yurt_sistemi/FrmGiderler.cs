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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        Clsconnection bgl = new Clsconnection();

        private void FrmGiderler_Load(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // >>> DOĞRU GRUPLAMA: Parantezler sayesinde YALNIZCA HEPSİ BİRDEN BOŞSA bloke eder <<<
            if (string.IsNullOrWhiteSpace(TxtElektrik.Text) &&
                string.IsNullOrWhiteSpace(TxtSu.Text) &&
                string.IsNullOrWhiteSpace(TxtDogalgaz.Text) &&
                string.IsNullOrWhiteSpace(Txtinternet.Text) &&
                string.IsNullOrWhiteSpace(TxtGida.Text) &&
                string.IsNullOrWhiteSpace(TxtPersonel.Text) &&
                string.IsNullOrWhiteSpace(TxtDiger.Text))
            {
                MessageBox.Show("Lütfen kaydetmek için en az bir gider alanı doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult onay = MessageBox.Show(
                    "Bu bilgileri kaydetmek istediğinize emin misiniz?", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (onay == DialogResult.Yes)
                {
                    // Bağlantıyı güvenli yönetim için tek bir nesneye atıyoruz
                    using (SqlConnection baglantiNesnesi = bgl.Baglanti())
                    {

                    // 1. ADIM: Gider tablosuna detaylı faturayı kaydet
                    SqlCommand komut = new SqlCommand(
                        "insert into Gider (Elektrik,Su,Dogalgaz,internet,Gida,Personel,Diger,OdemeTarihi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",
                        baglantiNesnesi);

                    // Kutuların boş kalma ihtimaline karşı güvenli dönüşüm (Boşsa 0 yazar)
                    int elektrik = string.IsNullOrEmpty(TxtElektrik.Text) ? 0 : Convert.ToInt32(TxtElektrik.Text);
                    int su = string.IsNullOrEmpty(TxtSu.Text) ? 0 : Convert.ToInt32(TxtSu.Text);
                    int dogalgaz = string.IsNullOrEmpty(TxtDogalgaz.Text) ? 0 : Convert.ToInt32(TxtDogalgaz.Text);
                    int internet = string.IsNullOrEmpty(Txtinternet.Text) ? 0 : Convert.ToInt32(Txtinternet.Text);
                    int gida = string.IsNullOrEmpty(TxtGida.Text) ? 0 : Convert.ToInt32(TxtGida.Text);
                    int personel = string.IsNullOrEmpty(TxtPersonel.Text) ? 0 : Convert.ToInt32(TxtPersonel.Text);
                    int diger = string.IsNullOrEmpty(TxtDiger.Text) ? 0 : Convert.ToInt32(TxtDiger.Text);

                    komut.Parameters.AddWithValue("@p1", elektrik);
                    komut.Parameters.AddWithValue("@p2", su);
                    komut.Parameters.AddWithValue("@p3", dogalgaz);
                    komut.Parameters.AddWithValue("@p4", internet);
                    komut.Parameters.AddWithValue("@p5", gida);
                    komut.Parameters.AddWithValue("@p6", personel);
                    komut.Parameters.AddWithValue("@p7", diger);
                    komut.Parameters.AddWithValue("@p8", dateOdemeTarihi.Value.Date);

                    komut.ExecuteNonQuery();

                    // 2. ADIM: Girilen tüm giderlerin toplamını hesapla ve Kasa tablosuna GİDER olarak ekle
                    decimal toplamGider = elektrik + su + dogalgaz + internet + gida + personel + diger;

                    if (toplamGider > 0)
                    {
                        SqlCommand kasaKomut = new SqlCommand(
                            "INSERT INTO Kasa (OdemeMiktar, Tip, Tarih, Kategori) VALUES (@k1, @k2, @k3, @k4)",
                            baglantiNesnesi);

                        kasaKomut.Parameters.AddWithValue("@k1", toplamGider); // Kasa tablosundaki decimal alana uyumlu
                        kasaKomut.Parameters.AddWithValue("@k2", "Gider");
                        kasaKomut.Parameters.AddWithValue("@k3", dateOdemeTarihi.Value.Date);
                        kasaKomut.Parameters.AddWithValue("@k4", "Sabit Yurt Giderleri");

                        kasaKomut.ExecuteNonQuery();
                    }

                    } // using: bağlantı hata olsa bile kapanır

                    MessageBox.Show("Giderler sisteme kaydedildi ve Kasa hesabından düşüldü.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Formu temizle
                    Temizle();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kayıttan sonra kutuları temizleyen yardımcı metot
        private void Temizle()
        {
            TxtElektrik.Clear();
            TxtSu.Clear();
            TxtDogalgaz.Clear();
            Txtinternet.Clear();
            TxtGida.Clear();
            TxtPersonel.Clear();
            TxtDiger.Clear();
            dateOdemeTarihi.Value = DateTime.Now;
        }
    }
}