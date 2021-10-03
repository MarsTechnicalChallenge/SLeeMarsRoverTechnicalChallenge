﻿using SLeeMarsRoverTechnicalChallenge.Enums;
using System;
using System.Collections.Generic;

namespace SLeeMarsRoverTechnicalChallenge.Models
{
    public class Rover
    {
        private int NoOfCollisions { get; set; }
        private Position LastPostition { get; set; }
        private Position StartingPosition { get; set; }
        private List<RoverMovementReport> RoverMovementReports = new List<RoverMovementReport>();

        public Rover(Position position) 
        {
            StartingPosition = position;
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

               if(!HasRoverGoneOffGrid())
               {
                    var roverMovementReport = new RoverMovementReport();
                    roverMovementReport.Position = new Position { XCoordinate = StartingPosition.XCoordinate, Direction = StartingPosition.Direction, YCoordinate = StartingPosition.YCoordinate };
                    RoverMovementReports.Add(roverMovementReport);
               }
            }
        }

        private bool HasRoverGoneOffGrid()
        {
            if (StartingPosition.XCoordinate < 0 || StartingPosition.XCoordinate >= 5 || StartingPosition.YCoordinate < 0 || StartingPosition.YCoordinate >= 5)
            {
                NoOfCollisions++;
                StartingPosition.XCoordinate = LastPostition.XCoordinate;
                StartingPosition.YCoordinate = LastPostition.YCoordinate;
                StartingPosition.Direction = LastPostition.Direction;
                return true;
            }

            return false;
        }

        private void MoveRoverLeft()
        {
            switch (StartingPosition.Direction)
            {
                case Direction.North:
                    StartingPosition.Direction = Direction.West;
                    break;

                case Direction.West:
                    StartingPosition.Direction = Direction.South;
                    break;

                case Direction.South:
                    StartingPosition.Direction = Direction.East;
                    break;

                case Direction.East:
                    StartingPosition.Direction = Direction.North;
                    break;
            }
        }

        private void MoveRoverRight()
        {
            switch (StartingPosition.Direction)
            {
                case Direction.North:
                    StartingPosition.Direction = Direction.East;
                    break;

                case Direction.East:
                    StartingPosition.Direction = Direction.South;
                    break;

                case Direction.South:
                    StartingPosition.Direction = Direction.West;
                    break;

                case Direction.West:
                    StartingPosition.Direction = Direction.North;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MoveRoverForward()
        {
            switch (StartingPosition.Direction)
            {
                case Direction.North:
                    StartingPosition.YCoordinate += 1;
                    break;

                case Direction.East:
                    StartingPosition.XCoordinate += 1;
                    break;

                case Direction.South:
                    StartingPosition.YCoordinate -= 1;
                    break;

                case Direction.West:
                    StartingPosition.XCoordinate -= 1;
                    break;
            }
        }

        private void SavePosition()
        {
            LastPostition = new Position
            {
                Direction = StartingPosition.Direction,
                XCoordinate = StartingPosition.XCoordinate,
                YCoordinate = StartingPosition.YCoordinate
            };
        }

        public (List<RoverMovementReport> roverMovements, int totalCollisions) GetMovementReports()
        {
            return (RoverMovementReports, NoOfCollisions);
        }
    }
}