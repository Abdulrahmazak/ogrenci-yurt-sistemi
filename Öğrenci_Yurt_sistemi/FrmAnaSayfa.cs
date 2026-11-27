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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        Clsconnection bgl = new Clsconnection();

        private void IstatistikleriGetir()
        {
            try
            {
                using (SqlConnection con = bgl.Baglanti())
                {
                    // 1. TOPLAM ÖĞRENCİ SAYISI
                    using (SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Ogrenci", con))
                    {
                        LblToplamOgrenci.Text = cmd1.ExecuteScalar().ToString();
                    }

                    // 2. BEKLEYEN TOPLAM BORÇ
                    using (SqlCommand cmd2 = new SqlCommand("SELECT SUM(CAST(OgrKalanBorc AS int)) FROM Borclar", con))
                    {
                        object borcSonuc = cmd2.ExecuteScalar();
                        LblToplamBorc.Text = (borcSonuc != null && borcSonuc != DBNull.Value ? borcSonuc.ToString() : "0") + " ₺";
                    }

                    // 3. BUGÜNKÜ KASA
                    using (SqlCommand cmd3 = new SqlCommand("SELECT SUM(CAST(OdemeMiktar AS decimal(10,2))) FROM Kasa WHERE Tip='Gelir' AND Tarih=@bugun", con))
                    {
                        cmd3.Parameters.AddWithValue("@bugun", DateTime.Today);
                        object kasaSonuc = cmd3.ExecuteScalar();
                        LblBugunkuKasa.Text = (kasaSonuc != null && kasaSonuc != DBNull.Value ? kasaSonuc.ToString() : "0") + " ₺";
                    }

                    // 4. BOŞ YATAK SAYISI
                    string query = "SELECT (SELECT SUM(CAST(OdaKapasite AS int)) FROM Odalar) - (SELECT COUNT(*) FROM Ogrenci)";
                    using (SqlCommand cmd4 = new SqlCommand(query, con))
                    {
                        object yatakSonuc = cmd4.ExecuteScalar();
                        LblBosYatak.Text = yatakSonuc != null && yatakSonuc != DBNull.Value ? yatakSonuc.ToString() : "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İstatistikler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public string girisYapanAdminAdi { get; set; }
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            LblAdmin.Text = " Kullanıcı: " + girisYapanAdminAdi;
            IstatistikleriGetir();
            timer1.Start();
        }

        private void BtnOgrenciIslemleri_Click(object sender, EventArgs e)
        {
            FrmOgrKayit frmOgrKayit = new FrmOgrKayit();
            frmOgrKayit.ShowDialog();
            IstatistikleriGetir(); // Form kapandığı an sayıları yeniler
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongDateString();
            label4.Text = DateTime.Now.ToLongTimeString();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdminIslemleri_Click(object sender, EventArgs e)
        {
            FrmYoneticislemleri frmYoneticislemleri = new FrmYoneticislemleri();
            frmYoneticislemleri.ShowDialog();
            IstatistikleriGetir(); // Form kapandığı an sayıları yeniler
        }

        private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnOgrIslemleri_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonContextMenu1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void kryptonDropButton1_Click(object sender, EventArgs e)
        {
        }

        private void BtnOgrenciEklemeMenu_Click(object sender, EventArgs e)
        {
            FrmOgrKayit frmOgrKayit = new FrmOgrKayit();
            frmOgrKayit.ShowDialog();
            IstatistikleriGetir(); // Form kapandığı an sayıları yeniler
        }

        private void BtnOgrenciListesi_Click(object sender, EventArgs e)
        {
            FrmOgrListe frmOgrListe = new FrmOgrListe();
            frmOgrListe.ShowDialog();
            IstatistikleriGetir(); // Liste üzerinden düzenleme/silme yapılırsa kartları yeniler
        }

        private void BtnBolumIslemleri_Click(object sender, EventArgs e)
        {
            FrmBolumler frmBolumler = new FrmBolumler();
            frmBolumler.ShowDialog();
            IstatistikleriGetir(); // Form kapandığı an sayıları yeniler
        }

        private void BtnOdemeIslemleri_Click(object sender, EventArgs e)
        {

        }

        private void BtnPersonelIslemelri_Click(object sender, EventArgs e)
        {
            FrmPersonel frmPersonel = new FrmPersonel();
            frmPersonel.ShowDialog();
            IstatistikleriGetir(); // Form kapandığı an sayıları yeniler
        }

        private void BtnAdminIslemleri_Click_1(object sender, EventArgs e)
        {
            FrmYoneticislemleri frmYoneticislemleri = new FrmYoneticislemleri();
            frmYoneticislemleri.ShowDialog();
            IstatistikleriGetir(); // Form kapandığı an sayıları yeniler
        }

        private void BtnKasa_Click(object sender, EventArgs e)
        {
            FrmKasa frmka = new FrmKasa();
            frmka.ShowDialog();
            IstatistikleriGetir(); // Form kapandığı an sayıları yeniler
        }

        private void BtnErisimKolayligi_Click(object sender, EventArgs e)
        {
        }

        private void BtnHesapMakinesi_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void BtnNotEkle_Click(object sender, EventArgs e)
        {
            FrmNotEkle frmNotEkle = new FrmNotEkle();
            frmNotEkle.ShowDialog();
        }

        private void BtnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje 2026 Yılında Mühendislik Tasarımı dersi için Bilgisayar Mühendisliği Öğrencisi Abdulrahman Zakri tarafından yapılmıştır.");
        }

        private void BtnGiderBorc_Click(object sender, EventArgs e)
        {
            FrmGiderler frmGiderler = new FrmGiderler();
            frmGiderler.ShowDialog();
            IstatistikleriGetir(); // Kasa ve gider değişimi için kartları yeniler
        }

        private void BtnOgrenciBorc_Click(object sender, EventArgs e)
        {
            Odemeler frm = new Odemeler();
            frm.ShowDialog();
            IstatistikleriGetir(); // Taksit ödenince borç ve kasa kartlarını anında yeniler
        }

        private void BtnGiderListesi_Click(object sender, EventArgs e)
        {
            FrmGiderListesi frmGiderListe = new FrmGiderListesi();
            frmGiderListe.ShowDialog();
            IstatistikleriGetir(); // Form kapandığı an sayıları yeniler
        }

        private void kryptonDropButton2_Click(object sender, EventArgs e)
        {

        }
    }
}