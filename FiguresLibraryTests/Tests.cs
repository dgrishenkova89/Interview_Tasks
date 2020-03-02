using System;
using FiguresLibrary.Interfaces;
using FiguresLibrary.Models;
using NUnit.Framework;

namespace FiguresLibraryTests
{
    public class Tests
    {
        [TestCaseSource(nameof(ParametersOfCircle))]
        public void Should_Calculate_Area_Circle(double radius, double expectedArea)
        {
            CheckArea(new Circle(radius), expectedArea);
        }

        [TestCaseSource(nameof(ParametersOfTriangle))]
        public void Should_Calculate_Area_Triangle(double a, double b, double c, double expectedArea, bool isRectangular)
        {
            var triangle = new Triangle(new TriangleSettings
            {
                SideA = a,
                SideB = b,
                SideC = c
            });
            
            CheckArea(triangle, expectedArea);

            Assert.AreEqual(triangle.IsRectangular, isRectangular);
        }

        private void CheckArea(IFigureBase figure, double expectedArea)
        {
            var area = Math.Round(figure.Area, 2);
            Assert.AreEqual(area, expectedArea);
        }

        private static readonly object[] ParametersOfCircle =
        {
            new object[] {10, 314.16},
            new object[] {-3, 0},
            new object[] {0, 0}
        };

        private static readonly object[] ParametersOfTriangle =
        {
            new object[] {11, 12, 13, 61.48, false},
            new object[] {3, 4, 5, 6, true},
            new object[] {-3, 7, 0, 0, false},
            new object[] {9.22, 6, 7, 21, true}
        };
    }
}