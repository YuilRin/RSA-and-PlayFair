namespace DoAnN
{
    partial class PlayFair
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
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtPlaintext = new System.Windows.Forms.TextBox();
            this.txtCiphertext = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lbKey = new System.Windows.Forms.Label();
            this.lbText = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnMove = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tPlaintext2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDecrypt = new System.Windows.Forms.TextBox();
            this.cmbMatrixSize = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(89, 53);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(199, 22);
            this.txtKey.TabIndex = 0;
            // 
            // txtPlaintext
            // 
            this.txtPlaintext.Location = new System.Drawing.Point(6, 22);
            this.txtPlaintext.Multiline = true;
            this.txtPlaintext.Name = "txtPlaintext";
            this.txtPlaintext.Size = new System.Drawing.Size(246, 85);
            this.txtPlaintext.TabIndex = 1;
            this.txtPlaintext.TextChanged += new System.EventHandler(this.txtPlaintext_TextChanged);
            // 
            // txtCiphertext
            // 
            this.txtCiphertext.Location = new System.Drawing.Point(6, 142);
            this.txtCiphertext.Multiline = true;
            this.txtCiphertext.Name = "txtCiphertext";
            this.txtCiphertext.Size = new System.Drawing.Size(246, 84);
            this.txtCiphertext.TabIndex = 2;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(97, 113);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(177, 115);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 4;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.Location = new System.Drawing.Point(40, 56);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(30, 16);
            this.lbKey.TabIndex = 5;
            this.lbKey.Text = "Key";
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Location = new System.Drawing.Point(6, 3);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(33, 16);
            this.lbText.TabIndex = 5;
            this.lbText.Text = "Text";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(96, 9);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(89, 26);
            this.lbName.TabIndex = 11;
            this.lbName.Text = "Playfair";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(32, 117);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(266, 261);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPlaintext);
            this.tabPage1.Controls.Add(this.lbText);
            this.tabPage1.Controls.Add(this.btnMove);
            this.tabPage1.Controls.Add(this.btnEncrypt);
            this.tabPage1.Controls.Add(this.txtCiphertext);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(258, 232);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Encrypt";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(177, 113);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 3;
            this.btnMove.Text = "Move -->";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tPlaintext2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtDecrypt);
            this.tabPage2.Controls.Add(this.btnDecrypt);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(258, 232);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Decrypt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tPlaintext2
            // 
            this.tPlaintext2.Location = new System.Drawing.Point(6, 24);
            this.tPlaintext2.Multiline = true;
            this.tPlaintext2.Name = "tPlaintext2";
            this.tPlaintext2.Size = new System.Drawing.Size(246, 85);
            this.tPlaintext2.TabIndex = 6;
            this.tPlaintext2.TextChanged += new System.EventHandler(this.tPlaintext2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Text";
            // 
            // txtDecrypt
            // 
            this.txtDecrypt.Location = new System.Drawing.Point(6, 144);
            this.txtDecrypt.Multiline = true;
            this.txtDecrypt.Name = "txtDecrypt";
            this.txtDecrypt.Size = new System.Drawing.Size(246, 84);
            this.txtDecrypt.TabIndex = 7;
            // 
            // cmbMatrixSize
            // 
            this.cmbMatrixSize.FormattingEnabled = true;
            this.cmbMatrixSize.Items.AddRange(new object[] {
            "5x5",
            "6x6"});
            this.cmbMatrixSize.Location = new System.Drawing.Point(89, 81);
            this.cmbMatrixSize.Name = "cmbMatrixSize";
            this.cmbMatrixSize.Size = new System.Drawing.Size(147, 24);
            this.cmbMatrixSize.TabIndex = 13;
            this.cmbMatrixSize.SelectedIndexChanged += new System.EventHandler(this.cmbMatrixSize_SelectedIndexChanged);
            // 
            // PlayFair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 399);
            this.Controls.Add(this.cmbMatrixSize);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbKey);
            this.Controls.Add(this.txtKey);
            this.Name = "PlayFair";
            this.Text = "Playfair";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtPlaintext;
        private System.Windows.Forms.TextBox txtCiphertext;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lbKey;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tPlaintext2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDecrypt;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.ComboBox cmbMatrixSize;
    }
}

