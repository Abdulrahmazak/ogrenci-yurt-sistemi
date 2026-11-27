using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Öğrenci_Yurt_sistemi
{
    public partial class FrmOgrListe : Form
    {
        public FrmOgrListe()
        {
            InitializeComponent();
        }

        Clsconnection bgl = new Clsconnection();

        private void FrmOgrListe_Load(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection con = bgl.Baglanti())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string sorgu = "SELECT * FROM Ogrenci";

                    using (SqlCommand komut = new SqlCommand(sorgu, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(komut))
                        {
                            DataTable tablo = new DataTable();
                            adapter.Fill(tablo);

                            dataGridView1.DataSource = tablo;
                        }
                    }
                }


                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Öğrenci Ad";
                    dataGridView1.Columns[2].HeaderText = "Öğrenci Soyad";
                    dataGridView1.Columns[3].HeaderText = "TC";
                    dataGridView1.Columns[4].HeaderText = "Telefon";
                    dataGridView1.Columns[5].HeaderText = "Doğum Tarihi";
                    dataGridView1.Columns[6].HeaderText = "Bölüm";
                    dataGridView1.Columns[7].HeaderText = "Mail";
                    dataGridView1.Columns[8].HeaderText = "Oda No";
                    dataGridView1.Columns[9].HeaderText = "Veli Ad Soyad";
                    dataGridView1.Columns[10].HeaderText = "Veli Telefon";
                    dataGridView1.Columns[11].HeaderText = "Adres";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Manuel veri çekme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            secilen = e.RowIndex;
            FrmOgrDuzenle1 fr = new FrmOgrDuzenle1();

            fr.id = dataGridView1.Rows[secilen].Cells[0].Value?.ToString() ?? "";
            fr.ad = dataGridView1.Rows[secilen].Cells[1].Value?.ToString() ?? "";
            fr.soyad = dataGridView1.Rows[secilen].Cells[2].Value?.ToString() ?? "";
            fr.TC = dataGridView1.Rows[secilen].Cells[3].Value?.ToString() ?? "";
            fr.telefon = dataGridView1.Rows[secilen].Cells[4].Value?.ToString() ?? "";
            fr.dogum = dataGridView1.Rows[secilen].Cells[5].Value?.ToString() ?? "";
            fr.bolum = dataGridView1.Rows[secilen].Cells[6].Value?.ToString() ?? "";
            fr.mail = dataGridView1.Rows[secilen].Cells[7].Value?.ToString() ?? "";
            fr.odano = dataGridView1.Rows[secilen].Cells[8].Value?.ToString() ?? "";
            fr.veliadsoyad = dataGridView1.Rows[secilen].Cells[9].Value?.ToString() ?? "";
            fr.velitelefon = dataGridView1.Rows[secilen].Cells[10].Value?.ToString() ?? "";
            fr.adres = dataGridView1.Rows[secilen].Cells[11].Value?.ToString() ?? "";


            fr.ListeyiYenile = () =>
            {
                FrmOgrListe_Load(null, null);
            };

            fr.ShowDialog();
        }
    }
}