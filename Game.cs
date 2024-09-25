using JalgpalliMang;

public class Game
{
    // Домашняя команда
    public Team HomeTeam { get; }

    // Гостевая команда
    public Team AwayTeam { get; }

    // Стадион
    public Stadium Stadium { get; }

    // Мяч
    public Ball Ball { get; private set; }

    // создание игры с домашней и гостевой командами и стадионом
    public Game(Team homeTeam, Team awayTeam, Stadium stadium)
    {
        HomeTeam = homeTeam;
        homeTeam.Game = this; // Устанавливаем игру для домашней команды
        AwayTeam = awayTeam;
        awayTeam.Game = this; // Устанавливаем  игру для гостевой команды
        Stadium = stadium; // Сохраняем информацию о стадионе
    }

    // Начинает игру, размещает мяч в центре стадиона и начинает игру для команд
    public void Start()
    {
        Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this); // Создаем мяч в центре стадиона
        HomeTeam.StartGame(Stadium.Width / 2, Stadium.Height); // Начинаем игру для домашней команды
        AwayTeam.StartGame(Stadium.Width / 2, Stadium.Height); // Начинаем игру для гостевой команды
    }

    // Получает позицию для гостевой команды (отражает координаты)
    private (double, double) GetPositionForAwayTeam(double x, double y)
    {
        return (Stadium.Width - x, Stadium.Height - y); // Отражение координат
    }

    // Получает позицию для команды в зависимости от того, домашняя она или гостевая
    public (double, double) GetPositionForTeam(Team team, double x, double y)
    {
        return team == HomeTeam ? (x, y) : GetPositionForAwayTeam(x, y);
    }

    // Получает позицию мяча для команд
    public (double, double) GetBallPositionForTeam(Team team)
    {
        return GetPositionForTeam(team, Ball.X, Ball.Y); // Возвращаем позицию мяча
    }

    // Устанавливает скорость мяча для команд
    public void SetBallSpeedForTeam(Team team, double vx, double vy)
    {
        if (team == HomeTeam)
        {
            Ball.SetSpeed(vx, vy); // Устанавливаем скорость для домашней команды
        }
        else
        {
            Ball.SetSpeed(-vx, -vy); // Устанавливаем обратную скорость для гостевой команды
        }
    }

    // Движение команд и мяча
    public void Move()
    {
        HomeTeam.Move(); 
        AwayTeam.Move();
        Ball.Move();
    }
}
