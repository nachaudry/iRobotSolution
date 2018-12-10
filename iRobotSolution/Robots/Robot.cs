using System;
using iRobotSolution.Models;

namespace iRobotSolution.Robots
{
    public class Robot
    {
        public RobotState RobotState { get; private set; }

        public Robot(int x, int y, Orientation orientation)
        {
            RobotState = new RobotState(x, y) { Orientation = orientation };
        }

        public RobotState GetNextPosition()
        {
            RobotState next = null;
            int x = RobotState.Coordinate.X;
            int y = RobotState.Coordinate.Y;

            switch (RobotState.Orientation)
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
            next = new RobotState(x, y) { Orientation = RobotState.Orientation };
            return next;
        }

        public virtual void MoveNext()
        {
            var nextPosition = GetNextPosition();
            RobotState = nextPosition;
        }

        public virtual void TurnLeft()
        {
            RobotState.Orientation = Turn(-1); // one step counter clock wise
        } 

        public void TurnRight()
        {
            RobotState.Orientation = Turn(1); // one step clock wise
        } 

        protected virtual Orientation Turn(int direction) // L:-1, R:+1
        {
            return (Orientation)((4 + (int)RobotState.Orientation + direction) % 4);
        }

        public virtual void Dead()
        {
            RobotState.isDead = true;
        } 

    }
}
