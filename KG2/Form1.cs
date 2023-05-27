using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KG2
{
     
    public partial class FormMain : Form
    {
        private Color brush = Color.Blue;

        public FormMain()
        {
            InitializeComponent();
        }

        private void bPaint_Click(object sender, EventArgs e)
        {
            Scene s = new Scene(pictureBoxView.Height, pictureBoxView.Width);
            s.Brush = brush;
            s.AddCylinder(Double.Parse(radiusTextBox.Text), Double.Parse(heightTextBox.Text));
            s.AddCamera(new Camera(new Point3D(textBoxCamPos.Text), new Point3D(textBoxCamDir.Text).Minus(new Point3D(textBoxCamPos.Text)), (double)udAngle.Value));
            s.LightDirt1 = new Point3D(light1TextBox.Text);
            s.LightDir2 = new Point3D(light2TextBox.Text);
            s.Render();
            pictureBoxView.Image = s.Pic;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            brush = colorDialog.Color;
            bPaint_Click(sender, e);
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            bPaint_Click(sender, e);
        }

        private void pictureBoxView_MouseMove(object sender, MouseEventArgs e)
        {
           /* if (DateTime.Today.Millisecond % 100 == 0)
            {
                textBoxCamPos.Text = (11 * Math.Cos(e.X * 2 * pi / pictureBoxView.Width)).ToString("0.##") + " " + (11 * Math.Sin(e.X * 2 * pi / pictureBoxView.Height)).ToString("0.##") + " 3";
                bPaint_Click(sender, e);
            }*/
        }
    }
}
