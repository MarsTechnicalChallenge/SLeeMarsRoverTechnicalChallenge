using Microsoft.Extensions.DependencyInjection;
using SLeeMarsRoverTechnicalChallenge.Enums;
using SLeeMarsRoverTechnicalChallenge.Extensions;
using SLeeMarsRoverTechnicalChallenge.Interfaces;
using SLeeMarsRoverTechnicalChallenge.Models;
using System;

namespace HelloWorld
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //The position the rover will start in
            var startingPosition = new Position
            {
                XCoordinate = 1,
                YCoordinate = 3,
                Direction = Direction.North
            };

            var serviceProvider = new ServiceCollection()
                .AddRoverDependencies()
                .BuildServiceProvider();

            var reportService = serviceProvider.GetService<IReportRepository>();

            RoverLogic rover = new RoverLogic(reportService, startingPosition);

            //Set of movements the rover will follow
            string movement = "FFLFFLFFFFF";

            //Move the rover
            rover.Move(movement);

            //Save all the reports for each individual movement
            var report = reportService.Get();

            //Display number of total collisions
            Console.WriteLine($"Number of collisions: {report.TotalNumberOfCollisions}");

            //Iterate through each report, displayint the co-ordinates
            foreach (var roverMovement in report.Positions)
            {
                Console.WriteLine($"Rover has moved to location: ({roverMovement.XCoordinate},{roverMovement.YCoordinate}) and is facing {roverMovement.Direction}");
            }

            Console.ReadLine();
        }
    }
}