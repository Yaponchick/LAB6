using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
   public  class Emitter
    {
        public List<Particle> particles = new List<Particle>();

        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы
        public int ParticlesPerTick = 1; // количество частиц

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

        // Координаты мыши
        public int MousePositionX;
        public int MousePositionY;

        // Гравитация по осям X и Y
        public float GravitationX = 0;
        public float GravitationY = 1;

        // метод для генерации частиц
        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }

        // Метод для обновления состояния эмиттера
        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick; // Фиксируем количество частиц, которые нужно создать за текущий такт времени

            foreach (var particle in particles)
            {
                // Если жизненный цикл частицы исчерпан
                if (particle.Life <= 0)
                {
                    // Сброс параметров частицы
                    particle.Life = 20 + Particle.rand.Next(100);
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;

                    // Генерация случайных параметров для новой частицы
                    var direction = (double)Particle.rand.Next(360);
                    var speed = 1 + Particle.rand.Next(10);
                    particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                    particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);
                    particle.Radius = 2 + Particle.rand.Next(10);

                    // Если еще не все частицы созданы в текущем такте, создаем еще одну
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1;
                        ResetParticle(particle);
                    }
                }
                else
                {
                    // Обновление положения и параметров частицы
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                    particle.Life -= 1;

                    // Применение воздействия точек гравитации (Гравитон)
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    // Применение гравитации к частице
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                }
            }

            // Создание новых частиц, если еще не все частицы созданы в текущем такте
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }

        // Метод для отрисовки всех частиц и точек воздействия
        public void Render(Graphics g)
        {
            // отрисовка частиц
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
            // Отрисовка элементов (телепорт, поедатель)
            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }

        // Сбрасывает параметры частицы до начальных значений
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2; // Направление
            var speed = Particle.rand.Next(SpeedMin, SpeedMax); 

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);

            // Сброс цвета на начальный
            if (particle is ParticleColorful colorfulParticle) // Является ли объект particle экземпляром класса ParticleColorful
            {
                colorfulParticle.FromColor = ColorFrom;
                colorfulParticle.ToColor = ColorTo;
            }

            particle.FromTeleporter = false;
        }
    }
}
