namespace AudioRecognitionApp.alg.audio
{
    public class SongSettings
    {
        public int SampleRate { get; private set; }

        public byte[] SongRepresentation { get; private set; }

        public SongSettings(int sampleRate, byte[] song)
        {
            this.SampleRate = sampleRate;
            this.SongRepresentation = song;
        }
    }
}
