namespace Banca
{
    partial class Tranzactie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tranzactie));
            this.panelTranzactie = new System.Windows.Forms.Panel();
            this.buttonTranzactie = new System.Windows.Forms.Button();
            this.textBoxSuma = new System.Windows.Forms.TextBox();
            this.labelSuma = new System.Windows.Forms.Label();
            this.textBoxIBAN = new System.Windows.Forms.TextBox();
            this.labelIBAN = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTranzactie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTranzactie
            // 
            this.panelTranzactie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTranzactie.Controls.Add(this.pictureBox1);
            this.panelTranzactie.Controls.Add(this.buttonTranzactie);
            this.panelTranzactie.Controls.Add(this.textBoxSuma);
            this.panelTranzactie.Controls.Add(this.labelSuma);
            this.panelTranzactie.Controls.Add(this.textBoxIBAN);
            this.panelTranzactie.Controls.Add(this.labelIBAN);
            this.panelTranzactie.Location = new System.Drawing.Point(12, 12);
            this.panelTranzactie.Name = "panelTranzactie";
            this.panelTranzactie.Size = new System.Drawing.Size(543, 373);
            this.panelTranzactie.TabIndex = 0;
            // 
            // buttonTranzactie
            // 
            this.buttonTranzactie.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonTranzactie.ForeColor = System.Drawing.Color.FloralWhite;
            this.buttonTranzactie.Location = new System.Drawing.Point(289, 167);
            this.buttonTranzactie.Name = "buttonTranzactie";
            this.buttonTranzactie.Size = new System.Drawing.Size(140, 64);
            this.buttonTranzactie.TabIndex = 4;
            this.buttonTranzactie.Text = "Confirma Tranzactie";
            this.buttonTranzactie.UseVisualStyleBackColor = false;
            this.buttonTranzactie.Click += new System.EventHandler(this.buttonTranzactie_Click);
            // 
            // textBoxSuma
            // 
            this.textBoxSuma.Location = new System.Drawing.Point(220, 87);
            this.textBoxSuma.Name = "textBoxSuma";
            this.textBoxSuma.Size = new System.Drawing.Size(182, 22);
            this.textBoxSuma.TabIndex = 3;
            // 
            // labelSuma
            // 
            this.labelSuma.AutoSize = true;
            this.labelSuma.Location = new System.Drawing.Point(80, 87);
            this.labelSuma.Name = "labelSuma";
            this.labelSuma.Size = new System.Drawing.Size(42, 16);
            this.labelSuma.TabIndex = 2;
            this.labelSuma.Text = "Suma";
            // 
            // textBoxIBAN
            // 
            this.textBoxIBAN.Location = new System.Drawing.Point(220, 39);
            this.textBoxIBAN.Name = "textBoxIBAN";
            this.textBoxIBAN.Size = new System.Drawing.Size(182, 22);
            this.textBoxIBAN.TabIndex = 1;
            // 
            // labelIBAN
            // 
            this.labelIBAN.AutoSize = true;
            this.labelIBAN.Location = new System.Drawing.Point(84, 45);
            this.labelIBAN.Name = "labelIBAN";
            this.labelIBAN.Size = new System.Drawing.Size(38, 16);
            this.labelIBAN.TabIndex = 0;
            this.labelIBAN.Text = "IBAN";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(36, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Tranzactie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 392);
            this.Controls.Add(this.panelTranzactie);
            this.Name = "Tranzactie";
            this.Text = "Tranzactie";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tranzactie_FormClosed);
            this.Load += new System.EventHandler(this.Tranzactie_Load);
            this.panelTranzactie.ResumeLayout(false);
            this.panelTranzactie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTranzactie;
        private System.Windows.Forms.TextBox textBoxIBAN;
        private System.Windows.Forms.Label labelIBAN;
        private System.Windows.Forms.Button buttonTranzactie;
        private System.Windows.Forms.TextBox textBoxSuma;
        private System.Windows.Forms.Label labelSuma;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}