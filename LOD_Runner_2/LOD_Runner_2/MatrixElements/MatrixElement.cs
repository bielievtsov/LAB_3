using System;
using System.Collections.Generic;
using System.Text;
using LOD_Runner_2;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using LOD_Runner_2.MatrixElements;

namespace LOD_Runner_2.MatrixElements
{

    abstract class MatrixElement
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Icon { get; set; }
        public virtual void Insert_In_Matrix(int x, int y,ConsoleKeyInfo keyInfo)
        {
            if (x < Field.size_y && x >= 0 && y < Field.size_x && y >= 0)
            {
                X = x;
                Y = y;
            }
        }
        public virtual void Draw(string Icon)
        {
            Console.Write(Icon);
        }
    }
}
