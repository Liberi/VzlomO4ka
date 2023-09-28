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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace VzlomO4ka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

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

        private void button1_Click(object sender, EventArgs e)
        {
            /*SendKeys.Send("^{ESC}");
            Thread.Sleep(500);
            SendKeys.Send("cmd");
            Thread.Sleep(1500);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(1000);*/
            Process.Start("cmd");
            Thread.Sleep(1000);
            SendKeys.Send("{F11}");
            Thread.Sleep(1000);
            SendKeys.Send("color 02");
            Thread.Sleep(500);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(500);
            SendKeys.Send(@"cd \");
            Thread.Sleep(500);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(500);
            SendKeys.Send("dir/s");
            Thread.Sleep(1000);
            SendKeys.Send("{ENTER}");
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("{F11}");
            Thread.Sleep(1000);
            SendKeys.Send("%{F4}");
            Thread.Sleep(1000);
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*SendKeys.Send("{%}");
            SendKeys.Send("{^}");
            SendKeys.Send("^{ESC}");
            Thread.Sleep(1000);
            SendKeys.Send("Microsoft Edge");
            Thread.Sleep(1000);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(3000);
            SendKeys.Send("^{T}");
            Thread.Sleep(2000);
            SendKeys.Send("{F4}");
            Thread.Sleep(500);
            SendKeys.Send("https://playcaliber.com");
            Thread.Sleep(1000);
            SendKeys.Send("{ENTER}");*/
            bool BrFt = true;
            string[] browser = { "msedge", "chrome", "firefox", "vivaldi", "yandex", "opera" };

            foreach (string b in browser)
            {
                try { Process.Start(b); }
                catch { }
                Thread.Sleep(1000);
                if (Process.GetProcessesByName(b).Length > 0)
                {
                    ProcessKill(b);
                    DialogResult res = MessageBox.Show($"Вашь используемый браузер {b}?",
                     "Пожалуста выполните действие",
                        MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        Process.Start(b, "https://playcaliber.com");
                        BrFt = false;
                        break;
                    }
                    else if (res == DialogResult.No)
                    {
                        continue;
                    }
                }

            }
            if (BrFt)
            {
                MessageBox.Show("Не найден подходящий браузер, запуск стандартного ...",
                 "ОШИБКА",
                    MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                Process.Start("https://playcaliber.com");
            }
            Thread.Sleep(5000);
            CursorCenter(0, 0);
            LeftMouseClick(Cursor.Position.X, Cursor.Position.Y + 130);

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            /*SendKeys.Send("^{ESC}");
            Thread.Sleep(1000);
            SendKeys.Send("cmd");
            Thread.Sleep(1500);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(2000);*/
            Process.Start("cmd.exe");
            Thread.Sleep(1000);
            SendKeys.Send("{F11}");
            Thread.Sleep(500);
            SendKeys.Send("color 04");
            Thread.Sleep(500);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(500);
            SendKeys.Send("ХОЧЕШЬ Я ПОКАЖУ ТЕБЕ ПРИКОЛ?");
            Thread.Sleep(1000);
            SendKeys.Send("{ENTER}");
            SendKeys.Send("Я ЗНАЮ, ТЫ ХОЧЕШЬ");
            Thread.Sleep(1000);
            SendKeys.Send("{ENTER}");
            SendKeys.Send("Shutdown /r /t 360");
            Thread.Sleep(1000);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(2000);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(1000);
            LeftMouseClick(666, 666);
            /*SendKeys.Send("%{ESC}");
            Thread.Sleep(1000);*/
            SendKeys.Send("ПРИКОЛЬНО ДА?");
            Thread.Sleep(1000);
            SendKeys.Send("{ENTER}");
            SendKeys.Send("ЛАДНО Я ПОШУТИЛ");
            Thread.Sleep(1000);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(1000);
            SendKeys.Send("Shutdown /a");
            Thread.Sleep(1000);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(2000);
            SendKeys.Send("%{F4}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Form2 f = new Form2(false);
        
        bool pusk = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (pusk)
            {
                DialogResult now = MessageBox.Show("У вас WIn 10 или 11?",
                    "Вопрос",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (now == DialogResult.Yes)
                {
                    MessageBox.Show("Во время работы программы не производите никаких действий с пк!",
                        "ВНИМАНИЕ!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    DialogResult r = MessageBox.Show("Если вы нажмете что-либо, то программа прервет действе с ошибкой для вашего пк, удачи)",
                        "Точно поняли?",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Еще не проверенно с другими версиями Win",
                      "НЕвозможно",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
                    this.Close();
                }
                
            }
            pusk = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*MessageBox.Show("Сейчас произойдет проверка наличия программы Paint",
                "Пожалуста подождите",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Thread.Sleep(1000);
            Process.Start("cmd");
            this.Hide();
            Thread.Sleep(500);
            SendKeys.Send("mspaint");
            Thread.Sleep(500);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(100);
            ProcessKill("cmd");
            if (Process.GetProcessesByName("mspaint").Length > 0)
            {
                Thread.Sleep(100);
                ProcessKill("mspaint");
                this.Show();
                MessageBox.Show("Выявленно наличие Paint; Пожалуйста проверте расположено ли окно формы в центре экрана",
                "Пожалуста выполните действие",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                MessageBox.Show("После выберите нужные настройки и нажмите на кнопку Запуск на форме",
                "Пожалуста выполните действие",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);*/
                Form2 newForm = new Form2(this);
                newForm.Show();
                this.Hide();
            /*}
            else
            {
                this.Show();
                MessageBox.Show("Наличие программы Paint не выявленно, далнейшая работа невозможна",
                 "Ошибка",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Process.Start("mspaint.exe");

            //Process.Start("opera.exe");

            //Process.Start("C:\\Program Files\\WindowsApps\\Microsoft.Paint_11.2210.4.0_x64__8wekyb3d8bbwe\\PaintApp\\mspaint");

            //Application.Exit();
            //ProcessStartInfo info = new ProcessStartInfo("iexplore.exe");

            /*this.Hide();
            Cursor.Position = new Point(this.Left + this.Width / 2, this.Top + this.Height / 2);
            LeftMouseClick(Cursor.Position.X, Cursor.Position.Y + 130);
            Thread.Sleep(2500);
            this.Show();*/
            /*Thread.Sleep(1000);
            Process.Start("cmd");
            this.Hide();
            Thread.Sleep(500);
            SendKeys.Send("cd \\");
            Thread.Sleep(500);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(500);
            SendKeys.Send("Applications");
            Thread.Sleep(500);
            SendKeys.Send("{ENTER}");
            this.Show();*/

            /*SendKeys.Send("^{ESC}");
            Thread.Sleep(1000);
            SendKeys.Send("Paint 3D");
            Thread.Sleep(1000);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(2000);
            SendKeys.Send("{TAB 6}");
            Thread.Sleep(500);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(500);
            int x = 100;
            int y = 200;
            LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X + x, Cursor.Position.Y);
            LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X, Cursor.Position.Y - y);
            LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X - x, Cursor.Position.Y);
            LeftMouseDrag(Cursor.Position.X, Cursor.Position.Y, Cursor.Position.X, Cursor.Position.Y + y);*/
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer2.Start();
            timer3.Start();
            timer4.Start();
        }
        Random rnd = new Random();
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (rnd.Next(1, 3) == 1)
            {
                MessageBox.Show("ОШИБКА", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("КРИТИЧЕСКАЯ ОШИБКА xx00057356782389074x", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (rnd.Next(1, 3) == 1)
            {
                MessageBox.Show("Критическая ошибка", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("НЕВОЗМОЖНАЯ ОШИБКА xx00057356782389074x", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Cursor.Position = new Point(this.Left + this.Width / 2, this.Top + this.Height / 2);
            /*LeftMouseClick(970, 475);
            LeftMouseDrag(970, 475, Cursor.Position.X + rnd.Next(10,200), Cursor.Position.Y + rnd.Next(10, 200));*/
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            Application.Exit();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
