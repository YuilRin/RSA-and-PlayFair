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
            cmbMatrixSize.SelectedIndex = 0;  
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string plaintext = txtPlaintext.Text;

            int matrixSize = cmbMatrixSize.SelectedItem.ToString() == "5x5" ? 5 : 6;
            PlayfairCipher cipher = new PlayfairCipher(key, matrixSize);
            string ciphertext = cipher.Encrypt(plaintext);

            txtCiphertext.Text = ciphertext;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string plaintext = tPlaintext2.Text;

            int matrixSize = cmbMatrixSize.SelectedItem.ToString() == "5x5" ? 5 : 6;
            PlayfairCipher cipher = new PlayfairCipher(key, matrixSize);
            string ciphertext = cipher.Decrypt(plaintext);

            txtDecrypt.Text = ciphertext;
        }


        private void btnMove_Click(object sender, EventArgs e)
        {        
            tabControl1.SelectedIndex = 1;
            tPlaintext2.Text=txtCiphertext.Text;
            txtDecrypt.Text="";
        }

        private void cmbMatrixSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCiphertext.Text=null;
            txtDecrypt.Text=null;   
        }

        private void txtPlaintext_TextChanged(object sender, EventArgs e)
        {
            txtCiphertext.Text=null;
        }

        private void tPlaintext2_TextChanged(object sender, EventArgs e)
        {
            txtDecrypt.Text=null;  
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
                    System.IO.File.WriteAllText(saveFileDialog.FileName, txtDecrypt.Text);
                    MessageBox.Show("Dữ liệu đã được xuất ra file.");
                }
            }
        }

        
    }
    public class PlayfairCipher
    {
        private char[,] keyMatrix;
        private int matrixSize;
        public PlayfairCipher(string key, int size)
        {
            matrixSize = size;
            keyMatrix = GenerateKeyMatrix(key);
        }

        private char[,] GenerateKeyMatrix(string key)
        {
            key = key.ToUpper();
            string alphabet = matrixSize == 5
                ? "ABCDEFGHIKLMNOPQRSTUVWXYZ"
                : "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

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

            char[,] matrix = new char[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = matrixKey[i * matrixSize + j];
                }
            }

            return matrix;
        }
        public string Encrypt(string text)
        {
            text = ValidateInput(text.ToUpper());
            text = PrepareText(text);

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i += 2)
            {
                char a = text[i];
                char b = text[i + 1];
                (int row1, int col1) = FindPosition(a);
                (int row2, int col2) = FindPosition(b);

                if (row1 == row2)
                {
                    result.Append(keyMatrix[row1, (col1 + 1) % matrixSize]);
                    result.Append(keyMatrix[row2, (col2 + 1) % matrixSize]);
                }
                else if (col1 == col2)
                {
                    result.Append(keyMatrix[(row1 + 1) % matrixSize, col1]);
                    result.Append(keyMatrix[(row2 + 1) % matrixSize, col2]);
                }
                else
                {
                    result.Append(keyMatrix[row1, col2]);
                    result.Append(keyMatrix[row2, col1]);
                }
            }

            return result.ToString();
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

                if (row1 == row2)
                {
                    result.Append(keyMatrix[row1, (col1 + matrixSize - 1) % matrixSize]);
                    result.Append(keyMatrix[row2, (col2 + matrixSize - 1) % matrixSize]);
                }
                else if (col1 == col2)
                {
                    result.Append(keyMatrix[(row1 + matrixSize - 1) % matrixSize, col1]);
                    result.Append(keyMatrix[(row2 + matrixSize - 1) % matrixSize, col2]);
                }
                else
                {
                    result.Append(keyMatrix[row1, col2]);
                    result.Append(keyMatrix[row2, col1]);
                }
            }
            for (int i = 1; i < result.Length - 1; i++)
            {
                if (result[i] == 'X' && result[i - 1] == result[i + 1])
                {
                    result.Remove(i, 1);
                    i--; // Lùi lại một bước để kiểm tra tiếp
                }
            }

            if (result.Length > 0 && result[result.Length - 1] == 'X')
            {
                result.Remove(result.Length - 1, 1);
            }

            return result.ToString();
        }
        private string ValidateInput(string input)
        {
            string validCharacters = matrixSize == 5
                ? "ABCDEFGHIKLMNOPQRSTUVWXYZ"
                : "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            StringBuilder validInput = new StringBuilder();
            foreach (char c in input)
            {
                if (validCharacters.Contains(c))
                {
                    validInput.Append(c);
                }
            }

            return validInput.ToString();
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
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
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
