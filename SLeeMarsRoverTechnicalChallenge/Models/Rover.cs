using SLeeMarsRoverTechnicalChallenge.Enums;
using System;

namespace SLeeMarsRoverTechnicalChallenge.Models
{
    public class Rover
    {
        private static int XCoordinate { get; set; }
        private static int YCoordinate { get; set; }
        private static CompassPoint CompassPoint { get; set; }

        public Rover(int xCoordinate, int yCoordinate, CompassPoint compassPoint)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            CompassPoint = compassPoint;
        }

        public void Move(MovementInstruction movement)
        {
            switch (movement)
            {
                case MovementInstruction.L:
                    MoveRoverLeft();
                    break;
                case MovementInstruction.R:
                    MoveRoverRight();
                    break;
                case MovementInstruction.F:
                    MoveRoverForward();
                    break;
            }
        }

        private void MoveRoverLeft()
        {
            switch (CompassPoint)
            {
                case CompassPoint.North:
                    CompassPoint = CompassPoint.West;
                    break;

                case CompassPoint.West:
                    CompassPoint = CompassPoint.South;
                    break;

                case CompassPoint.South:
                    CompassPoint = CompassPoint.East;
                    break;

                case CompassPoint.East:
                    CompassPoint = CompassPoint.North;
                    break;
            }
        }

        private void MoveRoverRight()
        {
            switch (CompassPoint)
            {
                case CompassPoint.North:
                    CompassPoint = CompassPoint.East;
                    break;

                case CompassPoint.East:
                    CompassPoint = CompassPoint.South;
                    break;

                case CompassPoint.South:
                    CompassPoint = CompassPoint.West;
                    break;

                case CompassPoint.West:
                    CompassPoint = CompassPoint.North;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void MoveRoverForward()
        {
            switch (CompassPoint)
            {
                case CompassPoint.North:
                    if (YCoordinate + 1 <= 5)
                        YCoordinate += 1;
                    break;

                case CompassPoint.East:
                    if (XCoordinate + 1 <= 5)
                        XCoordinate += 1;
                    break;

                case CompassPoint.South:
                    if (YCoordinate - 1 >= 0)
                        YCoordinate -= 1;
                    break;

                case CompassPoint.West:
                    if (XCoordinate - 1 >= 0)
                        XCoordinate -= 1;
                    break;
            }
        }

        public MovementResult GetMovementResult()
        {
            return new MovementResult()
            {
                NewPostion = new Position
                {
                    CompassPoint = CompassPoint,
                    XCoordinate = XCoordinate,
                    YCoordinate = YCoordinate
                },
                HasCollidedWithCraterWall = false
            };
        }
    }
}