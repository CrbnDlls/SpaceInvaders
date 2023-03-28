using SpaceInvaders.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Factories
{
    internal class InvadersFactory
    {
        readonly GameSettings gameSettings;
        public InvadersFactory(GameSettings gameSettings) 
        {
            this.gameSettings = gameSettings;
        }

        public List<InvaderShip> GetInvaders()
        {
            List<InvaderShip> invaders = new List<InvaderShip>();
            for (int i = 0; i < gameSettings.InvadersLines; i++)
            {
                for (int j = 0; j < gameSettings.InvadersCount; j++)
                {
                    invaders.Add(new InvaderShip(gameSettings.InvadersStartPositionTop + i,
                                                 gameSettings.InvadersStartPositionLeft + j, 
                                                 gameSettings.InvadersShip));
                }
            }
            return invaders;
        }
    }
}
