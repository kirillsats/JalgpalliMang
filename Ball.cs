
using System;

namespace Jalgpali
{
    public class Ball
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        private double _vx, _vy;

        private Game _game;

        public Ball(double x, double y, Game game)
        {
            _game = game;
            X = x;
            Y = y;
        }

        public void SetPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void SetSpeed(double vx, double vy)
        {
            _vx = vx;
            _vy = vy;
        }

        public void Move()
        {
            double newX = X + _vx;
            double newY = Y + _vy;

            if (_game.Stadium.IsIn(newX, newY)) // Проверка, нет ли столкновений со стенами
            {
                X = newX;
                Y = newY;
            }
            else
            {
                if (newX < 0 || newX >= _game.Stadium.Width) // Рикошет от стены
                {
                    _vx = -_vx; // Измените направление вдоль оси X
                    newX = X + _vx; // движение шарика на 1 пиксель
                    X = newX < 0 ? 1 : newX >= _game.Stadium.Width ? _game.Stadium.Width - 1 : newX;
                }

                if (newY < 0 || newY >= _game.Stadium.Height) // Рикошет от стены
                {
                    _vy = -_vy; // Измените направление вдоль оси Y
                    newY = Y + _vy; // движение шарика на 1 пиксель
                    Y = newY < 0 ? 1 : newY >= _game.Stadium.Height ? _game.Stadium.Height - 1 : newY;
                }
            }
        }
    }
}
