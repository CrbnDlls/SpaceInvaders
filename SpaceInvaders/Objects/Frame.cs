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
        private readonly List<Point> invaders;
        private readonly List<Point> earths;
        private readonly List<Point> playerMissiles;
        private readonly Point playerShip;
        private readonly List<Point> invaderMissiles;


        private static Frame frame;

        public List<Point> Invaders { get => invaders; }
        public List<Point> Earths { get => earths; }
        public List<Point> PlayerMissiles { get => playerMissiles; }
        public Point PlayerShip { get => playerShip; }

        public List<Point> InvaderMissiles { get => invaderMissiles;  }

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

            playerMissiles = new List<Point>();

            invaderMissiles = new List<Point>();
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
