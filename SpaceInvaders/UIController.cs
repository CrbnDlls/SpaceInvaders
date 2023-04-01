using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class UIController
    {
        public event EventHandler OnArrowLeftPress;
        public event EventHandler OnArrowRightPress;
        public event EventHandler OnSpacePress;
        public event EventHandler OnQPress;
        public event EventHandler OnPPress;
        public event EventHandler OnEscapePress;
        public event EventHandler OnEnterPress;

        public void StartListen()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    PushEvent(Console.ReadKey(true).Key);
                }
            }
        }

        private void PushEvent(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Q:
                    OnQPress?.Invoke(this, EventArgs.Empty);
                    break;
                case ConsoleKey.Escape:
                    OnEscapePress?.Invoke(this, EventArgs.Empty);
                    break;
                case ConsoleKey.Enter:
                    OnEnterPress?.Invoke(this, EventArgs.Empty);
                    break;
                case ConsoleKey.LeftArrow:
                    OnArrowLeftPress?.Invoke(this, EventArgs.Empty);
                    break;
                case ConsoleKey.RightArrow:
                    OnArrowRightPress?.Invoke(this, EventArgs.Empty);
                    break;
                case ConsoleKey.Spacebar:
                    OnSpacePress?.Invoke(this, EventArgs.Empty);
                    break;
                case ConsoleKey.P:
                    OnPPress?.Invoke(this, EventArgs.Empty);
                    break;
            }
        }
    }
}
