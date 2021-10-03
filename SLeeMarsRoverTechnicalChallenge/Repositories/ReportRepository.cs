using SLeeMarsRoverTechnicalChallenge.Interfaces;
using SLeeMarsRoverTechnicalChallenge.Models;
using System.Collections.Generic;

namespace SLeeMarsRoverTechnicalChallenge.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private List<Position> positions = new List<Position>();
        private int totalNoOfCollisions;

        public void Add(Position position)
        {
            positions.Add(position);
        }

        public void UpdateTotalNumberOfCollisions(int noOfCollisions)
        {
            totalNoOfCollisions = noOfCollisions;
        }

        public (List<Position>, int) Get()
        {
            return (positions, totalNoOfCollisions);
        }
    }
}