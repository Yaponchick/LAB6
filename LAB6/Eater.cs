using System;
using System.Drawing;

namespace LAB6
{
    public class Eater : IImpactPoint
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }

        private int particlesCollected = 0; // Счетчик собранных частиц

        // Массив строк для надписей
        private string[] labels = new string[]
        {
            "АМ АМ АМ",
            "Почти наелся",
            "Ещё!",
            "Скоро лопну",
            "Наевся"
        };

        // Конструктор класса, принимающий координаты и радиус
        public Eater(float x, float y, float radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public override void ImpactParticle(Particle particle)
        {
            if (particlesCollected >= 4000)
                return; // Если собрано более 4000 частиц, перестаем считать

            // Вычисляем расстояние между центром круга и частицей
            float distanceToCenter = (float)Math.Sqrt(Math.Pow(X - particle.X, 2) + Math.Pow(Y - particle.Y, 2));

            // Если частица попадает внутрь круга, то считаем ее собранной
            if (distanceToCenter <= Radius)
            {
                particlesCollected++;
                // Установить частицу за пределы экрана, чтобы она умерла
                particle.Life = 0;
            }
        }

        public override void Render(Graphics g)
        {
            // Получаем текущий цвет для круга
            Color circleColor = GetCircleColor();

            // Создаем цвет для обводки без прозрачности
            Color outlineColor = Color.FromArgb(255, circleColor);

            // Создаем кисть для круга
            using (Brush brush = new SolidBrush(circleColor))
            {
                // Рисуем круг с изменяемым цветом
                g.FillEllipse(brush, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            }

            // Обводка для круга
            using (Pen pen = new Pen(outlineColor, 3)) // толщина обводки 3 пикселя
            {
                g.DrawEllipse(pen, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            }

            // Получаем размер текста для надписи
            SizeF labelSize = g.MeasureString(labels[particlesCollected / 1000], new Font("Arial", 10));

            // Вычисляем координаты для отображения надписи в центре круга
            float labelX = X - labelSize.Width / 2;
            float labelY = Y - labelSize.Height / 2;

            // Отображаем надпись для текущего уровня собранных частиц
            g.DrawString(labels[particlesCollected / 1000], new Font("Arial", 10), Brushes.Black, labelX, labelY);

            // Получаем размер текста для количества собранных частиц
            SizeF textSize = g.MeasureString($"Собрано: {particlesCollected}", new Font("Arial", 10));

            // Вычисляем координаты для отображения текста под кругом
            float textX = X - textSize.Width / 2;
            float textY = Y + Radius + 5;

            // Отображаем количество собранных частиц под кругом
            g.DrawString($"Собрано: {particlesCollected}", new Font("Arial", 10), Brushes.Black, textX, textY);
        }

        private Color GetCircleColor()
        {
            if (particlesCollected < 1000)
            {
                int alpha = particlesCollected / 4;
                return Color.FromArgb(alpha, Color.Green);
            }
            else if (particlesCollected < 2000)
            {
                int alpha = (particlesCollected - 1000) / 4;
                return Color.FromArgb(alpha, Color.Yellow);
            }
            else if (particlesCollected < 3000)
            {
                int alpha = (particlesCollected - 2000) / 4;
                return Color.FromArgb(alpha, Color.Orange);
            }
            else if (particlesCollected < 4000)
            {
                int alpha = (particlesCollected - 3000) / 4;
                return Color.FromArgb(alpha, Color.Red);
            }
            else
            {
                return Color.Red;
            }
        }
    }
}
