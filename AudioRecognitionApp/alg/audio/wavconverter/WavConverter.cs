using System.IO;
using NAudio.Wave;

namespace AudioRecognitionApp.alg.audio.wavconverter
{
    public class WavConverter
    {
        private readonly string firstPath;
        private readonly string secondPath;
        public readonly string mp3Path;
        private const int sampleRate = 11025;
        private const int bitsPerSample = 8;
        private const int mono = 1;

        public WavConverter()
        {
            firstPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            firstPath += "\\temp\\Temp  Song 1.wav";
            secondPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            secondPath += "\\temp\\Temp Song 2.wav";
            mp3Path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            mp3Path += "\\temp\\Temp Mp3 Song 2.mp3";
        }

        public SongSettings convertWavFile(string path)
        {
            int sr = convertWav(path);
            byte[] song = ReadSong(firstPath);

            return new SongSettings(sr, song);
            //File.Delete(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\AudioRecognitionService\AudioRecognitionService\temp.wav");            
        }

        public bool isWav(string songPath)
        {
            return Path.GetExtension(songPath).Equals(".wav");
        }

        public void mp3ToWav(string mp3FilePath)
        {
            using(Mp3FileReader reader = new Mp3FileReader(mp3FilePath))
            {
                using(WaveStream pcmStream = WaveFormatConversionStream.CreatePcmStream(reader))
                {
                    WaveFileWriter.CreateWaveFile(mp3Path, pcmStream);
                }
            }
        }

        private byte[] convert11025WavFile(string path)
        {
            convert11025Wav(path);
            WaveStream stream = new WaveFileReader(secondPath);
            byte[] buffer = new byte[1024];
            int bytesRead;
            MemoryStream ms = new MemoryStream();
            int n = 0;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                //n++;
                //if (n > 1000)
                //{
                //    break;
                //}
                ms.Write(buffer, 0, bytesRead);
            }
            byte[] song = ms.ToArray();
            stream.Close();
            return song;
            //File.Delete(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\AudioRecognitionService\AudioRecognitionService\temp.wav");            
        }

        private int convertWav(string path)
        {
            int returnSampleRate = 0;
            using (WaveStream stream = new WaveFileReader(path))
            {
                WaveFormat newFormat = null;

                int channels = stream.WaveFormat.Channels;
                int bps = stream.WaveFormat.BitsPerSample;
                int sr = stream.WaveFormat.SampleRate;
                int c = stream.WaveFormat.AverageBytesPerSecond;

                if (sr > 11025)
                {
                    newFormat = new WaveFormat(sampleRate, bitsPerSample, mono);
                    returnSampleRate = sampleRate;
                }
                else
                {
                    newFormat = new WaveFormat(sr, bitsPerSample, mono);
                    returnSampleRate = sampleRate;
                }
                
                using (var conversionStream = new WaveFormatConversionStream(newFormat, stream))
                {
                    WaveFileWriter.CreateWaveFile(firstPath, conversionStream);
                }
            }

            return returnSampleRate;
        }

        private void convert11025Wav(string path)
        {
            var newFormat = new WaveFormat(11025, bitsPerSample, mono);
            using (WaveStream stream = new WaveFileReader(path))
            {
                int b = stream.WaveFormat.Channels;
                int a = stream.WaveFormat.BitsPerSample;
                int c = stream.WaveFormat.AverageBytesPerSecond;
                using (var conversionStream = new WaveFormatConversionStream(newFormat, stream))
                {
                    WaveFileWriter.CreateWaveFile(secondPath, conversionStream);
                }
            }
        }

        public byte[] ReadSong(string path)
        {
            WaveStream stream = new WaveFileReader(path);
            var buffer = new byte[1024];
            using (var ms = new MemoryStream())
            {
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, bytesRead);
                }
                stream.Close();
                return ms.ToArray();
            }
        }
    }
}
