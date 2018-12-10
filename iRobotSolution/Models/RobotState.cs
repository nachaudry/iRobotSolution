using System;
using System.Collections.Generic;
using System.Text;

namespace iRobotSolution.Models
{
    public class RobotState
    {
        public Coordinate Coordinate { get; private set; }
        public Orientation Orientation { get; set; }
        public bool isDead { get; set; }

        public RobotState(int x, int y)
        {
            Coordinate = new Coordinate(x, y);
        }
    }
}
