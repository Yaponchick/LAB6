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

        if (distanceToEntrance <= Radius)
        {
            // Генерируем случайный угол для направления вылета
            double randomAngle = random.NextDouble() * 2 * Math.PI;

            // Вычисляем новые координаты частицы на основе сгенерированного угла
            particle.X = ExitX + (float)(Radius * Math.Cos(randomAngle));
            particle.Y = ExitY + (float)(Radius * Math.Sin(randomAngle));
        }
    }




    public override void Render(Graphics g)
    {
        // Загрузите изображения для телепортов
        Bitmap teleporterImage = new Bitmap(@"D:\Политехъ\2 курс\4 семестр\Технолоджи программирования\6 Лабораторная работа\LAB6\LAB6\circle.png");
        Bitmap exitImage = new Bitmap(@"D:\Политехъ\2 курс\4 семестр\Технолоджи программирования\6 Лабораторная работа\LAB6\LAB6\sol.png");

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

