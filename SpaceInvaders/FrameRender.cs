using SpaceInvaders.Objects;
using System.Text;

namespace SpaceInvaders
{
    internal class FrameRender
    {
        readonly GameSettings gameSettings;

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

        private void RenderScore(Frame frame)
        {
            Console.SetCursorPosition(gameSettings.ScorePositionLeft, gameSettings.ScorePositionTop);

            StringBuilder sb = new StringBuilder();

            sb.Append("Invaders left: ");
            sb.Append(AddSpaceToNumber(frame.Invaders.Count));
            sb.Append("   ");
            sb.Append("Earth left: ");
            sb.Append(AddSpaceToNumber(frame.Earths.Count - gameSettings.MinimumEarth));
            sb.Append("   ");
            sb.Append("Missiles shot: ");
            sb.Append(AddSpaceToNumber(frame.PlayerMissileQuantity));
            sb.Append("   ");
            sb.Append("Invaders shot: ");
            sb.Append(AddSpaceToNumber(frame.InvaderMissileQuantity));

            Console.WriteLine(sb.ToString());
            Console.SetCursorPosition(0, 0);
        }

        public void Render(Frame frame)
        {
            AddListToMatrix(frame.Invaders);
            AddListToMatrix(frame.Earths);
            AddListToMatrix(frame.PlayerMissiles);
            AddPointToMatrix(frame.PlayerShip);
            AddListToMatrix(frame.InvaderMissiles);

            Render();
            RenderScore(frame);
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

        private void AddListToMatrix(List<Point> points)
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

        private string AddSpaceToNumber(int number)
        {
            string result = number.ToString();

            if (result.Length == 1)
            {
                result = "  " + result;
            }
            else if (result.Length == 2)
            {
                result = " " + result;
            }

            return result;

        }
    }
}
