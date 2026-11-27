using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Öğrenci_Yurt_sistemi
{
    public partial class Odemeler : Form
    {
        public Odemeler()
        {
            InitializeComponent();
        }

        Clsconnection bgl = new Clsconnection();

        private void GridDoldur()
        {
            try
            {
                using (SqlConnection con = bgl.Baglanti())
                {
                    // Bağlantı durum kontrolü güvenliği
                    if (con.State == ConnectionState.Closed) con.Open();

                    string sorgu = @"SELECT DISTINCT
                                        b.Ogrid,
                                        o.OgrAd,
                                        o.OgrSoyad,
                                        b.OgrKalanBorc,
                                        b.BorcOdemeTarihi
                                     FROM Borclar b
                                     INNER JOIN Ogrenci o ON b.Ogrid = o.Ogrid
                                     WHERE b.OgrKalanBorc > 0";

                    using (SqlCommand komut = new SqlCommand(sorgu, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(komut))
                        {
                            DataTable tablo = new DataTable();
                            adapter.Fill(tablo);
                            dataGridView1.DataSource = tablo;

                            if (dataGridView1.Columns["Ogrid"] != null) dataGridView1.Columns["Ogrid"].HeaderText = "Öğrenci ID";
                            if (dataGridView1.Columns["OgrAd"] != null) dataGridView1.Columns["OgrAd"].HeaderText = "Öğrenci Ad";
                            if (dataGridView1.Columns["OgrSoyad"] != null) dataGridView1.Columns["OgrSoyad"].HeaderText = "Öğrenci Soyad";
                            if (dataGridView1.Columns["OgrKalanBorc"] != null) dataGridView1.Columns["OgrKalanBorc"].HeaderText = "Kalan Borç";
                            if (dataGridView1.Columns["BorcOdemeTarihi"] != null) dataGridView1.Columns["BorcOdemeTarihi"].HeaderText = "Son Borç Ödeme Tarihi";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Odemeler_Load(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                int secilen = e.RowIndex;

                string id = dataGridView1.Rows[secilen].Cells["Ogrid"].Value?.ToString();
                string ad = dataGridView1.Rows[secilen].Cells["OgrAd"].Value?.ToString();
                string soyad = dataGridView1.Rows[secilen].Cells["OgrSoyad"].Value?.ToString();
                string kalan = dataGridView1.Rows[secilen].Cells["OgrKalanBorc"].Value?.ToString();
                string BorcOdemeTarihi = dataGridView1.Rows[secilen].Cells["BorcOdemeTarihi"].Value?.ToString();

                TxtOgrAd.Text = ad;
                TxtOgrSoyad.Text = soyad;
                TxtKalan.Text = kalan;
                TxtOgrid.Text = id;

                if (!string.IsNullOrEmpty(BorcOdemeTarihi))
                    dateBorcOdemeTarihi.Value = Convert.ToDateTime(BorcOdemeTarihi);
                else
                    dateBorcOdemeTarihi.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seçim esnasında hata oluştu: " + ex.Message);
            }
        }

        private void Btnodeme_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtOgrid.Text) ||
                    string.IsNullOrWhiteSpace(TxtOdenen.Text) ||
                    string.IsNullOrWhiteSpace(TxtKalan.Text))
                {
                    MessageBox.Show("Lütfen önce listeden öğrenci seçiniz ve ödenecek miktarı giriniz.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // >>> YENİLİK: int.TryParse ile harf girilme çökme riski tamamen önlendi <<<
                if (!int.TryParse(TxtOdenen.Text, out int odenen) || !int.TryParse(TxtKalan.Text, out int kalan))
                {
                    MessageBox.Show("Lütfen geçerli sayısal değerler giriniz.", "Hatalı Değer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (odenen <= 0)
                {
                    MessageBox.Show("Ödenen tutar 0'dan büyük olmalıdır.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (odenen > kalan)
                {
                    MessageBox.Show("Ödenen tutar kalan borçtan fazla olamaz.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int yeniborc = kalan - odenen;

                using (SqlConnection con = bgl.Baglanti())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    // 1. ADIM: Borç güncelleme (SQL smallint tipine uygun dönüşüm)
                    string updateSorgu = "UPDATE Borclar SET OgrKalanBorc=@p1, BorcOdemeTarihi=@p3 WHERE Ogrid=@p2";
                    using (SqlCommand komut = new SqlCommand(updateSorgu, con))
                    {
                        komut.Parameters.AddWithValue("@p1", Convert.ToInt16(yeniborc)); // smallint için Int16 güvenlidir
                        komut.Parameters.AddWithValue("@p2", Convert.ToInt32(TxtOgrid.Text));
                        komut.Parameters.AddWithValue("@p3", dateBorcOdemeTarihi.Value.Date);
                        komut.ExecuteNonQuery();
                    }

                    // 2. ADIM: Kasaya işleme
                    string insertSorgu = "INSERT INTO Kasa (OdemeMiktar, Tip, Tarih, Kategori) VALUES (@k1, @k2, @k3, @k4)";
                    using (SqlCommand kasaKomut = new SqlCommand(insertSorgu, con))
                    {
                        kasaKomut.Parameters.AddWithValue("@k1", Convert.ToDecimal(odenen));
                        kasaKomut.Parameters.AddWithValue("@k2", "Gelir");
                        kasaKomut.Parameters.AddWithValue("@k3", dateBorcOdemeTarihi.Value.Date);
                        kasaKomut.Parameters.AddWithValue("@k4", "Öğrenci Taksit Ödemesi (" + TxtOgrAd.Text + " " + TxtOgrSoyad.Text + ")");
                        kasaKomut.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Ödeme Başarıyla Alındı ve Kasaya İşlendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                TxtOdenen.Clear();
                TxtOgrAd.Clear();
                TxtOgrSoyad.Clear();
                TxtKalan.Clear();
                TxtOgrid.Clear();

                GridDoldur();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödeme işlemi sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}