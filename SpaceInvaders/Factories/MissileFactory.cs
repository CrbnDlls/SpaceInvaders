using SpaceInvaders.Objects;

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
