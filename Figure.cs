using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Figure
    {
        private char cFill;
        private KeyValuePair<char, List<Point>> clpPoints;
        private GameInfo giGame;
        private int nRotationState;
        private int nMid;

        public Figure(GameInfo giGame)
        {
            this.giGame = giGame;
            this.nRotationState = 1;

            Random rRand = new Random();
            generateFill(rRand);
            generateFigure(rRand);
        }

        public char Fill { get => this.cFill; }
        public KeyValuePair<char, List<Point>> Points { get => this.clpPoints; }

        private void generateFill(Random rRand)
        {
            this.cFill = BaseArrays.cChars[rRand.Next(BaseArrays.cChars.Length)];
        }
        private void generateFigure(Random rand)
        {
            this.nMid = this.giGame.Width / 2 - 1;
            char cFigId = BaseArrays.cFigureIds[rand.Next(BaseArrays.cFigureIds.Length)];
            this.clpPoints = BaseArrays.FigPoints(cFigId, this.nRotationState, this.nMid);

            if (isIntersectingAnUnpassable(this.clpPoints.Value) != 0)
                this.clpPoints = new KeyValuePair<char, List<Point>>('\0', null);
        }
        /// <summary>
        /// Checks if the figure will touch any border or unpassable
        /// </summary>
        /// <param name="pFig">Figure points</param>
        /// <returns>0 - Clear; 1 - Will touch an unpassable; 2 - Landed; 3 - Unpassable & Landed</returns>
        private int isIntersectingAnUnpassable(List<Point> pFig)
        {
            int nUnpassable = 0;
            int nLanded = 0;
            foreach (var p in pFig)
            {
                if (p.X <= 0 || p.X >= this.giGame.Width - 1 || this.giGame.Unpassables.Contains(p))
                    nUnpassable = 1;
                if (this.giGame.BottomBorder[p.X].Contains(p.Y))
                    nLanded = 2;
            }
            return nUnpassable + nLanded;
        }
        private int getTopY()
            => this.clpPoints.Value.Select(x => x.Y).Min();
        private int getBottomY()
            => this.clpPoints.Value.Select(x => x.Y).Max();

        /// <summary>
        /// Move the figure
        /// </summary>
        /// <param name="mdMove">Direction</param>
        /// <returns>0 - OK; 1 - Unpassable; 2 - Landed; 3 - Unpassable & Landed</returns>
        public int Move(MoveDirection mdMove)
        {
            var tempPoint = new List<Point>(this.clpPoints.Value);
            for (int i = 0; i < this.clpPoints.Value.Count; i++)
            {
                switch (mdMove)
                {
                    case MoveDirection.Down:
                        tempPoint[i] = tempPoint[i].AddY();
                        break;
                    case MoveDirection.Right:
                        tempPoint[i] = tempPoint[i].AddX();
                        break;
                    case MoveDirection.Left:
                        tempPoint[i] = tempPoint[i].SubX();
                        break;
                }
            }

            int nReturnCode = isIntersectingAnUnpassable(tempPoint);
            if (nReturnCode == 1 && mdMove != MoveDirection.Down ||
                nReturnCode == 2 && mdMove == MoveDirection.Down ||
                nReturnCode == 3)
                return nReturnCode;

            this.clpPoints = new KeyValuePair<char, List<Point>>(this.clpPoints.Key, tempPoint);
            switch (mdMove)
            {
                case MoveDirection.Down:
                    break;
                case MoveDirection.Right:
                    this.nMid++;
                    break;
                case MoveDirection.Left:
                    this.nMid--;
                    break;
            }
            return 0;
        }
        public void Rotate(RotateDirection rdRotate)
        {
            switch (rdRotate)
            {
                case RotateDirection.Clockwise:
                    this.nRotationState = this.nRotationState == BaseArrays.nFigureMaxRotationState[this.clpPoints.Key] ? 1 : this.nRotationState + 1;
                    break;
                case RotateDirection.CounterClockwise:
                    this.nRotationState = this.nRotationState == 1 ? BaseArrays.nFigureMaxRotationState[this.clpPoints.Key] : this.nRotationState - 1;
                    break;
            }
            var tempFig = BaseArrays.FigPoints(this.clpPoints.Key, this.nRotationState, this.nMid, this.getTopY());
            if (this.isIntersectingAnUnpassable(tempFig.Value) != 0)
                return;
            this.clpPoints = tempFig;
        }
        public bool IsLanded()
        {
            foreach (var p in this.clpPoints.Value)
                if (this.giGame.BottomBorder[p.X].Contains(p.Y + 1))
                    return true;
            return false;
        }
        public void Landed()
        {
            foreach (var p in this.clpPoints.Value)
            {
                this.giGame.BottomBorder[p.X].Add(p.Y);
                this.giGame.Unpassables.Add(p);
            }
            this.giGame.AddLandScore();
        }
        public bool IsGaveOver()
            => this.clpPoints.Key == '\0';
    }
}
