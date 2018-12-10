using System;
using System.Collections.Generic;
using System.Text;

namespace iRobotSolution
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is Coordinate right)
            {
                return right.Y == Y && right.X == X;
            }

            return false;
        }

    }
}
