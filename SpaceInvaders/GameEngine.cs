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

        private bool IsPause = false;

        private readonly ManualResetEvent manualResetEvent;

        private GameEngine(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            frame = Frame.GetFrame(gameSettings);
            frameRender = new FrameRender(gameSettings);
            manualResetEvent = new ManualResetEvent(true);
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

                manualResetEvent.WaitOne();
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
                    InvaderShipShot();
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

        public void PauseGame()
        {
            if (IsPause)
            {
                IsPause = false;
                manualResetEvent.Set();
            }
            else
            {
                IsPause = true; 
                manualResetEvent.Reset();
            }
        }

        public void InvaderShipShot()
        {
           frame.AddInvaderMissile();
        }

        public void PlayerShipShot()
        {
            frame.AddPlayerMissile();
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
                Point playerMissile = frame.PlayerMissiles[i];
                if (playerMissile.Top == gameSettings.StartCoordinate)
                {
                    frame.PlayerMissiles.RemoveAt(i);
                }
                else
                {
                    playerMissile.Top--;
                    
                    if (ObjectsHitByMissile(playerMissile, frame.InvaderMissiles, out int invaderRocketIndex))
                    {
                        frame.InvaderMissiles.RemoveAt(invaderRocketIndex);
                        frame.PlayerMissiles.RemoveAt(i);
                    }
                    else if (ObjectsHitByMissile(playerMissile, frame.Invaders, out int invaderIndex))
                    {
                        frame.Invaders.RemoveAt(invaderIndex);
                        frame.PlayerMissiles.RemoveAt(i);
                    }
                }
            }

            for (int i = 0; i < frame.InvaderMissiles.Count; i++)
            {
                Point invaderMissile = frame.InvaderMissiles[i];
                if (invaderMissile.Top == gameSettings.ConsoleHeight - 1)
                {
                    frame.InvaderMissiles.RemoveAt(i);
                }
                else
                {
                    invaderMissile.Top++;
                    if (ObjectsHitByMissile(invaderMissile, frame.PlayerMissiles, out int playerRocketIndex))
                    {
                        frame.InvaderMissiles.RemoveAt(i);
                        frame.PlayerMissiles.RemoveAt(playerRocketIndex);
                    }
                    else if (ObjectHitByMissile(invaderMissile, frame.PlayerShip))
                    {
                        IsGameOver = true;
                    }
                    else if (ObjectsHitByMissile(invaderMissile, frame.Earths, out int earthsIndex))
                    {
                        frame.Earths.RemoveAt(earthsIndex);
                        frame.InvaderMissiles.RemoveAt(i);
                    }
                }
            }

            if (frame.Invaders.Count == 0 || frame.Earths.Count <= gameSettings.MinimumEarth)
            {
                IsGameOver = true;
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

        private bool ObjectsHitByMissile(Point missile, List<Point> list, out int objectIndex)
        {
            objectIndex = -1;
            for (int j = 0; j < list.Count; j++)
            {
                if (ObjectHitByMissile(missile, list[j]))
                {
                    objectIndex = j;
                    return true;
                }
            }
            return false;
        }

        private bool ObjectHitByMissile(Point missile, Point obj)
        {
            return missile.Compare(obj);
        }
    }
}
