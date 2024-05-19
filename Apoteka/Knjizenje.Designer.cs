namespace Apoteka
{
    partial class Knjizenje
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Gotovinabox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Cenabox = new System.Windows.Forms.TextBox();
            this.Kusur_dugme = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(117, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "IZNOS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Gotovinabox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Location = new System.Drawing.Point(-1, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 164);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(196, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 44);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Gotovinabox
            // 
            this.Gotovinabox.BackColor = System.Drawing.SystemColors.Control;
            this.Gotovinabox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Gotovinabox.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Gotovinabox.Location = new System.Drawing.Point(196, 83);
            this.Gotovinabox.Name = "Gotovinabox";
            this.Gotovinabox.Size = new System.Drawing.Size(154, 44);
            this.Gotovinabox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 43);
            this.label4.TabIndex = 5;
            this.label4.Text = "Gotovina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 43);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kartica   ";
            // 
            // Cenabox
            // 
            this.Cenabox.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Cenabox.Location = new System.Drawing.Point(52, 53);
            this.Cenabox.Name = "Cenabox";
            this.Cenabox.ReadOnly = true;
            this.Cenabox.Size = new System.Drawing.Size(246, 44);
            this.Cenabox.TabIndex = 2;
            // 
            // Kusur_dugme
            // 
            this.Kusur_dugme.BackColor = System.Drawing.Color.White;
            this.Kusur_dugme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Kusur_dugme.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Kusur_dugme.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Kusur_dugme.Location = new System.Drawing.Point(102, 312);
            this.Kusur_dugme.Name = "Kusur_dugme";
            this.Kusur_dugme.Size = new System.Drawing.Size(154, 44);
            this.Kusur_dugme.TabIndex = 8;
            this.Kusur_dugme.Text = "PRINT";
            this.Kusur_dugme.UseVisualStyleBackColor = false;
            this.Kusur_dugme.Click += new System.EventHandler(this.button2_Click);
            // 
            // Knjizenje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(362, 417);
            this.Controls.Add(this.Kusur_dugme);
            this.Controls.Add(this.Cenabox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(70, 100);
            this.Name = "Knjizenje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Knjizenje";
            this.Load += new System.EventHandler(this.Knjizenje_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Knjizenje_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox Cenabox;
        private TextBox Gotovinabox;
        private Label label4;
        private Label label2;
        private TextBox Kusurbox;
        private Button button1;
        private Button Kusur_dugme;
    }
}