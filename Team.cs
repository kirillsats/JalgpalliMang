using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JalgpalliMang
{
    public class Team
    {
        public List<Player> Players { get; } = new List<Player>();
        public string Name { get; private set; }
        public Game Game { get; set; }

        public Team(string name)
        {
            Name = name;
        }

        // Начинаем игру
        // Alustame mängu
        public void StartGame(int width, int height)
        {
            Random rnd = new Random();
            foreach (var player in Players)
            {
                player.SetPosition(
                    rnd.NextDouble() * width,
                    rnd.NextDouble() * height
                );
            }
        }

        // Добавляем игрока в команду
        // Lisame mängija meeskonda
        public void AddPlayer(Player player)
        {
            if (player.Team != null) return;
            Players.Add(player);
            player.Team = this;
        }

        // Получаем позицию мяча
        // Saame palli positsiooni
        public (double, double) GetBallPosition()
        {
            return Game.GetBallPositionForTeam(this);
        }

        // Устанавливаем скорость мяча
        // Määrame palli kiirus
        public void SetBallSpeed(double vx, double vy)
        {
            Game.SetBallSpeedForTeam(this, vx, vy);
        }

        // Получаем ближайшего игрока к мячу
        // Saame palli poole lähima mängija
        public Player GetClosestPlayerToBall()
        {
            Player closestPlayer = Players[0];
            double bestDistance = Double.MaxValue;
            foreach (var player in Players)
            {
                var distance = player.GetDistanceToBall();
                if (distance < bestDistance)
                {
                    closestPlayer = player;
                    bestDistance = distance;
                }
            }

            return closestPlayer;
        }

        // Двигаем команду
        // Liigutame meeskonda
        public void Move()
        {
            GetClosestPlayerToBall().MoveTowardsBall();
            Players.ForEach(player => player.Move());
        }
    }
}