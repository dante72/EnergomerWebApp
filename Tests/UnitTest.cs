using EnergomerWebApp.Application.Services.Impl;
using EnergomerWebApp.Domain.Fields;
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
        [InlineData(false, new[] { 3.0, 1.0 }, new[] { 1.0, 1.0 }, new[] { 0.0, 0.0 }, new[] { 0.0, 2.0 }, new[] { 2.0, 2.0 }, new[] { 2.0, 0.0 })]
        [InlineData(false, new[] { -1.0, -1.0 }, new[] { 1.0, 1.0 }, new[] { 0.0, 0.0 }, new[] { 0.0, 2.0 }, new[] { 2.0, 2.0 }, new[] {2.0, 0.0})]
        [InlineData(true, new[] { 0.0, 0.0 }, new[] { 1.0, 1.0 }, new[] { 0.0, 0.0 }, new[] { 0.0, 2.0 }, new[] { 2.0, 2.0 }, new[] { 2.0, 0.0 })]
        [InlineData(true, new[] { 1.0, 1.0 }, new[] { 1.0, 1.0 }, new[] { 0.0, 0.0 }, new[] { 0.0, 2.0 }, new[] { 2.0, 2.0 }, new[] { 2.0, 0.0 })]
        [InlineData(true, new[] { 1.0, 1.5 }, new[] { 1.0, 1.0 }, new[] { 0.0, 0.0 }, new[] { 0.0, 2.0 }, new[] { 2.0, 2.0 }, new[] { 2.0, 0.0 })]
        [InlineData(false, new[] { 41.3380610642585, 1.5 }, new[] { 41.3380610642585, 45.6962567581079 }, new[] { 41.3346809239899, 45.7074047669366 }, new[] { 41.3414148034017, 45.707543073278 }, new[] { 41.3414148034017, 45.6850638023809 }, new[] { 41.3347304378091, 45.6849600309502 }, new[] { 41.3346809239899, 45.7074047669366 })]
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