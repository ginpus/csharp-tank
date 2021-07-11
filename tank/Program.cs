using System;
using System.Collections;
using System.Collections.Generic;

namespace tank
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // isprintinti papildomai, kiek liko suviu
            // tanko suviai baigiasi ir paraso, kad soviniu nebera
            Console.Write("-------------------------------------\n| Welcome to Panzer Tank rage game! |\n-------------------------------------\n");
            var desire = "y";
            int ammo = 10;
            int maxMoves = 100;
            Tank tank = new Tank(0, 0, ammo, 0, 0);

            while (desire == "y" || maxMoves == tank.MovesMade)
            {
                Console.Write("\n1 - Move ahead;\n2 - Move back;\n3 - Turn right;\n4 - Turn left;\n5 - SHOOT!;\n6 - Give information;\n7 - Make it Game Over...;\n\nMake your move: ");
                var input = Console.ReadLine();
                var choice = Convert.ToInt32(input);

                if (choice == 1)
                {
                    Console.WriteLine("Hit the road! Tank is moving ahead\n...................................");
                    tank.MovesMade++;
                    if (tank.Orientation == 0)
                    {
                        tank.VericalPosition++;
                    }
                    else if (tank.Orientation == 1)
                    {
                        tank.HorizontalPosition++;
                    }
                    else if (tank.Orientation == 2)
                    {
                        tank.VericalPosition--;
                    }
                    else if (tank.Orientation == 3)
                    {
                        tank.HorizontalPosition--;
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Fall back! Tank is moving backwards\n...................................");
                    tank.MovesMade++;
                    if (tank.Orientation == 0)
                    {
                        tank.VericalPosition--;
                    }
                    else if (tank.Orientation == 1)
                    {
                        tank.HorizontalPosition--;
                    }
                    else if (tank.Orientation == 2)
                    {
                        tank.VericalPosition++;
                    }
                    else if (tank.Orientation == 3)
                    {
                        tank.HorizontalPosition++;
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Alrighty - turning to the right\n...................................");
                    if (tank.Orientation == 0 || tank.Orientation == 1 || tank.Orientation == 2)
                    {
                        tank.Orientation++;
                    }
                    else if (tank.Orientation == 3)
                    {
                        tank.Orientation = 0;
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Lefty-loosey - turning to the left\n...................................");
                    if (tank.Orientation == 1 || tank.Orientation == 2 || tank.Orientation == 3)
                    {
                        tank.Orientation--;
                    }
                    else if (tank.Orientation == 0)
                    {
                        tank.Orientation = 3;
                    }
                }
                else if (choice == 5)
                {
                    if (tank.Ammo != 0)
                    {
                        Console.WriteLine("KABOOOOM!\n...................................");
                        tank.ShotsMade++;
                        tank.Ammo--;
                        if (tank.VericalPosition > 0 && tank.HorizontalPosition > 0)
                        {
                            if (tank.Orientation == 0)
                            {
                                tank.OrientationString = "North";
                            }
                            else if (tank.Orientation == 1)
                            {
                                tank.OrientationString = "East";
                            }
                            else if (tank.Orientation == 2)
                            {
                                tank.OrientationString = "South";
                            }
                            else if (tank.Orientation == 3)
                            {
                                tank.OrientationString = "West";
                            }
                            string coordinates = $"Shot number: {tank.ShotsMade}; Shots left {tank.Ammo}; Orientation: {tank.OrientationString}; Position (North: {tank.VericalPosition}, East: {tank.HorizontalPosition})";
                            Console.WriteLine(coordinates);
                            tank.Stats.Add(coordinates);
                        }
                        else if (tank.VericalPosition < 0 && tank.HorizontalPosition > 0)
                        {
                            if (tank.Orientation == 0)
                            {
                                tank.OrientationString = "North";
                            }
                            else if (tank.Orientation == 1)
                            {
                                tank.OrientationString = "East";
                            }
                            else if (tank.Orientation == 2)
                            {
                                tank.OrientationString = "South";
                            }
                            else if (tank.Orientation == 3)
                            {
                                tank.OrientationString = "West";
                            }
                            string coordinates = $"Shot number: {tank.ShotsMade}; Shots left {tank.Ammo}; Orientation: {tank.OrientationString}; Position (South: {tank.VericalPosition * (-1)}, East: {tank.HorizontalPosition})";
                            Console.WriteLine(coordinates);
                            tank.Stats.Add(coordinates);
                        }
                        else if (tank.VericalPosition < 0 && tank.HorizontalPosition < 0)
                        {
                            if (tank.Orientation == 0)
                            {
                                tank.OrientationString = "North";
                            }
                            else if (tank.Orientation == 1)
                            {
                                tank.OrientationString = "East";
                            }
                            else if (tank.Orientation == 2)
                            {
                                tank.OrientationString = "South";
                            }
                            else if (tank.Orientation == 3)
                            {
                                tank.OrientationString = "West";
                            }
                            string coordinates = $"Shot number: {tank.ShotsMade}; Shots left {tank.Ammo}; Orientation: {tank.OrientationString}; Position (South: {tank.VericalPosition * (-1)}, West: {tank.HorizontalPosition * (-1)})";
                            Console.WriteLine(coordinates);
                            tank.Stats.Add(coordinates);
                        }
                        else if (tank.VericalPosition > 0 && tank.HorizontalPosition < 0)
                        {
                            if (tank.Orientation == 0)
                            {
                                tank.OrientationString = "North";
                            }
                            else if (tank.Orientation == 1)
                            {
                                tank.OrientationString = "East";
                            }
                            else if (tank.Orientation == 2)
                            {
                                tank.OrientationString = "South";
                            }
                            else if (tank.Orientation == 3)
                            {
                                tank.OrientationString = "West";
                            }
                            string coordinates = $"Shot number: {tank.ShotsMade}; Shots left {tank.Ammo}; Orientation: {tank.OrientationString}; Position (North: {tank.VericalPosition}, West: {tank.HorizontalPosition * (-1)})";
                            Console.WriteLine(coordinates);
                            tank.Stats.Add(coordinates);
                        }
                        else if (tank.VericalPosition == 0 && tank.HorizontalPosition < 0)
                        {
                            if (tank.Orientation == 0)
                            {
                                tank.OrientationString = "North";
                            }
                            else if (tank.Orientation == 1)
                            {
                                tank.OrientationString = "East";
                            }
                            else if (tank.Orientation == 2)
                            {
                                tank.OrientationString = "South";
                            }
                            else if (tank.Orientation == 3)
                            {
                                tank.OrientationString = "West";
                            }
                            string coordinates = $"Shot number: {tank.ShotsMade}; Shots left {tank.Ammo}; Orientation: {tank.OrientationString}; Position (Tank is between North and South, West: {tank.HorizontalPosition * (-1)})";
                            Console.WriteLine(coordinates);
                            tank.Stats.Add(coordinates);
                        }
                        else if (tank.VericalPosition == 0 && tank.HorizontalPosition > 0)
                        {
                            if (tank.Orientation == 0)
                            {
                                tank.OrientationString = "North";
                            }
                            else if (tank.Orientation == 1)
                            {
                                tank.OrientationString = "East";
                            }
                            else if (tank.Orientation == 2)
                            {
                                tank.OrientationString = "South";
                            }
                            else if (tank.Orientation == 3)
                            {
                                tank.OrientationString = "West";
                            }
                            string coordinates = $"Shot number: {tank.ShotsMade}; Shots left {tank.Ammo}; Orientation: {tank.Orientation}; Position (Tank is between North and South, East: {tank.HorizontalPosition})";
                            Console.WriteLine(coordinates);
                            tank.Stats.Add(coordinates);
                        }
                        else if (tank.VericalPosition > 0 && tank.HorizontalPosition == 0)
                        {
                            if (tank.Orientation == 0)
                            {
                                tank.OrientationString = "North";
                            }
                            else if (tank.Orientation == 1)
                            {
                                tank.OrientationString = "East";
                            }
                            else if (tank.Orientation == 2)
                            {
                                tank.OrientationString = "South";
                            }
                            else if (tank.Orientation == 3)
                            {
                                tank.OrientationString = "West";
                            }
                            string coordinates = $"Shot number: {tank.ShotsMade}; Shots left {tank.Ammo}; Orientation: {tank.OrientationString}; Position (North: {tank.VericalPosition}, Tank is between East and West)";
                            Console.WriteLine(coordinates);
                            tank.Stats.Add(coordinates);
                        }
                        else if (tank.VericalPosition < 0 && tank.HorizontalPosition == 0)
                        {
                            if (tank.Orientation == 0)
                            {
                                tank.OrientationString = "North";
                            }
                            else if (tank.Orientation == 1)
                            {
                                tank.OrientationString = "East";
                            }
                            else if (tank.Orientation == 2)
                            {
                                tank.OrientationString = "South";
                            }
                            else if (tank.Orientation == 3)
                            {
                                tank.OrientationString = "West";
                            }
                            string coordinates = $"Shot number: {tank.ShotsMade}; Shots left {tank.Ammo}; Orientation: {tank.OrientationString}; Position (South: {tank.VericalPosition * (-1)}, Tank is between East and West)";
                            Console.WriteLine(coordinates);
                            tank.Stats.Add(coordinates);
                        }
                        else if (tank.VericalPosition == 0 && tank.HorizontalPosition == 0 && tank.MovesMade > 0)
                        {
                            if (tank.Orientation == 0)
                            {
                                tank.OrientationString = "North";
                            }
                            else if (tank.Orientation == 1)
                            {
                                tank.OrientationString = "East";
                            }
                            else if (tank.Orientation == 2)
                            {
                                tank.OrientationString = "South";
                            }
                            else if (tank.Orientation == 3)
                            {
                                tank.OrientationString = "West";
                            }
                            string coordinates = $"Shot number: {tank.ShotsMade}; Shots left {tank.Ammo}; Orientation: {tank.OrientationString}; Position (Tank is at the very center)";
                            Console.WriteLine(coordinates);
                            tank.Stats.Add(coordinates);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No ammo left! Brace yourself!\n...................................");
                    }
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Sir, yes, sir! Reporting: \n...................................");
                    tank.Info();
                    foreach (var stat in tank.Stats)
                    {
                        Console.WriteLine(stat);
                    }
                }
                else if (choice == 7)
                {
                    Console.WriteLine("---GAME OVER---");
                    desire = "n";
                }
                else
                {
                    Console.WriteLine("Sorry, no such selection. Try again");
                }
                /*                Console.Write("Do you want to continue (Y/N)?: ");
                                desire = Console.ReadLine();
                                desire = desire.ToLower();
                                Console.WriteLine(desire);*/
            }
        }
    }
}