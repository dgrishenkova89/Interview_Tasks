using System;
using FiguresLibrary.Interfaces;

namespace FiguresLibrary.Models
{
    public class Circle : IFigureBase
    {
        private readonly double _pi = 3.1416;
        private readonly double _radius;

        public double Area => (_pi * Math.Pow(_radius, 2));

        public Circle(double radius)
        {
            _radius = radius < 0 ? 0 : radius;
        }
    }
}
