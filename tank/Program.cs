using System;

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
            while (desire == "y")
            {
                Console.Write("\n1 - Move ahead;\n2 - Move back;\n3 - Turn right;\n4 - Turn left;\n5 - SHOOT!;\n6 - Give information;\n7 - Make it Game Over...;\n\nMake your move: ");
                var input = Console.ReadLine();
                var choice = Convert.ToInt32(input);
                if (choice == 1)
                {
                    Console.WriteLine("Hit the road! Tank is moving ahead\n...................................");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Fall back! Tank is moving backwards\n...................................");
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Alrighty - moving to the right\n...................................");
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Lefty-loosey - moving to the left\n...................................");
                }
                else if (choice == 5)
                {
                    Console.WriteLine("KABOOOOM!\n...................................");
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Sir, yes, sir! Reporting: \n...................................");
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

    internal enum Direction
    {
        North,
        South,
        East,
        West
    }
}