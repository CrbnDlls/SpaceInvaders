using SpaceInvaders.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Objects
{
    internal class Frame
    {
        private readonly List<InvaderShip> invaders;
        private readonly List<Earth> earths;
        private readonly List<Missile> playerMissiles;
        private readonly PlayerShip playerShip;

        private static Frame frame;

        public List<InvaderShip> Invaders { get => invaders; }
        public List<Earth> Earths { get => earths; }
        public List<Missile> PlayerMissiles { get => playerMissiles; }
        public PlayerShip PlayerShip { get => playerShip; }

        private GameSettings gameSettings;

        private Frame(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;

            InvadersFactory invadersFactory = new InvadersFactory(gameSettings);
            invaders = invadersFactory.GetInvaders();

            EarthFactory earthFactory = new EarthFactory(gameSettings);
            earths = earthFactory.GetEarths();

            playerShip = new PlayerShip(gameSettings.PlayerShipStartPositionTop,
                                        gameSettings.PlayerShipStartPositionLeft,
                                        gameSettings.PlayerShip);

            playerMissiles = new List<Missile>();
        }

        public static Frame GetFrame(GameSettings gameSettings)
        {
            if (frame == null)
            {
                frame = new Frame(gameSettings);
            }

            return frame;
        }

        

        
    }
}
