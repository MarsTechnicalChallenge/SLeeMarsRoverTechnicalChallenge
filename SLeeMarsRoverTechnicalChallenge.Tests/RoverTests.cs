using FluentAssertions;
using SLeeMarsRoverTechnicalChallenge.Enums;
using SLeeMarsRoverTechnicalChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SLeeMarsRoverTechnicalChallenge.Tests
{
    public class RoverTests
    {
        [Theory]
        [ClassData(typeof(RoverTestData))]
        public void Given_an_Initial_Position_and_Movement_Instructions_the_Final_Position_Of_Rover_and_Number_Of_Scruffs_Should_Be(Position initalPosition, string movementInstructions, Position finalPostition, int noOfCollisions)
        {
            //Arrange
            var rover = new Rover(initalPosition.XCoordinate, initalPosition.YCoordinate, initalPosition.CompassPoint);
            var movements = movementInstructions.Select(movement => Enum.Parse<MovementInstruction>(movement.ToString())).ToList();

            //Act
            var movementResults = new List<MovementResult>();

            foreach(var movement in movements)
            {
                rover.Move(movement);
                var movementResult = rover.GetMovementResult();
                movementResults.Add(movementResult);
            }

            //Assert
            movementResults.Count(x => x.HasCollidedWithCraterWall).Should().Be(movementResults.Count(x => x.HasCollidedWithCraterWall));
            movementResults.Last().NewPostion.Should().BeEquivalentTo(movementResults.Last().NewPostion);
        }
    }
}