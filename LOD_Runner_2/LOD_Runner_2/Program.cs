using System;
using System.Threading;
using LOD_Runner_2.MatrixElements;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace LOD_Runner_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("<<<< HERE WE STARTNG ON >>>>");
            Console.Write("\n");
            Console.WriteLine("<<<<  U CONTROL HERO I  >>>>");
            Console.WriteLine("<<<< U CAN USE LADDER '|'>>>");
            Console.WriteLine("<<<<     OR ROPE '-'    >>>>");
            Console.WriteLine("<<<< TO MOVE UP OR DOWN >>>>");
            Console.WriteLine("<<<<  HERE UR ENEMY 'T' >>>>");
            Console.WriteLine("<<<< AND TRAP For U '+' >>>>");
            Console.WriteLine("<<<< U CAN DESRTROY '#' >>>>");
            Console.WriteLine("<<< U CAN`t DESRTROY 'X' >>>");
            Console.WriteLine("<<U CAN TAKE SOME BONUSES>>>");
            Console.WriteLine("<<<< IT CAN DESTROY 'O' >>>>");
            Console.WriteLine("<<<< THIS IS '+' A MINE >>>>");
            Console.WriteLine("<<<<       FOR U :)     >>>>");
            Console.WriteLine("<<<< SOME '*' BONUS LIFE>>>>");
            Console.Write("\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Hero hero = new Hero(9, 5);
            Enemy enemy = new Enemy(6, 5);

            Console.WriteLine($"TYPE IN UR NAME HERE, PLS ^__^");
            hero.Name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"Hello, {hero.Name}, WISH U ONLY TO WIN :-)");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            Field newField = new Field();
            Field.gameField = newField.load_lvl("Field.json");

            void Draw(object xx)
            {
                Console.Clear();
                newField.Draw(hero, enemy);
                Console.WriteLine($"U HAVE {hero.HealthPoints} HEALTH POINTS");
                Console.WriteLine($"U HAVE {hero.NumberOfPosibleBlicks} TO CREATE NEW BLOCKS");
                Console.WriteLine($"U HAVE MADE {hero.number_of_steps} STEPS");
                Console.WriteLine($"U HAVE TAKEN {hero.Number_Of_Gold} GOLD");
                Console.WriteLine($"NUMBER OF BONUSES IF {hero.TakenBonuses}");
            }

            if (hero.Status != false)
            {

                int x1 = enemy.X, y1 = enemy.Y;
                TimerCallback t = new TimerCallback(hero.Recreate);
                Timer timer4 = new Timer(t, null, 0, 1500);
                TimerCallback tm = new TimerCallback(enemy.Insert_In_Matrix);
                Timer timer = new Timer(tm, x1 + 1, 0, 1000);
                Timer timer1 = new Timer(tm, x1 + 1, 0, 700);
                Timer timer2 = new Timer(tm, x1 - 1, 2, 500);
                TimerCallback tm1 = new TimerCallback(Draw);
                Timer timer22 = new Timer(tm1, x1 + 1, 0, 350);
                
                while (hero.Status == true)
                {
                    if (Console.KeyAvailable)
                    {
                        int x = hero.X, y = hero.Y;
                        var keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.Escape)
                            hero.Status = false;
                        if (keyInfo.Key == ConsoleKey.RightArrow)
                            hero.Insert_In_Matrix(x + 1, y, keyInfo);
                        if (keyInfo.Key == ConsoleKey.LeftArrow)
                            hero.Insert_In_Matrix(x - 1, y, keyInfo);
                        if (keyInfo.Key == ConsoleKey.DownArrow)
                            hero.Insert_In_Matrix(x, y + 1, keyInfo);
                        if (keyInfo.Key == ConsoleKey.UpArrow)
                            hero.Insert_In_Matrix(x, y - 1, keyInfo);
                        if (keyInfo.Key == ConsoleKey.Spacebar)
                            hero.Insert_In_Matrix(x, y, keyInfo);
                        if (keyInfo.Key == ConsoleKey.R)
                            hero.Insert_In_Matrix(x, y, keyInfo);
                        if (hero.Number_Of_Gold == newField.Number_Of_Gold())
                        {
                            hero = new Hero(4, 1);
                            newField.load_lvl("Field.json");
                            hero.Number_Of_Gold = 0;
                        }
                        if (keyInfo.Key == ConsoleKey.D)
                            hero.Insert_In_Matrix(x, y, keyInfo);
                        if (hero.HealthPoints <= 0)
                        {
                            hero.Status = false;
                        }
                    }
                }
            }
        
        }
    }
}
