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
        string name = "";
        int tmp = 0;
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
                if (name == "Прямоугольник")
                {
                    grafics.DrawPolygon(pen, currentFigure.GetPoints(prevPoint, e.Location));
                }
                if(name == "Круг")
                {
                    Point[] points=currentFigure.GetPoints(prevPoint, e.Location);
                    grafics.DrawEllipse(pen,points[0].X, points[0].Y, points[1].X - points[0].X, points[1].X- points[0].X);//Должно все меняться кроме центра
                }
                if (name == "Кисть")
                {

                    grafics = Graphics.FromImage(mainBm);
                    grafics.DrawLine(pen, prevPoint, e.Location);
                    prevPoint = e.Location;

                }
                if (name == "Эллипс")
                {
                    Point[] points = currentFigure.GetPoints(prevPoint, e.Location);
                    grafics.DrawEllipse(pen, points[0].X, points[0].Y, points[1].X - points[0].X, points[1].Y - points[0].Y);
                }
                if (name == "Квадрат")
                {
                    grafics.DrawPolygon(pen, currentFigure.GetPoints(prevPoint, e.Location));
                }
                
                if (name == "Линия")
                {
                    grafics.DrawLine(pen, prevPoint, e.Location);
                }
                if (name == "Ломанная линия")
                {
                    grafics.DrawLine(pen, prevPoint, e.Location);
                    prevPoint = e.Location;


                }
                if (name == "Равнобедренный треугольник")
                {
                    grafics.DrawPolygon(pen, currentFigure.GetPoints(prevPoint, e.Location));
                }
                if (name == "Прямоугольный треугольник")
                {
                    grafics.DrawPolygon(pen, currentFigure.GetPoints(prevPoint, e.Location));
                }
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
            name = "Прямоугольник";
            currentFigure = new RectangleFigure();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainBm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pen = new Pen(Color.Black, 1);
            prevPoint = new Point(0, 0);
            MD = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = "Линия";
            currentFigure = new Line();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            name = "Квадрат";
            currentFigure = new Square();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            name = "Круг";
            currentFigure = new Circle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            name = "Эллипс";
            currentFigure = new Circle();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            name = "Равнобедренный треугольник";
            currentFigure = new Triangle();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            name = "Прямоугольный треугольник";
            currentFigure = new PTriangle();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            name = "Кисть";
           
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            name = "Ломанная линия";
            currentFigure = new Line();
        }

       

    }
}
