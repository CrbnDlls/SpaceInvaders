using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Objects
{
    internal class PlayerShip : Point
    {
        public PlayerShip(int top, int left, char symbol) : base(top, left, symbol)
        {
        }
    }
}
