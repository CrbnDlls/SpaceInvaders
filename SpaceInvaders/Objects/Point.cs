using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Objects
{
    internal class Point
    {
        private int top;
        private int left;
        private char symbol;

        public int Top 
        { 
            get => top;
            set => top = value;
        }

        public int Left 
        { 
            get => left; 
            set => left = value;
        }

        public char Symbol
        {
            get => symbol;
        }

        public Point(int top, int left, char symbol)
        {
            this.top = top;
            this.left = left;
            this.symbol = symbol;
        }
        public void Draw()
        {
            Console.SetCursorPosition(left, top);
            Console.Write(symbol);
        }

        public bool Compare(Point other)
        {
            return left == other.left && top == other.top;
        }

    }
}
