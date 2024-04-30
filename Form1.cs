using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace bitSlice
{
    public partial class Form1 : Form
    {
        Bitmap p1, p2;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                p1 = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = p1;
                p2 = new Bitmap(p1.Width, p1.Height);
                Srez();
                pictureBox2.Image = p2;
                p2.Save("srez.bmp");
                Process.Start("mspaint.exe", "srez.bmp");
            }
        }
        void Srez()
        {
            for (int i =0; i <p1.Height; i++)
                for (int j = 0; j < p1.Width; j++)
                {
                    Color col1 = p1.GetPixel(j, i);
                    byte r2, b2, g2;
                    r2 = GetBit0(col1.R);
                    b2 = GetBit0(col1.B);
                    g2 = GetBit0(col1.G);
                    Color col2 = Color.FromArgb(r2, g2, b2);
                    p2.SetPixel(j, i, col2);
                }
        }
        byte GetBit0(byte b)
        {
            int a = b & 1;
            if (a == 0)
                return 0;
            else
                return 255;
        }

    }
}
