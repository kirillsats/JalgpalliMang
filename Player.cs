using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JalgpalliMang
{
    public class Player
    {
        public string Name { get; }
        //координаты, где находится игрок
        public double X { get; private set; }
        public double Y { get; private set; }
        //насколько происходит передвижение по x,y
        private double _vx, _vy;
        //
        public Team Team { get; set; } = null;
        //постоянное значение 
        private const double MaxSpeed = 5;
        private const double MaxKickSpeed = 25;
        private const double BallKickDistance = 10;
        //рандомное значение
        private Random _random = new Random();
        //принимаетимя игрока
        public Player(string name)
        {
            Name = name;
        }
        //определяется команда и позиция
        public Player(string name, double x, double y, Team team)
        {
            Name = name;
            X = x;
            Y = y;
            Team = team;
        }
        //устанавливаем позицию игрока
        public void SetPosition(double x, double y)
        {
            X = x;
            Y = y;
        }
        //получение позиции игрока до мяча
        public (double, double) GetAbsolutePosition()
        {
            return Team.Game.GetPositionForTeam(Team, X, Y);
        }
        //получаем дистанцию до мяча
        public double GetDistanceToBall()
        {
            var ballPosition = Team.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        //движение игрока к мячу
        public void MoveTowardsBall()
        {
            var ballPosition = Team.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed;
            _vx = dx / ratio;
            _vy = dy / ratio;
        }
        //движение
        public void Move()
        {
            if (Team.GetClosestPlayerToBall() != this)
            {
                _vx = 0;
                _vy = 0;
            }
            //ближний игрок бьет мяч
            if (GetDistanceToBall() < BallKickDistance)
            {
                Team.SetBallSpeed(
                    MaxKickSpeed * _random.NextDouble(),
                    MaxKickSpeed * (_random.NextDouble() - 0.5)
                    );
            }

            var newX = X + _vx;
            var newY = Y + _vy;
            var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY);
            if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2))
            {
                X = newX;
                Y = newY;
            }
            else
            {
                _vx = _vy = 0;
            }
        }
    }
}
