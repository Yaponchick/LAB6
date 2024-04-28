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

    public override void ImpactParticle(Particle particle)
    {
        float distanceToEntrance = (float)Math.Sqrt(Math.Pow(X - particle.X, 2) + Math.Pow(Y - particle.Y, 2));

        if (distanceToEntrance <= Radius)
        {
            float directionToExit = (float)Math.Atan2(ExitY - Y, ExitX - X);

            particle.X = ExitX + (float)(Radius * Math.Cos(directionToExit));
            particle.Y = ExitY + (float)(Radius * Math.Sin(directionToExit));
        }
    }


    public override void Render(Graphics g)
    {
        g.FillEllipse(Brushes.Green, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);

        g.FillEllipse(Brushes.Blue, ExitX - Radius, ExitY - Radius, 2 * Radius, 2 * Radius);
    }
}

