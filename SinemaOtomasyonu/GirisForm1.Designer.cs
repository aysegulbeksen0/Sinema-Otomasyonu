namespace SinemaOtomasyonu
{
    partial class GirisForm1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            txtboxKullaniciAdi = new TextBox();
            label2 = new Label();
            txtboxSifre = new TextBox();
            yazi = new Label();
            txtboxSifr = new TextBox();
            label3 = new Label();
            txtboxKullanici = new TextBox();
            label4 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(165, 177);
            button1.Name = "button1";
            button1.Size = new Size(148, 56);
            button1.TabIndex = 0;
            button1.Text = "GİRİŞ YAP";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(55, 47);
            label1.Name = "label1";
            label1.Size = new Size(167, 31);
            label1.TabIndex = 1;
            label1.Text = "KULANICI ADI";
            // 
            // txtboxKullaniciAdi
            // 
            txtboxKullaniciAdi.Location = new Point(269, 51);
            txtboxKullaniciAdi.Name = "txtboxKullaniciAdi";
            txtboxKullaniciAdi.Size = new Size(125, 27);
            txtboxKullaniciAdi.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(55, 107);
            label2.Name = "label2";
            label2.Size = new Size(72, 31);
            label2.TabIndex = 3;
            label2.Text = "ŞİFRE";
            // 
            // txtboxSifre
            // 
            txtboxSifre.Location = new Point(269, 107);
            txtboxSifre.Name = "txtboxSifre";
            txtboxSifre.Size = new Size(125, 27);
            txtboxSifre.TabIndex = 4;
            txtboxSifre.UseSystemPasswordChar = true;
            // 
            // yazi
            // 
            yazi.AutoSize = true;
            yazi.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            yazi.Location = new Point(197, 295);
            yazi.Name = "yazi";
            yazi.Size = new Size(80, 31);
            yazi.TabIndex = 6;
            yazi.Text = "KAYIT";
            // 
            // txtboxSifr
            // 
            txtboxSifr.Location = new Point(269, 405);
            txtboxSifr.Name = "txtboxSifr";
            txtboxSifr.Size = new Size(125, 27);
            txtboxSifr.TabIndex = 14;
            txtboxSifr.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(55, 405);
            label3.Name = "label3";
            label3.Size = new Size(72, 31);
            label3.TabIndex = 13;
            label3.Text = "ŞİFRE";
            // 
            // txtboxKullanici
            // 
            txtboxKullanici.Location = new Point(269, 349);
            txtboxKullanici.Name = "txtboxKullanici";
            txtboxKullanici.Size = new Size(125, 27);
            txtboxKullanici.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(55, 345);
            label4.Name = "label4";
            label4.Size = new Size(167, 31);
            label4.TabIndex = 11;
            label4.Text = "KULANICI ADI";
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.Location = new Point(165, 474);
            button3.Name = "button3";
            button3.Size = new Size(148, 56);
            button3.TabIndex = 10;
            button3.Text = "KAYDOL";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // GirisForm1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 595);
            Controls.Add(txtboxSifr);
            Controls.Add(label3);
            Controls.Add(txtboxKullanici);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(yazi);
            Controls.Add(txtboxSifre);
            Controls.Add(label2);
            Controls.Add(txtboxKullaniciAdi);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "GirisForm1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox txtboxKullaniciAdi;
        private Label label2;
        private TextBox txtboxSifre;
        private Label yazi;
        private TextBox txtboxSifr;
        private Label label3;
        private TextBox txtboxKullanici;
        private Label label4;
        private Button button3;
    }
}