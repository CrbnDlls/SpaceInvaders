using SpaceInvaders.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Factories
{
    internal class MissileFactory : PointFactory
    {
        public MissileFactory(GameSettings gameSettings) : base(gameSettings)
        {
        }

        public Point GetPlayerMissile(int top, int left)
        {
            return GetPoint(top, left, gameSettings.PlayerMissile);
        }

        public Point GetInvaderMissile(int top, int left)
        {
            return GetPoint(top, left, gameSettings.InvaderMissile);
        }

        public override Point GetPoint(int top, int left, char symbol)
        {
            return new Missile(top, left, symbol);
        }
    }
}
