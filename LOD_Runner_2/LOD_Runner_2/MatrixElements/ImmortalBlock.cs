using System;
using System.Collections.Generic;
using System.Text;

namespace LOD_Runner_2.MatrixElements
{
    class ImmortalBlock : Block
    {
        public ImmortalBlock(int X, int Y) : base(X, Y)
        {
            this.X = X;
            this.Y = Y;
            Icon = "X";
        }
    }
}
