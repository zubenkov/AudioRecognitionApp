using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AudioRecognitionApp.alg;
using AudioRecognitionApp.alg.audio.wavconverter;
using System.Collections.Generic;

namespace AudioRecognitionAppTest
{
    [TestClass]
    public class AudioFingerPrinterTest
    {
        [TestMethod]
        public void TestGetIndexForTrue()
        {
            AudioFingerPrinter audioFingerPrinter = new AudioFingerPrinter();
            int result = audioFingerPrinter.getIndex(15);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestGetIndexForFalse()
        {
            AudioFingerPrinter audioFingerPrinter = new AudioFingerPrinter();
            int result = audioFingerPrinter.getIndex(15);
            Assert.AreNotEqual(1, result);
        }

        [TestMethod]
        public void TestHashLowPeaksForTrue()
        {
            AudioFingerPrinter audioFingerPrinter = new AudioFingerPrinter();
            long result = audioFingerPrinter.hashLowPeaks(15, 30, 115, 155);
            Assert.AreEqual(1541143014, result);
        }
        [TestMethod]
        public void TestHashLowPeaksForFalse()
        {
            AudioFingerPrinter audioFingerPrinter = new AudioFingerPrinter();
            long result = audioFingerPrinter.hashLowPeaks(15, 30, 115, 155);
            Assert.AreNotEqual(1541143015, result);
        }
        [TestMethod]
        public void TestDetermineKeyPoints()
        {
            AudioFingerPrinter audioFingerPrinter = new AudioFingerPrinter();
            WavConverter converter = new WavConverter();
            byte[] array = new byte[1024];
            for (int i = 0; i < 1024; i++)
            {
                array[i] = 100;
            }
            List<DataPoint> points = audioFingerPrinter.determineKeyPoints(array);
            long expect = 800402610;
            long result = points[0].hash;
           
            Assert.AreEqual(expect, result);
        }
    }
}
