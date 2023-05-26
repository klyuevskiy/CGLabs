using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private readonly Image img = Properties.Resources.Image;
        private Bitmap imgBitmap;

        public Form1()
        {
            InitializeComponent();
            imgBitmap = new Bitmap(img);
            pictureBox1.Image = imgBitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private byte ToByte(int value)
        {
            if (value > 255)
                return 255;
            if (value < 0)
                return 0;
            return (byte)value;
        }

        private void changeBrightButton_Click(object sender, EventArgs e)
        {
            int change = BrightTrackBar.Value;

            int r, g, b;

            for (int i = 0; i < imgBitmap.Width; i++)
            {
                for (int j = 0; j < imgBitmap.Height; j++)
                {
                    Color color = imgBitmap.GetPixel(i, j);
                    r = ToByte(color.R + change);
                    g = ToByte(color.G + change);
                    b = ToByte(color.B + change);
                    Color newColor = Color.FromArgb(r, g, b);
                    imgBitmap.SetPixel(i, j, newColor);
                }
            }
            pictureBox1.Image = imgBitmap;
        }

        private byte ContrastByte(byte b, double contrast)
        {
            double pixel = (double)b / 255.0;
            pixel -= 0.5;
            pixel *= contrast;
            pixel += 0.5;
            pixel *= 255;
            return ToByte((int)pixel);
        }

        private void changeContButton_Click(object sender, EventArgs e)
        {
            double contrast = (100.0 + contrastTrackBar.Value) / 100.0;
            contrast *= contrast;

            int change = BrightTrackBar.Value;

            int r, g, b;

            for (int i = 0; i < imgBitmap.Width; i++)
            {
                for (int j = 0; j < imgBitmap.Height; j++)
                {
                    Color color = imgBitmap.GetPixel(i, j);
                    r = ContrastByte(color.R, contrast);
                    g = ContrastByte(color.G, contrast);
                    b = ContrastByte(color.B, contrast);
                    Color newColor = Color.FromArgb(r, g, b);
                    imgBitmap.SetPixel(i, j, newColor);
                }
            }
            pictureBox1.Image = imgBitmap;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void changeSatuButton_Click(object sender, EventArgs e)
        {
            double change = satuTrackBar.Value;
            change /= -100.0;

            double r, g, b;
            double gray;

            for (int i = 0; i < imgBitmap.Width; i++)
            {
                for (int j = 0; j < imgBitmap.Height; j++)
                {
                    Color color = imgBitmap.GetPixel(i, j);
                    r = color.R; g = color.G; b = color.B;
                    gray = 0.2989 * r + 0.5870 * g + 0.1140 * b;
                    r = gray * change + r * (1 - change);
                    g = gray * change + g * (1 - change);
                    b = gray * change + b * (1 - change);
                    Color newColor = Color.FromArgb(ToByte((int)r), ToByte((int)g), ToByte((int)b));
                    imgBitmap.SetPixel(i, j, newColor);
                }
            }
            pictureBox1.Image = imgBitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imgBitmap = new Bitmap(img);
            pictureBox1.Image = imgBitmap;
        }
    }
}
