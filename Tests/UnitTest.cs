using EnergomerWebApp.Fields;
using EnergomerWebApp.Services.Impl;
using GeoCoordinatePortable;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests
{
    public class UnitTest
    {

        private CalculationService calculationService;
        private Mock<ILogger<CalculationService>> mockLogger = new Mock<ILogger<CalculationService>>();

        public UnitTest()
        {
            calculationService = new CalculationService(mockLogger.Object);
        }

        //latitude, longitude

        [Theory]
        [InlineData(false, new[] { -1.0, -1.0 }, new[] { 1.0, 1.0 }, new[] { 0.0, 0.0 }, new[] { 0.0, 2.0 }, new[] { 2.0, 2.0 }, new[] {2.0, 0.0})]
        [InlineData(true, new[] { 50.5, 50.5 }, new[] { 51.0, 51.0 }, new[] { 50.0, 50.0 }, new[] { 50.0, 52.0 }, new[] { 52.0, 52.0 }, new[] { 52.0, 50.0 })]
        [InlineData(false, new[] { 49.5, 50.5 }, new[] { 51.0, 51.0 }, new[] { 50.0, 50.0 }, new[] { 50.0, 52.0 }, new[] { 52.0, 52.0 }, new[] { 52.0, 50.0 })]
        [InlineData(true, new[] { 1.0, 1.5 }, new[] { 1.0, 1.0 }, new[] { 0.0, 0.0 }, new[] { 0.0, 2.0 }, new[] { 2.0, 2.0 }, new[] { 2.0, 0.0 })]
        public void Test1(bool expected, double[] testPoint, double[] center, params double[][] points)
        {
            var field = new Field()
            {
                Locations = new Locations()
                {
                    Center = Create(center[0], center[1]),
                    Polygon = points.Select(p => Create(p[0], p[1])).ToArray()
                }
            };

            var result = calculationService.CheckField(field, Create(testPoint[0], testPoint[1]));
            Assert.True(result == expected);
        }

        private static GeoCoordinate Create(double latitude, double longitude)
        {
            return new GeoCoordinate(latitude, longitude);
        }
    }
}