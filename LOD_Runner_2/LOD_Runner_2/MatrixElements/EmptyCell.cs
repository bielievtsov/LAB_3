using System;
using System.Collections.Generic;
using System.Text;

namespace LOD_Runner_2.MatrixElements
{
    class EmptyCell : MatrixElement
    {
        public EmptyCell(int x, int y)
        {
            x = X;
            y = Y;
            Icon = " "; 
        }
    }
}
