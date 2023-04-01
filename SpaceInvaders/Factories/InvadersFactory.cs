using SpaceInvaders.Objects;

namespace SpaceInvaders.Factories
{
    internal class InvadersFactory : PointFactory
    {

        public InvadersFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }

        public List<Point> GetInvaders()
        {
            List<Point> invaders = new List<Point>();
            for (int i = 0; i < gameSettings.InvadersLines; i++)
            {
                for (int j = 0; j < gameSettings.InvadersCount; j++)
                {
                    invaders.Add(GetPoint(gameSettings.InvadersStartPositionTop + i,
                                                 gameSettings.InvadersStartPositionLeft + j,
                                                 gameSettings.InvadersShip));
                }
            }
            return invaders;
        }

        public override Point GetPoint(int top, int left, char symbol)
        {
            return new InvaderShip(top, left, symbol);
        }
    }
}
