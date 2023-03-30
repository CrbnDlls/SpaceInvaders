using SpaceInvaders.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class GameSettings
    {
        public GameSettings() 
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
        }

        public int StartCoordinate { get; } = 0;

        public int ConsoleWidth { get; } = 80;

        public int ConsoleHeight { get; } = 20;

        public int InvadersStartPositionLeft {  get; } = 10;

        public int InvadersStartPositionTop { get; } = 1;

        public int InvadersCount { get; } = 60;

        public int InvadersLines { get; } = 2;
        
        public char InvadersShip { get; } = '\u00A5'; //¥

        public int EarthStartPositionLeft { get; } = 0;

        public int EarthStartPositionTop { get; } = 19;

        public int EarthCount { get; } = 80;

        public char Earth { get; } = '\u02A3'; //ʣ

        public int PlayerShipStartPositionLeft { get; } = 39;

        public int PlayerShipStartPositionTop { get; } = 18;

        public char PlayerShip { get; } = '\u0466'; //Ѧ

        public char PlayerMissile { get;  } = '\u013C';//ļ

        public char InvaderMissile { get; } = '\u01D0';//ǐ

        public int GameSpeed { get; } = 100;

        public int InvadersSpeed { get; } = 40;

        public int MissileSpeed { get; } = 3;

        public int InvaderShotSpeed { get; } = 3;

    }
}
