using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Tetris : ITetris
    {
        private GameInfo giGame;
        public Tetris(int nWidth = Const.nMinWidth, int nHeight = Const.nMinHeight)
        {
            this.giGame = new GameInfo(nWidth, nHeight);
        }
        public GameInfo Game { get => this.giGame; }

        private void writeColored(string strText, ConsoleColor ccColor = ConsoleColor.Blue)
        {
            Console.ForegroundColor = ccColor;
            Console.Write(strText);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void drawMainMenu()
        {
            int nOffset = 0;
            string strPressE = "- Press E to rotate Right".Center(this.giGame.Width, out nOffset);

            Console.WriteLine();
            Console.WriteLine("╔" + "".FillChar('═', this.giGame.Width - 2) + "╗");
            Console.WriteLine("║" + "".FillChar('─', this.giGame.Width - 2) + "║");
            Console.WriteLine("║" + (" Tetris | Тетрис " + "".FillChar('─', (this.giGame.Width - 2 - " Tetris ┼ Тетрис ".Length) / 2)).FillChar('─', (this.giGame.Width - 2 - " Tetris | Тетрис ".Length) / 2 + (this.giGame.Width % 2 == 0 ? 1 : 0)) + "║");
            Console.WriteLine("║" + "".FillChar('─', this.giGame.Width - 2) + "║");
            Console.WriteLine("╚" + "".FillChar('═', this.giGame.Width - 2) + "╝");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("PRESS ANY KEY TO PLAY :)".Center(this.giGame.Width));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("- Press D to move Right".FillChar(' ', nOffset));
            Console.WriteLine("- Press A to move Left".FillChar(' ', nOffset));
            Console.WriteLine(strPressE);
            Console.WriteLine("- Press Q to rotate Left".FillChar(' ', nOffset));
            Console.WriteLine("- Press ESC to Quit".FillChar(' ', nOffset));
        }

        public void Draw(int nScreen = 1, bool bIsGameOver = false)
        {
            Console.Clear();
            
            if (nScreen == 0)
            {
                drawMainMenu();
                return;
            }

            var figurePoints = (from f in this.giGame.Figures
                               let points = f.Points.Value
                               where points != null
                               from p in points
                               select new KeyValuePair<Point, char>(p, f.Fill)).ToList();
            for (int i = 0; i < this.giGame.Height; i++)
            {
                for (int j = 0; j < this.giGame.Width; j++)
                {
                    // Draw Borders
                    if (i == 0 && j == 0)
                        writeColored("╔");
                    else if (i == 0 && j == this.giGame.Width - 1)
                        writeColored("╗");
                    else if (i == this.giGame.Height - 1 && j == this.giGame.Width - 1)
                        writeColored("╝");
                    else if (i == this.giGame.Height - 1 && j == 0)
                        writeColored("╚");
                    else if (i == 0 || i == this.giGame.Height - 1)
                        writeColored("═");
                    else if (j == 0 || j == this.giGame.Width - 1)
                        writeColored("║");
                    // Draw Figures
                    else if (figurePoints.Select(x => x.Key).Contains(new Point(j, i)))
                        Console.Write(figurePoints.Find(x => x.Key == new Point(j, i)).Value);
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Score: {this.giGame.Score}".Center(this.giGame.Width));
            if (bIsGameOver)
            {
                this.giGame.PlayGameOver();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Game Over".Center(this.giGame.Width));
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Read();
            }
        }
        public void GenerateFigure()
            => this.giGame.GenerateFigure();
        public void MoveCurrentFigure(MoveDirection mdMove)
            => this.giGame.Figures.Last().Move(mdMove);
        public void RotateCurrentFigure(RotateDirection rdRotate)
            => this.giGame.Figures.Last().Rotate(rdRotate);
        public void Reset()
            => this.giGame.Reset();
        public bool IsGameOver()
            => this.Game.Figures.Count > 0 && this.Game.Figures.Last().IsGaveOver();
    }
}