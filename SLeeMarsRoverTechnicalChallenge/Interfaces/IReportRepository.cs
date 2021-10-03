using SLeeMarsRoverTechnicalChallenge.Models;
using System.Collections.Generic;

namespace SLeeMarsRoverTechnicalChallenge.Interfaces
{
    public interface IReportRepository
    {
        (List<Position> Positions, int TotalNumberOfCollisions) Get();

        void Add(Position position);

        void UpdateTotalNumberOfCollisions(int NoOfCollisions);
    }
}