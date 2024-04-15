namespace Banca
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
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
            this.panelUser = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelValute = new System.Windows.Forms.Panel();
            this.labelNume = new System.Windows.Forms.Label();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.textBoxCNP = new System.Windows.Forms.TextBox();
            this.labelCNP = new System.Windows.Forms.Label();
            this.textBoxTelefon = new System.Windows.Forms.TextBox();
            this.labelTelefon = new System.Windows.Forms.Label();
            this.textBoxPrenume = new System.Windows.Forms.TextBox();
            this.labelPrenume = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxValute = new System.Windows.Forms.ListBox();
            this.buttonAdaugaUser = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAdaugaValuta = new System.Windows.Forms.Button();
            this.panelUser.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelValute.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.buttonAdaugaUser);
            this.panelUser.Controls.Add(this.listBoxValute);
            this.panelUser.Controls.Add(this.textBoxPrenume);
            this.panelUser.Controls.Add(this.labelPrenume);
            this.panelUser.Controls.Add(this.textBoxTelefon);
            this.panelUser.Controls.Add(this.labelTelefon);
            this.panelUser.Controls.Add(this.textBoxCNP);
            this.panelUser.Controls.Add(this.labelCNP);
            this.panelUser.Controls.Add(this.textBoxNume);
            this.panelUser.Controls.Add(this.labelNume);
            this.panelUser.Location = new System.Drawing.Point(0, 31);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(559, 623);
            this.panelUser.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.valuteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1099, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.userToolStripMenuItem.Text = "User";
            // 
            // valuteToolStripMenuItem
            // 
            this.valuteToolStripMenuItem.Name = "valuteToolStripMenuItem";
            this.valuteToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.valuteToolStripMenuItem.Text = "Valute";
            // 
            // panelValute
            // 
            this.panelValute.Controls.Add(this.buttonAdaugaValuta);
            this.panelValute.Controls.Add(this.textBox4);
            this.panelValute.Controls.Add(this.label4);
            this.panelValute.Controls.Add(this.textBox3);
            this.panelValute.Controls.Add(this.label3);
            this.panelValute.Controls.Add(this.textBox2);
            this.panelValute.Controls.Add(this.label2);
            this.panelValute.Controls.Add(this.textBox1);
            this.panelValute.Controls.Add(this.label1);
            this.panelValute.Controls.Add(this.textBox5);
            this.panelValute.Controls.Add(this.label5);
            this.panelValute.Location = new System.Drawing.Point(582, 31);
            this.panelValute.Name = "panelValute";
            this.panelValute.Size = new System.Drawing.Size(517, 610);
            this.panelValute.TabIndex = 1;
            // 
            // labelNume
            // 
            this.labelNume.AutoSize = true;
            this.labelNume.Location = new System.Drawing.Point(45, 53);
            this.labelNume.Name = "labelNume";
            this.labelNume.Size = new System.Drawing.Size(45, 17);
            this.labelNume.TabIndex = 0;
            this.labelNume.Text = "Nume";
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(164, 50);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(216, 22);
            this.textBoxNume.TabIndex = 1;
            // 
            // textBoxCNP
            // 
            this.textBoxCNP.Location = new System.Drawing.Point(164, 174);
            this.textBoxCNP.Name = "textBoxCNP";
            this.textBoxCNP.Size = new System.Drawing.Size(216, 22);
            this.textBoxCNP.TabIndex = 3;
            // 
            // labelCNP
            // 
            this.labelCNP.AutoSize = true;
            this.labelCNP.Location = new System.Drawing.Point(45, 177);
            this.labelCNP.Name = "labelCNP";
            this.labelCNP.Size = new System.Drawing.Size(36, 17);
            this.labelCNP.TabIndex = 2;
            this.labelCNP.Text = "CNP";
            // 
            // textBoxTelefon
            // 
            this.textBoxTelefon.Location = new System.Drawing.Point(164, 236);
            this.textBoxTelefon.Name = "textBoxTelefon";
            this.textBoxTelefon.Size = new System.Drawing.Size(216, 22);
            this.textBoxTelefon.TabIndex = 5;
            // 
            // labelTelefon
            // 
            this.labelTelefon.AutoSize = true;
            this.labelTelefon.Location = new System.Drawing.Point(45, 239);
            this.labelTelefon.Name = "labelTelefon";
            this.labelTelefon.Size = new System.Drawing.Size(56, 17);
            this.labelTelefon.TabIndex = 4;
            this.labelTelefon.Text = "Telefon";
            // 
            // textBoxPrenume
            // 
            this.textBoxPrenume.Location = new System.Drawing.Point(164, 112);
            this.textBoxPrenume.Name = "textBoxPrenume";
            this.textBoxPrenume.Size = new System.Drawing.Size(216, 22);
            this.textBoxPrenume.TabIndex = 7;
            // 
            // labelPrenume
            // 
            this.labelPrenume.AutoSize = true;
            this.labelPrenume.Location = new System.Drawing.Point(45, 115);
            this.labelPrenume.Name = "labelPrenume";
            this.labelPrenume.Size = new System.Drawing.Size(65, 17);
            this.labelPrenume.TabIndex = 6;
            this.labelPrenume.Text = "Prenume";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(205, 48);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(216, 22);
            this.textBox5.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "label5";
            // 
            // listBoxValute
            // 
            this.listBoxValute.FormattingEnabled = true;
            this.listBoxValute.ItemHeight = 16;
            this.listBoxValute.Location = new System.Drawing.Point(164, 313);
            this.listBoxValute.Name = "listBoxValute";
            this.listBoxValute.Size = new System.Drawing.Size(216, 100);
            this.listBoxValute.TabIndex = 8;
            // 
            // buttonAdaugaUser
            // 
            this.buttonAdaugaUser.Location = new System.Drawing.Point(196, 438);
            this.buttonAdaugaUser.Name = "buttonAdaugaUser";
            this.buttonAdaugaUser.Size = new System.Drawing.Size(152, 85);
            this.buttonAdaugaUser.TabIndex = 9;
            this.buttonAdaugaUser.Text = "Adauga User";
            this.buttonAdaugaUser.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(205, 270);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 22);
            this.textBox1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(205, 196);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(216, 22);
            this.textBox2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "label2";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(205, 344);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(216, 22);
            this.textBox3.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "label3";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(205, 122);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(216, 22);
            this.textBox4.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "label4";
            // 
            // buttonAdaugaValuta
            // 
            this.buttonAdaugaValuta.Location = new System.Drawing.Point(166, 438);
            this.buttonAdaugaValuta.Name = "buttonAdaugaValuta";
            this.buttonAdaugaValuta.Size = new System.Drawing.Size(152, 85);
            this.buttonAdaugaValuta.TabIndex = 10;
            this.buttonAdaugaValuta.Text = "Adauga Valuata";
            this.buttonAdaugaValuta.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 700);
            this.Controls.Add(this.panelValute);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelValute.ResumeLayout(false);
            this.panelValute.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valuteToolStripMenuItem;
        private System.Windows.Forms.Button buttonAdaugaUser;
        private System.Windows.Forms.ListBox listBoxValute;
        private System.Windows.Forms.TextBox textBoxPrenume;
        private System.Windows.Forms.Label labelPrenume;
        private System.Windows.Forms.TextBox textBoxTelefon;
        private System.Windows.Forms.Label labelTelefon;
        private System.Windows.Forms.TextBox textBoxCNP;
        private System.Windows.Forms.Label labelCNP;
        private System.Windows.Forms.TextBox textBoxNume;
        private System.Windows.Forms.Label labelNume;
        private System.Windows.Forms.Panel panelValute;
        private System.Windows.Forms.Button buttonAdaugaValuta;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
    }
}

