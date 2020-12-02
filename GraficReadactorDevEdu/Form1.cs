using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu
{
    public partial class Form1 : Form
    {
        Bitmap mainBm;
        Bitmap tmpBm;
        Graphics grafics;
        Pen pen;
        bool MD = false;
        Point prevPoint;
        IFigure currentFigure;


        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            MD = true;
            prevPoint = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MD)
            {

                tmpBm = (Bitmap)mainBm.Clone();
                grafics = Graphics.FromImage(tmpBm);
                grafics.DrawPolygon(pen, currentFigure.GetPoints(prevPoint, e.Location));
                pictureBox1.Image = tmpBm;
                GC.Collect();

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MD = false;
            mainBm = tmpBm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentFigure = new RectangleFigure();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainBm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pen = new Pen(Color.Black, 1);
            prevPoint = new Point(0, 0);
            MD = false;
        }
    }
}
