using SLeeMarsRoverTechnicalChallenge.Enums;
using SLeeMarsRoverTechnicalChallenge.Models;
using System;

namespace HelloWorld
{
    public class Hello
    {
        static int NoOfCollisions = 0;
        static void Main(string[] args)
        {

            var startingPosition = new Position
            {
                XCoordinate = 1,
                YCoordinate = 3,
                Direction = Direction.North
            };

            Rover rover = new Rover(startingPosition.XCoordinate, startingPosition.YCoordinate, startingPosition.Direction);
            string movement = "FFLFFLFFFFF";
            rover.Move(movement);


            var reports = rover.GetMovementReports();
            Console.WriteLine(movement.Length);
            foreach(var report in reports.roverMovements)
            {
                Console.WriteLine($"Rover has moved to: X{report.Position.XCoordinate} Y{report.Position.YCoordinate} facing {report.Position.Direction}");
            }

            Console.ReadLine();
        }

        //static void rover_TheRoverHasCrashed(object sender, EventArgs e)
        //{
        //    NoOfCollisions++;
        //}
    }
}