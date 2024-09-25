public class Ball
{
    // Координата X 
    public double X { get; private set; }

    // Координата Y 
    public double Y { get; private set; }

    // Скорость мяча по осям X и Y
    private double _vx, _vy;

    // Игра, к которой принадлежит мяч
    private Game _game;

    // Конструктор для создания мяча с заданными координатами и игрой
    public Ball(double x, double y, Game game)
    {
        _game = game; // Сохраняем ссылку на игру
        X = x; // Устанавливаем начальную координату X
        Y = y; // Устанавливаем начальную координату Y
    }

    // Устанавливает скорость мяча
    public void SetSpeed(double vx, double vy)
    {
        _vx = vx; // Устанавливаем скорость по оси X
        _vy = vy; // Устанавливаем скорость по оси Y
    }

    // Двигает мяч
    public void Move()
    {
        double newX = X + _vx; // Вычисляем новую координату X
        double newY = Y + _vy; // Вычисляем новую координату Y

        // Проверяем, находится ли новая позиция мяча в пределах стадиона
        if (_game.Stadium.IsIn(newX, newY))
        {
            X = newX; // Обновляем координату X
            Y = newY; // Обновляем координату Y
        }
        else
        {
            _vx = 0; // Останавливаем движение по оси X
            _vy = 0; // Останавливаем движение по оси Y
        }
    }
}
