using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB6
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; //поле для эмиттера

        GravityPoint point1; // добавил поле под первую точку
        GravityPoint point2; // добавил поле под вторую точку

        private bool teleportEnabled = false;


        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // Установите изображение в качестве фона формы
            this.BackgroundImage = Image.FromFile(@"D:\Политехъ\2 курс\4 семестр\Технолоджи программирования\6 Лабораторная работа\LAB6\LAB6\fon2.jpg"); // Замените путь на свой
            this.BackgroundImageLayout = ImageLayout.Stretch; // Растянуть изображение на всю форму

            picDisplay.BackgroundImage = Image.FromFile(@"D:\Политехъ\2 курс\4 семестр\Технолоджи программирования\6 Лабораторная работа\LAB6\LAB6\fon2.jpg");
            picDisplay.BackgroundImageLayout = ImageLayout.Stretch; // Настроить масштабирование изображения
            picDisplay.Refresh(); // Обновить picDisplay для отображения изменений




            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };


            emitters.Add(this.emitter); // все равно добавляю в список emitters, чтобы он рендерился и обновлялся

            // привязываем гравитоны к полям
            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };
            point2 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // тут теперь обновляем эмиттер

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Transparent);

                /*                g.Clear(Color.Black);
                */
                emitter.Render(g); // а тут теперь рендерим через эмиттер
            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
          /*  foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            // а тут передаем положение мыши, в положение гравитона
            point2.X = e.X;
            point2.Y = e.Y;*/
        }



        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value; // направлению эмиттера присваиваем значение ползунка 
            lblDirection.Text = $"{tbDirection.Value}°"; // добавил вывод значения
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
            lblGraviton.Text = $"{tbGraviton.Value}°";
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            point2.Power = tbGraviton2.Value;
            lblGraviton2.Text = $"{tbGraviton2.Value}°";
        }






        private Teleporter teleporter;

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (!teleportEnabled) // Проверяем, включен ли телепорт
                return;
            if (e.Button == MouseButtons.Left) // Проверяем, что была нажата левая кнопка мыши
            {
                if (teleporter == null) // Если телепортёр не существует, создаём его с входом
                {
                    teleporter = new Teleporter(e.X, e.Y, 40);
                    // Задаем начальные координаты выхода равными координатам входа
                    teleporter.ExitX = e.X;
                    teleporter.ExitY = e.Y;
                    emitters[0].impactPoints.Add(teleporter); // Добавляем телепортёр в список точек воздействия
                }
                else // Если телепортёр уже существует, обновляем его положение входа
                {
                    teleporter.X = e.X; // Перемещаем вход в точку клика
                    teleporter.Y = e.Y;
                }
            }
            else if (e.Button == MouseButtons.Right) // Проверяем, что была нажата правая кнопка мыши
            {
                if (teleporter == null) // Если телепортёр не существует, создаём его с выходом
                {
                    teleporter = new Teleporter(e.X, e.Y, 40);
                    // Задаем начальные координаты входа равными координатам выхода
                    teleporter.X = e.X;
                    teleporter.Y = e.Y;
                    emitters[0].impactPoints.Add(teleporter); // Добавляем телепортёр в список точек воздействия
                }
                else // Если телепортёр уже существует, обновляем его положение выхода
                {
                    teleporter.ExitX = e.X; // Перемещаем выход в точку клика
                    teleporter.ExitY = e.Y;
                }
            }

            // Принудительно вызываем перерисовку элемента управления для обновления отображения
            picDisplay.Invalidate();
        }

        // включалка\выключалка телепортатора
        private void checkBoxTeleport_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTeleport.Checked)
            {
                // Включаем работу телепорта
                teleportEnabled = true;
            }
            else
            {
                // Выключаем работу телепорта
                teleportEnabled = false;

                // Удаляем телепорт с формы
                if (teleporter != null)
                {
                    // Удаляем телепорт из списка точек воздействия
                    emitters[0].impactPoints.Remove(teleporter);
                    // Обнуляем переменную teleporter
                    teleporter = null;
                    // Принудительно вызываем перерисовку элемента управления для обновления отображения
                    picDisplay.Invalidate();
                }
            }
        }
    }
}
