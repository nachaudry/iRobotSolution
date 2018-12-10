using iRobotSolution.Models;
using iRobotSolution.Robots;

namespace iRobotSolution
{
    public class RobotFactory
    {
        public static Robot Create(int startingX, int startingY, Orientation orientation)
        {
            Robot robot = new Robot(startingX, startingY, orientation);
            return robot;

            //Robot robot = new RobotExtended(startingX, startingY, orientation);
            //return robot;

            //Robot robot = new RobotDoesntTurn(startingX, startingY, orientation);
            //return robot;


        }
    }
}
