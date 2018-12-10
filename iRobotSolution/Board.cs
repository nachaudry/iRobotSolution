using System;
using System.Collections.Generic;
using System.Linq;

namespace iRobotSolution
{
   public class Board
    {
        readonly int[,] Mar;
        readonly List<Coordinate> _deadCoordinates = new List<Coordinate>();

        public Board(int upperX, int upperY)
        {
            Mar = new int[upperX + 1, upperY + 1];
        }
        public void ProcessRobot(int startingX, int startingY, Orientation orientation, string actions)
        {
            Robot r = new Robot(startingX, startingY, orientation);

            foreach (var action in actions)
            {
                if (action.Equals('L'))
                {
                    r.TurnLeft();
                }
                else if (action.Equals('R'))
                {
                    r.TurnRight();
                }
                else if (action.Equals('F'))
                {
                    var nextPos = r.GetNextPosition();
                    if (_deadCoordinates.Any(c => c.Equals(nextPos.Coordinate)))
                    {
                        PrintCoordinate(r);
                        //Console.WriteLine("Instruction ignored");
                        return;
                    }

                    var newX = nextPos.Coordinate.X;
                    var newY = nextPos.Coordinate.Y;

                    var maxX = Mar.GetUpperBound(0);
                    var maxY = Mar.GetUpperBound(1);

                    if ((newX < 0 || newY < 0) || (newX > maxX || newY > maxY))
                    {
                        _deadCoordinates.Add(nextPos.Coordinate);
                        r.Dead();
                        return;
                    }
                    r.MoveNext();
                }
                else
                {
                    throw new InvalidOperationException("Invalid action");
                }
            }
            
            PrintCoordinate(r);
        }

        private static void PrintCoordinate(Robot r)
        {
            var coordinate = r.Position.Coordinate;
            Console.WriteLine($"{coordinate.X}{coordinate.Y}{r.Position.Orientation.ToString()}");
        }
    }
}
