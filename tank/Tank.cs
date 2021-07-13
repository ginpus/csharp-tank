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
        public Direction Orientation;
        public List<string> Stats;
        public int ShotsNorth;
        public int ShotsEast;
        public int ShotsSouth;
        public int ShotsWest;
        private readonly int _maxMoves; // dabar jau enkapsuliuotas kintamasis - nepasiekiamas tiesiogiai, bet tik per metoda

        public void Info()
        {
            Console.WriteLine("Sir, yes, sir! Reporting: \n...................................");
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
            if (ShotsMade > 0)
            {
                Console.WriteLine($"Shots made: {ShotsMade}");
                Console.WriteLine($"Ammo left: {Ammo}");
            }
            Console.WriteLine($"Moves made: {MovesMade}");
            Console.WriteLine($"Orientation: {(string)Orientation.ToString()}");

            if (ShotsNorth > 0)
            {
                Console.WriteLine($"Shots made to the North: {ShotsNorth}");
            }
            if (ShotsEast > 0)
            {
                Console.WriteLine($"Shots made to the East: {ShotsEast}");
            }
            if (ShotsSouth > 0)
            {
                Console.WriteLine($"Shots made to the South: {ShotsSouth}");
            }
            if (ShotsWest > 0)
            {
                Console.WriteLine($"Shots made to the West: {ShotsWest}");
            }

            foreach (var stat in Stats)
            {
                Console.WriteLine(stat);
            }
        }

        public void MoveAhead()
        {
            Console.WriteLine("Hit the road! Tank is moving ahead\n...................................");
            MovesMade++;
            switch (Orientation)
            {
                case Direction.North:
                    VericalPosition++;
                    break;

                case Direction.East:
                    HorizontalPosition++;
                    break;

                case Direction.South:
                    VericalPosition--;
                    break;

                case Direction.West:
                    HorizontalPosition--;
                    break;
            }
        }

        public void MoveBack()
        {
            Console.WriteLine("Fall back! Tank is moving backwards\n...................................");
            MovesMade++;
            switch (Orientation)
            {
                case Direction.North:
                    VericalPosition--;
                    break;

                case Direction.East:
                    HorizontalPosition--;
                    break;

                case Direction.South:
                    VericalPosition++;
                    break;

                case Direction.West:
                    HorizontalPosition++;
                    break;
            }
        }

        public void TurnRight()
        {
            Console.WriteLine("Alrighty - turning to the right\n...................................");
            switch (Orientation)
            {
                case Direction.North:
                case Direction.East:
                case Direction.South:
                    Orientation++;
                    break;

                case Direction.West:
                    Orientation = Direction.North;
                    break;
            }
        }

        public void TurnLeft()
        {
            //with switch
            Console.WriteLine("Lefty-loosey - turning to the left\n...................................");
            switch (Orientation)
            {
                case Direction.East:
                case Direction.South:
                case Direction.West:
                    Orientation--;
                    break;

                case Direction.North:
                    Orientation = Direction.West;
                    break;
            }
        }

        public void Shoot()
        {
            if (Ammo != 0)
            {
                Console.WriteLine("KABOOOOM!\n...................................");
                ShotsMade++;
                Ammo--;
                switch (Orientation)
                {
                    case Direction.North:
                        ShotsNorth++;
                        break;

                    case Direction.East:
                        ShotsEast++;
                        break;

                    case Direction.South:
                        ShotsSouth++;
                        break;

                    case Direction.West:
                        ShotsWest++;
                        break;
                }

                if (VericalPosition > 0 && HorizontalPosition > 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {(string)Orientation.ToString()}; Position (North: {VericalPosition}, East: {HorizontalPosition})";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition < 0 && HorizontalPosition > 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {(string)Orientation.ToString()}; Position (South: {VericalPosition * (-1)}, East: {HorizontalPosition})";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition < 0 && HorizontalPosition < 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {(string)Orientation.ToString()}; Position (South: {VericalPosition * (-1)}, West: {HorizontalPosition * (-1)})";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition > 0 && HorizontalPosition < 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {(string)Orientation.ToString()}; Position (North: {VericalPosition}, West: {HorizontalPosition * (-1)})";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition == 0 && HorizontalPosition < 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {(string)Orientation.ToString()}; Position (Tank is between North and South, West: {HorizontalPosition * (-1)})";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition == 0 && HorizontalPosition > 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {(string)Orientation.ToString()}; Position (Tank is between North and South, East: {HorizontalPosition})";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition > 0 && HorizontalPosition == 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {(string)Orientation.ToString()}; Position (North: {VericalPosition}, Tank is between East and West)";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition < 0 && HorizontalPosition == 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {(string)Orientation.ToString()}; Position (South: {VericalPosition * (-1)}, Tank is between East and West)";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition == 0 && HorizontalPosition == 0 && MovesMade > 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {(string)Orientation.ToString()}; Position (Tank is at the very center)";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
            }
            else
            {
                Console.WriteLine("No ammo left! Brace yourself!\n...................................");
            }
        }

        public Tank(int vposition, int hposition, int ammo, int maxMoves)
        {
            VericalPosition = vposition;
            HorizontalPosition = hposition;
            Ammo = ammo;
            ShotsMade = 0;
            MovesMade = 0;
            Orientation = Direction.North;
            Stats = new List<string>();
            ShotsNorth = 0;
            ShotsEast = 0;
            ShotsSouth = 0;
            ShotsWest = 0;
            _maxMoves = maxMoves;
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