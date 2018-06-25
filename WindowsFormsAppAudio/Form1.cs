using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;

namespace WindowsFormsAppAudio
{
    public partial class Form1 : Form
    {
        List<string> Timestamps = new List<string>();
        List<string> Names = new List<string>();
        string musicFileLocation = "";
        string fileFolder = "";
        string[] stringSeparators = new string[] { ".mp3" };
        string[] result;

        public Form1()
        {
            InitializeComponent();
        }

        private void Browse1Button_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog();

            if(result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = System.IO.File.ReadAllText(file);
                    AudioFileLocationTextBox.Text = file;
                    musicFileLocation = file;
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size);  //Shows file size for debugging

            Console.WriteLine(result); //
            Timestamps.Clear();
            Names.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void BrowseJPGButton_Click(object sender, EventArgs e)
        {
            using (StringReader reader = new StringReader(TimestampNameRichTextBox.Text))
            {
                string line;
                string Name = "";
                int value;
                while((line = reader.ReadLine()) != null)
                {
                    //Do something with the line
                    bool colon = false;
                    String[] elements = line.Split();
                    foreach(string element in elements)
                    {
                        //element added to Timestamps
                        if (element.Contains(':') && !colon && int.TryParse(element.Split(':')[0], out value) && int.TryParse(element.Split(':')[1], out value)) 
                        {
                            Timestamps.Add(element);
                            colon = true;  //Set colon to true.  We are only interested in the beginning time, not the end times.
                        }
                        //element will be added to Names
                        else
                        {
                            if (!element.Contains('\\') && !element.Contains('/'))
                            {
                                var charsToRemove = new string[] { "?", "@", ";", "!", "#", ":", "\""};



                                string modified = element;
                                foreach(var c in charsToRemove)
                                {
                                    modified = modified.Replace(c, string.Empty);
                                    string NoNumbers = new String(modified.Where(cd => (cd < '0' || cd > '9')).ToArray());
                                    modified = NoNumbers;
                                }
                                Name += " " + modified;
                            }
                        }
                    }

                    //Check if the string is not just whitespaces.  
                    if(!String.IsNullOrWhiteSpace(Name))
                        Names.Add(Name);
                    Name = "";
                }
            }


            //Put the information into the list boxes.
            listBox1.DataSource = Timestamps;
            listBox2.DataSource = Names;

        }

        private void ComputeButton_Click(object sender, EventArgs e)
        {
            if(musicFileLocation == "")
            {
                Browse1Button_Click(sender, e);
                ComputeButton_Click(sender, e);
            }
            else
            {
                //What if the file has a period within it?
                //fileFolder = musicFileLocation.Split('.')[0];  //Split by the .extension and give me the first part
                fileFolder = musicFileLocation.Split(stringSeparators, StringSplitOptions.None)[0];
                System.IO.Directory.CreateDirectory(fileFolder);

                var Timestamp = Timestamps.GetEnumerator();
                var NextTimestamp = Timestamps.GetEnumerator();
                var Name = Names.GetEnumerator();
                Name.MoveNext();
                NextTimestamp.MoveNext();
                NextTimestamp.MoveNext();



                int count = 1;
                while (Timestamp.MoveNext())
                {
                    //If this is the last timestamp/song, then the nextTimestamp.Current will be null.
                    if (NextTimestamp.Current == null)
                    {
                        TrimMp3(musicFileLocation, System.IO.Path.Combine(fileFolder, Name.Current + ".mp3"), computeSecs(Timestamp.Current), new Mp3FileReader(musicFileLocation).TotalTime);
                    }
                    else
                    {
                        TrimMp3(musicFileLocation, System.IO.Path.Combine(fileFolder, Name.Current + ".mp3"), computeSecs(Timestamp.Current), computeSecs(NextTimestamp.Current));
                    }

                    //Adjusting the file tag information
                    var file = TagLib.File.Create(System.IO.Path.Combine(fileFolder, Name.Current +".mp3"));
                    file.Tag.Track = (uint)count;
                    file.Tag.TrackCount = (uint)Timestamps.Count();
                    file.Save();

                    Name.MoveNext();
                    NextTimestamp.MoveNext();
                    count++;
                }

            }
        }


        public TimeSpan computeSecs(string TimeStamp)
        {
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            //Return the end if null
            if (TimeStamp == null)
                return new Mp3FileReader(musicFileLocation).TotalTime;


            string[] Parts = TimeStamp.Split(':');
            Console.WriteLine("The timestamp had " + Parts.Length + " number of elements");

            if(Parts.Length == 3)
            {
                Int32.TryParse(Parts[0], out hours);
                
                Int32.TryParse(Parts[1], out minutes);

                Int32.TryParse(Parts[2], out seconds);

                return new TimeSpan(hours, minutes, seconds);//hours + minutes + seconds;
            }
            else
            {
                Int32.TryParse(Parts[0], out minutes);

                Int32.TryParse(Parts[1], out seconds);

                return new TimeSpan(hours, minutes, seconds);
            }
        }


        public static void TrimWavFile(string inPath, string outPath, TimeSpan cutFromStart, TimeSpan cutFromEnd)
        {
            using (WaveFileReader reader = new WaveFileReader(inPath))
            {
                using (WaveFileWriter writer = new WaveFileWriter(outPath, reader.WaveFormat))
                {
                    int bytesPerMillisecond = reader.WaveFormat.AverageBytesPerSecond / 1000;

                    int startPos = (int)cutFromStart.TotalMilliseconds * bytesPerMillisecond;
                    startPos = startPos - startPos % reader.WaveFormat.BlockAlign;

                    int endBytes = (int)cutFromEnd.TotalMilliseconds * bytesPerMillisecond;
                    endBytes = endBytes - endBytes % reader.WaveFormat.BlockAlign;
                    int endPos = (int)reader.Length - endBytes;

                    TrimWavFile(reader, writer, startPos, endPos);
                }
            }
        }

        private static void TrimWavFile(WaveFileReader reader, WaveFileWriter writer, int startPos, int endPos)
        {
            reader.Position = startPos;
            byte[] buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                int bytesRequired = (int)(endPos - reader.Position);
                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }


        void TrimMp3(string inputPath, string outputPath, TimeSpan? begin, TimeSpan? end)
        {
            if (begin.HasValue && end.HasValue && begin > end)
                throw new ArgumentOutOfRangeException("end", "end should be greater than begin");

            using (var reader = new Mp3FileReader(inputPath))
            using (var writer = System.IO.File.Create(outputPath))
            {
                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                    if (reader.CurrentTime >= begin || !begin.HasValue)
                    {
                        if (reader.CurrentTime <= end || !end.HasValue)
                            writer.Write(frame.RawData, 0, frame.RawData.Length);
                        else break;
                    }
            }
        }
    }

}
