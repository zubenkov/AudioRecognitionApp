using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioRecognitionApp.alg
{
    public class Song
    {
        public readonly string songName;
        public readonly List<DataPoint> points;

        public Song(string songName, List<DataPoint> points)
        {
            this.songName = songName;
            this.points = new List<DataPoint>();
            points.ForEach((item) =>
            {
                this.points.Add(item);
            });
        }
    }
}
