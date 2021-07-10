using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tank
{
    internal class Tank
    {
        public int VericalPosition;
        public int HorizontalPosition;
        public int Ammo;
        public int ShotsMade;
        public int MovesMade;
        public int Orientation;
        public string OrientationString; // somehow could not deal with enum to convert into string value...

        public void Info()
        {
            if (VericalPosition > 0)
            {
                Console.WriteLine($"North position: {VericalPosition}");
            }
            else if (VericalPosition < 0)
            {
                Console.WriteLine($"South position: {VericalPosition * (-1)}");
            }
            else if (VericalPosition == 0 && MovesMade > 0)
            {
                Console.WriteLine($"Tank is neither in North nor South.");
            }

            if (HorizontalPosition > 0)
            {
                Console.WriteLine($"East position: {HorizontalPosition}");
            }
            else if (HorizontalPosition < 0)
            {
                Console.WriteLine($"West position: {HorizontalPosition * (-1)}");
            }
            else if (HorizontalPosition == 0 && MovesMade > 0)
            {
                Console.WriteLine($"Tank is neither in East nor West.");
            }
            Console.WriteLine($"Shots made: {ShotsMade}");
            Console.WriteLine($"Ammo left: {Ammo}");
            Console.WriteLine($"Moves made: {MovesMade}");
            if (Orientation == 0)
            {
                OrientationString = "North";
            }
            else if (Orientation == 1)
            {
                OrientationString = "East";
            }
            else if (Orientation == 2)
            {
                OrientationString = "South";
            }
            else if (Orientation == 3)
            {
                OrientationString = "West";
            }
            Console.WriteLine($"Orientation: {OrientationString}");
        }

        public Tank(int vposition, int hposition, int ammo, int shotsmade, int movesmade)
        {
            VericalPosition = vposition;
            HorizontalPosition = hposition;
            Ammo = ammo;
            ShotsMade = shotsmade;
            MovesMade = movesmade;
            Orientation = (int)Direction.North;
        }
    }

    internal enum Direction
    {
        North,
        East,
        South,
        West
    }
}