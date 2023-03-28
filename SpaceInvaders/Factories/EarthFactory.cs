using SpaceInvaders.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Factories
{
    internal class EarthFactory
    {
        readonly GameSettings gameSettings;
        public EarthFactory(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
        }

        public List<Earth> GetEarths()
        {
            List<Earth> earths = new List<Earth>();
            for (int j = 0; j < gameSettings.EarthCount; j++)
            {
                earths.Add(new Earth(gameSettings.EarthStartPositionTop,
                                             gameSettings.EarthStartPositionLeft + j,
                                             gameSettings.Earth));
            }
            
            return earths;
        }
    }
}
