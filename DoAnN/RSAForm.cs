using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DoAnN
{
    public partial class RSAForm : Form
    {
        private BigInteger p, q, n, phi, ee, d;

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
            // Tạo số nguyên tố p và q
            Random rnd = new Random();
            do
            {


                p = GeneratePrime(rnd);

                q = GeneratePrime(rnd);
            }
            while (p==q);

            n = p * q;
            phi = (p - 1) * (q - 1);

            // Chọn e sao cho gcd(e, phi) = 1
            do
            {
                ee = rnd.Next(2, (int)phi);
            } while (Gcd(ee, phi) != 1);

            // Tính d = e^(-1) mod phi
            d = ModInverse(ee, phi);
        }

        private BigInteger GeneratePrime(Random rnd)
        {
            while (true)
            {
                BigInteger candidate = rnd.Next(1000, 5000); // Tùy chỉnh dải số nguyên tố
                if (IsPrime(candidate))
                    return candidate;
            }
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
            txtPublicKey.Text = $"e: {ee}, n: {n}, p: {p}, q: {q};";
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
            if (string.IsNullOrEmpty(txtCiphertext.Text))
            {
                MessageBox.Show("Vui lòng nhập bản mã cần giải mã.");
                return;
            }

            string plaintext = Decrypt(txtCiphertext.Text);
            txtDecrypted.Text = plaintext;
        }
    }
}
