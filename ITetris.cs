using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    interface ITetris
    {
        /// <summary>
        /// Draws the screen i.e. borders, figures, etc.
        /// </summary>
        /// <param name="nScreenId">0 - Main Menu; 1 - Game</param>
        /// <param name="bIsGameOver">Is the game over?</param>
        void Draw(int nScreenId, bool bIsGameOver);
        /// <summary>
        /// Generate a new figure at the top of the screen.
        /// </summary>
        void GenerateFigure();
        /// <summary>
        /// Move the current figure in the specified direction.
        /// </summary>
        /// <param name="mdMove">Move direction</param>
        void MoveCurrentFigure(MoveDirection mdMove);
        /// <summary>
        /// Rotate the current figure in the specified direction.
        /// </summary>
        /// <param name="mdMove">Rotate direction</param>
        void RotateCurrentFigure(RotateDirection rdRotate);
        /// <summary>
        /// Reset the game;
        /// </summary>
        void Reset();
        /// <summary>
        /// Checks whether the game is over
        /// </summary>
        /// <returns>True if the game is over, otherwise False</returns>
        bool IsGameOver();
    }
}