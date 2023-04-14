using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public struct Point
    {
        private int nX;
        private int nY;

        public Point(int nX, int nY)
        {
            this.nX = nX;
            this.nY = nY;
        }

        public int X { get => this.nX; set => this.nX = value; }
        public int Y { get => this.nY; set => this.nY = value; }

        public static bool operator ==(Point pA, Point pB)
            => pA.nX == pB.nX && pA.nY == pB.nY;
        public static bool operator !=(Point pA, Point pB)
            => !(pA == pB);

        public Point AddX()
            => new Point(nX + 1, nY);
        public Point SubX()
            => new Point(nX - 1, nY);
        public Point AddY()
            => new Point(nX, nY + 1);
    }
}
