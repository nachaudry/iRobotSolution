using System;
using iRobotSolution.Models;

namespace iRobotSolution.Robots
{
    public class RobotExtended : Robot
    {
        public RobotExtended(int x, int y, Orientation orientation) : base(x, y, orientation)
        {

        }
    
        public override void Dead()
        {
            // custom functionaly in future
            RobotState.isDead = true;
        } 

    }
}
