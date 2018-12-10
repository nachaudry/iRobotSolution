using System;
using System.Collections.Generic;
using System.Text;

namespace iRobotSolution
{
    public class Robot
    {
        public Position Position { get; private set; }

        public Robot(int x, int y, Orientation orientation)
        {
            Position = new Position(x, y) { Orientation = orientation };
        }

        public Position GetNextPosition()
        {
            var currentPos = Position;
            Position next = null;
            int x = currentPos.Coordinate.X;
            int y = currentPos.Coordinate.Y;

            switch (currentPos.Orientation)
            {
                case Orientation.W:
                    x = x - 1;
                    break;
                case Orientation.E:
                    x = x + 1;
                    break;
                case Orientation.S:
                    y = y - 1;
                    break;
                case Orientation.N:
                    y = y + 1;
                    break;

            }
            next = new Position(x, y) { Orientation = Position.Orientation };
            return next;
        }

        public void MoveNext()
        {
            var nextPosition = GetNextPosition();
            Position = nextPosition;
        }

        public void TurnLeft()
        {
            switch (Position.Orientation)
            {
                case Orientation.W:
                    Position.Orientation = Orientation.S;
                    break;
                case Orientation.E:
                    Position.Orientation = Orientation.N;
                    break;
                case Orientation.S:
                    Position.Orientation = Orientation.E;
                    break;
                case Orientation.N:
                    Position.Orientation = Orientation.W;
                    break;

            }
        } // ? review

        public void TurnRight()
        {
            switch (Position.Orientation)
            {
                case Orientation.W:
                    Position.Orientation = Orientation.N;
                    break;
                case Orientation.E:
                    Position.Orientation = Orientation.S;
                    break;
                case Orientation.S:
                    Position.Orientation = Orientation.W;
                    break;
                case Orientation.N:
                    Position.Orientation = Orientation.E;
                    break;
            }
        } // ? review

        public void Dead()
        {
            var coordinate = Position.Coordinate;
            Console.WriteLine($"{coordinate.X}{coordinate.Y}{Position.Orientation.ToString()} LOST");

        } 

    }
}
