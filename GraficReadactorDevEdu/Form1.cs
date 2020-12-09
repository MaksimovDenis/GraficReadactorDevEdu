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
        int quantity = 0;
        Point endPoint;
        int tmp = 0;
        Point begin;
        int quantity2 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            MD = true;

            if (name == "Ломанная линия" && tmp < quantity && tmp != 0)
            {
                if (tmp < quantity && tmp != 0)
                {
                    prevPoint = endPoint;

                }

                if (tmp == quantity - 1)
                {

                    tmp = 0;
                }
                else
                {

                    tmp++;
                }
            }

            if (name == "Треугольник по трем точкам")
            {

                if (tmp == 0)
                {
                    begin = e.Location;
                }
                if (tmp < 2 && tmp != 0)
                {
                    prevPoint = endPoint;

                }


                if (tmp == 1)
                {

                    tmp = 0;
                }
                else
                {

                    tmp++;
                }
            }

            if (name == "Многоугольник")
            {
                if (tmp == 0)
                {
                    begin = e.Location;
                }
                if (tmp < quantity2 && tmp != 0)
                {
                    prevPoint = endPoint;

                }

                if (tmp == quantity2 - 1)
                {

                    tmp = 0;
                }
                else
                {

                    tmp++;
                }
            }
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MD = false;
            mainBm = tmpBm;
            if (name == "Треугольник по трем точкам" || (name == "Многоугольник" && tmp == 0))
            {
                grafics.DrawLine(pen, begin, e.Location);//

            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (MD)
            {
                tmpBm = (Bitmap)mainBm.Clone();
                grafics = Graphics.FromImage(tmpBm);
                if (name == "Ломанная линия")
                {
                    
                    grafics.DrawLine(pen, currentFigure.GetPoints(prevPoint, e.Location)[0], currentFigure.GetPoints(prevPoint, e.Location)[1]);
                    
                    endPoint = currentFigure.GetPoints(prevPoint, e.Location)[1];
                }

                if (name == "Треугольник по трем точкам")
                {

                    grafics.DrawLine(pen, currentFigure.GetPoints(prevPoint, e.Location)[0], currentFigure.GetPoints(prevPoint, e.Location)[1]);

                    endPoint = currentFigure.GetPoints(prevPoint, e.Location)[1];
                }

                if (name == "Многоугольник")
                {

                    grafics.DrawLine(pen, currentFigure.GetPoints(prevPoint, e.Location)[0], currentFigure.GetPoints(prevPoint, e.Location)[1]);

                    endPoint = currentFigure.GetPoints(prevPoint, e.Location)[1];
                }

                if (name == "Линия")
                {
                    grafics.DrawLine(pen, currentFigure.GetPoints(prevPoint, e.Location)[0], currentFigure.GetPoints(prevPoint, e.Location)[1]);
                    
                }
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
            else
            {
                prevPoint = e.Location;
            }
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            name = "Прямоугольник";
            currentFigure = new RectangleFigure();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainBm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
            pen = new Pen(colorDialog1.Color, (int)numericUpDown3.Value);
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
            tmp = 0; 
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            quantity = (int)numericUpDown2.Value;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            name = "Треугольник по трем точкам";

            currentFigure = new Line();
            tmp = 0;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            name = "Многоугольник";
            currentFigure = new Line();
            quantity2 = (int)numericUpDown1.Value;
            tmp = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            quantity2 = (int)numericUpDown1.Value;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();

            if (MyDialog.ShowDialog()==DialogResult.OK)
            {
                pen.Color = MyDialog.Color;
            }
            
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = (int)numericUpDown3.Value;
        }
    }
}
