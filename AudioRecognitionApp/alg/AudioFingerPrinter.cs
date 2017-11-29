using AudioRecognitionApp.alg.math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioRecognitionApp.alg.audio;

namespace AudioRecognitionApp.alg
{
    public class AudioFingerPrinter
    {
        private const int UPPER_LIMIT = 511;
        private const int LOWER_LIMIT = 0;
        private const int FUZ_FACTOR = 1;
        private const double FrequencyResolution = 10.77;

        private double[][] highscores;
        
        private long[][] points;

        private static readonly int[] RANGE = new int[] { 40, 80, 160, 280, 350, 511 };

        public int getIndex(int freq)
        {
            int i = 0;
            while (RANGE[i] < freq)
                i++;
            return i;
        }

        private Complex[][] transformToFFT(byte[] audio, int chunkSize)
        {
            int totalSize = audio.Length;

            int amountPossible = totalSize / chunkSize;

            //When turning into frequency domain we'll need complex numbers:
            Complex[][] results = new Complex[amountPossible][];

            //For all the chunks:
            for (int times = 0; times < amountPossible; times++)
            {
                Complex[] complex = new Complex[chunkSize];
                for (int i = 0; i < chunkSize; i++)
                {
                    //Put the time domain data into a complex number with imaginary part as 0:
                    complex[i] = new Complex(audio[(times * chunkSize) + i], 0);
                }
                //Perform FFT analysis on the chunk:
                results[times] = FFT.fft(hamming(complex));
            }

            return results;
        }

        public long hashLowPeaks(long p1, long p2, long p3, long p4)
        {
            return (p4 - (p4 % FUZ_FACTOR))
                    * 10000000 + (p3 - (p3 % FUZ_FACTOR)) * 10000 + (p2 - (p2 % FUZ_FACTOR)) * 100
                    + (p1 - (p1 % FUZ_FACTOR));
        }

        public long hashHighPeaks(long p1, long p2, long p3)
        {
            return (p3 - (p3 % FUZ_FACTOR)) * 1000000 + (p2 - (p2 % FUZ_FACTOR)) * 1000
                    + (p1 - (p1 % FUZ_FACTOR));
        }

        public List<DataPoint> determineKeyPoints(SongSettings song)
        {
            int chunkSize = (int)(song.SampleRate / FrequencyResolution);

            if (!((chunkSize & (chunkSize - 1)) == 0))
            {
                chunkSize++;
            }

            double timeForOneHash = Math.Round((double)chunkSize / song.SampleRate, 3);
            Complex[][] results = transformToFFT(song.SongRepresentation, chunkSize);

            List<DataPoint> hashes = new List<DataPoint>();
            highscores = new double[results.Length][];
            for (int i = 0; i < results.Length; i++)
            {
                highscores[i] = new double[RANGE.Length];
                for (int j = 0; j < RANGE.Length; j++)
                {
                    highscores[i][j] = 0;
                }
            }

            points = new long[results.Length][];
            for (int i = 0; i < results.Length; i++)
            {
                points[i] = new long[RANGE.Length];
                for (int j = 0; j < RANGE.Length; j++)
                {
                    points[i][j] = 0;
                }
            }

            for (int t = 0; t < results.Length; t++)
            {
                for (int freq = LOWER_LIMIT; freq < UPPER_LIMIT - 1; freq++)
                {
                    // Get the magnitude:
                    double mag = Math.Log(results[t][freq].abs() + 1);

                    // Find out which range we are in:
                    int index = getIndex(freq);

                    // Save the highest magnitude and corresponding frequency:
                    if (mag > highscores[t][index] && mag > 3)
                    {
                        highscores[t][index] = mag;
                        points[t][index] = freq;
                    }
                }

                long[] hashPoints = CreateHashPoint(points[t]).ToArray();

                foreach (long hash in hashPoints)
                {
                    hashes.Add(new DataPoint(Math.Round(timeForOneHash * (t + 1), 3), hash));
                }

            }
            return hashes;
        }

        private List<long> CreateHashPoint(long[] points)
        {
            List<long> HashPoints = new List<long>();
            points = points.Where(p => p > 0).ToArray();

            if (points.Length >= 3)
            {
                for (int i = 0; i < (points.Length / 3); i+=3)
                {
                    long hash = hashHighPeaks(points[i], points[i+1], points[i+2]);
                    HashPoints.Add(hash);
                }
            }

            //if (points.Length % 3 == 2)
            //{
            //    long hash = hashHighPeaks(points[points.Length - 2], points[points.Length - 1], 0);
            //    HashPoints.Add(hash);
            //}

            return HashPoints;
        }


        private Complex[] hamming(Complex[] iwv)
        {
            int N = iwv.Length;

            // iwv[i].Re = real number (raw wave data) 
            // iwv[i].Im = imaginary number (0 since it hasn't gone through FFT yet)
            for (int n = 0; n < N; n++)
                iwv[n].re *= 0.54 - 0.46 * Math.Cos((2 * Math.PI * n) / (N - 1));

            return iwv;
        }
    }
}
