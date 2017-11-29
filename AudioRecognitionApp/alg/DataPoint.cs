using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioRecognitionApp.alg
{
    public class DataPoint
    {        
        public double time { get; set; }
        public long hash { get; set; }
        public int id { get; set; }

        public DataPoint(double time, long hash, int id = 1)
        {
            this.time = time;
            this.hash = hash;
            this.id = id;
        }
    }
}
