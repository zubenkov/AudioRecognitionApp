using Microsoft.VisualStudio.TestTools.UnitTesting;
using AudioRecognitionApp.alg;
using System.Collections.Generic;

namespace AudioRecognitionAppTest
{
    [TestClass]
    public class MatchesFinderTest
    {
        [TestMethod]
        public void TestGetAbsoluteTimeForTrue()
        {
            MatchesFinder finder = new MatchesFinder();
            List<double> list = new List<double>();
            list.Add(8.02);
            double result = finder.getAbsoluteTime(list);
            Assert.AreEqual(8.02, result);
        }

        [TestMethod]
        public void TestGetAbsoluteTimeForFalse()
        {
            MatchesFinder finder = new MatchesFinder();
            List<double> list = new List<double>();
            list.Add(8.02);
            double result = finder.getAbsoluteTime(list);
            Assert.AreNotEqual(8.03, result);
        }

        [TestMethod]
        public void TestGetMatchesForTrue()
        {
            MatchesFinder finder = new MatchesFinder();
            List<DataPoint> micro = new List<DataPoint>();
            List<DataPoint> song = new List<DataPoint>();
            micro.Add(new DataPoint(1.0, 123, 1));
            song.Add(new DataPoint(2.0, 123, 1));
            double expected = 1;
            double result = finder.getMatches(micro, song).totalMatches;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetMatchesForFalse()
        {
            MatchesFinder finder = new MatchesFinder();
            List<DataPoint> micro = new List<DataPoint>();
            List<DataPoint> song = new List<DataPoint>();
            micro.Add(new DataPoint(1.0, 123, 1));
            song.Add(new DataPoint(2.0, 123, 1));
            double expected = 2;
            double result = finder.getMatches(micro, song).totalMatches;
            Assert.AreNotEqual(expected, result);
        }
    }
}
