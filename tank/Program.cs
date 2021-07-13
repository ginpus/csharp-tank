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
            Console.Write("Insert number of maximum moves:");
            var movesInput = Console.ReadLine();
            var maxMoves = Convert.ToInt32(movesInput);
            Console.Write("Insert ammount of ammo:");
            var ammoInput = Console.ReadLine();
            var ammo = Convert.ToInt32(ammoInput);

            var desire = "y";
            int startPositionNorth = 0; // if desired, could be used as a propt to user (dynamic input into constructor)
            int startPositionEast = 0; // if desired, could be used as a propt to user (dynamic input into constructor)
            Tank tank = new Tank(startPositionNorth, startPositionEast, ammo, maxMoves);

            while (desire == "y" && maxMoves > tank.MovesMade)
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
                if (maxMoves == tank.MovesMade)
                {
                    Console.WriteLine("Out of gasoline! Game over...");
                    tank.Info();
                }
            }
        }
    }
}