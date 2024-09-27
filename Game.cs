namespace JalgpalliMang
{
    public class Game
    {
        public Team HomeTeam { get; }
        public Team AwayTeam { get; }
        public Stadium Stadium { get; }
        public Ball Ball { get; private set; }

        public Game(Team homeTeam, Team awayTeam, Stadium stadium)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Stadium = stadium;
            Ball = new Ball(stadium.Width / 2, stadium.Height / 2); // Изначальное положение мяча в центре
        }

        public void Start()
        {
            // Логика начала игры
        }

        public void Move()
        {
            // Движение мяча
            Ball.Move();

            // Движение игроков
            foreach (var player in HomeTeam.Players)
            {
                player.Move();
            }
            foreach (var player in AwayTeam.Players)
            {
                player.Move();
            }
        }
    }
}
