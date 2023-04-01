using SpaceInvaders.Objects;

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
