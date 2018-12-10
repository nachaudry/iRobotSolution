using System;
using iRobotSolution.Models;

namespace iRobotSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Robot!");
            try
            {
                MarsWorld mWorld = new MarsWorld(5, 3);

                //ideally read a file for inputs, OK for now
                Print(mWorld.ProcessRobot(1, 1, Orientation.E, "RFRFRFRF"));
                Print(mWorld.ProcessRobot(3, 2, Orientation.N, "FRRFLLFFRRFLL"));
                Print(mWorld.ProcessRobot(0, 3, Orientation.W, "LLFFFLFLFL"));  
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static void Print(RobotState rs)
        {
            Console.Write($"{rs.Coordinate.X}{rs.Coordinate.Y}{rs.Orientation.ToString()}");
            if (rs.isDead)
                Console.WriteLine(" LOST");
            else
                Console.WriteLine();
        }

    }
}
