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
using GraficReadactorDevEdu.Factor;

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
        List<IFigure> Figures;
        IFactory factory;
        string mode;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            MD = true;
            switch (mode)
            {
                case "Draw": currentFigure = factory.CreateFigure();
                    if (name == "Ломанная линия")
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
                        if (tmp < quantity2 - 1 && tmp != 0)
                        {
                            prevPoint = endPoint;

                        }

                        if (tmp == quantity2 - 2)
                        {

                            tmp = 0;
                        }
                        else
                        {

                            tmp++;
                        }
                    }

                    currentFigure.color = pen.Color;
                    currentFigure.width = (int)pen.Width;
                    break;
                case "Move":
                    currentFigure = null;
                    foreach (IFigure figure in Figures)
                    {
                        if (figure.IsItYou(e.Location))
                        {
                            currentFigure = figure;
                            Figures.Remove(currentFigure);
                            DrawAll();
                            pen.Color = figure.color;
                            pen.Width = figure.width;
                            break;
                        }
                    }
               break;
          
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

            if (currentFigure!=null)
            {
                Figures.Add(currentFigure);
            }
            else
            {
                return;
            }
            pictureBox1.Image = tmpBm;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MD && currentFigure != null)
            {
                tmpBm = (Bitmap)mainBm.Clone();
                grafics = Graphics.FromImage(tmpBm);
                switch (mode)
                {
                    case "Draw":




                        //if (name == "Кисть")
                        //{

                        //    grafics = Graphics.FromImage(mainBm);
                        //    grafics.DrawLine(pen, prevPoint, e.Location);
                        //    prevPoint = e.Location;

                        //}
                        //else
                        //{
                           

                            currentFigure.Update(prevPoint, e.Location);

                            endPoint = e.Location;//нужно для ломанных линий
                        //}


                        break;
                    case "Move":
                        Point delta = new Point(e.X - prevPoint.X, e.Y - prevPoint.Y);
                        currentFigure.Move(delta);
                        prevPoint = e.Location;
                        break;

                }
                            currentFigure.Draw(grafics, pen, currentFigure.Points.ToArray());
                        pictureBox1.Image = tmpBm;
                        GC.Collect();
            }
            else
            {
                prevPoint = e.Location;
            }

        }
        private void DrawAll()
        {
            mainBm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grafics = Graphics.FromImage(mainBm);
            foreach(IFigure figure in Figures)
            {
                pen.Color = figure.color;
                pen.Width = figure.width;
                figure.Draw(grafics, pen, figure.Points.ToArray());
                //figure.DrawPolygon( pen, figure.Points.ToArray());
            }
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            factory = new RectangleFigureFactory();
            mode = "Draw";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainBm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
            pen = new Pen(colorDialog1.Color, (int)numericUpDown3.Value);
            prevPoint = new Point(0, 0);
            MD = false;
            Figures = new List<IFigure>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = "Линия";
            factory = new LineFactory();
          
            mode = "Draw";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            name = "Квадрат";
            factory = new SquareFactory();
           
            mode = "Draw";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            name = "Круг";
            factory = new CircleFactory();
          
            mode = "Draw";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            name = "Эллипс";
            factory = new EllipseFactory();
            
            mode = "Draw";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            name = "Равнобедренный треугольник";
            factory = new TriangleFactory();
          
            mode = "Draw";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            name = "Прямоугольный треугольник";
            factory = new PTriangleFactory();
       
            mode = "Draw";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            name = "Кисть";
         
            mode = "Draw";
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            name = "Ломанная линия";
            factory = new BrokenLinesFactory();
            tmp = 0;
            mode = "Draw";

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            quantity = (int)numericUpDown2.Value;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            name = "Треугольник по трем точкам";

            factory = new BrokenLinesFactory();
            tmp = 0;
            mode = "Draw";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            name = "Многоугольник";
            factory = new BrokenLinesFactory();
            quantity2 = (int)numericUpDown1.Value;
            tmp = 0;
            mode = "Draw";
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

        private void button13_Click(object sender, EventArgs e)
        {
            mainBm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = mainBm;
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            mode = "Move";
        }
    }
}
