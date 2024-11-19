using System;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace DoAnN
{
    public partial class RSA : Form
    {
        private RSAEncryption rsa;

        public RSA()
        {
            InitializeComponent();
            rsa = new RSAEncryption(512); // Tạo khóa RSA với độ dài 512-bit
        }

        private void btnRSAEncrypt_Click(object sender, EventArgs e)
        {
            string plaintext = txtRSAPlaintext.Text;
            BigInteger plaintextNum = new BigInteger(Encoding.UTF8.GetBytes(plaintext));
            BigInteger ciphertext = rsa.Encrypt(plaintextNum);

            txtRSACiphertext.Text = ciphertext.ToString();
        }

        private void btnRSADecrypt_Click(object sender, EventArgs e)
        {
            BigInteger ciphertext = BigInteger.Parse(txtRSACiphertext.Text);
            BigInteger plaintextNum = rsa.Decrypt(ciphertext);
            string plaintext = Encoding.UTF8.GetString(plaintextNum.ToByteArray());

            txtRSAPlaintext.Text = plaintext;
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

            // Tính phi(n) = (p-1)*(q-1)
            BigInteger phi = (p - 1) * (q - 1);

            // Chọn e sao cho gcd(e, phi) = 1
            e = 65537; // Giá trị phổ biến cho e
            while (BigInteger.GreatestCommonDivisor(e, phi) != 1)
            {
                e++;
            }

            // Tính d sao cho (d * e) % phi = 1
            d = ModInverse(e, phi);
        }

        public (BigInteger, BigInteger) GetPublicKey() => (e, n);

        public BigInteger Encrypt(BigInteger plaintext)
        {
            return BigInteger.ModPow(plaintext, e, n);
        }

        public BigInteger Decrypt(BigInteger ciphertext)
        {
            return BigInteger.ModPow(ciphertext, d, n);
        }

        private BigInteger GeneratePrime(int bitLength)
        {
            BigInteger prime;
            do
            {
                prime = GenerateRandomBigInteger(bitLength);
            } while (!IsProbablyPrime(prime, 10));
            return prime;
        }

        private static BigInteger GenerateRandomBigInteger(int bitLength)
        {
            if (bitLength <= 0)
                throw new ArgumentException("Bit length must be a positive number.");

            int byteLength = (bitLength + 7) / 8; // Số byte cần thiết
            byte[] randomBytes = new byte[byteLength];

            Random random = new Random();
            random.NextBytes(randomBytes);

            // Đảm bảo số là không dấu
            return CreateUnsignedBigInteger(randomBytes);
        }

        private static BigInteger CreateUnsignedBigInteger(byte[] bytes)
        {
            // Nếu byte đầu tiên có bit cao nhất là 1, thêm byte 0x00 ở đầu
            if ((bytes[0] & 0x80) != 0)
            {
                byte[] temp = new byte[bytes.Length + 1];
                Array.Copy(bytes, 0, temp, 1, bytes.Length);
                bytes = temp;
            }
            return new BigInteger(bytes);
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

        private static BigInteger RandomIntegerBelow(BigInteger max)
        {
            byte[] bytes = max.ToByteArray();
            BigInteger result;
            Random random = new Random();

            do
            {
                random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= 0x7F; // Đảm bảo số dương
                result = new BigInteger(bytes);
            } while (result >= max);

            return result;
        }
    }
}
