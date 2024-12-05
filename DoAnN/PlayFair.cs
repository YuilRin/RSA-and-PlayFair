using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace DoAnN
{
    public partial class PlayFair : Form
    {
        public PlayFair()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string plaintext = txtPlaintext.Text;

            PlayfairCipher cipher = new PlayfairCipher(key);
            string ciphertext = cipher.Encrypt(plaintext);

            txtCiphertext.Text = ciphertext;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string plaintext = txtPlaintext.Text;

            PlayfairCipher cipher = new PlayfairCipher(key);
            string ciphertext = cipher.Decrypt(plaintext);

            txtCiphertext.Text = ciphertext;
        }
    }
    public class PlayfairCipher
    {
        private char[,] keyMatrix;

        public PlayfairCipher(string key)
        {
            keyMatrix = GenerateKeyMatrix(key);
        }

        private char[,] GenerateKeyMatrix(string key)
        {
            key = key.ToUpper().Replace("J", "I");
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            HashSet<char> used = new HashSet<char>();
            StringBuilder matrixKey = new StringBuilder();

            foreach (char c in key)
            {
                if (!used.Contains(c) && alphabet.Contains(c))
                {
                    matrixKey.Append(c);
                    used.Add(c);
                }
            }

            foreach (char c in alphabet)
            {
                if (!used.Contains(c))
                {
                    matrixKey.Append(c);
                    used.Add(c);
                }
            }

            char[,] matrix = new char[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = matrixKey[i * 5 + j];
                }
            }

            return matrix;
        }
        public string Decrypt(string text)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i += 2)
            {
                char a = text[i];
                char b = text[i + 1];
                (int row1, int col1) = FindPosition(a);
                (int row2, int col2) = FindPosition(b);

                if (row1 == row2) // Same row
                {
                    result.Append(keyMatrix[row1, (col1 + 4) % 5]);
                    result.Append(keyMatrix[row2, (col2 + 4) % 5]);
                }
                else if (col1 == col2) // Same column
                {
                    result.Append(keyMatrix[(row1 + 4) % 5, col1]);
                    result.Append(keyMatrix[(row2 + 4) % 5, col2]);
                }
                else // Rectangle rule
                {
                    result.Append(keyMatrix[row1, col2]);
                    result.Append(keyMatrix[row2, col1]);
                }
            }

            return result.ToString();
        }


        public string Encrypt(string text)
        {
            text = PrepareText(text.ToUpper().Replace("J", "I"));
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i += 2)
            {
                char a = text[i];
                char b = text[i + 1];
                (int row1, int col1) = FindPosition(a);
                (int row2, int col2) = FindPosition(b);

                if (row1 == row2) // Same row
                {
                    result.Append(keyMatrix[row1, (col1 + 1) % 5]);
                    result.Append(keyMatrix[row2, (col2 + 1) % 5]);
                }
                else if (col1 == col2) // Same column
                {
                    result.Append(keyMatrix[(row1 + 1) % 5, col1]);
                    result.Append(keyMatrix[(row2 + 1) % 5, col2]);
                }
                else // Rectangle rule
                {
                    result.Append(keyMatrix[row1, col2]);
                    result.Append(keyMatrix[row2, col1]);
                }
            }

            return result.ToString();
        }

        private string PrepareText(string text)
        {
            StringBuilder prepared = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                prepared.Append(text[i]);
                if (i + 1 < text.Length && text[i] == text[i + 1])
                {
                    prepared.Append('X');
                }
            }
            if (prepared.Length % 2 != 0)
            {
                prepared.Append('X');
            }
            return prepared.ToString();
        }

        private (int, int) FindPosition(char c)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (keyMatrix[i, j] == c)
                    {
                        return (i, j);
                    }
                }
            }
            throw new ArgumentException($"Character {c} not found in key matrix.");
        }
    }

}
