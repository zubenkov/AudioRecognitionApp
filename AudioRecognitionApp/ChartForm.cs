using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AudioRecognitionApp
{
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();
        }

        public ChartForm(List<MainWindow.Match> matches) : this()
        {
            var t = matches.OrderByDescending(x => x.Matches.totalMatches).ToList().Take(5);
            foreach (var item in t)
            {
                resultChart.Series["result"].Points.AddXY(item.Name, item.Matches.totalMatches);
            }
        }
    }
}
