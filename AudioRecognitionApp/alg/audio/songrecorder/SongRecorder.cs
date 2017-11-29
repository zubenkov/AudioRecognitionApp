using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioRecognitionApp.alg.audio.songrecorder
{
    public class SongRecorder
    {
        private const int sampleRate = 11025;
        private const int bitsPerSample = 8;
        private const int channels = 1;
        public readonly string path;

        private static WaveInEvent waveSource;
        private static WaveFileWriter waveFile;

        public byte[] recordedSong { get; private set; }

        private const int RECORD_TIME = 15000; //15 seconds

        public SongRecorder()
        {
            path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            path += "\\temp\\Temp Record.wav";
        }

        public void record15SecSong()
        {
            //Task stopper = new Task(() =>
            //{
                
            //});
            //stopper.Start();
            recordSong();
            Thread.Sleep(RECORD_TIME);
            waveSource.StopRecording();
            waveFile.Close();
            readRecordedFile();
            Console.WriteLine("the end");

            //Thread.Sleep(16000);

        }

        private void recordSong()
        {
            waveSource = new WaveInEvent();
            waveSource.WaveFormat = new WaveFormat(sampleRate, bitsPerSample, channels);

            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);


            waveFile = new WaveFileWriter(path, waveSource.WaveFormat);

            waveSource.StartRecording();
        }

        private void readRecordedFile()
        {
            WaveStream stream = new WaveFileReader(path);
            byte[] buffer = new byte[1024];
            int bytesRead;
            MemoryStream ms = new MemoryStream();
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, bytesRead);
            }
            recordedSong = ms.ToArray();
            stream.Close();
            //File.Delete(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\AudioRecognitionService\AudioRecognitionService\temp.wav");            
        }

        private void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        private void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null)
            {
                //waveFile.Dispose();
                waveFile = null;
            }


        }
    }
}
