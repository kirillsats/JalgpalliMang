using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Stadium
{
    public Stadium(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width { get; }
    public int Height { get; }

    // Проверяем, находится ли точка в пределах стадиона
    // Kontrollime, kas punkt on staadioni piires
    public bool IsIn(double x, double y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }
}

