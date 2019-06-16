using System;
using System.Threading;
using LOD_Runner_2.MatrixElements;

namespace LOD_Runner_2.MatrixElements
{
    class Hero : MatrixElement
    {
        public bool Status { get; set; } = true;
        public int TakenBonuses = 0;
        int denied_block = 0, x1, y1;
        public int HealthPoints { get; set; } = 3;
        public Hero(int X, int Y)
        {
            this.Icon = "I";
            this.X = X;
            this.Y = Y;
        }
        public int number_of_steps { get; set; }
        public string Name { get; set; }
        public int NumberOfPosibleBlicks { get; set; } = 4;
        public void Recreate(object s)
        {
            Field.gameField[y1, x1] = new Block(x1, y1);
        }
        public override void Insert_In_Matrix(int x, int y, ConsoleKeyInfo keyInfo)
        {
            try
            {
                if (x < Field.size_x && x >= 0 && y < Field.size_y && y >= 0)
                {
                    if (Field.gameField[y, x] is AddLife)
                    {
                        X = x;
                        Y = y;
                        Field.gameField[y, x] = new EmptyCell(x, y);
                        HealthPoints += 2;
                    }
                    if (Field.gameField[y, x] is ImmortalSubstence)
                    {
                        HealthPoints -= 2;
                        X = x;
                        Y = y;
                    }
                    if (keyInfo.Key == ConsoleKey.D && Field.gameField[y + 1, x] is Block)
                    {
                        X = x;
                        Y = y;
                        Field.gameField[y + 1, x] = new EmptyCell(x, y + 1);
                    }
                    if (keyInfo.Key == ConsoleKey.R && NumberOfPosibleBlicks != 0 && (Field.gameField[y - 1, x] is EmptyCell))
                    {
                        Field.gameField[y - 1, x] = new Block(y - 1, x);
                        NumberOfPosibleBlicks--;
                    }
                    if (((Field.gameField[y, x]) is Bomb))
                    {
                        HealthPoints--;
                        Field.gameField[y, x] = new EmptyCell(y, x);
                        Field.gameField[y + 1, x] = new EmptyCell(y + 1, x);
                        Field.gameField[y + 1, x + 1] = new EmptyCell(y + 1, x + 1);
                    }
                    if (((Field.gameField[y, x]) is Enemy))
                    {
                        Status = false;
                    }
                    if (!((Field.gameField[y, x]) is Block) && !((Field.gameField[y, x]) is ImmortalBlock))
                    {
                        X = x;
                        Y = y;
                    }
                    if (!((Field.gameField[y, x]) is Block) && Field.gameField[y, x] is Gold)
                    {
                        X = x;
                        Y = y;
                        Number_Of_Gold++;
                        Field.gameField[y, x] = new EmptyCell(x, y);
                    }
                    if (!((Field.gameField[y, x]) is Block) && Field.gameField[y, x] is Bonus)
                    {
                        X = x;
                        Y = y;
                        TakenBonuses++;
                        Field.gameField[y, x] = new EmptyCell(x, y);
                    }
                    if (Field.gameField[y, x] is Mine)
                    {
                        Field.gameField[y, x] = new EmptyCell(x, y);
                        HealthPoints--;
                        if (HealthPoints <= 0)
                            Status = false;
                    }
                    if (((Field.gameField[y + 1, x + 1]) is Block) && keyInfo.Key == ConsoleKey.Spacebar && !((Field.gameField[y + 1, x + 1]) is ImmortalBlock))
                    {
                        X = x;
                        Y = y;
                        Field.gameField[y + 1, x + 1] = new EmptyCell(x + 1, y + 1);
                        Field.gameField[y, x + 1] = new Bonus(y - 1, x + 2, "^");
                        denied_block++;
                        x1 = x + 1;
                        y1 = y + 1;
                    }
                    if (((Field.gameField[y + 1, x]) is EmptyCell) && !((Field.gameField[y, x]) is Ladder))
                    {
                        for (; !((Field.gameField[y, x]) is ImmortalBlock) && !(Field.gameField[y, x] is Block);)
                        {
                            X = x;
                            Y = y++;
                        }
                    }
                    if (Field.gameField[y, x] is AntiPrize)
                    {
                        Field.gameField[y, x] = new EmptyCell(y, x);
                        TakenBonuses -= 2;
                    }
                    number_of_steps++;
                }
            }
            catch
            {
                X = x;
                Y = y - 1;
            }
        }
        public int Number_Of_Gold { get; set;}
    }
}
