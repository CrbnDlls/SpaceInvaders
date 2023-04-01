using SpaceInvaders.Factories;

namespace SpaceInvaders.Objects
{
    internal class Frame
    {
        private List<Point> invaders;
        private List<Point> earths;
        private List<Point> playerMissiles;
        private Point playerShip;
        private List<Point> invaderMissiles;


        private static Frame? frame;
        public int PlayerMissileQuantity { get; private set; }
        public int InvaderMissileQuantity { get; private set; } 
        public List<Point> Invaders { get => invaders; }
        public List<Point> Earths { get => earths; }
        public List<Point> PlayerMissiles { get => playerMissiles; }
        public Point PlayerShip { get => playerShip; }

        public List<Point> InvaderMissiles { get => invaderMissiles; }

        private readonly GameSettings gameSettings;

        private Frame(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;

            Initialize();
        }

        public void Initialize()
        {
            InvadersFactory invadersFactory = new InvadersFactory(gameSettings);
            invaders = invadersFactory.GetInvaders();

            EarthFactory earthFactory = new EarthFactory(gameSettings);
            earths = earthFactory.GetEarths();

            playerShip = new PlayerShip(gameSettings.PlayerShipStartPositionTop,
                                        gameSettings.PlayerShipStartPositionLeft,
                                        gameSettings.PlayerShip);

            playerMissiles = new List<Point>();

            invaderMissiles = new List<Point>();

            PlayerMissileQuantity = 0;

            InvaderMissileQuantity = 0;
        }

        public static Frame GetFrame(GameSettings gameSettings)
        {
            if (frame == null)
            {
                frame = new Frame(gameSettings);
            }

            return frame;
        }

        public void AddPlayerMissile()
        {
            MissileFactory missileFactory = new MissileFactory(gameSettings);
            PlayerMissiles.Add(missileFactory.GetPlayerMissile(PlayerShip.Top - 1, PlayerShip.Left));
            PlayerMissileQuantity++;
        }

        public void AddInvaderMissile()
        {
            Random random = new Random();

            int invaderIndex = random.Next(0, frame.Invaders.Count - 1);

            Point invader = frame.Invaders[invaderIndex];

            MissileFactory missileFactory = new MissileFactory(gameSettings);

            invaderMissiles.Add(missileFactory.GetInvaderMissile(invader.Top + 1, invader.Left));

            InvaderMissileQuantity++;
        }
    }
}
