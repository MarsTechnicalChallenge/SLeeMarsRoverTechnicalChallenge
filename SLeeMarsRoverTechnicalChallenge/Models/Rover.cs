using SLeeMarsRoverTechnicalChallenge.Enums;
using System;
using System.Collections.Generic;

namespace SLeeMarsRoverTechnicalChallenge.Models
{
    public class Rover
    {
        private int XCoordinate { get; set; }
        private int YCoordinate { get; set; }
        private Direction CompassPoint { get; set; }
        private int NoOfCollisions { get; set; }
        private Position LastKnown { get; set; }

        private List<RoverMovementReport> RoverMovementReports = new List<RoverMovementReport>();

        public Rover(int xCoordinate, int yCoordinate, Direction compassPoint)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            CompassPoint = compassPoint;
        }

        public void Move(string movements)
        {
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

                if (XCoordinate < 0 || XCoordinate >=5 || YCoordinate < 0 || YCoordinate >=5)
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
                case Direction.North:
                    CompassPoint = Direction.West;
                    break;

                case Direction.West:
                    CompassPoint = Direction.South;
                    break;

                case Direction.South:
                    CompassPoint = Direction.East;
                    break;

                case Direction.East:
                    CompassPoint = Direction.North;
                    break;
            }
        }

        private void MoveRoverRight()
        {
            switch (CompassPoint)
            {
                case Direction.North:
                    CompassPoint = Direction.East;
                    break;

                case Direction.East:
                    CompassPoint = Direction.South;
                    break;

                case Direction.South:
                    CompassPoint = Direction.West;
                    break;

                case Direction.West:
                    CompassPoint = Direction.North;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SavePosition()
        {
            LastKnown = new Position
            {
                Direction = CompassPoint,
                XCoordinate = XCoordinate,
                YCoordinate = YCoordinate
            };
        }

        private void MoveRoverForward()
        {
            switch (CompassPoint)
            {
                case Direction.North:
                    YCoordinate += 1;
                    break;

                case Direction.East:
                    XCoordinate += 1;
                    break;

                case Direction.South:
                    YCoordinate -= 1;
                    break;

                case Direction.West:
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