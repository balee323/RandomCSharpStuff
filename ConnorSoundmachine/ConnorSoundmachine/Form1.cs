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

namespace ConnorSoundmachine
{
    public partial class Form1 : Form
    {



        List<FileInfo> soundFiles;

        public Form1()
        {
            InitializeComponent();


            string path = @"d:\ConnorAudio\";

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {

                    var dir = new DirectoryInfo(path);
                    soundFiles = dir.GetFiles().ToList();
                }
                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("That path does not exist, folder created.");
                }          
               
            }
            catch
            {

            }




        }

        private void ClickMe_Click(object sender, EventArgs e)
        {

            System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            var rand = new Random(DateTime.Now.Second);
            var selected = rand.Next(0, soundFiles.Count - 1);

            var fileLocation = soundFiles[selected].FullName;
        
            player.SoundLocation = fileLocation;

            player.Play();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
