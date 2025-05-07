namespace Rez_Lab
{
    partial class Admin_LogsCheck_Form
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
            this.Refresh_btn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Refresh_btn
            // 
            this.Refresh_btn.BackColor = System.Drawing.Color.Green;
            this.Refresh_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Refresh_btn.FlatAppearance.BorderSize = 0;
            this.Refresh_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Refresh_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Refresh_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Refresh_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.Refresh_btn.ForeColor = System.Drawing.Color.White;
            this.Refresh_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Refresh_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Refresh_btn.Location = new System.Drawing.Point(622, 586);
            this.Refresh_btn.Name = "Refresh_btn";
            this.Refresh_btn.Size = new System.Drawing.Size(167, 45);
            this.Refresh_btn.TabIndex = 34;
            this.Refresh_btn.Text = "Обновить";
            this.Refresh_btn.UseVisualStyleBackColor = false;
            this.Refresh_btn.Click += new System.EventHandler(this.Refresh_btn_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Green;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(-7, -2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(814, 92);
            this.label13.TabIndex = 33;
            this.label13.Text = "История изменения данных";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Green;
            this.dataGridView1.Location = new System.Drawing.Point(13, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 467);
            this.dataGridView1.TabIndex = 32;
            // 
            // Admin_LogsCheck_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 654);
            this.Controls.Add(this.Refresh_btn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Admin_LogsCheck_Form";
            this.Text = "Admin_LogsCheck_Form";
            this.Load += new System.EventHandler(this.Admin_LogsCheck_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Refresh_btn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}