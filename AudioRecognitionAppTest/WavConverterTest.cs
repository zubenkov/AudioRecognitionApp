using AudioRecognitionApp.alg.audio.wavconverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAudio.Wave;

namespace AudioRecognitionAppTest
{
    [TestClass]
    public class WavConverterTest
    {
        [TestMethod]
        public void TestIsWavForTrue()
        {
            WavConverter converter = new WavConverter();
            bool result = converter.isWav(@"C:\Users\admin\Desktop\AudioRecognitionApp\AudioRecognitionAppTest\temp\Temp Record.wav");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsWavForFalse()
        {
            WavConverter converter = new WavConverter();
            bool result = converter.isWav(@"C:\Users\admin\Desktop\AudioRecognitionApp\AudioRecognitionAppTest\temp\02 - Angel Of Small Death And The Codeine Scene.mp3");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestConvertWavFileForTrue()
        {
            WavConverter converter = new WavConverter();
            byte[] result = converter.convertWavFile(@"C:\Users\admin\Desktop\AudioRecognitionApp\AudioRecognitionAppTest\temp\Temp Record.wav");
            using (WaveStream stream = new WaveFileReader(@"C:\Users\admin\Desktop\AudioRecognitionApp\AudioRecognitionAppTest\temp\Temp Song 2.wav"))
            {                
                int sampleRate = stream.WaveFormat.AverageBytesPerSecond;
                Assert.AreEqual(11025, sampleRate);
            }
        }

        [TestMethod]
        public void TestConvertWavFileForFalse()
        {
            WavConverter converter = new WavConverter();
            byte[] result = converter.convertWavFile(@"C:\Users\admin\Desktop\AudioRecognitionApp\AudioRecognitionAppTest\temp\Temp Record.wav");
            using (WaveStream stream = new WaveFileReader(@"C:\Users\admin\Desktop\AudioRecognitionApp\AudioRecognitionAppTest\temp\Temp Song 2.wav"))
            {
                int sampleRate = stream.WaveFormat.AverageBytesPerSecond;
                Assert.AreNotEqual(44100, sampleRate);
            }
        }
    }
}
