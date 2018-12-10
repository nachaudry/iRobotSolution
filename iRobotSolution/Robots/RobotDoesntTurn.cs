using System;
using iRobotSolution.Models;

namespace iRobotSolution.Robots
{
    public class RobotDoesntTurn : Robot
    {
        public RobotDoesntTurn(int x, int y, Orientation orientation) : base(x, y, orientation)
        {

        }

        protected override Orientation Turn(int direction)
        {
            return RobotState.Orientation;
        }

    }
}
