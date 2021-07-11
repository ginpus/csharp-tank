﻿using System;
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
        public List<string> Stats;
        public int ShotsNorth;
        public int ShotsEast;
        public int ShotsSouth;
        public int ShotsWest;

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
            if (Orientation == (int)Direction.North)
            {
                OrientationString = (string)Direction.North.ToString();
            }
            else if (Orientation == (int)Direction.East)
            {
                OrientationString = (string)Direction.East.ToString();
            }
            else if (Orientation == (int)Direction.South)
            {
                OrientationString = (string)Direction.South.ToString();
            }
            else if (Orientation == (int)Direction.West)
            {
                OrientationString = (string)Direction.West.ToString();
            }
            Console.WriteLine($"Orientation: {OrientationString}");

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
            if (Orientation == 0)
            {
                VericalPosition++;
            }
            else if (Orientation == 1)
            {
                HorizontalPosition++;
            }
            else if (Orientation == 2)
            {
                VericalPosition--;
            }
            else if (Orientation == 3)
            {
                HorizontalPosition--;
            }
        }

        public void MoveBack()
        {
            Console.WriteLine("Fall back! Tank is moving backwards\n...................................");
            MovesMade++;
            if (Orientation == (int)Direction.North)
            {
                VericalPosition--;
            }
            else if (Orientation == (int)Direction.East)
            {
                HorizontalPosition--;
            }
            else if (Orientation == (int)Direction.South)
            {
                VericalPosition++;
            }
            else if (Orientation == (int)Direction.West)
            {
                HorizontalPosition++;
            }
        }

        public void TurnRight()
        {
            //persidaryt su switch. darbui su enum net patogesnis
            Console.WriteLine("Alrighty - turning to the right\n...................................");
            if (Orientation == (int)Direction.North || Orientation == (int)Direction.East || Orientation == (int)Direction.South)
            {
                Orientation++;
            }
            else if (Orientation == (int)Direction.West)
            {
                Orientation = (int)Direction.North;
            }
        }

        public void TurnLeft()
        {
            Console.WriteLine("Lefty-loosey - turning to the left\n...................................");
            if (Orientation == (int)Direction.East || Orientation == (int)Direction.South || Orientation == (int)Direction.West)
            {
                Orientation--;
            }
            else if (Orientation == (int)Direction.North)
            {
                Orientation = (int)Direction.West;
            }
        }

        public void Shoot()
        {
            if (Ammo != 0)
            {
                Console.WriteLine("KABOOOOM!\n...................................");
                ShotsMade++;
                Ammo--;
                if (Orientation == 0)
                {
                    OrientationString = (string)Direction.North.ToString();
                    ShotsNorth++;
                }
                else if (Orientation == 1)
                {
                    OrientationString = (string)Direction.East.ToString();
                    ShotsEast++;
                }
                else if (Orientation == 2)
                {
                    OrientationString = (string)Direction.South.ToString();
                    ShotsSouth++;
                }
                else if (Orientation == 3)
                {
                    OrientationString = (string)Direction.West.ToString();
                    ShotsWest++;
                }
                if (VericalPosition > 0 && HorizontalPosition > 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {OrientationString}; Position (North: {VericalPosition}, East: {HorizontalPosition})";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition < 0 && HorizontalPosition > 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {OrientationString}; Position (South: {VericalPosition * (-1)}, East: {HorizontalPosition})";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition < 0 && HorizontalPosition < 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {OrientationString}; Position (South: {VericalPosition * (-1)}, West: {HorizontalPosition * (-1)})";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition > 0 && HorizontalPosition < 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {OrientationString}; Position (North: {VericalPosition}, West: {HorizontalPosition * (-1)})";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition == 0 && HorizontalPosition < 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {OrientationString}; Position (Tank is between North and South, West: {HorizontalPosition * (-1)})";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition == 0 && HorizontalPosition > 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {OrientationString}; Position (Tank is between North and South, East: {HorizontalPosition})";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition > 0 && HorizontalPosition == 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {OrientationString}; Position (North: {VericalPosition}, Tank is between East and West)";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition < 0 && HorizontalPosition == 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {OrientationString}; Position (South: {VericalPosition * (-1)}, Tank is between East and West)";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
                else if (VericalPosition == 0 && HorizontalPosition == 0 && MovesMade > 0)
                {
                    string coordinates = $"Shot number: {ShotsMade}; Shots left {Ammo}; Orientation: {OrientationString}; Position (Tank is at the very center)";
                    Console.WriteLine(coordinates);
                    Stats.Add(coordinates);
                }
            }
            else
            {
                Console.WriteLine("No ammo left! Brace yourself!\n...................................");
            }
        }

        public Tank(int vposition, int hposition, int ammo)
        {
            VericalPosition = vposition;
            HorizontalPosition = hposition;
            Ammo = ammo;
            ShotsMade = 0;
            MovesMade = 0;
            Orientation = (int)Direction.North;
            Stats = new List<string>();
            ShotsNorth = 0;
            ShotsEast = 0;
            ShotsSouth = 0;
            ShotsWest = 0;
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