namespace Öğrenci_Yurt_sistemi
{
    partial class FrmYoneticislemleri
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYoneticislemleri));
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnSil = new System.Windows.Forms.Button();
            this.MskYoneticiTelefon = new System.Windows.Forms.MaskedTextBox();
            this.TxtYoneticiid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSifre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtYoneticiMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtYoneticiSoyad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtYoneticiAd = new System.Windows.Forms.TextBox();
            this.labe1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.yoneticiidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoneticiAdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoneticiSoyadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoneticiTelefonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoneticiMailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoneticiKullaniciAdiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yoneticiSifreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ogrenci_Yurt_SistemiDataSet9 = new Öğrenci_Yurt_sistemi.Ogrenci_Yurt_SistemiDataSet9();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtKullaniciAd = new System.Windows.Forms.TextBox();
            this.adminTableAdapter = new Öğrenci_Yurt_sistemi.Ogrenci_Yurt_SistemiDataSet9TableAdapters.AdminTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ogrenci_Yurt_SistemiDataSet9)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnKaydet.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(420, 39);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(122, 52);
            this.BtnKaydet.TabIndex = 8;
            this.BtnKaydet.Text = "Kaydet";
            this.BtnKaydet.UseVisualStyleBackColor = false;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnGuncelle.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Location = new System.Drawing.Point(420, 101);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(122, 47);
            this.BtnGuncelle.TabIndex = 9;
            this.BtnGuncelle.Text = "Güncelle";
            this.BtnGuncelle.UseVisualStyleBackColor = false;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnSil.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Location = new System.Drawing.Point(420, 158);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(122, 50);
            this.BtnSil.TabIndex = 10;
            this.BtnSil.Text = "Sil";
            this.BtnSil.UseVisualStyleBackColor = false;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // MskYoneticiTelefon
            // 
            this.MskYoneticiTelefon.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MskYoneticiTelefon.Location = new System.Drawing.Point(178, 94);
            this.MskYoneticiTelefon.Mask = "(999) 000-0000";
            this.MskYoneticiTelefon.Name = "MskYoneticiTelefon";
            this.MskYoneticiTelefon.Size = new System.Drawing.Size(191, 26);
            this.MskYoneticiTelefon.TabIndex = 4;
            // 
            // TxtYoneticiid
            // 
            this.TxtYoneticiid.Enabled = false;
            this.TxtYoneticiid.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtYoneticiid.Location = new System.Drawing.Point(588, 12);
            this.TxtYoneticiid.Name = "TxtYoneticiid";
            this.TxtYoneticiid.Size = new System.Drawing.Size(43, 25);
            this.TxtYoneticiid.TabIndex = 1;
            this.TxtYoneticiid.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(497, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 42;
            this.label1.Text = "Yönerici id:";
            this.label1.Visible = false;
            // 
            // TxtSifre
            // 
            this.TxtSifre.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtSifre.Location = new System.Drawing.Point(178, 188);
            this.TxtSifre.Name = "TxtSifre";
            this.TxtSifre.Size = new System.Drawing.Size(191, 25);
            this.TxtSifre.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(115, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 18);
            this.label5.TabIndex = 43;
            this.label5.Text = "Şifre:";
            // 
            // TxtYoneticiMail
            // 
            this.TxtYoneticiMail.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtYoneticiMail.Location = new System.Drawing.Point(178, 126);
            this.TxtYoneticiMail.Name = "TxtYoneticiMail";
            this.TxtYoneticiMail.Size = new System.Drawing.Size(191, 25);
            this.TxtYoneticiMail.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(115, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 18);
            this.label4.TabIndex = 44;
            this.label4.Text = "Mail:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(95, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 45;
            this.label3.Text = "Telefon:";
            // 
            // TxtYoneticiSoyad
            // 
            this.TxtYoneticiSoyad.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtYoneticiSoyad.Location = new System.Drawing.Point(178, 63);
            this.TxtYoneticiSoyad.Name = "TxtYoneticiSoyad";
            this.TxtYoneticiSoyad.Size = new System.Drawing.Size(191, 25);
            this.TxtYoneticiSoyad.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(45, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 46;
            this.label2.Text = "Yönetici Soyad:";
            // 
            // TxtYoneticiAd
            // 
            this.TxtYoneticiAd.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtYoneticiAd.Location = new System.Drawing.Point(178, 32);
            this.TxtYoneticiAd.Name = "TxtYoneticiAd";
            this.TxtYoneticiAd.Size = new System.Drawing.Size(191, 25);
            this.TxtYoneticiAd.TabIndex = 2;
            // 
            // labe1
            // 
            this.labe1.AutoSize = true;
            this.labe1.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labe1.Location = new System.Drawing.Point(68, 39);
            this.labe1.Name = "labe1";
            this.labe1.Size = new System.Drawing.Size(90, 18);
            this.labe1.TabIndex = 47;
            this.labe1.Text = "Yönetici Ad:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yoneticiidDataGridViewTextBoxColumn,
            this.yoneticiAdDataGridViewTextBoxColumn,
            this.yoneticiSoyadDataGridViewTextBoxColumn,
            this.yoneticiTelefonDataGridViewTextBoxColumn,
            this.yoneticiMailDataGridViewTextBoxColumn,
            this.yoneticiKullaniciAdiDataGridViewTextBoxColumn,
            this.yoneticiSifreDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.adminBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 235);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(741, 301);
            this.dataGridView1.TabIndex = 57;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // yoneticiidDataGridViewTextBoxColumn
            // 
            this.yoneticiidDataGridViewTextBoxColumn.DataPropertyName = "Yoneticiid";
            this.yoneticiidDataGridViewTextBoxColumn.HeaderText = "Yoneticiid";
            this.yoneticiidDataGridViewTextBoxColumn.Name = "yoneticiidDataGridViewTextBoxColumn";
            this.yoneticiidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yoneticiAdDataGridViewTextBoxColumn
            // 
            this.yoneticiAdDataGridViewTextBoxColumn.DataPropertyName = "YoneticiAd";
            this.yoneticiAdDataGridViewTextBoxColumn.HeaderText = "YoneticiAd";
            this.yoneticiAdDataGridViewTextBoxColumn.Name = "yoneticiAdDataGridViewTextBoxColumn";
            // 
            // yoneticiSoyadDataGridViewTextBoxColumn
            // 
            this.yoneticiSoyadDataGridViewTextBoxColumn.DataPropertyName = "YoneticiSoyad";
            this.yoneticiSoyadDataGridViewTextBoxColumn.HeaderText = "YoneticiSoyad";
            this.yoneticiSoyadDataGridViewTextBoxColumn.Name = "yoneticiSoyadDataGridViewTextBoxColumn";
            // 
            // yoneticiTelefonDataGridViewTextBoxColumn
            // 
            this.yoneticiTelefonDataGridViewTextBoxColumn.DataPropertyName = "YoneticiTelefon";
            this.yoneticiTelefonDataGridViewTextBoxColumn.HeaderText = "YoneticiTelefon";
            this.yoneticiTelefonDataGridViewTextBoxColumn.Name = "yoneticiTelefonDataGridViewTextBoxColumn";
            // 
            // yoneticiMailDataGridViewTextBoxColumn
            // 
            this.yoneticiMailDataGridViewTextBoxColumn.DataPropertyName = "YoneticiMail";
            this.yoneticiMailDataGridViewTextBoxColumn.HeaderText = "YoneticiMail";
            this.yoneticiMailDataGridViewTextBoxColumn.Name = "yoneticiMailDataGridViewTextBoxColumn";
            // 
            // yoneticiKullaniciAdiDataGridViewTextBoxColumn
            // 
            this.yoneticiKullaniciAdiDataGridViewTextBoxColumn.DataPropertyName = "YoneticiKullaniciAdi";
            this.yoneticiKullaniciAdiDataGridViewTextBoxColumn.HeaderText = "YoneticiKullaniciAdi";
            this.yoneticiKullaniciAdiDataGridViewTextBoxColumn.Name = "yoneticiKullaniciAdiDataGridViewTextBoxColumn";
            // 
            // yoneticiSifreDataGridViewTextBoxColumn
            // 
            this.yoneticiSifreDataGridViewTextBoxColumn.DataPropertyName = "YoneticiSifre";
            this.yoneticiSifreDataGridViewTextBoxColumn.HeaderText = "YoneticiSifre";
            this.yoneticiSifreDataGridViewTextBoxColumn.Name = "yoneticiSifreDataGridViewTextBoxColumn";
            // 
            // adminBindingSource
            // 
            this.adminBindingSource.DataMember = "Admin";
            this.adminBindingSource.DataSource = this.ogrenci_Yurt_SistemiDataSet9;
            // 
            // ogrenci_Yurt_SistemiDataSet9
            // 
            this.ogrenci_Yurt_SistemiDataSet9.DataSetName = "Ogrenci_Yurt_SistemiDataSet9";
            this.ogrenci_Yurt_SistemiDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(68, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 18);
            this.label6.TabIndex = 43;
            this.label6.Text = "Kullanıcı Ad:";
            // 
            // TxtKullaniciAd
            // 
            this.TxtKullaniciAd.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtKullaniciAd.Location = new System.Drawing.Point(178, 157);
            this.TxtKullaniciAd.Name = "TxtKullaniciAd";
            this.TxtKullaniciAd.Size = new System.Drawing.Size(191, 25);
            this.TxtKullaniciAd.TabIndex = 6;
            // 
            // adminTableAdapter
            // 
            this.adminTableAdapter.ClearBeforeFill = true;
            // 
            // FrmYoneticislemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(643, 537);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.MskYoneticiTelefon);
            this.Controls.Add(this.TxtYoneticiid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtKullaniciAd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtSifre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtYoneticiMail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtYoneticiSoyad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtYoneticiAd);
            this.Controls.Add(this.labe1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmYoneticislemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin İşlemleri";
            this.Load += new System.EventHandler(this.FrmYoneticislemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ogrenci_Yurt_SistemiDataSet9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Button BtnSil;
        private System.Windows.Forms.MaskedTextBox MskYoneticiTelefon;
        private System.Windows.Forms.TextBox TxtYoneticiid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSifre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtYoneticiMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtYoneticiSoyad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtYoneticiAd;
        private System.Windows.Forms.Label labe1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtKullaniciAd;
        private Ogrenci_Yurt_SistemiDataSet9 ogrenci_Yurt_SistemiDataSet9;
        private System.Windows.Forms.BindingSource adminBindingSource;
        private Ogrenci_Yurt_SistemiDataSet9TableAdapters.AdminTableAdapter adminTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoneticiidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoneticiAdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoneticiSoyadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoneticiTelefonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoneticiMailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoneticiKullaniciAdiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yoneticiSifreDataGridViewTextBoxColumn;
    }
}