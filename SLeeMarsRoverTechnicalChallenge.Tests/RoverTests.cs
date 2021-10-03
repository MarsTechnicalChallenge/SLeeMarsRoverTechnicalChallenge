using FluentAssertions;
using SLeeMarsRoverTechnicalChallenge.Enums;
using SLeeMarsRoverTechnicalChallenge.Models;
using System.Linq;
using Xunit;

namespace SLeeMarsRoverTechnicalChallenge.Tests
{
    public class RoverTests
    {
        [Fact]
        public void Given_an_Initial_Position_of_02E_and_Movement_Instructions_of_FLFRFFFRFFRR_the_Final_Position_Of_Rover_Should_Be_41N_with_0_collisions()
        {
            //Arrange
            Position position = new Position { XCoordinate = 0, YCoordinate = 2, Direction = Direction.East };
            var rover = new Rover(position);
            var expectedPosition = new Position { XCoordinate = 4, YCoordinate = 1, Direction = Direction.North };
            
            //Act
            rover.Move("FLFRFFFRFFRR");
            var reports = rover.GetMovementReports().roverMovements;
            var noOfCollisions = rover.GetMovementReports().totalCollisions;

            //Assert
            noOfCollisions.Should().Be(0);
            reports.Last().Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Fact]
        public void Given_an_Initial_Position_of_44S_and_Movement_Instructions_of_LFLLFFLFFFRFF_the_Final_Position_Of_Rover_Should_Be_01W_with_1_collisions()
        {
            //Arrange
            Position position = new Position { XCoordinate = 4, YCoordinate = 4, Direction = Direction.South };
            var rover = new Rover(position);
            var expectedPosition = new Position { XCoordinate = 0, YCoordinate = 1, Direction = Direction.West };

            //Act
            rover.Move("LFLLFFLFFFRFF");
            var reports = rover.GetMovementReports().roverMovements;
            var noOfCollisions = rover.GetMovementReports().totalCollisions;

            //Assert
            noOfCollisions.Should().Be(1);
            reports.Last().Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Fact]
        public void Given_an_Initial_Position_of_22W_and_Movement_Instructions_of_FLFLFLFRFRFRFRF_the_Final_Position_Of_Rover_Should_Be_22N_with_0_collisions()
        {
            //Arrange
            Position position = new Position { XCoordinate = 2, YCoordinate = 2, Direction = Direction.West };
            var rover = new Rover(position);
            var expectedPosition = new Position { XCoordinate = 2, YCoordinate = 2, Direction = Direction.North };

            //Act
            rover.Move("FLFLFLFRFRFRFRF");
            var reports = rover.GetMovementReports().roverMovements;
            var noOfCollisions = rover.GetMovementReports().totalCollisions;

            //Assert
            noOfCollisions.Should().Be(0);
            reports.Last().Position.Should().BeEquivalentTo(expectedPosition);
        }

        [Fact]
        public void Given_an_Initial_Position_of_N_and_Movement_Instructions_of_FFLFFLFFFFF_the_Final_Position_Of_Rover_Should_Be_00S_with_3_collisions()
        {
            //Arrange
            Position position = new Position { XCoordinate = 1, YCoordinate = 3, Direction = Direction.North };
            var rover = new Rover(position);
            var expectedPosition = new Position { XCoordinate = 0, YCoordinate = 0, Direction = Direction.South };

            //Act
            rover.Move("FFLFFLFFFFF");
            var reports = rover.GetMovementReports().roverMovements;
            var noOfCollisions = rover.GetMovementReports().totalCollisions;

            //Assert
            noOfCollisions.Should().Be(3);
            reports.Last().Position.Should().BeEquivalentTo(expectedPosition);
        }
    }
}