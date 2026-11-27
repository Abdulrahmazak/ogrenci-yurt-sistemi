namespace Öğrenci_Yurt_sistemi
{
    partial class FrmKasa
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKasa));
            this.dateFiltre = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnFiltrele = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PnlGelir = new System.Windows.Forms.Panel();
            this.PnlGider = new System.Windows.Forms.Panel();
            this.PnlBakiye = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.LblToplamGelir = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblToplamGider = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblKasaBakiye = new System.Windows.Forms.Label();
            this.lblRaporBaslik = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.PnlGelir.SuspendLayout();
            this.PnlGider.SuspendLayout();
            this.PnlBakiye.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateFiltre
            // 
            this.dateFiltre.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaption;
            this.dateFiltre.CustomFormat = "         MMMM      yyyy";
            this.dateFiltre.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateFiltre.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFiltre.Location = new System.Drawing.Point(374, 33);
            this.dateFiltre.Name = "dateFiltre";
            this.dateFiltre.Size = new System.Drawing.Size(238, 26);
            this.dateFiltre.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.lblRaporBaslik);
            this.panel1.Controls.Add(this.BtnFiltrele);
            this.panel1.Controls.Add(this.dateFiltre);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1145, 84);
            this.panel1.TabIndex = 1;
            // 
            // BtnFiltrele
            // 
            this.BtnFiltrele.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnFiltrele.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnFiltrele.Location = new System.Drawing.Point(645, 24);
            this.BtnFiltrele.Name = "BtnFiltrele";
            this.BtnFiltrele.Size = new System.Drawing.Size(175, 49);
            this.BtnFiltrele.TabIndex = 1;
            this.BtnFiltrele.Text = "Filtrele";
            this.BtnFiltrele.UseVisualStyleBackColor = false;
            this.BtnFiltrele.Click += new System.EventHandler(this.BtnFiltrele_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.0524F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.9476F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 84);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1145, 565);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chart1.BorderlineColor = System.Drawing.SystemColors.GradientActiveCaption;
            chartArea1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            chartArea1.BackSecondaryColor = System.Drawing.SystemColors.GradientActiveCaption;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(599, 3);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(543, 559);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // PnlGelir
            // 
            this.PnlGelir.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.PnlGelir.Controls.Add(this.LblToplamGelir);
            this.PnlGelir.Controls.Add(this.label1);
            this.PnlGelir.Location = new System.Drawing.Point(37, 20);
            this.PnlGelir.Name = "PnlGelir";
            this.PnlGelir.Size = new System.Drawing.Size(150, 163);
            this.PnlGelir.TabIndex = 0;
            // 
            // PnlGider
            // 
            this.PnlGider.BackColor = System.Drawing.Color.Maroon;
            this.PnlGider.Controls.Add(this.LblToplamGider);
            this.PnlGider.Controls.Add(this.label3);
            this.PnlGider.Location = new System.Drawing.Point(218, 20);
            this.PnlGider.Name = "PnlGider";
            this.PnlGider.Size = new System.Drawing.Size(155, 163);
            this.PnlGider.TabIndex = 0;
            // 
            // PnlBakiye
            // 
            this.PnlBakiye.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PnlBakiye.Controls.Add(this.LblKasaBakiye);
            this.PnlBakiye.Controls.Add(this.label5);
            this.PnlBakiye.Location = new System.Drawing.Point(412, 20);
            this.PnlBakiye.Name = "PnlBakiye";
            this.PnlBakiye.Size = new System.Drawing.Size(155, 163);
            this.PnlBakiye.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.PnlBakiye);
            this.panel2.Controls.Add(this.PnlGider);
            this.panel2.Controls.Add(this.PnlGelir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(590, 559);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 200);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(584, 356);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aylık Toplam Gelir";
            // 
            // LblToplamGelir
            // 
            this.LblToplamGelir.AutoSize = true;
            this.LblToplamGelir.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamGelir.Location = new System.Drawing.Point(45, 109);
            this.LblToplamGelir.Name = "LblToplamGelir";
            this.LblToplamGelir.Size = new System.Drawing.Size(56, 18);
            this.LblToplamGelir.TabIndex = 0;
            this.LblToplamGelir.Text = "0,00 ₺";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(10, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Aylık Toplam Gider";
            // 
            // LblToplamGider
            // 
            this.LblToplamGider.AutoSize = true;
            this.LblToplamGider.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamGider.Location = new System.Drawing.Point(48, 109);
            this.LblToplamGider.Name = "LblToplamGider";
            this.LblToplamGider.Size = new System.Drawing.Size(56, 18);
            this.LblToplamGider.TabIndex = 0;
            this.LblToplamGider.Text = "0,00 ₺";
            this.LblToplamGider.Click += new System.EventHandler(this.LblToplamGider_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(14, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Kasa Net Bakiye";
            // 
            // LblKasaBakiye
            // 
            this.LblKasaBakiye.AutoSize = true;
            this.LblKasaBakiye.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblKasaBakiye.Location = new System.Drawing.Point(50, 109);
            this.LblKasaBakiye.Name = "LblKasaBakiye";
            this.LblKasaBakiye.Size = new System.Drawing.Size(56, 18);
            this.LblKasaBakiye.TabIndex = 0;
            this.LblKasaBakiye.Text = "0,00 ₺";
            // 
            // lblRaporBaslik
            // 
            this.lblRaporBaslik.AutoSize = true;
            this.lblRaporBaslik.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRaporBaslik.Location = new System.Drawing.Point(151, 39);
            this.lblRaporBaslik.Name = "lblRaporBaslik";
            this.lblRaporBaslik.Size = new System.Drawing.Size(105, 18);
            this.lblRaporBaslik.TabIndex = 2;
            this.lblRaporBaslik.Text = "Kasa Durumu";
            // 
            // FrmKasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1145, 649);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKasa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kasa";
            this.Load += new System.EventHandler(this.FrmKasa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.PnlGelir.ResumeLayout(false);
            this.PnlGelir.PerformLayout();
            this.PnlGider.ResumeLayout(false);
            this.PnlGider.PerformLayout();
            this.PnlBakiye.ResumeLayout(false);
            this.PnlBakiye.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateFiltre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnFiltrele;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel PnlBakiye;
        private System.Windows.Forms.Panel PnlGider;
        private System.Windows.Forms.Panel PnlGelir;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label LblToplamGelir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblKasaBakiye;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblToplamGider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRaporBaslik;
    }
}