using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    static class Test
    {
        public static void Stack(Tetris tTetris)
        {
            while (!tTetris.IsGameOver())
            {
                if (tTetris.Game.Figures.Count > 0)
                    tTetris.Game.Figures.Last().Move(MoveDirection.Down);
                if (tTetris.Game.Figures.Count > 0 && tTetris.Game.Figures.Last().IsLanded())
                {
                    tTetris.Game.Figures.Last().Landed();
                    tTetris.GenerateFigure();
                }
                else if (tTetris.Game.Figures.Count == 0)
                    tTetris.GenerateFigure();

                tTetris.Draw();
                Thread.Sleep(Const.nGameSpeed);
            }
        }
        public static void MoveRight(Tetris tTetris)
        {
            while (!tTetris.IsGameOver())
            {
                goto MoveRight_Run;
            MoveRight_Landed:
                tTetris.Game.Figures.Last().Landed();
                tTetris.GenerateFigure();
                goto MoveRight_Sleep;
            MoveRight_Run:
                tTetris.Draw();
                if (tTetris.Game.Figures.Count > 0)
                {
                    if (new List<int>() { 2, 3 }.Contains(tTetris.Game.Figures.Last().Move(MoveDirection.Down)))
                        goto MoveRight_Landed;
                    tTetris.Game.Figures.Last().Move(MoveDirection.Right);
                }
                else if (tTetris.Game.Figures.Count == 0)
                    tTetris.GenerateFigure();

                MoveRight_Sleep:
                Thread.Sleep(Const.nGameSpeed);
            }
        }
        public static void MoveLeft(Tetris tTetris)
        {
            while (!tTetris.IsGameOver())
            {
                goto MoveLeft_Run;
            MoveLeft_Landed:
                tTetris.Game.Figures.Last().Landed();
                tTetris.GenerateFigure();
                goto MoveLeft_Sleep;
            MoveLeft_Run:
                tTetris.Draw();
                if (tTetris.Game.Figures.Count > 0)
                {
                    if (new List<int>() { 2, 3 }.Contains(tTetris.Game.Figures.Last().Move(MoveDirection.Down)))
                        goto MoveLeft_Landed;
                    tTetris.Game.Figures.Last().Move(MoveDirection.Left);
                }
                else if (tTetris.Game.Figures.Count == 0)
                    tTetris.GenerateFigure();

                MoveLeft_Sleep:
                Thread.Sleep(Const.nGameSpeed);
            }
        }
        public static void MoveRightLeft(Tetris tTetris)
        {
            Random rRand = new Random();
            while (!tTetris.IsGameOver())
            {
                goto MoveRightLeft_Run;
            MoveRightLeft_Landed:
                tTetris.Game.Figures.Last().Landed();
                tTetris.GenerateFigure();
                goto MoveRightLeft_Sleep;
            MoveRightLeft_Run:
                tTetris.Draw();
                if (tTetris.Game.Figures.Count > 0)
                {
                    if (new List<int>() { 2, 3 }.Contains(tTetris.Game.Figures.Last().Move(MoveDirection.Down)))
                        goto MoveRightLeft_Landed;
                    MoveDirection mdMove = rRand.Next(0, 2) == 0 ? MoveDirection.Left : MoveDirection.Right;
                    tTetris.Game.Figures.Last().Move(mdMove);
                }
                else if (tTetris.Game.Figures.Count == 0)
                    tTetris.GenerateFigure();

                MoveRightLeft_Sleep:
                Thread.Sleep(Const.nGameSpeed);
            }
        }
        public static void RotateClockwise(Tetris tTetris)
        {
            while (!tTetris.IsGameOver())
            {
                goto RotateClockwise_Run;
            RotateClockwise_Landed:
                tTetris.Game.Figures.Last().Landed();
                tTetris.GenerateFigure();
                goto RotateClockwise_Sleep;
            RotateClockwise_Run:
                tTetris.Draw();
                if (tTetris.Game.Figures.Count > 0)
                {
                    if (new List<int>() { 2, 3 }.Contains(tTetris.Game.Figures.Last().Move(MoveDirection.Down)))
                        goto RotateClockwise_Landed;
                    tTetris.Game.Figures.Last().Rotate(RotateDirection.Clockwise);
                }
                else if (tTetris.Game.Figures.Count == 0)
                    tTetris.GenerateFigure();

                RotateClockwise_Sleep:
                Thread.Sleep(Const.nGameSpeed);
            }
        }
        public static void RotateCounterClockwise(Tetris tTetris)
        {
            while (!tTetris.IsGameOver())
            {
                goto RotateCounterlockwise_Run;
            RotateCounterClockwise_Landed:
                tTetris.Game.Figures.Last().Landed();
                tTetris.GenerateFigure();
                goto RotateCounterClockwise_Sleep;
            RotateCounterlockwise_Run:
                tTetris.Draw();
                if (tTetris.Game.Figures.Count > 0)
                {
                    if (new List<int>() { 2, 3 }.Contains(tTetris.Game.Figures.Last().Move(MoveDirection.Down)))
                        goto RotateCounterClockwise_Landed;
                    tTetris.Game.Figures.Last().Rotate(RotateDirection.CounterClockwise);
                }
                else if (tTetris.Game.Figures.Count == 0)
                    tTetris.GenerateFigure();

                RotateCounterClockwise_Sleep:
                Thread.Sleep(Const.nGameSpeed);
            }
        }
    }
}
