using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    class GameInfo
    {
        private int nWidth;
        private int nHeight;
        private int nScore;
        private SoundPlayer spTheme;
        private SoundPlayer spGameOver;
        private List<Figure> lfFigures;
        private List<Point> lpUnpassables;
        private Dictionary<int, List<int>> dnlnBottomBorder;

        public GameInfo(int nWidth = Const.nMinWidth, int nHeight = Const.nMinHeight)
        {
            this.nWidth = nWidth >= Const.nMinWidth ? nWidth : Const.nMinWidth;
            this.nHeight = nHeight >= Const.nMinHeight ? nHeight : Const.nMinHeight;
            this.spTheme = new SoundPlayer(global::Tetris.Properties.Resources.theme);
            this.spGameOver = new SoundPlayer(global::Tetris.Properties.Resources.game_over);
            Reset();

            Console.SetWindowSize(nWidth, nHeight + 6);
            Console.Title = "Tetris | Тетрис";
            Console.CursorVisible = false;
        }

        public int Width { get => this.nWidth; }
        public int Height { get => this.nHeight; }
        public int Score { get => this.nScore; }
        public List<Figure> Figures { get => this.lfFigures; }
        public List<Point> Unpassables { get => this.lpUnpassables; }
        public Dictionary<int, List<int>> BottomBorder { get => this.dnlnBottomBorder; }

        public void GenerateFigure()
            => this.lfFigures.Add(new Figure(this));
        public void AddLandScore()
            => this.nScore += 10;
        public void Reset()
        {
            this.spTheme.Stop();
            this.nScore = 0;
            this.lfFigures = new List<Figure>();
            this.lpUnpassables = new List<Point>();
            this.dnlnBottomBorder = new Dictionary<int, List<int>>();

            for (int i = 0; i < this.nWidth; i++)
                this.dnlnBottomBorder[i] = new List<int>() { this.nHeight - 1 };
        }
        public void PlayTheme()
            => this.spTheme.PlayLooping();
        public void PlayGameOver()
            => this.spGameOver.Play();
    }
}