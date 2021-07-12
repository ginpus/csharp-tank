using System;
using System.Collections;
using System.Collections.Generic;

namespace tank
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("-------------------------------------\n| Welcome to Panzer Tank rage game! |\n-------------------------------------\n");
            var desire = "y";
            int ammo = 10;
            int startPositionNorth = 0;
            int startPositionEast = 0;
            int maxMoves = 100;
            Tank tank = new Tank(startPositionNorth, startPositionEast, ammo);

            while (desire == "y" || maxMoves >= tank.MovesMade)
            {
                Console.Write("\n1 - Move ahead;\n2 - Move back;\n3 - Turn right;\n4 - Turn left;\n5 - SHOOT!;\n6 - Give information;\n7 - Make it Game Over...;\n\nMake your move: ");
                var input = Console.ReadLine();
                var choice = Convert.ToInt32(input);

                if (choice == 1)
                {
                    tank.MoveAhead();
                }
                else if (choice == 2)
                {
                    tank.MoveBack();
                }
                else if (choice == 3)
                {
                    tank.TurnRight();
                }
                else if (choice == 4)
                {
                    tank.TurnLeft();
                }
                else if (choice == 5)
                {
                    tank.Shoot();
                }
                else if (choice == 6)
                {
                    tank.Info();
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
            }
        }
    }
}