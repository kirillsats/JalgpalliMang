using System;

namespace JalgpalliMang
{
    public class Ball
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        private float directionX;
        private float directionY;

        public Ball(float x, float y)
        {
            X = x;
            Y = y;
            Random rand = new Random();
            directionX = (float)(rand.NextDouble() * 2 - 1); // Случайное направление по X
            directionY = (float)(rand.NextDouble() * 2 - 1); // Случайное направление по Y
        }

        public void Move()
        {
            X += directionX * 0.5f; // Скорость мяча
            Y += directionY * 0.5f;

            // Проверка границ
            if (X <= 1 || X >= 33) // Учитываем границы стадиона
            {
                directionX = -directionX; // Отскок от стенки
            }
            if (Y <= 1 || Y >= 23) // Учитываем границы стадиона
            {
                directionY = -directionY; // Отскок от стенки
            }
        }
    }
}
