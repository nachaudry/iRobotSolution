using System;

namespace iRobotSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Robot!");
            try
            {
                Board b = new Board(5, 3);

                //ideally read a file for inputs, OK for now
                b.ProcessRobot(1, 1, Orientation.E, "RFRFRFRF");
                b.ProcessRobot(3, 2, Orientation.N, "FRRFLLFFRRFLL");
                b.ProcessRobot(0, 3, Orientation.W, "LLFFFLFLFL"); 
                

            }
            catch { }

            Console.ReadLine();

        }
    }
}
