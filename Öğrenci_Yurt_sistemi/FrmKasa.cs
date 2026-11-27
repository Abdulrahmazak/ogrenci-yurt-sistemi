using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Öğrenci_Yurt_sistemi
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        Clsconnection bgl = new Clsconnection();

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            dateFiltre.Value = DateTime.Now;
            KasaRaporuHazirla(dateFiltre.Value.Year, dateFiltre.Value.Month);
        }

        private void BtnFiltrele_Click(object sender, EventArgs e)
        {
            KasaRaporuHazirla(dateFiltre.Value.Year, dateFiltre.Value.Month);
        }

        private void KasaRaporuHazirla(int yil, int ay)
        {
            // >>> YENİLİK: using bloğu sayesinde hata oluşsa bile SQL bağlantısı %100 güvenle kapanır <<<
            try
            {
                using (SqlConnection con = bgl.Baglanti())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    // 1. ADIM: SEÇİLEN AYA AİT KAYIT KONTROLÜ
                    SqlCommand cmdKontrol = new SqlCommand(
                        "SELECT COUNT(*) FROM Kasa WHERE YEAR(Tarih) = @yil AND MONTH(Tarih) = @ay", con);
                    cmdKontrol.Parameters.AddWithValue("@yil", yil);
                    cmdKontrol.Parameters.AddWithValue("@ay", ay);

                    int kayitSayisi = (int)cmdKontrol.ExecuteScalar();

                    if (kayitSayisi == 0)
                    {
                        MessageBox.Show("Seçilen aya ait herhangi bir gelir veya gider kaydı bulunamadı!", "Kayıt Bulunamadı",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        LblToplamGelir.Text = "0,00 ₺";
                        LblToplamGider.Text = "0,00 ₺";
                        LblKasaBakiye.Text = "0,00 ₺";
                        LblKasaBakiye.ForeColor = Color.Black;

                        dataGridView1.DataSource = null;
                        chart1.Series.Clear();
                        chart1.Titles.Clear();
                        return; // using bloğundan çıkıldığı an bağlantı otomatik kapanır
                    }

                    // 2. ADIM: TOPLAM GELİR VE GİDER HESAPLAMA
                    SqlCommand cmdGelir = new SqlCommand(
                        "SELECT SUM(OdemeMiktar) FROM Kasa WHERE Tip = 'Gelir' AND YEAR(Tarih) = @yil AND MONTH(Tarih) = @ay", con);
                    cmdGelir.Parameters.AddWithValue("@yil", yil);
                    cmdGelir.Parameters.AddWithValue("@ay", ay);
                    object gelirSonuc = cmdGelir.ExecuteScalar();
                    decimal totalGelir = (gelirSonuc != DBNull.Value && gelirSonuc != null) ? Convert.ToDecimal(gelirSonuc) : 0;

                    SqlCommand cmdGider = new SqlCommand(
                        "SELECT SUM(OdemeMiktar) FROM Kasa WHERE Tip = 'Gider' AND YEAR(Tarih) = @yil AND MONTH(Tarih) = @ay", con);
                    cmdGider.Parameters.AddWithValue("@yil", yil);
                    cmdGider.Parameters.AddWithValue("@ay", ay);
                    object giderSonuc = cmdGider.ExecuteScalar();
                    decimal totalGider = (giderSonuc != DBNull.Value && giderSonuc != null) ? Convert.ToDecimal(giderSonuc) : 0;

                    decimal netBakiye = totalGelir - totalGider;

                    LblToplamGelir.Text = totalGelir.ToString("C2");
                    LblToplamGider.Text = totalGider.ToString("C2");
                    LblKasaBakiye.Text = netBakiye.ToString("C2");

                    if (netBakiye < 0)
                        LblKasaBakiye.ForeColor = Color.Red;
                    else
                        LblKasaBakiye.ForeColor = Color.FromArgb(40, 40, 40);

                    lblRaporBaslik.Text = $"{yil} Yılı {ay}. Ay Kasa Raporu";

                    // 3. ADIM: DATAGRIDVIEW LİSTELEME
                    SqlCommand cmdListe = new SqlCommand(
                        "SELECT Kasaid, OdemeMiktar, Tip, Tarih, Kategori FROM Kasa WHERE YEAR(Tarih) = @yil AND MONTH(Tarih) = @ay ORDER BY Tarih DESC", con);
                    cmdListe.Parameters.AddWithValue("@yil", yil);
                    cmdListe.Parameters.AddWithValue("@ay", ay);

                    SqlDataAdapter da = new SqlDataAdapter(cmdListe);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Başlıkların kaybolmasını engellemek için doğrudan indeks veya DataTable kolon eşleşmesi sağlandı
                    if (dataGridView1.Columns.Count > 0)
                    {
                        dataGridView1.Columns[0].HeaderText = "İşlem ID";
                        dataGridView1.Columns[1].HeaderText = "Tutar";
                        dataGridView1.Columns[2].HeaderText = "Tip";
                        dataGridView1.Columns[3].HeaderText = "Tarih";
                        dataGridView1.Columns[4].HeaderText = "Kategori";
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }

                    // 4. ADIM: CHART GRAFİK İŞLEMLERİ
                    chart1.Series.Clear();
                    chart1.Titles.Clear();

                    chart1.Titles.Add($"{yil} - {ay}. Ay Gelir / Gider Dağılımı");

                    Series finansSerisi = new Series("TL Bazında");
                    finansSerisi.ChartType = SeriesChartType.Column;

                    finansSerisi.Points.AddXY("Toplam Gelir", totalGelir);
                    finansSerisi.Points.AddXY("Toplam Gider", totalGider);

                    finansSerisi.Points[0].Color = Color.MediumSeaGreen;
                    if (finansSerisi.Points.Count > 1)
                        finansSerisi.Points[1].Color = Color.Maroon;

                    chart1.Series.Add(finansSerisi);

                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisX.LineColor = Color.LightGray;
                    chart1.ChartAreas[0].AxisY.LineColor = Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kasa verileri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblToplamGider_Click(object sender, EventArgs e)
        {
        }
    }
}