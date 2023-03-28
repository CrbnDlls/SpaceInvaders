using SpaceInvaders.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class GameEngine
    {
        private static GameEngine instance;

        private readonly GameSettings gameSettings;

        private readonly FrameRender frameRender;

        private readonly Frame frame;

        private bool IsGameOver = false;

        private GameEngine(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            frame = Frame.GetFrame(gameSettings);
            frameRender = new FrameRender(gameSettings);
        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (instance == null)
            {
                instance = new GameEngine(gameSettings);
            }
            return instance;
        }

        public void Run()
        {
            int invaderMoveCounter = 0;
            int missileCounter = 0;

            do
            {
                frameRender.Render(frame);

                Thread.Sleep(gameSettings.GameSpeed);

                frameRender.ClearFrame();
                
                if (invaderMoveCounter == gameSettings.InvadersSpeed)
                {
                    InvadersMove();
                    invaderMoveCounter = -1;
                }
                
                invaderMoveCounter++;

                if (missileCounter == gameSettings.MissileSpeed)
                {
                    MissilesMove();
                    missileCounter = -1;
                }

                missileCounter++;

            } while (!IsGameOver);

            frameRender.RenderGameOver();
        }

        public void QuitGame()
        {
            IsGameOver = true;
        }

        public void PlayerShipShot()
        {
            frame.PlayerMissiles.Add(new Missile(frame.PlayerShip.Top - 1, frame.PlayerShip.Left, gameSettings.PlayerMissile));
            Console.Beep(1000, 200);
        }

        public void PlayerShipMoveLeft()
        {
            if (frame.PlayerShip.Left > gameSettings.StartCoordinate)
            {
                frame.PlayerShip.Left--;
            }
        }

        public void PlayerShipMoveRight()
        {
            if (frame.PlayerShip.Left < gameSettings.ConsoleWidth - 1)
            {
                frame.PlayerShip.Left++;
            }
        }

        public void MissilesMove()
        {
            for (int i = 0; i < frame.PlayerMissiles.Count; i++)
            {
                Missile missile = frame.PlayerMissiles[i];
                if (missile.Top == gameSettings.StartCoordinate)
                {
                    frame.PlayerMissiles.RemoveAt(i);
                }
                else
                {
                    missile.Top--;
                    for (int j = 0; j < frame.Invaders.Count; j++)
                    {
                        if (missile.Compare(frame.Invaders[j]))
                        {
                            frame.Invaders.RemoveAt(j);
                            frame.PlayerMissiles.RemoveAt(i);
                        }
                    }

                    if (frame.Invaders.Count == 0)
                    {
                        IsGameOver = true;
                    }
                }
            }
        }

        public void InvadersMove()
        {
            for (int i = 0; i < frame.Invaders.Count; i++)
            {
                frame.Invaders[i].Top++;

                if (frame.Invaders[i].Top == frame.PlayerShip.Top)
                {
                    IsGameOver = true;
                    break;
                }
            }
        }
    }
}
