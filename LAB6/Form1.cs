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
        List<Emitter> emitters = new List<Emitter>(); // Список для хранения эмиттеров
        Emitter emitter; // Поле для текущего эмиттера

        private bool teleportEnabled = false; // Флаг для включения/выключения телепортатора
        private bool eaterEnabled = false; // Флаг для включения/выключения поедателя
        private Teleporter teleporter; // Поле для телепортатора

        // Конструктор формы
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // Загрузка фона для picDisplay и его масштабирование
            picDisplay.BackgroundImage = Image.FromFile(@"D:\Политехъ\2 курс\4 семестр\Технолоджи программирования\6 Лабораторная работа\LAB6\LAB6\cloud.jpg");
            picDisplay.BackgroundImageLayout = ImageLayout.Stretch;
            picDisplay.Refresh();

            // Создание и настройка эмиттера
            this.emitter = new Emitter
            {
                Direction = 0, // Начальное направление движения частиц (в градусах)
                Spreading = 10, // Разброс направления движения частиц
                SpeedMin = 10, // Минимальная скорость частиц
                SpeedMax = 10, // Максимальная скорость частиц
                ColorFrom = Color.Gold, // Начальный цвет частиц
                ColorTo = Color.FromArgb(0, Color.Red), // Конечный цвет частиц
                ParticlesPerTick = 10, // Количество частиц, создаваемых за один такт времени
                X = picDisplay.Width / 2, // Начальная координата X эмиттера
                Y = picDisplay.Height / 2, // Начальная координата Y эмиттера
            };

            emitters.Add(this.emitter); // Добавление эмиттера в список для отображения
        }

        // Обработчик таймера для обновления состояния эмиттера и отрисовки
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // Обновление состояния эмиттера

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Transparent); // Очистка изображения

                emitter.Render(g); // Отрисовка эмиттера
            }

            picDisplay.Invalidate(); // Обновление отображения. Invalidate() - эл упр помечается недействительным и обновляет
        }

        // Обработчик движения мыши по picDisplay для привязки позиции
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (checkBoxWand.Checked) // Проверка включен ли CheckBox
            {
                foreach (var emitter in emitters)
                {
                    emitter.MousePositionX = e.X;
                    emitter.MousePositionY = e.Y;
                }
            }
        }

        // Обработчик изменения значения ползунка направления эмиттера
        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value; // Изменение направления эмиттера
            lblDirection.Text = $"{tbDirection.Value}°"; // Обновление текста метки
        }

        // Обработчик клика мыши по picDisplay для добавления телепортатора или поедателя
        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (teleportEnabled)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (teleporter == null)
                    {
                        teleporter = new Teleporter(e.X, e.Y, 40);
                        teleporter.ExitX = e.X;
                        teleporter.ExitY = e.Y;
                        emitters[0].impactPoints.Add(teleporter);
                    }
                    else
                    {
                        teleporter.X = e.X;
                        teleporter.Y = e.Y;
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (teleporter == null)
                    {
                        teleporter = new Teleporter(e.X, e.Y, 40);
                        teleporter.X = e.X;
                        teleporter.Y = e.Y;
                        emitters[0].impactPoints.Add(teleporter);
                    }
                    else
                    {
                        teleporter.ExitX = e.X;
                        teleporter.ExitY = e.Y;
                    }
                }
            }

            if (eaterEnabled && e.Button == MouseButtons.Left)
            {
                Eater newExplosion = new Eater(e.X, e.Y, 50);
                emitter.impactPoints.Add(newExplosion);
                picDisplay.Invalidate();
            }
        }

        // Обработчик изменения состояния CheckBox для включения/выключения телепортатора
        private void checkBoxTeleport_CheckedChanged(object sender, EventArgs e)
        {
            teleportEnabled = checkBoxTeleport.Checked;
            if (!teleportEnabled && teleporter != null)
            {
                emitters[0].impactPoints.Remove(teleporter);
                teleporter = null;
                picDisplay.Invalidate();
            }
        }

        // Обработчик изменения состояния CheckBox для включения/выключения поедателя
        private void checkBoxExplosion_CheckedChanged(object sender, EventArgs e)
        {
            eaterEnabled = checkBoxExplosion.Checked;
            if (!eaterEnabled)
            {
                foreach (Emitter emitter in emitters)
                {
                    emitter.impactPoints.RemoveAll(point => point is Eater);
                }
                picDisplay.Invalidate();
            }
        }

        // Обработчик изменения состояния CheckBox для включения/выключения привязки позиции эмиттера к курсору
        private void checkBoxWand_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWand.Checked) // Если CheckBox включен
            {
                // Включение функциональности привязки позиции эмиттера к курсору
                picDisplay.MouseMove += picDisplay_MouseMove;
            }
            else
            {
                // Выключение функциональности привязки позиции эмиттера к курсору
                picDisplay.MouseMove -= picDisplay_MouseMove;

                // Сброс привязки позиции мыши к эмиттеру при выключенном CheckBox
                foreach (var emitter in emitters)
                {
                    emitter.MousePositionX = 10000;
                    emitter.MousePositionY = 0;
                }
            }
        }

        // Обработчик изменения разброса частиц
        private void tbSpreading_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = tbSpreading.Value*20;
            lblSpreading.Text = $"{tbSpreading.Value}"; // Обновление текста метки
        }

        // Обработчик изменения скорости частиц
        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            emitter.SpeedMin = tbSpeed.Value*2; // Установка минимальной скорости частиц
            emitter.SpeedMax = tbSpeed.Value*2;
            lblSpeed.Text = $"{tbSpeed.Value}";
        }

        // Обработчик изменения количества частиц
        private void tbParticlesPerTick_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = tbParticlesPerTick.Value*5;
            lblParticlesPerTick.Text = $"{tbParticlesPerTick.Value}";
        }
    }
}
