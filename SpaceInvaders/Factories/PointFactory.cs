using SpaceInvaders.Objects;

namespace SpaceInvaders.Factories
{
    internal abstract class PointFactory
    {
        protected readonly GameSettings gameSettings;
        protected PointFactory(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
        }

        public abstract Point GetPoint(int top, int left, char symbol);
    }
}
