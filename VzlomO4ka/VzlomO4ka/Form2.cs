using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace VzlomO4ka
{
    public partial class Form2 : Form
    {
        public Form2(bool pusk)
        {
            InitializeComponent();
            this.pusk = pusk;
        }
        bool pusk;

        public Form2(Form1 f1)
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        //This simulates a left mouse click

        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }
        public static void LeftMouseDoubleClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }
        public static void LeftMouseDrag(int xpos, int ypos, int toX, int toY)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            SetCursorPos(toX, toY);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        public static void ProcessKill(string Proc)
        {
            Process[] localByName = Process.GetProcessesByName(Proc);
            foreach (Process p in localByName)
            {
                try { p.Kill(); }
                catch { }
            }
        }
        public void CursorCenter(int LW, int TH)
        {
            Cursor.Position = new Point(this.Left + this.Width / 2 + LW, this.Top + this.Height / 2 + TH);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //pusk = false;
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.checkBox1, "Установите флажок тут что-бы программа автоматически закрывалась через 5 минут, если возникнет ошибка");
            ToolTip2.SetToolTip(this.comboBox1, "Установите желаемое значение пера, изначалоно оно равно 5");
        }

        int figure = 0;
        //int count = 0;
        int x = 0;
        int y = 0;
        int penSize = 1;
        bool penSize3 = true;
        bool penSize1 = false;
        //string TAB = "{TAB}";
        Random rnd = new Random();

        private void button5_Click(object sender, EventArgs e)
        {
            if (x == 0 || y == 0)
            {
                figure = 0;
            }
            else
            {
                /*MessageBox.Show("Пожалуйста НЕ взаймодействуйте с пк во время задачи (особенно с мышкой)",
                    "Пожалуста выполните действие",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                MessageBox.Show("Если программа не выполняет действий в течении 10с можете предпринимать действия по ее завершению",
                     "ВНИМАНИЕ",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information);*/
                button5.Enabled = false;
                Thread.Sleep(1000);
                //Cursor.Position = new Point(this.Left + this.Width / 2, this.Top + this.Height / 2);
                CursorCenter(0, 0);
                Process.Start("cmd");
                this.Hide();
                Thread.Sleep(1500);
                SendKeys.Send("mspaint");
                Thread.Sleep(500);
                SendKeys.Send("{ENTER}");
                Thread.Sleep(100);
                ProcessKill("cmd");
                Thread.Sleep(500);
                if (penSize3)
                {
                    SendKeys.Send("{TAB 17}");
                    Thread.Sleep(500);
                    SendKeys.Send("{ENTER}");
                    Thread.Sleep(500);
                    if (penSize1)
                    {
                        SendKeys.Send("{ENTER}");
                        Thread.Sleep(500);
                    }
                    else
                    {
                        for (int i = 0; i <= penSize; i++)
                        {
                            SendKeys.Send("{DOWN}");
                        }
                        Thread.Sleep(500);
                        SendKeys.Send("{ENTER}");
                        Thread.Sleep(500);
                        //Cursor.Position = new Point(this.Left + this.Width / 2, this.Top + this.Height / 2);
                        CursorCenter(0, 0);
                        SendKeys.Send("{TAB 5}");
                        Thread.Sleep(500);
                    }
                }
                /*int CursorX = Cursor.Position.X;
                int CursorY = Cursor.Position.Y;
                int CursorX = this.Left + this.Width / 2;
                int CursorY = this.Top + this.Height / 2;*/
                //Cursor.Position = new Point(this.Left + this.Width / 2, this.Top + this.Height / 2);
                CursorCenter(0, 0);
                Thread.Sleep(500);
            }

            switch (figure)
            {
                case 0:
                    MessageBox.Show("Пожалуйста выберите фигуру и введите ВСЕ значения",
                "Пожалуста выполните действие",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                    break;
                case 1:
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 450);
                    /*for (int i = 1; i <= (x + y) * 2; i++)
                    {
                        if (i <= x)
                        {
                            SendKeys.Send(" ");
                            Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y);
                        }
                        else if (i <= x + y)
                        {
                            SendKeys.Send(" ");
                            Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 1);
                        }
                        else if (i <= x * 2 + y)
                        {
                            SendKeys.Send(" ");
                            Cursor.Position = new Point(Cursor.Position.X - 1, Cursor.Position.Y);
                        }
                        else
                        {
                            SendKeys.Send(" ");
                            Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 1);
                        }
                    }*/
                    LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X + x, Cursor.Position.Y);
                    LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X, Cursor.Position.Y - y);
                    LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X - x, Cursor.Position.Y);
                    LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X, Cursor.Position.Y + y);
                    figure = 0;
                    x = 0;
                    y = 0;
                    label1.Visible = false;
                    textBox1.Visible = false;
                    label2.Visible = false;
                    textBox2.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    break;
                case 2:
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 250);
                    /*for (int i = 1; i <= x * 3; i++)
                    {
                        if (i <= x)
                        {
                            SendKeys.Send(" ");
                            Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y + 1);
                        }
                        else if (i <= x * 2)
                        {
                            SendKeys.Send(" ");
                            Cursor.Position = new Point(Cursor.Position.X - 2, Cursor.Position.Y);
                            SendKeys.Send(" ");
                        }
                        else if (i <= x * 3)
                        {
                            SendKeys.Send(" ");
                            Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y - 1);
                        }
                    }*/
                    LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X + x, Cursor.Position.Y + x);
                    LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X - x * 2, Cursor.Position.Y);
                    LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X + x, Cursor.Position.Y - x);
                    figure = 0;
                    x = 0;
                    label1.Visible = false;
                    textBox1.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    break;
                case 3:
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 90);
                    int CursorX = Cursor.Position.X;
                    int CursorY = Cursor.Position.Y;
                    LeftMouseClick(Cursor.Position.X, Cursor.Position.Y);
                    Cursor.Position = new Point(Cursor.Position.X + x, Cursor.Position.Y);
                    for (int i = 0; i <= y; i++)
                    {
                        //Thread.Sleep(200);
                        LeftMouseClick((int)((CursorX) + x * Math.Cos(i)), (int)((CursorY) + x * Math.Sin(i)));
                        //Cursor.Position = new Point((int)((this.Left + this.Width / 2) + x * Math.Cos(i)), (int)((this.Top + this.Height / 2) + x * Math.Sin(i)));
                        //SendKeys.Send(" ");
                    }
                    figure = 0;
                    x = 0;
                    y = 0;
                    label1.Visible = false;
                    textBox1.Visible = false;
                    label2.Visible = false;
                    textBox2.Visible = false;
                    label4.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    break;
                case 4:
                    /*
                    if (MouseButtons.Left)
                    {

                    }
                    if (e.Button == MouseButtons.Left)*/
                    CursorX = Cursor.Position.X;
                    CursorY = Cursor.Position.Y;
                    for (int i = 0; i <= y; i++)
                    {
                        LeftMouseDrag(CursorX, CursorY, CursorX + rnd.Next(-100, x), CursorY + rnd.Next(-100, x));
                    }
                    figure = 0;
                    x = 0;
                    y = 0;
                    label1.Visible = false;
                    textBox1.Visible = false;
                    label2.Visible = false;
                    textBox2.Visible = false;
                    label4.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    break;
                case 5:

                    break;

            }
            Thread.Sleep(5000);
            /*for (int i = 0; i <= x * 3; i++)
            {
                if (i <= x)
                {
                    SendKeys.Send(" ");
                    Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y + 1);
                }
                else if (i <= x * 2)
                {
                    SendKeys.Send(" ");
                    Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y);
                }
                else if (i <= x * 3)
                {
                    SendKeys.Send(" ");
                    Cursor.Position = new Point(Cursor.Position.X - 1, Cursor.Position.Y - 1);
                }
            }
            figure = 0;
            x = 0;
            label1.Visible = false;
            textBox1.Visible = false;*/
            this.Show();
            button5.Enabled = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
            label4.Visible = true;
            comboBox1.Visible = false;
            label4.Text = "X - длина Y - высота";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            CursorCenter(0, 0);
            SendKeys.Send("^{ESC}");
            Thread.Sleep(1000);
            SendKeys.Send("Paint 3D");
            Thread.Sleep(1000);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(2000);
            SendKeys.Send("{TAB 6}");
            Thread.Sleep(500);
            SendKeys.Send("{ENTER}");
            CursorCenter(0, 0);
            LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X + x, Cursor.Position.Y);
            LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X, Cursor.Position.Y - y);
            LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X - x, Cursor.Position.Y);
            LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X, Cursor.Position.Y + y);
            figure = 0;
            x = 0;
            y = 0;
            label1.Visible = false;
            textBox1.Visible = false;
            label2.Visible = false;
            textBox2.Visible = false;
            label4.Visible = false;
            comboBox1.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
        }
        //Form1 form1 = new Form1();
        private void button4_Click(object sender, EventArgs e)
        {
            /*form1.Show();
            this.Close();*/
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (pusk)
            {
                MessageBox.Show($"Это {pusk} если что",
                    $"{pusk}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*count++;
            SendKeys.Send(" ");
            Cursor.Position = new Point((this.Left + this.Width / 2) + count, this.Top + this.Height / 2);*/
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("НЕ рекомендуется вводить значения больше 730",
                "Если у вас монитор меньше или равер 1080р",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            figure = 1;
            label1.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
            label4.Visible = true;
            label4.Text = "X - длина Y - высота";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("НЕ рекомендуется вводить значения больше 650",
                "Если у вас монитор меньше или равер 1080р",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            figure = 2;
            y = 1;
            label1.Visible = true;
            textBox1.Visible = true;
            //label2.Visible = true;
            //textBox2.Visible = true;
            label2.Visible = false;
            textBox2.Visible = false;
            label4.Visible = true;
            label4.Text = "X - длина стороны";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("НЕ рекомендуется вводить значения радиуса больше 350",
                "Если у вас монитор меньше или равер 1080р",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            figure = 3;
            y = 0;
            label1.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
            label4.Visible = true;
            label4.Text = "X - радиус Y - колл точек на мм";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { x = int.Parse(textBox1.Text); }
            catch { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try { y = int.Parse(textBox2.Text); }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            figure = 4;
            x = 1;
            label1.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
            label4.Visible = true;
            label4.Text = "X - длина * 2 Y - колл лучей";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer2.Start();
        }

        void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Space)
            {
                MessageBox.Show("Это пробел если что",
                    "ага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: penSize1 = true; break;
                case 1: penSize3 = false; ; break;
                case 2: penSize = 1; break;
                case 3: penSize = 2; break;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
