
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
        IFactory factory;
        SolidBrush brush2;
        AFigure currentFigure;
        string name = "";
        int quantity = 0;
        int quantity2 = 0;
        List<AFigure> Figures;
        string mode;
        int text;
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
                case "Veer":
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
                
                    currentFigure.Veer(text);
                    break;
                   

            }

        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MD = false;
            mainBm = tmpBm;
            currentFigure?.DrawEndLine(grafics, pen);
            Figures.Add(currentFigure);

            pictureBox1.Image = tmpBm;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (MD)
            {
                if (currentFigure != null)
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
            name = "Прямоугольник";
            factory = new RectangleFigureFactory();
            button19.Height = button1.Height;
            button19.Top = button1.Top;
            button1.BackColor = Color.FromArgb(62, 120, 138);
            currentFigure = factory.CreateFigure();
            quantity = 0;
            currentFigure.UpN(0);
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
            button19.Height = button2.Height;
            button19.Top = button2.Top;
            factory = new LineFactory();
            quantity = 0;
            currentFigure.UpN(0);
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            name = "Квадрат";
            button19.Height = button3.Height;
            button19.Top = button3.Top;
            factory = new SquareFactory();
            quantity = 0;
            currentFigure.UpN(0);
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            name = "Круг";
            button19.Height = button4.Height;
            button19.Top = button4.Top;
            factory = new CircleFactory();
            quantity = 0;
            currentFigure.UpN(0);
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            name = "Эллипс";
            button19.Height = button8.Height;
            button19.Top = button8.Top;
            factory = new EllipseFactory();
            quantity = 0;
            currentFigure.UpN(0);
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            name = "Равнобедренный треугольник";
            button19.Height = button6.Height;
            button19.Top = button6.Top;
            factory = new TriangleFactory();
            quantity = 0;
            currentFigure.UpN(0);
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            name = "Прямоугольный треугольник";
            button19.Height = button7.Height;
            button19.Top = button7.Top;
            factory = new PTriangleFactory();
            currentFigure.UpN(0);
            quantity = 0;
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            name = "Кисть";
            button19.Height = button9.Height;
            button19.Top = button9.Top;
            factory = new PenFactory();
            quantity = 0;
            currentFigure.UpN(0);
            currentFigure = factory.CreateFigure();
            mode = "Draw";
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            name = "Ломанная линия";
            factory = new BrokenLinesFactory();
            button19.Height = button5.Height;
            button19.Top = button5.Top;
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
            button19.Height = button10.Height;
            button19.Top = button10.Top;

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
            button19.Height = button11.Height;
            button19.Top = button11.Top;
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
            currentFigure.UpN(0);
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

        private void button17_Click_1(object sender, EventArgs e)
        {
            mode = "Veer";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          text = Convert.ToInt32(textBox1.Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            button20.BackColor = Color.Red;
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}