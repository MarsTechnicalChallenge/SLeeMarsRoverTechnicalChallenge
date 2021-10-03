using SLeeMarsRoverTechnicalChallenge.Enums;
using SLeeMarsRoverTechnicalChallenge.Models;
using System;

namespace HelloWorld
{
    public class Hello
    {
        private static void Main(string[] args)
        {
            //Position the rover will start in
            var startingPosition = new Position
            {
                XCoordinate = 1,
                YCoordinate = 3,
                Direction = Direction.North
            };

            Rover rover = new Rover(startingPosition);

            //Set of movements the rover will follow
            string movement = "FFLFFLFFFFF";

            //Move the rover
            rover.Move(movement);

            //Save all the reports for each individual movement
            var report = rover.GetMovementReports();

            //Display number of total collisions
            Console.WriteLine($"Number of collisions: {report.totalCollisions}");

            //Iterate through each report, displayint the co-ordinates
            foreach (var roverMovement in report.roverMovements)
            {
                Console.WriteLine($"Rover has moved to location: ({roverMovement.Position.XCoordinate},{roverMovement.Position.YCoordinate}) and is facing {roverMovement.Position.Direction}");
            }

            Console.ReadLine();
        }
    }
}