using System;
using System.Collections.Generic;
using System.Text;

namespace LOD_Runner_2.MatrixElements
{
    class Enemy : MatrixElement
    {
        public Enemy(object x, object y)
        {
            X = (int)x;
            Y = (int)y;
            Icon = "T";
        }
        public void Insert_In_Matrix(object x)
        {

            int x1 = (int)x;

            if (x1 < Field.size_x && x1 >= 0 && !((Field.gameField[Y, x1]) is Block))
                X = x1;
        }
    }
}

