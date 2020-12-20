
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
        Pen penNoDraw;
        bool MD = false;
        IFactory factory;
        SolidBrush brush2;
        AFigure currentFigure;
        string name = "";
        int quantity = 0;
        int quantity2 = 0;
        List<AFigure> Figures;
        string mode;
        public Form1()
        {
            InitializeComponent();
            factory = new LineFactory();
            currentFigure = factory.CreateFigure();
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            MD = true;
            switch (mode)
            {
                case "Draw":
               
                    currentFigure.UpN(quantity);
                    currentFigure.UpdateBegin(e.Location);
                    currentFigure.MousDown();
                    currentFigure.color = pen.Color;
                    currentFigure.width = (int)pen.Width;
                    break;
                case "Move":
                    currentFigure = null;
                    foreach (AFigure figure in Figures)
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

                case "Fill":
                    foreach (AFigure figure in Figures)
                    {
                        if (figure.IsItYou(e.Location))
                        {
                            currentFigure = figure;
                            Figures.Remove(currentFigure);
                            currentFigure.FillPolygon(grafics, brush2);

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
            currentFigure.DrawEndLine(grafics, pen);
            Figures.Add(currentFigure);

            pictureBox1.Image = tmpBm;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (MD)
            {
                
                tmpBm = (Bitmap)mainBm.Clone();
                grafics = Graphics.FromImage(tmpBm);
                switch (mode)
                {
                    case "Draw":
                            currentFigure.Update(currentFigure.GetPrevPoint(), e.Location);
                        if (name == "Кисть")
                        {
                            grafics = Graphics.FromImage(mainBm);
                        }
                            currentFigure.SetEndPoint(e.Location);
                        break;
                    case "Move":
                        Point delta = new Point(e.X - currentFigure.prevPoint.X, e.Y - currentFigure.prevPoint.Y);
                        currentFigure.Move(delta);
                        currentFigure.SetPrevPoint(e.Location);
                        break;


                }
                currentFigure.Draw(grafics, pen);
                if (name == "Кисть")
                {
                    currentFigure.SetPrevPoint(e.Location);
                }
                pictureBox1.Image = tmpBm;
                GC.Collect();
            }
            else
            {
                currentFigure.SetPrevPoint(e.Location);
            }

    }
        private void DrawAll()
        {
            mainBm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grafics = Graphics.FromImage(mainBm);
            foreach (AFigure figure in Figures)
            {
                pen.Color = figure.color;
                pen.Width = figure.width;
                figure.Draw(grafics, pen);

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            factory = new RectangleFigureFactory();
            currentFigure = factory.CreateFigure();
            mode = "Draw";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainBm = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            pen = new Pen(colorDialog1.Color, (int)numericUpDown3.Value);
            brush2 = new SolidBrush(colorDialog1.Color);

            currentFigure?.SetPrevPoint(new Point(0, 0));
            MD = false;
            Figures = new List<AFigure>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = "Линия";
            factory = new LineFactory();
            quantity = 0;
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            name = "Квадрат";
            factory = new SquareFactory();
            quantity = 0;
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            name = "Круг";
            factory = new CircleFactory();
            quantity = 0;
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            name = "Эллипс";
            factory = new EllipseFactory();
            quantity = 0;
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            name = "Равнобедренный треугольник";
            factory = new TriangleFactory();
            quantity = 0;
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            name = "Прямоугольный треугольник";
            factory = new PTriangleFactory();
            quantity = 0;
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            name = "Кисть";
            factory = new PenFactory();
            quantity = 0;
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            name = "Ломанная линия";
            factory = new BrokenLinesFactory();

            currentFigure = factory.CreateFigure();
             quantity = (int)numericUpDown1.Value;
            currentFigure.UpN(quantity);
            mode = "Draw";

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            quantity = (int)numericUpDown2.Value;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            name = "Треугольник по трем точкам";

            factory = new FreeTriangleFactory();
            currentFigure = factory.CreateFigure();
            quantity = (int)numericUpDown1.Value;
            currentFigure.UpN(quantity);
            mode = "Draw";
        }

        private void button11_Click(object sender, EventArgs e)
            
        {
            name = "Многоугольник";
            factory = new FreePolygonFactory();
            currentFigure = factory.CreateFigure();
            quantity2 = (int)numericUpDown1.Value;
           
            currentFigure.UpN(quantity);
            mode = "Draw";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            quantity2 = (int)numericUpDown1.Value;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                pen.Color = MyDialog.Color;
                brush2.Color = MyDialog.Color;
            }

        }


        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = (int)numericUpDown3.Value;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            mainBm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Figures = new List<AFigure>();
            pictureBox1.Image = mainBm;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            mode = "Move";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            name = "Правильный Многоугольник";
            factory = new NRegularPolygonFactory();
            quantity = (int)numericUpDown1.Value;
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            quantity = (int)numericUpDown1.Value;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить картинку как...";
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;

                sfd.Filter = "Image Files(*.BMP)|*.BMP | Image Files(*.JPG)|*.JPG|Image Files(*.PNG)|*.PNG|All file(*.*)|*.*";
                sfd.ShowHelp = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image.Save(sfd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void button17_Click(object sender, EventArgs e) 
        {
            mode = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            mode = "Fill";
        }
    }
}