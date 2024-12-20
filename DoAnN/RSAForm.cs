﻿using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DoAnN
{
    public partial class RSAForm : Form
    {
        private BigInteger p = 0, q = 0, n = 0, phi = 0, ee = 0, d = 0;

        public RSAForm()
        {
            InitializeComponent();
        }

        private bool IsPrime(BigInteger n)
        {
            if (n < 2) return false;
            for (BigInteger i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private BigInteger Gcd(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m, x0 = 0, x1 = 1;

            if (m == 1) return 0;

            while (a > 1)
            {
                BigInteger q = a / m;
                BigInteger t = m;

                m = a % m;
                a = t;
                t = x0;

                x0 = x1 - q * x0;
                x1 = t;
            }

            return x1 < 0 ? x1 + m0 : x1;
        }

        private void GenerateKeyPair()
        {
            lbMess.Text="Lấy mã tự động thành công";
            Random rnd = new Random();
            do
            {
                p = GeneratePrime(rnd);
                q = GeneratePrime(rnd);
            }
            while (p == q);
            FindNumberNeed();
        }

        private void FindNumberNeed()
        {
            Random rnd = new Random();
            n = p * q;
            phi = (p - 1) * (q - 1);

            do
            {
                ee = rnd.Next(2, (int)phi);
            } while (Gcd(ee, phi) != 1);

            d = ModInverse(ee, phi);
        }

        private BigInteger GeneratePrime(Random rnd)
        {
            while (true)
            {
                BigInteger candidate = rnd.Next(1000, 5000);
                if (IsPrime(candidate))
                    return candidate;
            }
        }

        private void edt_Q_Changed(object sender, EventArgs e)
        {
            editChanged();
        }

        private void editChanged()
        {
            if (txtP.Text.Length == 0)
            {
                lbMess.Text = "Chú ý Hãy nhập P";
                return;
            }
            if (txtQ.Text.Length == 0)
            {
                lbMess.Text = "Chú ý Hãy nhập Q";
                return;
            }
            q = BigInteger.Parse(txtQ.Text);
            p = BigInteger.Parse(txtP.Text);
            if (!IsPrime(p))
            {
                lbMess.Text = "Chú ý P phải là số nguyên tố";
                return;
            }
            else if (!IsPrime(q))
            {
                lbMess.Text = "Chú ý Q phải là số nguyên tố";
                return;
            }
            else if (p == q)
            {
                lbMess.Text = "Chú ý: Q và P phải khác nhau";
                return;
            }
            else if (p * q < 128)
            {
                lbMess.Text = "Chú ý: Q*P phải lớn hơn 128";
                return;
            }
            else
            {
                lbMess.Text = "";
                FindNumberNeed();

                txtPublicKey.Text = $"e: {ee}, n: {n}    {p}   {q}";
                txtPrivateKey.Text = $"d: {d}, n: {n}";
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            txtCiphertext2.Text = txtCiphertext.Text;
            txtDecrypted.Text = "";
        }

        private void txtCiphertext2_TextChanged(object sender, EventArgs e)
        {
            txtDecrypted.Text = null;
        }

        private void txtPlaintext_TextChanged(object sender, EventArgs e)
        {
            txtCiphertext.Text = null;
        }

        private string Encrypt(string plaintext)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(plaintext);
            BigInteger[] cipherBytes = new BigInteger[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
            {
                cipherBytes[i] = BigInteger.ModPow(bytes[i], ee, n);
            }

            return string.Join(" ", cipherBytes);
        }

        private string Decrypt(string ciphertext)
        {
            string[] parts = ciphertext.Split(' ');
            byte[] plainBytes = new byte[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                BigInteger cipherValue = BigInteger.Parse(parts[i]);
                plainBytes[i] = (byte)BigInteger.ModPow(cipherValue, d, n);
            }

            return Encoding.UTF8.GetString(plainBytes);
        }

        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            GenerateKeyPair();
            txtP.Text = $"{p}";
            txtQ.Text = $"{q}";

            txtPublicKey.Text = $"e: {ee}, n: {n}          {p}   {q}";
            txtPrivateKey.Text = $"d: {d}, n: {n}";
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlaintext.Text))
            {
                MessageBox.Show("Vui lòng nhập thông điệp cần mã hóa.");
                return;
            }

            string ciphertext = Encrypt(txtPlaintext.Text);
            txtCiphertext.Text = ciphertext;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCiphertext2.Text))
            {
                MessageBox.Show("Vui lòng nhập bản mã cần giải mã.");
                return;
            }

            string plaintext = Decrypt(txtCiphertext2.Text);
            txtDecrypted.Text = plaintext;
        }

        private void btnImportFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileContent = System.IO.File.ReadAllText(openFileDialog.FileName);
                    txtPlaintext.Text = fileContent;
                    MessageBox.Show("Dữ liệu đã được tải lên.");
                }
            }
        }

        private void btnExportToFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, txtDecrypted.Text);
                    MessageBox.Show("Dữ liệu đã được xuất ra file.");
                }
            }
        }
    }
}
