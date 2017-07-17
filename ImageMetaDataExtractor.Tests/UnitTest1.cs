using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageMetadataExtractor;

namespace ImageMetaDataExtractor.Tests
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void fromDegreeMinuteSecondStringShouldHandleSymbols()
        {
            Coordinate actual = Coordinate.fromDegreeMinuteSecondString("38° 53′ 23″ N, -77° 00′ 32″ W");

            var expected = "38.8897,-77.0089";
            float delta = .1f;

            Assert.AreEqual(38.8897, actual.Latitude, delta);
            Assert.AreEqual(-77.0089, actual.Longitude, delta);
        }
    }
}
