using SLeeMarsRoverTechnicalChallenge.Enums;
using SLeeMarsRoverTechnicalChallenge.Interfaces;
using System;

namespace SLeeMarsRoverTechnicalChallenge.Models
{
    public class RoverLogic
    {
        private int NoOfCollisions { get; set; }
        private Position LastPostition { get; set; }
        private Position StartingPosition { get; set; }
        private readonly IReportRepository _reportService;

        public RoverLogic(IReportRepository reportService, Position position)
        {
            _reportService = reportService;
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

                if (StartingPosition.XCoordinate < 0 || StartingPosition.XCoordinate >= 5 || StartingPosition.YCoordinate < 0 || StartingPosition.YCoordinate >= 5)
                {
                    NoOfCollisions++;
                    StartingPosition.XCoordinate = LastPostition.XCoordinate;
                    StartingPosition.YCoordinate = LastPostition.YCoordinate;
                    StartingPosition.Direction = LastPostition.Direction;
                }
                else
                {
                    var position = new Position { XCoordinate = StartingPosition.XCoordinate, Direction = StartingPosition.Direction, YCoordinate = StartingPosition.YCoordinate };
                    _reportService.Add(position);
                }
            }

            _reportService.UpdateTotalNumberOfCollisions(NoOfCollisions);
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
    }
}