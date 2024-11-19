using System;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DoAnN
{
    public partial class RSA : Form
    {
        private RSAEncryption rsa;

        public RSA()
        {
            InitializeComponent();
        }

        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            rsa = new RSAEncryption(512); // Tạo khóa với 512-bit
            var publicKey = rsa.GetPublicKey();
            var privateKey = rsa.GetPrivateKey();

            // Hiển thị Public và Private Key
            txtPublicKey.Text = $"e: {publicKey.e}\nn: {publicKey.n}";
            txtPrivateKey.Text = $"d: {privateKey}\nn: {publicKey.n}";
        }


        private void btnRSAEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string plaintext = txtPlaintext.Text;
                StringBuilder ciphertextBuilder = new StringBuilder();

                // Lấy e và n từ TextBox Public Key
                string[] publicKeyParts = txtPublicKey.Text.Split(new[] { '\n', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                BigInteger ee = BigInteger.Parse(publicKeyParts[1]);
                BigInteger n = BigInteger.Parse(publicKeyParts[3]);

                // Mã hóa từng ký tự của chuỗi
                foreach (char c in plaintext)
                {
                    // Chuyển ký tự thành mã ASCII (hoặc bạn có thể dùng UTF-8)
                    BigInteger plaintextNum = new BigInteger(Encoding.UTF8.GetBytes(c.ToString()));

                    // Mã hóa ký tự
                    BigInteger ciphertext = BigInteger.ModPow(plaintextNum, ee, n);

                    // Ghép các kết quả mã hóa lại thành chuỗi
                    ciphertextBuilder.Append(ciphertext.ToString() + " ");
                }

                // Hiển thị kết quả mã hóa
                txtRSACiphertext.Text = ciphertextBuilder.ToString().Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mã hóa: {ex.Message}");
            }
        }


        private void btnRSADecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                BigInteger ciphertext = BigInteger.Parse(txtRSACiphertext.Text);

                // Lấy d và n từ TextBox Private Key
                string[] privateKeyParts = txtPrivateKey.Text.Split(new[] { '\n', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                BigInteger d = BigInteger.Parse(privateKeyParts[1]);
              //  textBox1.Text += d.ToString();
                BigInteger n = BigInteger.Parse(privateKeyParts[3]);
                //textBox2 .Text += n.ToString();

                // Giải mã
                BigInteger plaintextNum = BigInteger.ModPow(ciphertext, d, n);
                textBox1.Text=plaintextNum.ToString();
                string plaintext = Encoding.UTF8.GetString(plaintextNum.ToByteArrayUnsigned());

                txtPlaintext.Text = plaintext;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi giải mã: {ex.Message}");
            }
        }
    }

    public class RSAEncryption
    {
        private BigInteger n;
        private BigInteger e;
        private BigInteger d;

        public RSAEncryption(int keySize = 1024)
        {
            GenerateKeys(keySize);
        }

        private void GenerateKeys(int keySize)
        {
            // Tạo 2 số nguyên tố lớn
            BigInteger p = GeneratePrime(keySize / 2);
            BigInteger q = GeneratePrime(keySize / 2);
            n = p * q;

            // Tính phi(n)
            BigInteger phi = (p - 1) * (q - 1);

            // Chọn e sao cho gcd(e, phi) = 1
            e = 65537; // Giá trị phổ biến
            while (BigInteger.GreatestCommonDivisor(e, phi) != 1)
            {
                e++;
            }

            // Tính d sao cho (d * e) % phi = 1
            d = ModInverse(e, phi);
        }

        public (BigInteger e, BigInteger n) GetPublicKey() => (e, n);
        public BigInteger GetPrivateKey() => d;

        private BigInteger GeneratePrime(int bitLength)
        {
            BigInteger prime;
            do
            {
                prime = GenerateRandomBigInteger(bitLength);
            } while (!IsProbablyPrime(prime, 10));
            return prime;
        }

        private BigInteger GenerateRandomBigInteger(int bitLength)
        {
            int byteLength = (bitLength + 7) / 8;
            byte[] randomBytes = new byte[byteLength];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }

            randomBytes[randomBytes.Length - 1] &= (byte)(0xFF >> (8 - bitLength % 8));
            return new BigInteger(randomBytes);
        }

        private static BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m, x0 = 0, x1 = 1;
            if (m == 1) return 0;

            while (a > 1)
            {
                BigInteger q = a / m;
                (m, a) = (a % m, m);
                (x0, x1) = (x1 - q * x0, x0);
            }

            return x1 < 0 ? x1 + m0 : x1;
        }

        private static bool IsProbablyPrime(BigInteger source, int certainty)
        {
            if (source < 2) return false;
            if (source != 2 && source % 2 == 0) return false;

            BigInteger d = source - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s++;
            }

            Random rand = new Random();
            for (int i = 0; i < certainty; i++)
            {
                BigInteger a = RandomIntegerBelow(source - 2) + 2;
                BigInteger temp = d;
                BigInteger mod = BigInteger.ModPow(a, temp, source);
                while (temp != source - 1 && mod != 1 && mod != source - 1)
                {
                    mod = BigInteger.ModPow(mod, 2, source);
                    temp *= 2;
                }
                if (mod != source - 1 && temp % 2 == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static BigInteger RandomIntegerBelow(BigInteger upperLimit)
        {
            byte[] bytes = upperLimit.ToByteArray();
            BigInteger randomValue;

            using (var rng = new RNGCryptoServiceProvider())
            {
                do
                {
                    rng.GetBytes(bytes);
                    bytes[bytes.Length - 1] &= (byte)0x7F; // Đảm bảo giá trị dương
                    randomValue = new BigInteger(bytes);
                } while (randomValue >= upperLimit || randomValue < 2);
            }

            return randomValue;
        }
    }

    public static class BigIntegerExtensions
    {
        public static byte[] ToByteArrayUnsigned(this BigInteger bigInteger)
        {
            byte[] bytes = bigInteger.ToByteArray();
            if (bytes[bytes.Length - 1] == 0)
            {
                Array.Resize(ref bytes, bytes.Length - 1);
            }
            return bytes;
        }
    }
}
