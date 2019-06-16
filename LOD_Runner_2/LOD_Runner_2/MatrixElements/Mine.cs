using System;
using System.Collections.Generic;
using System.Text;

namespace LOD_Runner_2.MatrixElements
{
    class Mine : MatrixElement
    {
        public Mine(int X, int Y)
        {
            this.Y = Y;
            this.X = X;
            Icon = "+";
        }
    }
}
