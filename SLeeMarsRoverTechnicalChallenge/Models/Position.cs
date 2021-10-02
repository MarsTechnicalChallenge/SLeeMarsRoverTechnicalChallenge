using SLeeMarsRoverTechnicalChallenge.Enums;

namespace SLeeMarsRoverTechnicalChallenge.Models
{
    public class Position
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public CompassPoint Direction { get; set; }
    }
}