namespace Rez_Lab
{
    partial class Save_Excel
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Save_Excel));
			this.button1 = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Green;
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button1.Location = new System.Drawing.Point(118, 210);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(194, 61);
			this.button1.TabIndex = 24;
			this.button1.Text = "Сохранить данные в файл Excel";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.Color.Green;
			this.label13.Dock = System.Windows.Forms.DockStyle.Top;
			this.label13.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
			this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label13.Location = new System.Drawing.Point(0, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(471, 109);
			this.label13.TabIndex = 19;
			this.label13.Text = "Выгрузка БД в Excel";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox3.BackColor = System.Drawing.SystemColors.Control;
			this.pictureBox3.BackgroundImage = global::Rez_Lab.Properties.Resources.Rez11;
			this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pictureBox3.Image = global::Rez_Lab.Properties.Resources.Rez11;
			this.pictureBox3.Location = new System.Drawing.Point(422, 294);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(47, 33);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 75;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Green;
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
			this.pictureBox1.Location = new System.Drawing.Point(2, 30);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 40);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 78;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Black_Hole_BAK1",
            "Black_Hole_BAK1012",
            "Black_Hole_BAK1022",
            "Black_Hole_BAK2",
            "Black_Hole_BHC1",
            "Black_Hole_BHC2",
            "Black_Hole_Cleaner",
            "Black_Hole_Conditioner",
            "Black_Hole_Microtrav_1",
            "Black_Hole_Microtrav_23",
            "Galvan_Line_MG_Cu",
            "Galvan_Line_MG_CuEl1819",
            "Galvan_Line_MG_CuEl2021",
            "Galvan_Line_MG_KisOch",
            "Galvan_Line_MG_Microtrav",
            "Galvan_Line_MG_Sn",
            "Galvan_Line_MG_SnEl",
            "Trav_Podv",
            "Galvan_Line_PAL_Cu",
            "Galvan_Line_PAL_CuEl1920",
            "Galvan_Line_PAL_CuEl2122",
            "Galvan_Line_PAL_CuEl2324",
            "Galvan_Line_PAL_KisOch",
            "Galvan_Line_PAL_Microtrav",
            "Galvan_Line_PAL_Sn",
            "Galvan_Line_PAL_SnEl",
            "Trav_Podv_PAL",
            "Galvan_Zat_Cu",
            "Galvan_Zat_CuEl12",
            "Galvan_Zat_CuEl34",
            "Himich_Podgotov_Dek",
            "Himich_Podgotov_KisOch",
            "Himich_Podgotov_Microtrav",
            "Lushenie",
            "Perm_Obra_PredNe",
            "Perm_Obra_PredNe2",
            "Perm_Obra_RasOkis",
            "Perm_Obra_Sens",
            "Proyavlen_Photomask_ProvMod",
            "Proyavlen_Photomask_Ult1",
            "Proyavlen_Photomask_Ult2",
            "Proyavlen_Photorez_ProvMod",
            "Proyavlen_Photorez_Ult1",
            "Proyavlen_Photorez_Ult2",
            "Pryam_Metal_Cond",
            "Pryam_Metal_Met",
            "Pryam_Metal_PredMet",
            "Pryam_Metal_PredMet303",
            "Pryam_Metal_Uskor",
            "Snatie_Olova",
            "Snatie_Photorez",
            "Snatie_Photorez_2",
            "Trav_Med_1",
            "Amm_Prom",
            "Trav_Med_2",
            "Himich_Photorez_KisOch",
            "Himich_Photorez_Microtrav",
            "Himich_Photorez_Dek",
            "Zolot_Activ",
            "Zolot_Azot",
            "Zolot_HimNik",
            "Zolot_ImerZolot",
            "Zolot_KisOch",
            "Zolot_Microtrav",
            "Zolot_PostActiv",
            "Zolot_PredActiv",
            "DES_ProvMod",
            "DES_Ult1",
            "DES_KisTrav",
            "DES_Snatie_Photorez",
            "Oxide_ShelOch",
            "Oxide_PredActiv",
            "Oxide_Oxidir"});
			this.comboBox1.Location = new System.Drawing.Point(71, 160);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(294, 26);
			this.comboBox1.TabIndex = 79;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(137, 137);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(166, 17);
			this.checkBox1.TabIndex = 80;
			this.checkBox1.Text = "Выгрузить все таблицы БД";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
			// 
			// Save_Excel
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(471, 331);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label13);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Save_Excel";
			this.Text = "Лаборатория Резонит";
			this.Load += new System.EventHandler(this.Save_Excel_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}

