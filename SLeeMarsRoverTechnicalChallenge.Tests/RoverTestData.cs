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
            yield return new object[] { new Position { XCoordinate = 0, YCoordinate = 2, Direction = Direction.East }, "FLFRFFFRFFRR", new Position { XCoordinate = 4, YCoordinate = 1, Direction = Direction.North }, 0 };
            yield return new object[] { new Position { XCoordinate = 4, YCoordinate = 4, Direction = Direction.South }, "LFLLFFLFFFRFF", new Position { XCoordinate = 0, YCoordinate = 1, Direction = Direction.West }, 1 };
            yield return new object[] { new Position { XCoordinate = 1, YCoordinate = 3, Direction = Direction.North }, "FFLFFLFFFFF", new Position { XCoordinate = 0, YCoordinate = 0, Direction = Direction.South }, 3 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}