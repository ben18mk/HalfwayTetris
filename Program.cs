using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        static Tetris tTetris;

        static void actOnLanded()
        {
            tTetris.Game.Figures.Last().Landed();
            tTetris.GenerateFigure();
            tTetris.Draw();
            Thread.Sleep(Const.nGameSpeed);
        }

        static bool checkInput()
        {
            if (!Console.KeyAvailable)
                return false;
            ConsoleKeyInfo ckiKey = Console.ReadKey(true);
            switch (ckiKey.Key)
            {
                case ConsoleKey.D:
                    tTetris.MoveCurrentFigure(MoveDirection.Right);
                    break;
                case ConsoleKey.A:
                    tTetris.MoveCurrentFigure(MoveDirection.Left);
                    break;
                case ConsoleKey.E:
                    tTetris.RotateCurrentFigure(RotateDirection.Clockwise);
                    break;
                case ConsoleKey.Q:
                    tTetris.RotateCurrentFigure(RotateDirection.CounterClockwise);
                    break;
                case ConsoleKey.Escape:
                    return true;
                default:
                    return false;
            }
            tTetris.Draw();
            return false;
        }

        static void Main(string[] args)
        {
            tTetris = new Tetris();
            bool bQuit = false;

            while (true)
            {
                tTetris.Draw(0);
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    Environment.Exit(0);

                tTetris.Game.PlayTheme();

                while (!tTetris.IsGameOver())
                {
                    if (tTetris.Game.Figures.Count > 0)
                    {
                        if (new List<int>() { 2, 3 }.Contains(tTetris.Game.Figures.Last().Move(MoveDirection.Down)))
                        {
                            actOnLanded();
                            continue;
                        }
                        if (bQuit = checkInput())
                            break;
                    }
                    else if (tTetris.Game.Figures.Count == 0)
                        tTetris.GenerateFigure();

                    tTetris.Draw();
                    Thread.Sleep(Const.nGameSpeed);
                }

                if (!bQuit)
                    tTetris.Draw(bIsGameOver: true);
                tTetris.Reset();
            }
        }
    }
}
