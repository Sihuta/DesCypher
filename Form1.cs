using BPDT_lab1.DES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPDT_lab1
{
    public partial class Form1 : Form
    {
        private const int Encrypt = 0;
        private const int Decrypt = 1;

        private int _operation = Encrypt;
        private bool _hexKey = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void hexKeycheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _hexKey = hexKeycheckBox.Checked;
        }

        private void encryptRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _operation = encryptRadioButton.Checked ? Encrypt : Decrypt;
        }

        private void decryptRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _operation = decryptRadioButton.Checked ? Decrypt : Encrypt;
        }

        private void execButton_Click(object sender, EventArgs e)
        {
            string key = keyTextBox.Text.Trim();
            string inputText = inputTextBox.Text.Trim();

            if (_hexKey)
            {
                key = Converter.HexStrToNormal(key);
            }

            var desCipher = new DesCipher();
            string outputText;

            try
            {
                outputText = desCipher.Cipher(inputText, key, _operation == Encrypt);
            }
            catch (WeakKeyException ex)
            {
                MessageBox.Show(ex.Message, $"{typeof(WeakKeyException)}");
                return;
            }

            outputTextBox.Text = outputText;
            entropyTextBox.Text = GetEntropyOutput(desCipher.RoundsEntropy);
        }

        private string GetEntropyOutput(double[] arr)
        {
            var res = new StringBuilder();
            for (int i = 0; i < arr.Length; ++i)
            {
                res.Append($"{i + 1}. {arr[i]}\r\n");
            }
            return res.ToString();
        }
    }
}
