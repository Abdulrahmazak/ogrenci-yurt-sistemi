using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Öğrenci_Yurt_sistemi
{
    public partial class FrmNotEkle : Form
    {
        public FrmNotEkle()
        {
            InitializeComponent();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Kayıt Yeri Seçiniz";
                saveFileDialog1.Filter = "Metin Dosyası|*.txt";
                saveFileDialog1.InitialDirectory = "D:\\Notlar";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK) // ← iptal kontrolü
                {
                    StreamWriter kaydet = new StreamWriter(saveFileDialog1.FileName);
                    kaydet.WriteLine(richTextBox1.Text);
                    kaydet.Close();
                    MessageBox.Show("Not başarıyla kaydedildi.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
