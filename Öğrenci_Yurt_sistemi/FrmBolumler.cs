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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        Clsconnection bgl = new Clsconnection();
        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ogrenci_Yurt_SistemiDataSet.Bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.ogrenci_Yurt_SistemiDataSet.Bolumler);

        }

        private void PcbBolumEkle_Click(object sender, EventArgs e)
        {
            // BOŞ OLMAMA KONTROLÜ
            if (string.IsNullOrWhiteSpace(TxtBolumAd.Text))
            {
                MessageBox.Show("Lütfen bölüm ad alanını doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult onay = MessageBox.Show(
           "Bu bölümü eklemek istediğinize emin misiniz?", "Onay",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (onay == DialogResult.No) return;

                using (SqlConnection con = bgl.Baglanti())
                using (SqlCommand komut1 = new SqlCommand("insert into Bolumler (BolumAd) values (@p1)", con))
                {
                    komut1.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                    komut1.ExecuteNonQuery();
                }
                MessageBox.Show("Bölüm Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.bolumlerTableAdapter.Fill(this.ogrenci_Yurt_SistemiDataSet.Bolumler);
            }
            catch (Exception)
            {
                MessageBox.Show("Bölüm Eklenirken Bir Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PcbBolumSil_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TxtBolumid.Text))
            {
                MessageBox.Show("Lütfen silinecek bölümü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult onay = MessageBox.Show(
                "Bu bölümü silmek istediğinize emin misiniz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (onay == DialogResult.No) return;

                using (SqlConnection con = bgl.Baglanti())
                using (SqlCommand komut2 = new SqlCommand("delete from Bolumler where Bolumid=@p1", con))
                {
                    komut2.Parameters.AddWithValue("@p1", TxtBolumid.Text);
                    komut2.ExecuteNonQuery();
                }
                MessageBox.Show("Bölüm Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.bolumlerTableAdapter.Fill(this.ogrenci_Yurt_SistemiDataSet.Bolumler);
            }
            catch (Exception)
            {
                MessageBox.Show("Bölüm Silinirken Bir Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtBolumid.Text = id;
            TxtBolumAd.Text = bolumad;
        }

        private void PcbBolumDuzenle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TxtBolumid.Text) || string.IsNullOrWhiteSpace(TxtBolumAd.Text))
            {
                MessageBox.Show("Lütfen güncellenecek bölümü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult onay = MessageBox.Show(
           "Bu bölümü Güncellemek istediğinize emin misiniz?", "Onay",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (onay == DialogResult.No) return;
                using (SqlConnection con = bgl.Baglanti())
                using (SqlCommand komut3 = new SqlCommand("update Bolumler set BolumAd=@p1 where Bolumid=@p2", con))
                {
                    komut3.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                    komut3.Parameters.AddWithValue("@p2", TxtBolumid.Text);
                    komut3.ExecuteNonQuery();
                }
                this.bolumlerTableAdapter.Fill(this.ogrenci_Yurt_SistemiDataSet.Bolumler);
                MessageBox.Show("Bölüm Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Bölüm Güncellenirken Bir Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}