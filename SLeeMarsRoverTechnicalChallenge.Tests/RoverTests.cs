using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using SLeeMarsRoverTechnicalChallenge.Enums;
using SLeeMarsRoverTechnicalChallenge.Extensions;
using SLeeMarsRoverTechnicalChallenge.Interfaces;
using SLeeMarsRoverTechnicalChallenge.Models;
using System.Linq;
using Xunit;

namespace SLeeMarsRoverTechnicalChallenge.Tests
{
    public class RoverTests
    {
        private readonly IReportService _reportService;

        public RoverTests()
        {
            var serviceProvider = new ServiceCollection()
                   .AddRoverDependencies()
                   .BuildServiceProvider();

            _reportService = serviceProvider.GetService<IReportService>();
        }

        [Fact]
        public void Given_an_Initial_Position_of_02E_and_Movement_Instructions_of_FLFRFFFRFFRR_the_Final_Position_Of_Rover_Should_Be_41N_with_0_collisions()
        {
            //Arrange
            Position position = new Position { XCoordinate = 0, YCoordinate = 2, Direction = Direction.East };
            var rover = new RoverLogic(_reportService, position);
            var expectedPosition = new Position { XCoordinate = 4, YCoordinate = 1, Direction = Direction.North };

            //Act
            rover.Move("FLFRFFFRFFRR");
            var reports = _reportService.Get();

            //Assert
            reports.TotalNumberOfCollisions.Should().Be(0);
            reports.Positions.Last().Should().BeEquivalentTo(expectedPosition);
        }

        [Fact]
        public void Given_an_Initial_Position_of_44S_and_Movement_Instructions_of_LFLLFFLFFFRFF_the_Final_Position_Of_Rover_Should_Be_01W_with_1_collisions()
        {
            //Arrange
            Position position = new Position { XCoordinate = 4, YCoordinate = 4, Direction = Direction.South };
            var rover = new RoverLogic(_reportService, position);
            var expectedPosition = new Position { XCoordinate = 0, YCoordinate = 1, Direction = Direction.West };

            //Act
            rover.Move("LFLLFFLFFFRFF");
            var reports = _reportService.Get();

            //Assert
            reports.TotalNumberOfCollisions.Should().Be(1);
            reports.Positions.Last().Should().BeEquivalentTo(expectedPosition);
        }

        [Fact]
        public void Given_an_Initial_Position_of_22W_and_Movement_Instructions_of_FLFLFLFRFRFRFRF_the_Final_Position_Of_Rover_Should_Be_22N_with_0_collisions()
        {
            //Arrange
            Position position = new Position { XCoordinate = 2, YCoordinate = 2, Direction = Direction.West };
            var rover = new RoverLogic(_reportService, position);
            var expectedPosition = new Position { XCoordinate = 2, YCoordinate = 2, Direction = Direction.North };

            //Act
            rover.Move("FLFLFLFRFRFRFRF");
            var reports = _reportService.Get();

            //Assert
            reports.TotalNumberOfCollisions.Should().Be(0);
            reports.Positions.Last().Should().BeEquivalentTo(expectedPosition);
        }

        [Fact]
        public void Given_an_Initial_Position_of_N_and_Movement_Instructions_of_FFLFFLFFFFF_the_Final_Position_Of_Rover_Should_Be_00S_with_3_collisions()
        {
            //Arrange
            Position position = new Position { XCoordinate = 1, YCoordinate = 3, Direction = Direction.North };
            var rover = new RoverLogic(_reportService, position);
            var expectedPosition = new Position { XCoordinate = 0, YCoordinate = 0, Direction = Direction.South };

            //Act
            rover.Move("FFLFFLFFFFF");
            var reports = _reportService.Get();

            //Assert
            reports.TotalNumberOfCollisions.Should().Be(3);
            reports.Positions.Last().Should().BeEquivalentTo(expectedPosition);
        }
    }
}