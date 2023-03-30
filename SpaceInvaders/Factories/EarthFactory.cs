using SpaceInvaders.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Factories
{
    internal class EarthFactory : PointFactory
    {
        public EarthFactory(GameSettings gameSettings) : base(gameSettings)
        {
        }

        public List<Point> GetEarths()
        {
            List<Point> earths = new List<Point>();
            for (int j = 0; j < gameSettings.EarthCount; j++)
            {
                earths.Add(GetPoint(gameSettings.EarthStartPositionTop,
                                             gameSettings.EarthStartPositionLeft + j,
                                             gameSettings.Earth));
            }
            
            return earths;
        }

        public override Point GetPoint(int top, int left, char symbol)
        {
            return new Earth(top, left, symbol);
        }
    }
}
