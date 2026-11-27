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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        Clsconnection bgl = new Clsconnection();

        // 1. KAYDET BUTONU KONTROLÜ
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPersonelAd.Text) ||
                string.IsNullOrWhiteSpace(TxtPersonelSoyad.Text) ||
                string.IsNullOrWhiteSpace(TxtMail.Text) ||
                string.IsNullOrWhiteSpace(TxtGorev.Text) ||
                string.IsNullOrWhiteSpace(TxtMaas.Text) ||
                !MskTelefon.MaskFull)
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return;
            }

            try
            {
                using (SqlConnection con = bgl.Baglanti())
                using (SqlCommand komut = new SqlCommand("insert into Personel (PersonelAd,PersonelSoyad,PersonelTelefon,PersonelMail,PersonelGorev,PersonelMaas) values (@p1,@p2,@p3,@p4,@p5,@p6)", con))
                {
                    komut.Parameters.AddWithValue("@p1", TxtPersonelAd.Text);
                    komut.Parameters.AddWithValue("@p2", TxtPersonelSoyad.Text);
                    komut.Parameters.AddWithValue("@p3", MskTelefon.Text);
                    komut.Parameters.AddWithValue("@p4", TxtMail.Text);
                    komut.Parameters.AddWithValue("@p5", TxtGorev.Text);
                    komut.Parameters.AddWithValue("@p6", TxtMaas.Text);
                    komut.ExecuteNonQuery();
                }
                MessageBox.Show("Personel bilgisi sisteme kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.personelTableAdapter1.Fill(this.ogrenci_Yurt_SistemiDataSet11.Personel);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel kaydedilemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            this.personelTableAdapter1.Fill(this.ogrenci_Yurt_SistemiDataSet11.Personel);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Personel Adı";
            dataGridView1.Columns[2].HeaderText = "Personel Soyadı";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "Mail";
            dataGridView1.Columns[5].HeaderText = "Görev";
            dataGridView1.Columns[6].HeaderText = "Maaş";
        }

        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtPersonelid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtPersonelAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtPersonelSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            MskTelefon.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtMail.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtGorev.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtMaas.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        // 2. SİL BUTONU KONTROLÜ
        private void BtnSil_Click(object sender, EventArgs e)
        {
            // Silme işlemi için ID alanının (yani listeden birinin seçilmiş olmasının) kontrolü
            if (string.IsNullOrWhiteSpace(TxtPersonelid.Text))
            {
                MessageBox.Show("Lütfen silmek istediğiniz personeli önce listeden seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = bgl.Baglanti())
                using (SqlCommand komut = new SqlCommand("Delete From Personel where Personelid=@p1", con))
                {
                    komut.Parameters.AddWithValue("@p1", TxtPersonelid.Text);
                    komut.ExecuteNonQuery();
                }
                MessageBox.Show("Personel bilgisi sistemden silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.personelTableAdapter1.Fill(this.ogrenci_Yurt_SistemiDataSet11.Personel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel silinemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. GÜNCELLE BUTONU KONTROLÜ (Görseldeki hatayı engelleyen kısım)
        private void button1_Click(object sender, EventArgs e)
        {
            // Güncelleme basıldığında alanların boş olup olmadığını kontrol ediyoruz
            if (string.IsNullOrWhiteSpace(TxtPersonelid.Text) ||
                string.IsNullOrWhiteSpace(TxtPersonelAd.Text) ||
                string.IsNullOrWhiteSpace(TxtPersonelSoyad.Text) ||
                string.IsNullOrWhiteSpace(TxtMail.Text) ||
                string.IsNullOrWhiteSpace(TxtGorev.Text) ||
                string.IsNullOrWhiteSpace(TxtMaas.Text) ||
                !MskTelefon.MaskFull)
            {
                MessageBox.Show("Lütfen listeden bir personel seçiniz ve alanları eksiksiz doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = bgl.Baglanti())
                using (SqlCommand komut = new SqlCommand("Update Personel set PersonelAd=@p2, PersonelSoyad=@p3,PersonelTelefon=@p4,PersonelMail=@p5,PersonelGorev=@p6,PersonelMaas=@p7 where Personelid=@p1", con))
                {
                    komut.Parameters.AddWithValue("@p1", TxtPersonelid.Text);
                    komut.Parameters.AddWithValue("@p2", TxtPersonelAd.Text);
                    komut.Parameters.AddWithValue("@p3", TxtPersonelSoyad.Text);
                    komut.Parameters.AddWithValue("@p4", MskTelefon.Text);
                    komut.Parameters.AddWithValue("@p5", TxtMail.Text);
                    komut.Parameters.AddWithValue("@p6", TxtGorev.Text);
                    komut.Parameters.AddWithValue("@p7", TxtMaas.Text);
                    komut.ExecuteNonQuery();
                }
                MessageBox.Show("Personel bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.personelTableAdapter1.Fill(this.ogrenci_Yurt_SistemiDataSet11.Personel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel güncellenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}