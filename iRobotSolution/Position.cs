using System;
using System.Collections.Generic;
using System.Text;

namespace iRobotSolution
{
    public class Position
    {
        public Coordinate Coordinate { get; private set; }
        public Orientation Orientation { get; set; }

        public Position(int x, int y)
        {
            Coordinate = new Coordinate(x, y);
        }
    }
    
    public enum Orientation
    {
        E,
        W,
        N,
        S
    }
}
