using AudioRecognitionApp.alg;
using AudioRecognitionApp.alg.audio.songrecorder;
using AudioRecognitionApp.alg.audio.wavconverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioRecognitionApp
{
    public partial class MainWindow : Form
    {
        private byte[] microphone;
        private string songPath;
        private List<Song> songs = new List<Song>();
        WavConverter wavConverter;
        SongRecorder songRecorder;
        AudioFingerPrinter fingerPrinter;
        MatchesFinder matchesFinder;
        List<Match> matches;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void recordBtn_Click(object sender, EventArgs e)
        {
            this.recordBtn.BackColor = Color.Green;
            songRecorder = new SongRecorder();
            Task record = new Task(() =>
            {
                songRecorder.record15SecSong();
                microphone = songRecorder.recordedSong;
                this.recordBtn.BackColor = Color.Red;
                MessageBox.Show("Record Ended!");
            });
            record.Start();
        }

        private void openSongBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "all files (*.*)|*.*|mp3 files (*.mp3)|*.mp3|wav files (*.wav)|*.wav";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                songPath = openFile.FileName;
                this.songPathField.Text = songPath;
            }
        }
        
        private void recognizeBtn_Click(object sender, EventArgs e)
        {
            if (songs.Count == 0)
            {
                MessageBox.Show("List of songs is empty!");
                return;
            }
            if (microphone == null && songPath == null)
            {
                MessageBox.Show("Please, record song or open it on your disk driver!");
                return;
            }
            matchesGridView.Rows.Clear();
            matchesGridView.Refresh();
            fingerPrinter = new AudioFingerPrinter();
            
            List<DataPoint> dataCheck;
            WavConverter converter = new WavConverter();

            if (microphone != null)
            {
                dataCheck = fingerPrinter.determineKeyPoints(converter.convertWavFile(songRecorder.path));
            }
            else
            {                
                if (converter.isWav(songPath))
                {
                    var song1 = converter.convertWavFile(songPath);
                    dataCheck = fingerPrinter.determineKeyPoints(converter.convertWavFile(songPath));
                }
                else
                {
                    converter.mp3ToWav(songPath);
                    dataCheck = fingerPrinter.determineKeyPoints(converter.convertWavFile(converter.mp3Path));
                }
                
            }

            List<Match> matches = findMatches(dataCheck,songs);
            writeMatches(matches);
            microphone = null;
            songPath = null;
            songPathField.Text = "";
        }

        private void writeMatches(List<Match> matches)
        {
            this.matches = matches;
            var t = matches.OrderByDescending(x => x.Matches.totalMatches).ToList().Take(5);
            foreach (var match in t)
            {
                //double matchPercentage = match.Matches.totalMatches > 480 ? 100 : Math.Round(100 * (match.Matches.totalMatches * 1.0) / 480, 1);
                //string absoluteTime = matchPercentage > 35 ? convertToMinutes(match.Matches.absoluteTime) : " - ";
                matchesGridView.Rows.Add(match.Name, match.Matches.totalMatches);
            }
            
        }

        private string convertToMinutes(double time)
        {
            int minutes = (int)time / 60;
            int seconds = (int)time % 60;
            return minutes.ToString() + " : " + seconds.ToString();
        }

        private List<Match> findMatches(List<DataPoint> dataCheck, List<Song> songs)
        {
            if (songs == null)
            {
                return null;
            }
            matchesFinder = new MatchesFinder();
            List<Match> matches = new List<Match>();
            int n = 0;
            foreach (var song in songs)
            {
                
                matches.Add(new Match(Path.GetFileNameWithoutExtension(song.songName), matchesFinder.getMatches(dataCheck, song.points)));
                
            }
            return matches;
        }

        public struct Match
        {
            public string Name { get; set; }
            public MatchesFinder.TotalMatches Matches { get; set; }

            public Match(string name, MatchesFinder.TotalMatches matches)
            {
                this.Name = name;
                this.Matches = matches;
            }
        }

        private void addSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "all files (*.*)|*.*|mp3 files (*.mp3)|*.mp3|wav files (*.wav)|*.wav";
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                
                
                fingerPrinter = new AudioFingerPrinter();
                wavConverter = new WavConverter();

                foreach (var file in openFile.FileNames)
                {
                    if (wavConverter.isWav(file))
                    {
                        songs.Add(new Song(Path.GetFileNameWithoutExtension(file), fingerPrinter.determineKeyPoints(wavConverter.convertWavFile(file))));
                    }
                    else
                    {
                        wavConverter.mp3ToWav(file);
                        songs.Add(new Song(Path.GetFileNameWithoutExtension(file), fingerPrinter.determineKeyPoints(wavConverter.convertWavFile(wavConverter.mp3Path))));
                    }
                }
                MessageBox.Show("Songs successfully added!");
            }
        }

        private void openRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            recordBtn.Visible = false;
            openSongBtn.Visible = true;
            songPathField.Visible = true;
        }

        private void recordRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            openSongBtn.Visible = false;
            songPathField.Visible = false;
            recordBtn.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChartForm form = new ChartForm(matches);
            form.Show();
        }
    }
}
