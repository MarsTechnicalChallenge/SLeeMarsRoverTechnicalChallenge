using SLeeMarsRoverTechnicalChallenge.Enums;
using SLeeMarsRoverTechnicalChallenge.Models;
using System.Collections;
using System.Collections.Generic;

namespace SLeeMarsRoverTechnicalChallenge.Tests
{
    public class RoverTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Position { XCoordinate = 0, YCoordinate = 2, CompassPoint = CompassPoint.East }, "FLFRFFFRFFRR", new Position { XCoordinate = 4, YCoordinate = 1, CompassPoint = CompassPoint.North }, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}