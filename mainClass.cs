using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JalgpalliMang
{
    public class mainClass
    {
        public static void Main(string[] args)
        {
            // Создаем стадион
            // Loome staadioni
            Stadium stadium = new Stadium(35, 25);

            // Создаем команды
            // Loome meeskonnad
            Team homeTeam = new Team("Kodumeeskond");
            Team awayTeam = new Team("Võõrsil meeskond");

            // Добавляем игроков в команды
            // Lisame mängijad meeskondadesse
            for (int i = 1; i <= 11; i++) // 11 игроков в каждой команде
            {
                homeTeam.AddPlayer(new Player($"Mängija kodus {i}"));
                awayTeam.AddPlayer(new Player($"Külalismängija {i}"));
            }

            // Создаем игру
            // Loome mängu
            Game game = new Game(homeTeam, awayTeam, stadium);
            game.Start();

            // Отображение стадиона
            // Staadoni kuvamine
            DisplayStadium(game);

            // Симуляция игры
            // Mängu simuleerimine
            while (true) // Бесконечный цикл для продолжения игры
            // Lõputu tsükkel mängu jätkamiseks
            {
                // Движение команд и мяча
                // Meeskondade ja palli liikumine
                game.Move();

                // Отображение обновленного стадиона
                // Kuvame uuendatud staadioni
                DisplayStadium(game);
                DisplayGameStatus(game);
                System.Threading.Thread.Sleep(500); // Пауза для видимости
                // Paus nähtavuse jaoks
            }
        }

        static void DisplayStadium(Game game)
        {
            // Обводим стадион символами '*'
            // Ümbritseme staadioni sümbolitega '*'
            for (int y = 0; y < game.Stadium.Height; y++)
            {
                for (int x = 0; x < game.Stadium.Width; x++)
                {
                    // Границы стадиона
                    // Staadioni piirid
                    if (y == 0 || y == game.Stadium.Height - 1)
                    {
                        Console.Write('*');
                    }
                    else if (x == 0 || x == game.Stadium.Width - 1)
                    {
                        Console.Write('*');
                    }
                    // Горизонтальная линия в середине стадиона
                    // Horisontaalne joon staadioni keskel
                    else if (y == game.Stadium.Height / 2)
                    {
                        Console.Write('-'); // Линия разделения
                    }
                    else
                    {
                        // Проверяем, где находятся игроки
                        // Kontrollime, kus mängijad asuvad
                        char playerChar = ' '; // Пустое пространство по умолчанию

                        // Проверяем игроков домашней команды
                        // Kontrollime kodumeeskonna mängijaid
                        for (int i = 0; i < game.HomeTeam.Players.Count; i++)
                        {
                            var player = game.HomeTeam.Players[i];
                            int playerX = (int)player.X;
                            int playerY = (int)player.Y;
                            if (x == playerX && y == playerY)
                            {
                                playerChar = (char)('1' + i); // Номера от 1 до 11
                            }
                        }

                        // Проверяем игроков гостевой команды
                        // Kontrollime külaliste meeskonna mängijaid
                        for (int i = 0; i < game.AwayTeam.Players.Count; i++)
                        {
                            var player = game.AwayTeam.Players[i];
                            int playerX = (int)player.X;
                            int playerY = (int)player.Y;
                            if (x == playerX && y == playerY)
                            {
                                playerChar = (char)('6' + i); // Номера от 6 до 16
                            }
                        }

                        // Проверяем, где находится мяч
                        // Kontrollime, kus pall asub
                        if (x == (int)game.Ball.X && y == (int)game.Ball.Y)
                        {
                            Console.Write('O'); // Символ мяча
                        }
                        else
                        {
                            Console.Write(playerChar); // Выводим символ игрока или пробел
                        }
                    }
                }
                Console.WriteLine(); // Переход на новую строку
            }
        }

        static void DisplayGameStatus(Game game)
        {
            // Отображаем позицию мяча
            // Kuvame palli positsiooni
            Console.WriteLine($"Palli asukoht: ({game.Ball.X}, {game.Ball.Y})");
            Console.WriteLine();
        }
    }

    

    
}

