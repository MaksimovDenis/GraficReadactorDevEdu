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
        int quantity=0;
        Point endPoint;
        int tmp=0;
        int crnt = 0;
        int n;//количество сторон
        int R;//расстояние от центра до стороны
        Point Cntr;//центр
        Point[] p; //массив точек будущего многоугольника
        public Form1()
        {
            InitializeComponent();
        }
                    

       
        private void LineAngle(double angle)
        {
            double z = 0; int i = 0;
            while (i < n + 1)
            {

                p[i].X = Cntr.X + (int)(Math.Round(Math.Cos(z / 180 * Math.PI) * R));
                p[i].Y = Cntr.Y - (int)(Math.Round(Math.Sin(z / 180 * Math.PI) * R));
                z = z + angle;
                i++;
            }
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            MD = true;
            
            if (name == "Ломанная линия" && tmp < quantity && tmp != 0)
            {
                prevPoint = endPoint;
                
            }
            
            if (tmp >= quantity-1)
            {
                crnt = 0;
                tmp = 0;
            }
            else
            {
                crnt++;
                tmp++;
            }
            

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MD = false;
            mainBm = tmpBm;
           
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

                if (name == "Правильный многоугольник")
                {
                    grafics.DrawLine(pen, currentFigure.GetPoints(prevPoint, e.Location)[0], currentFigure.GetPoints(prevPoint, e.Location)[1]);

                    endPoint = currentFigure.GetPoints(prevPoint, e.Location)[1];
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
            tmp = 0; 
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            quantity = (int)numericUpDown2.Value;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            name = "Правильный многоугольник";
            currentFigure = new RegularPolygon();
            tmp = 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {        
             label10.Text = "";
             //получаем входные данные и проверяем их на корректность
             n = Convert.ToInt32(textBox4.Text);
             R = Convert.ToInt32(textBox5.Text);
             Cntr.X = Convert.ToInt32(textBox6.Text);
             Cntr.Y = Convert.ToInt32(textBox7.Text);
             if (n < 0 || R < 0)
                 label10.Text = "Неверные входные данные!";
             else //входные данные корректны, рисуем многоуголник
             {
                 p = new Point[n + 1];
                 LineAngle((double)(360.0 / (double)n));
                 int i = n;
                 Graphics g = pictureBox1.CreateGraphics();
                 while (i > 0)
                 {
                     g.DrawLine(new Pen(Color.Black, 2), p[i], p[i - 1]);
                     i = i - 1;
                 }
             }
        }


         //оставляем нарисованный многоугольник, обнуляем входные значения для нового ввода
         private void button13_Click_1(object sender, EventArgs e)
         {
             textBox4.Text = "0";
             textBox5.Text = "0";
             textBox6.Text = "0";
             textBox7.Text = "0";
             label10.Text = "";

         }
         //стираем всё нарисованное, не обнуляя последние входные данные
         private void button12_Click(object sender, EventArgs e)
         {
             pictureBox1.Image = null;
             label10.Text = "";
         }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }


