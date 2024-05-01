using LAB6;
using System;
using System.Drawing;


public class Teleporter : IImpactPoint
{
    public float X { get; set; } 
    public float Y { get; set; } 
    public float ExitX { get; set; } 
    public float ExitY { get; set; }
    public float Radius { get; set; } 

    // Constructor
    public Teleporter(float x, float y, float radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }
    private Random random = new Random();

    public override void ImpactParticle(Particle particle)
    {
        float distanceToEntrance = (float)Math.Sqrt(Math.Pow(X - particle.X, 2) + Math.Pow(Y - particle.Y, 2));
        float distanceToExit = (float)Math.Sqrt(Math.Pow(ExitX - particle.X, 2) + Math.Pow(ExitY - particle.Y, 2));

        if (distanceToEntrance <= Radius && distanceToExit > Radius)
        {

            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

            if (particle is ParticleColorful colorfulParticle)
            {
                colorfulParticle.FromColor = randomColor;
                colorfulParticle.ToColor = Color.FromArgb(0, randomColor); 
            }

            double randomAngle = random.NextDouble() * 2 * Math.PI;

            particle.X = ExitX + (float)(Radius * Math.Cos(randomAngle));
            particle.Y = ExitY + (float)(Radius * Math.Sin(randomAngle));
        }
    }

    public override void Render(Graphics g)
    {
        // Загрузите изображения для телепортов
        Bitmap teleporterImage = new Bitmap(@"D:\Политехъ\2 курс\4 семестр\Технолоджи программирования\6 Лабораторная работа\LAB6\LAB6\circle.png");
        Bitmap exitImage = new Bitmap(@"D:\Политехъ\2 курс\4 семестр\Технолоджи программирования\6 Лабораторная работа\LAB6\LAB6\circleRGB.png");

        // Отобразите изображения на экране вместо кругов
        g.DrawImage(teleporterImage, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
        g.DrawImage(exitImage, ExitX - Radius, ExitY - Radius, 2 * Radius, 2 * Radius);

        // Освободите ресурсы изображений после использования
        teleporterImage.Dispose();
        exitImage.Dispose();
    }

    /*   Bitmap teleporterImage = new Bitmap(@"D:\Политехъ\2 курс\4 семестр\Технолоджи программирования\6 Лабораторная работа\LAB6\LAB6\pakman.png");
       Bitmap exitImage = new Bitmap(@"D:\Политехъ\2 курс\4 семестр\Технолоджи программирования\6 Лабораторная работа\LAB6\LAB6\pakman.png");


       public override void Render(Graphics g)
       {
           // Рисуем изображение телепорта
           g.DrawImage(teleporterImage, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);

           // Рисуем изображение выхода
           g.DrawImage(exitImage, ExitX - Radius, ExitY - Radius, 2 * Radius, 2 * Radius);
       }*/

}

