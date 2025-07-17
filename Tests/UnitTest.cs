using EnergomerWebApp.Fields;
using EnergomerWebApp.Services.Impl;
using GeoCoordinatePortable;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;

namespace Tests
{
    public class UnitTest
    {

        private readonly CalculationService calculationService = new CalculationService();

        public UnitTest()
        {
            var logger = new Logger<UnitTest>();
            calculationService = new CalculationService();
        }

        //latitude, longitude

        [Theory]
        [InlineData(false, new[] { -1.0, 0.0 }, new[] { 1.0, 1.0 }, new[] { 0.0, 0.0 }, new[] { 0.0, 2.0 }, new[] { 2.0, 0.0 }, new[] {2.0, 2.0})]
        [InlineData(true, new[] { 1.0, 0.0 }, new[] { 1.0, 1.0 }, new[] { 0.0, 0.0 }, new[] { 0.0, 2.0 }, new[] { 2.0, 0.0 }, new[] { 2.0, 2.0 })]
        [InlineData(true, new[] { 1.0, 1.5 }, new[] { 1.0, 1.0 }, new[] { 0.0, 0.0 }, new[] { 0.0, 2.0 }, new[] { 2.0, 0.0 }, new[] { 2.0, 2.0 })]
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
            TestExecutionContext.Equals(result, expected);
            Assert.True(result == expected);
        }

        private static GeoCoordinate Create(double latitude, double longitude)
        {
            return new GeoCoordinate(latitude, longitude);
        }
    }
}