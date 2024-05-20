using LAB6;
using System;
using System.Drawing;


public class Teleporter : IImpactPoint
{
    public float X; // Координата X точки входа телепорта
    public float Y; // Координата Y точки входа телепорта
    public float ExitX; // Координата X точки выхода телепорта
    public float ExitY; // Координата Y точки выхода телепорта
    public float Radius;  // Радиус телепорта

    private Random random = new Random(); // Генерация случайных чисел

    // Конструктор класса Teleporter
    public Teleporter(float x, float y, float radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }

    // Воздействуем на частицу
    public override void ImpactParticle(Particle particle)
    {
        // Расчет расстояния от частицы до точки входа телепорта
        float distanceToEntrance = (float)Math.Sqrt(Math.Pow(X - particle.X, 2) + Math.Pow(Y - particle.Y, 2));
        particle.FromTeleporter = true;

        if (distanceToEntrance <= Radius)
        {
            // Генерируем случайный угол для направления вылета
            double randomAngle = random.NextDouble() * 2 * Math.PI;

            // Вычисляем новые координаты частицы на основе сгенерированного угла
            particle.X = ExitX + (float)(Radius * Math.Cos(randomAngle));
            particle.Y = ExitY + (float)(Radius * Math.Sin(randomAngle));

            // Изменяем цвет только для частиц, выходящих из телепорта
            if (particle is ParticleColorful colorfulParticle)
            {
                colorfulParticle.FromColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                colorfulParticle.ToColor = Color.FromArgb(0, colorfulParticle.FromColor);
            }
        }
    }

    // Метод отрисовки телепорта
    public override void Render(Graphics g)
    {
        Bitmap teleporterImage = new Bitmap(@"D:\Политехъ\2 курс\4 семестр\Технолоджи программирования\6 Лабораторная работа\LAB6\LAB6\circle.png");
        Bitmap exitImage = new Bitmap(@"D:\Политехъ\2 курс\4 семестр\Технолоджи программирования\6 Лабораторная работа\LAB6\LAB6\circleRGB.png");

        // Отображение изображения на экране вместо кругов
        g.DrawImage(teleporterImage, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
        g.DrawImage(exitImage, ExitX - Radius, ExitY - Radius, 2 * Radius, 2 * Radius);

        // освобождение ресурсов отображения
        teleporterImage.Dispose();
        exitImage.Dispose();
    }
}

