using System;
using FiguresLibrary.Interfaces;

namespace FiguresLibrary.Models
{
    public class Triangle : IFigureBase
    {
        private readonly ITriangleSettings _settings;

        public double Area => CalculatingArea();

        public bool IsRectangular => CheckIsRectangular();

        public Triangle(ITriangleSettings settings)
        {
            _settings = settings;
        }

        private bool CheckIsRectangular()
        {
            return Math.Round(Math.Pow(_settings.SideA, 2), MidpointRounding.AwayFromZero).Equals(
                       Math.Round(Math.Pow(_settings.SideB, 2) + Math.Pow(_settings.SideC, 2),
                           MidpointRounding.AwayFromZero)) ||
                   Math.Round(Math.Pow(_settings.SideB, 2), MidpointRounding.AwayFromZero).Equals(
                       Math.Round(Math.Pow(_settings.SideA, 2) + Math.Pow(_settings.SideC, 2),
                           MidpointRounding.AwayFromZero)) ||
                   Math.Round(Math.Pow(_settings.SideC, 2), MidpointRounding.AwayFromZero).Equals(
                       Math.Round(Math.Pow(_settings.SideA, 2) + Math.Pow(_settings.SideB, 2),
                           MidpointRounding.AwayFromZero));
        }

        private double CalculatingArea()
        {
            if (_settings == null ||
                _settings.SideA < 0 ||
                _settings.SideB < 0 ||
                _settings.SideC < 0)
                return default;

            var halfPerimeter = (_settings.SideA + _settings.SideB + _settings.SideC) / 2;

            return Math.Sqrt(halfPerimeter *
                             (halfPerimeter - _settings.SideA) *
                             (halfPerimeter - _settings.SideB) *
                             (halfPerimeter - _settings.SideC));
        }
    }
}
