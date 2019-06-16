using System;
using LOD_Runner_2.MatrixElements;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace LOD_Runner_2
{
    class Field
    {        
        public const int size_y = 10;
        public const int size_x = 20;
        public static MatrixElement[,] gameField = new MatrixElement[size_y, size_x];

        public MatrixElement this[int x, int y]
        {
            get => gameField[y, x];
            set => gameField[y, x] = value;
        }

        public string[,] field;

        public MatrixElement[,] load_lvl(string name)
        {
            Field newField = new Field();
            field = JsonConvert.DeserializeObject<string[,]>(File.ReadAllText(name));
            for (int i = 0; i < size_y; i++)
            {
                for (int j = 0; j < size_x; j++)
                {
                    switch (field[i, j])
                    {
                        case "*": gameField[i, j] = new AddLife(i, j); break;
                        case "&": gameField[i, j] = new ImmortalSubstence(i, j); break;
                        case "O": gameField[i, j] = new Bomb(i, j); break;
                        case "%": gameField[i, j] = new AntiPrize(i, j); break;
                        case "-": gameField[i, j] = new Ladder(i, j, "-"); break;
                        case "=": gameField[i, j] = new Bonus(i, j, "="); break;
                        case "~": gameField[i, j] = new Bonus(i, j, "~"); break;
                        case "#": gameField[i, j] = new Block(i, j) ; break;
                        case "X": gameField[i, j] = new ImmortalBlock(i, j); break;
                        case "|": gameField[i, j] = new Ladder(i, j, "|"); break;
                        case "@": gameField[i, j] = new Gold(i, j); break;
                        case "+": gameField[i, j] = new Mine(i, j); break;                      
                        default: gameField[i, j] =  new EmptyCell(i, j); break;
                    }
                }
            }
            return gameField;
        }

        public void SSS()
        {
            File.WriteAllText("Field.json", JsonConvert.SerializeObject(field));
        }
        
        public int Number_Of_Gold()
        {
            int res = 0;
            for (int n = 0; n < size_y; n++)
                for (int j = 0; j < size_x; j++)
                    if (field[n, j] == "@")res++;                        
            return res;
        }

        public void Draw(Hero player, MatrixElement enemy)
        {
            for (int i = 0; i < size_y; i++)
            {
                for (int j = 0; j < size_x; j++)
                {
                    if(gameField[i, j] is Block)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if(gameField[i, j] is Bonus)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if(gameField[i, j] is ImmortalBlock)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if(gameField[i, j] is ImmortalSubstence)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if(gameField[i, j] is Ladder)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else if(gameField[i, j] is Gold)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if(gameField[i, j] is Bomb)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    if (i == player.Y && j == player.X)
                    {
                        player.Draw(player.Icon);
                    }
                    else if (i == enemy.Y && j == enemy.X)
                    {
                        enemy.Draw(enemy.Icon);
                    }
                    else if (enemy.Y == player.Y && enemy.X == player.X)
                    {
                        player.Status = false;
                    }
                    else Console.Write(gameField[i, j].Icon);                       
                }
                Console.Write("\n");
            }
        }
    }
}
