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
            this.panelTranzactie = new System.Windows.Forms.Panel();
            this.buttonTranzactie = new System.Windows.Forms.Button();
            this.textBoxSuma = new System.Windows.Forms.TextBox();
            this.labelSuma = new System.Windows.Forms.Label();
            this.textBoxIBAN = new System.Windows.Forms.TextBox();
            this.labelIBAN = new System.Windows.Forms.Label();
            this.panelTranzactie.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTranzactie
            // 
            this.panelTranzactie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.buttonTranzactie.Location = new System.Drawing.Point(364, 271);
            this.buttonTranzactie.Name = "buttonTranzactie";
            this.buttonTranzactie.Size = new System.Drawing.Size(140, 64);
            this.buttonTranzactie.TabIndex = 4;
            this.buttonTranzactie.Text = "Confirma Tranzactie";
            this.buttonTranzactie.UseVisualStyleBackColor = true;
            this.buttonTranzactie.Click += new System.EventHandler(this.buttonTranzactie_Click);
            // 
            // textBoxSuma
            // 
            this.textBoxSuma.Location = new System.Drawing.Point(211, 173);
            this.textBoxSuma.Name = "textBoxSuma";
            this.textBoxSuma.Size = new System.Drawing.Size(182, 22);
            this.textBoxSuma.TabIndex = 3;
            // 
            // labelSuma
            // 
            this.labelSuma.AutoSize = true;
            this.labelSuma.Location = new System.Drawing.Point(65, 176);
            this.labelSuma.Name = "labelSuma";
            this.labelSuma.Size = new System.Drawing.Size(44, 17);
            this.labelSuma.TabIndex = 2;
            this.labelSuma.Text = "Suma";
            // 
            // textBoxIBAN
            // 
            this.textBoxIBAN.Location = new System.Drawing.Point(211, 95);
            this.textBoxIBAN.Name = "textBoxIBAN";
            this.textBoxIBAN.Size = new System.Drawing.Size(182, 22);
            this.textBoxIBAN.TabIndex = 1;
            // 
            // labelIBAN
            // 
            this.labelIBAN.AutoSize = true;
            this.labelIBAN.Location = new System.Drawing.Point(65, 98);
            this.labelIBAN.Name = "labelIBAN";
            this.labelIBAN.Size = new System.Drawing.Size(39, 17);
            this.labelIBAN.TabIndex = 0;
            this.labelIBAN.Text = "IBAN";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTranzactie;
        private System.Windows.Forms.TextBox textBoxIBAN;
        private System.Windows.Forms.Label labelIBAN;
        private System.Windows.Forms.Button buttonTranzactie;
        private System.Windows.Forms.TextBox textBoxSuma;
        private System.Windows.Forms.Label labelSuma;
    }
}