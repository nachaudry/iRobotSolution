using System;
using System.Collections.Generic;
using System.Linq;
using iRobotSolution.Models;
using iRobotSolution.Robots;

namespace iRobotSolution
{
   public class MarsWorld
    {
        private const int MAX_COORDINATE_VAL = 50, MAX_ACTION_LENGTH = 100;

        private readonly int _upperX;
        private readonly int _upperY;

        readonly List<Coordinate> _deadCoordinates = new List<Coordinate>();

        public MarsWorld(int upperX, int upperY)
        {
            _upperX = upperX;
            _upperY = upperY;

        }

        public RobotState ProcessRobot(int startingX, int startingY, Orientation orientation, string actions)
        {
            if(startingX > MAX_COORDINATE_VAL || startingY > MAX_COORDINATE_VAL)
                throw new InvalidOperationException("Coordinate value must be less than " + MAX_COORDINATE_VAL);
            if(string.IsNullOrEmpty(actions))
                throw new InvalidOperationException("Invalid action");
            if (actions.Length > MAX_ACTION_LENGTH)
                throw new InvalidOperationException("action length must be less than "+ MAX_ACTION_LENGTH);

            Robot r = RobotFactory.Create(startingX, startingY, orientation);

            foreach (var action in actions)
            {
                switch (action)
                {
                    case 'L':
                        r.TurnLeft();
                        break;
                    case 'R':
                        r.TurnRight();
                        break;
                    case 'F':
                        var nextPos = r.GetNextPosition();
                        if (_deadCoordinates.Any(c => c.Equals(nextPos.Coordinate)))
                        {
                            continue; //process subsequent requests
                        }
                        
                        var newX = nextPos.Coordinate.X;
                        var newY = nextPos.Coordinate.Y;

                        var maxX = _upperX;
                        var maxY = _upperY;

                        if ((newX < 0 || newY < 0) || (newX > maxX || newY > maxY))
                        {
                            _deadCoordinates.Add(nextPos.Coordinate);
                            r.Dead();

                            return r.RobotState;
                        }
                        r.MoveNext();
                        break;
                    default:
                        throw new InvalidOperationException("Invalid action");
                }

            }

            return r.RobotState;
        }
    }
}
