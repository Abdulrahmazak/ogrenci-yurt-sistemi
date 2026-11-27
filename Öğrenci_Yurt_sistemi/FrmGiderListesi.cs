using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Öğrenci_Yurt_sistemi
{
    public partial class FrmGiderListesi : Form
    {
        public FrmGiderListesi()
        {
            InitializeComponent();
        }

        private void FrmGiderListesi_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns["odemeidDataGridViewTextBoxColumn"].Visible = false;
            this.giderTableAdapter2.Fill(this.ogrenci_Yurt_SistemiDataSet8.Gider);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int secilen= e.RowIndex;

            FrmGiderGuncelle frg = new FrmGiderGuncelle();
            frg.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            frg.elektrik = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            frg.su = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            frg.dogalgaz = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            frg.internet = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            frg.gida = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            frg.personel = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            frg.diger = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            frg.OdemeTarihi = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            frg.ListeyiYenile = () =>
            {
                this.ogrenci_Yurt_SistemiDataSet8.Gider.Clear();
                this.giderTableAdapter2.Fill(this.ogrenci_Yurt_SistemiDataSet8.Gider);
            };
            frg.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}