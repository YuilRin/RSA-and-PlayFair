namespace DoAnN
{
    partial class RSA
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
            this.RSAPlaintext = new System.Windows.Forms.Label();
            this.btnRSADecrypt = new System.Windows.Forms.Button();
            this.btnRSAEncrypt = new System.Windows.Forms.Button();
            this.txtRSACiphertext = new System.Windows.Forms.TextBox();
            this.txtPlaintext = new System.Windows.Forms.TextBox();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RSAPlaintext
            // 
            this.RSAPlaintext.AutoSize = true;
            this.RSAPlaintext.Location = new System.Drawing.Point(49, 120);
            this.RSAPlaintext.Name = "RSAPlaintext";
            this.RSAPlaintext.Size = new System.Drawing.Size(33, 16);
            this.RSAPlaintext.TabIndex = 11;
            this.RSAPlaintext.Text = "Text";
            // 
            // btnRSADecrypt
            // 
            this.btnRSADecrypt.Location = new System.Drawing.Point(123, 239);
            this.btnRSADecrypt.Name = "btnRSADecrypt";
            this.btnRSADecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnRSADecrypt.TabIndex = 10;
            this.btnRSADecrypt.Text = "Decrypt";
            this.btnRSADecrypt.UseVisualStyleBackColor = true;
            this.btnRSADecrypt.Click += new System.EventHandler(this.btnRSADecrypt_Click);
            // 
            // btnRSAEncrypt
            // 
            this.btnRSAEncrypt.Location = new System.Drawing.Point(123, 201);
            this.btnRSAEncrypt.Name = "btnRSAEncrypt";
            this.btnRSAEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnRSAEncrypt.TabIndex = 9;
            this.btnRSAEncrypt.Text = "Encrypt";
            this.btnRSAEncrypt.UseVisualStyleBackColor = true;
            this.btnRSAEncrypt.Click += new System.EventHandler(this.btnRSAEncrypt_Click);
            // 
            // txtRSACiphertext
            // 
            this.txtRSACiphertext.Location = new System.Drawing.Point(98, 288);
            this.txtRSACiphertext.Name = "txtRSACiphertext";
            this.txtRSACiphertext.Size = new System.Drawing.Size(100, 22);
            this.txtRSACiphertext.TabIndex = 8;
            // 
            // txtPlaintext
            // 
            this.txtPlaintext.Location = new System.Drawing.Point(98, 117);
            this.txtPlaintext.Name = "txtPlaintext";
            this.txtPlaintext.Size = new System.Drawing.Size(100, 22);
            this.txtPlaintext.TabIndex = 7;
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Location = new System.Drawing.Point(98, 154);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(238, 41);
            this.txtPublicKey.TabIndex = 12;
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Location = new System.Drawing.Point(440, 148);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.Size = new System.Drawing.Size(136, 47);
            this.txtPrivateKey.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(377, 252);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(377, 288);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 14;
            // 
            // RSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 336);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtPrivateKey);
            this.Controls.Add(this.txtPublicKey);
            this.Controls.Add(this.RSAPlaintext);
            this.Controls.Add(this.btnRSADecrypt);
            this.Controls.Add(this.btnRSAEncrypt);
            this.Controls.Add(this.txtRSACiphertext);
            this.Controls.Add(this.txtPlaintext);
            this.Name = "RSA";
            this.Text = "RSA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RSAPlaintext;
        private System.Windows.Forms.Button btnRSADecrypt;
        private System.Windows.Forms.Button btnRSAEncrypt;
        private System.Windows.Forms.TextBox txtRSACiphertext;
        private System.Windows.Forms.TextBox txtPlaintext;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}