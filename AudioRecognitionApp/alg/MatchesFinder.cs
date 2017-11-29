using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioRecognitionApp.alg
{
    public class MatchesFinder
    {
        private const double timeForOneHash = 0.1;

        public int findMatches(List<DataPoint> recordPrints, List<DataPoint> songPrints)
        {
            int max = 0;
            for (int songStart = 0; songStart < songPrints.Count; songStart += 10)
            {
                if ((songPrints.Count - songStart) < recordPrints.Count)
                {
                    break;
                }
                List<DataPoint> songPoints = songPrints.GetRange(songStart, recordPrints.Count);
                //int tempMax = getMatches(recordPrints, songPoints);
                //if (tempMax > max)
                //{
                //    max = tempMax;
                //}
            }

            return max;
        }

        public int getMatch(List<DataPoint> micro, List<DataPoint> song)
        {
            int count = 0;
            foreach (var item in micro)
            {
                foreach (var item1 in song)
                {
                    if (item.hash == item1.hash) count++;
                }
            }
            return count;
        }

        public TotalMatches getMatches(List<DataPoint> micro, List<DataPoint> song)
        {
            Lookup<long, double> hashes = (Lookup<long, double>)song.ToLookup(item => item.hash, item => item.time);
            int matches = getMatch(micro, song);
            return new TotalMatches(matches, 0);
        }

        public double getAbsoluteTime(List<double> list)
        {
            return list.GroupBy(x => x).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        }

        private struct MatchTime
        {
            public double time;
            public int count;
        }

        public struct TotalMatches
        {
            public int totalMatches;
            public double absoluteTime;

            public TotalMatches(int totalMatches, double absoluteTime)
            {
                this.totalMatches = totalMatches;
                this.absoluteTime = absoluteTime;
            }
        }
    }
}
