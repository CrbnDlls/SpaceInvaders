﻿using SpaceInvaders.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class FrameRender
    {
        GameSettings gameSettings;

        readonly char[,] screenMatrix;

        public FrameRender(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            screenMatrix = new char[gameSettings.ConsoleHeight, gameSettings.ConsoleWidth];
        }

        public void RenderGameOver()
        {
            screenMatrix[10, 45] = 'G';
            screenMatrix[10, 46] = 'a';
            screenMatrix[10, 47] = 'm';
            screenMatrix[10, 48] = 'e';
            screenMatrix[10, 49] = ' ';
            screenMatrix[10, 50] = 'O';
            screenMatrix[10, 51] = 'v';
            screenMatrix[10, 52] = 'e';
            screenMatrix[10, 53] = 'r';
            screenMatrix[10, 54] = '!';
            
            Render();
        }

        public void Render(Frame frame)
        {
            AddListToMatrix(frame.Invaders);
            AddListToMatrix(frame.Earths);
            AddListToMatrix(frame.PlayerMissiles);
            AddPointToMatrix(frame.PlayerShip);

            Render();
        }

        private void Render()
        {
            Console.SetCursorPosition(0, 0);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < screenMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < screenMatrix.GetLength(1); j++)
                {
                    sb.Append(screenMatrix[i, j]);
                }
                sb.Append(Environment.NewLine);
            }

            Console.WriteLine(sb.ToString());
            Console.SetCursorPosition(0, 0);
        }

        public void ClearFrame()
        {
            for (int i = 0; i < gameSettings.ConsoleHeight; i++)
            {
                for (int j = 0; j < gameSettings.ConsoleWidth; j++)
                {
                    screenMatrix[i, j] = ' ';
                }
            }

            Render();
        }

        private void AddListToMatrix<T>(List<T> points) where T : Point
        {
            foreach (Point point in points)
            {
                AddPointToMatrix(point);
            }
        }

        private void AddPointToMatrix(Point point)
        {
            screenMatrix[point.Top, point.Left] = point.Symbol;
        }
    }
}