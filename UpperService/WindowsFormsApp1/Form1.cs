using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly ServiceReference1.UpperServiceClient client = new ServiceReference1.UpperServiceClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            textBox4.Enabled = false;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string str = textBox1.Text;
                string result = client.Upper(str);
                textBox2.Text = result;
            }

            if (radioButton2.Checked)
            {
                string str = textBox1.Text;
                string result = client.Lower(str);
                textBox2.Text = result;
            }

            if (radioButton3.Checked)
            {
                string str = textBox1.Text;
                string result = client.FirstLetterOfSentenceToUpper(str);
                textBox2.Text = result;
            }

            if (radioButton4.Checked)
            {
                string str = textBox1.Text;
                string before = textBox3.Text;
                string after = textBox4.Text;
                string result = client.Refactor(str, before, after);
                textBox2.Text = result;
            }

            if (radioButton5.Checked)
            {
                string str = textBox1.Text;
                string result = client.SpaceAfterPunctuationMark(str);
                textBox2.Text = result;
            }

            if (radioButton6.Checked)
            {
                string str = textBox1.Text;
                string result = client.CountOfSymbols(str);
                textBox2.Text = result;
            }

            if (radioButton7.Checked)
            {
                string str = textBox1.Text;
                string word = textBox3.Text;
                string result = client.Remove(str, word);
                textBox2.Text = result;
            }

            if (radioButton8.Checked)
            {
                string str = textBox1.Text;
                string result = client.Capitalize(str);
                textBox2.Text = result;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
