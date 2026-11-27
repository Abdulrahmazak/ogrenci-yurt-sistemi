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
    public partial class FrmYoneticislemleri : Form
    {
        public FrmYoneticislemleri()
        {
            InitializeComponent();
        }
        Clsconnection bgl = new Clsconnection();
        private void FrmYoneticislemleri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ogrenci_Yurt_SistemiDataSet9.Admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.ogrenci_Yurt_SistemiDataSet9.Admin);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Yönetici Ad";
            dataGridView1.Columns[2].HeaderText = "Yönetici Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "Mail";
            dataGridView1.Columns[5].HeaderText = "Kullanıcı Ad";

            // Şifre (hash) sütunu ekranda GÖSTERİLMEZ
            foreach (DataGridViewColumn kolon in dataGridView1.Columns)
            {
                if (kolon.DataPropertyName == "YoneticiSifre")
                    kolon.Visible = false;
            }

            // Şifre kutusu maskeli; boş bırakılırsa güncellemede mevcut şifre korunur
            TxtSifre.UseSystemPasswordChar = true;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // KAYDET BUTONU İÇİN BOŞ OLMAMA KONTROLÜ
            if (string.IsNullOrWhiteSpace(TxtYoneticiAd.Text) ||
                string.IsNullOrWhiteSpace(TxtYoneticiSoyad.Text) ||
                string.IsNullOrWhiteSpace(TxtYoneticiMail.Text) ||
                string.IsNullOrWhiteSpace(TxtKullaniciAd.Text) ||
                string.IsNullOrWhiteSpace(TxtSifre.Text) ||
                !MskYoneticiTelefon.MaskFull)
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = bgl.Baglanti())
                using (SqlCommand komut = new SqlCommand("insert into Admin (YoneticiAd,YoneticiSoyad,YoneticiTelefon,YoneticiMail,YoneticiKullaniciAdi,YoneticiSifre) values (@p1,@p2,@p3,@p4,@p5,@p6)", con))
                {
                    komut.Parameters.AddWithValue("@p1", TxtYoneticiAd.Text);
                    komut.Parameters.AddWithValue("@p2", TxtYoneticiSoyad.Text);
                    komut.Parameters.AddWithValue("@p3", MskYoneticiTelefon.Text);
                    komut.Parameters.AddWithValue("@p4", TxtYoneticiMail.Text);
                    komut.Parameters.AddWithValue("@p5", TxtKullaniciAd.Text);
                    komut.Parameters.AddWithValue("@p6", SifreHasher.Hashle(TxtSifre.Text));
                    komut.ExecuteNonQuery();
                }
                TxtSifre.Clear();
                MessageBox.Show("Yönetici başarıyla eklendi.");
                this.adminTableAdapter.Fill(this.ogrenci_Yurt_SistemiDataSet9.Admin);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yönetici eklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            // GÜNCELLEME BUTONU İÇİN BOŞ OLMAMA KONTROLÜ
            if (string.IsNullOrWhiteSpace(TxtYoneticiid.Text) ||
                string.IsNullOrWhiteSpace(TxtYoneticiAd.Text) ||
                string.IsNullOrWhiteSpace(TxtYoneticiSoyad.Text) ||
                string.IsNullOrWhiteSpace(TxtYoneticiMail.Text) ||
                string.IsNullOrWhiteSpace(TxtKullaniciAd.Text) ||
                !MskYoneticiTelefon.MaskFull)
            {
                MessageBox.Show("Lütfen listeden bir yönetici seçiniz ve alanları eksiksiz doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Şifre kutusu boşsa şifre DEĞİŞTİRİLMEZ; doluysa yeni şifre hash'lenerek kaydedilir.
            bool sifreDegisecek = !string.IsNullOrEmpty(TxtSifre.Text);
            string sorgu = sifreDegisecek
                ? "update Admin set YoneticiAd=@p2,YoneticiSoyad=@p3,YoneticiTelefon=@p4,YoneticiMail=@p5,YoneticiKullaniciAdi=@p6,YoneticiSifre=@p7 where Yoneticiid=@p1"
                : "update Admin set YoneticiAd=@p2,YoneticiSoyad=@p3,YoneticiTelefon=@p4,YoneticiMail=@p5,YoneticiKullaniciAdi=@p6 where Yoneticiid=@p1";

            try
            {
                using (SqlConnection con = bgl.Baglanti())
                using (SqlCommand komut2 = new SqlCommand(sorgu, con))
                {
                    komut2.Parameters.AddWithValue("@p1", TxtYoneticiid.Text);
                    komut2.Parameters.AddWithValue("@p2", TxtYoneticiAd.Text);
                    komut2.Parameters.AddWithValue("@p3", TxtYoneticiSoyad.Text);
                    komut2.Parameters.AddWithValue("@p4", MskYoneticiTelefon.Text);
                    komut2.Parameters.AddWithValue("@p5", TxtYoneticiMail.Text);
                    komut2.Parameters.AddWithValue("@p6", TxtKullaniciAd.Text);
                    if (sifreDegisecek)
                        komut2.Parameters.AddWithValue("@p7", SifreHasher.Hashle(TxtSifre.Text));
                    komut2.ExecuteNonQuery();
                }
                TxtSifre.Clear();
                MessageBox.Show(sifreDegisecek
                    ? "Yönetici bilgileri ve şifresi güncellendi."
                    : "Yönetici bilgileri güncellendi (şifre değiştirilmedi).");
                this.adminTableAdapter.Fill(this.ogrenci_Yurt_SistemiDataSet9.Admin);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yönetici güncellenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            FrmYoneticislemleri.ActiveForm.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtYoneticiid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtYoneticiAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtYoneticiSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            MskYoneticiTelefon.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtYoneticiMail.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtKullaniciAd.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            // Kayıtlı şifre/hash kutuya DOLDURULMAZ. Değiştirmek için yeni şifre yazılır.
            TxtSifre.Clear();


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            // SİLME BUTONU İÇİN SEÇİLİ OLMA KONTROLÜ
            if (string.IsNullOrWhiteSpace(TxtYoneticiid.Text))
            {
                MessageBox.Show("Lütfen silmek istediğiniz yöneticiyi önce listeden seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = bgl.Baglanti())
                using (SqlCommand komut3 = new SqlCommand("delete from Admin where Yoneticiid=@p1", con))
                {
                    komut3.Parameters.AddWithValue("@p1", TxtYoneticiid.Text);
                    komut3.ExecuteNonQuery();
                }
                MessageBox.Show("Yönetici başarıyla silindi.");
                this.adminTableAdapter.Fill(this.ogrenci_Yurt_SistemiDataSet9.Admin);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yönetici silinemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}