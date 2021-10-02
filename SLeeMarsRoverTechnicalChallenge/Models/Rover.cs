using SLeeMarsRoverTechnicalChallenge.Enums;
using System;
using System.Collections.Generic;

namespace SLeeMarsRoverTechnicalChallenge.Models
{
    public class Rover
    {
        private static int XCoordinate { get; set; }
        private static int YCoordinate { get; set; }
        private static CompassPoint CompassPoint { get; set; }
        private static int NoOfCollisions { get; set; }
        private static Position LastKnown { get; set; }

        private static List<RoverMovementReport> RoverMovementReports = new List<RoverMovementReport>();

        public Rover(int xCoordinate, int yCoordinate, CompassPoint compassPoint)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            CompassPoint = compassPoint;
        }

        public void Move(string movements)
        {

           // SavePosition();

            foreach (var movement in movements)
            {

                SavePosition();
                switch (Enum.Parse<MovementInstruction>(movement.ToString()))
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

                if (XCoordinate < 0 || XCoordinate > 5 || YCoordinate <= 0 || YCoordinate > 5)
                {
                    NoOfCollisions++;
                    XCoordinate = LastKnown.XCoordinate;
                    YCoordinate = LastKnown.YCoordinate;
                    CompassPoint = LastKnown.Direction;
                }
                else
                {
                    var roverMovementReport = new RoverMovementReport();
                    roverMovementReport.Position = new Position { XCoordinate = XCoordinate, Direction = CompassPoint, YCoordinate = YCoordinate };
                    RoverMovementReports.Add(roverMovementReport);
                }

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

        private static void SavePosition()
        {
            LastKnown = new Position
            {
                Direction = CompassPoint,
                XCoordinate = XCoordinate,
                YCoordinate = YCoordinate
            };
        }

        private static void MoveRoverForward()
        {
            switch (CompassPoint)
            {
                case CompassPoint.North:
                    YCoordinate += 1;
                    break;

                case CompassPoint.East:
                    XCoordinate += 1;
                    break;

                case CompassPoint.South:
                    YCoordinate -= 1;
                    break;

                case CompassPoint.West:
                    XCoordinate -= 1;
                    break;
            }
        }

        public (List<RoverMovementReport> roverMovements, int noOfCollisions) GetMovementReports()
        {
            return (RoverMovementReports, NoOfCollisions);
        }
    }
}