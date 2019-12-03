using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
/*Name: Jun Yang LEE (Jayden)
 * ID: 30003668
 * Task: AT3 Final Project
 */


namespace AT3Project
{
    public partial class MusicPlayer : Form //Question 3 - Contain GUI
    {
        public MusicPlayer()
        {
            InitializeComponent();
        }
        //Question 3 - Contain dynamic data structures
        //create the linked list         
        LinkedList<string> mySongs = new LinkedList<string>();
        //declare empty value for the song;
        string song = "";
        //create a field value for OpenFileDialog;
        private OpenFileDialog OpenFileDialog;

        //method of playing song
        private void PlaySong(string playsong)
        {
            try
            {
                axWindowsMediaPlayer1.URL = playsong;
            }
            catch
            {
                MessageBox.Show("Song couldn't play");
            }
        }


        //method to display song in list box
        private void DisplaySong()
        {
            listBoxSong.Items.Clear();

            foreach (var songs in mySongs)
            {
                listBoxSong.Items.Add(songs);
            }

            tbNoSongs.Text = NumberOfSongs().ToString();
        }

        //display song in totals
        private int NumberOfSongs()
        {
            return mySongs.Count();
        }
        //Method of playing fist song in the list
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                song = mySongs.First();
                PlaySong(song);
            }
            catch
            {
                MessageBox.Show("There is not song in the list");
            }
        }
        //method of playing next song
        private void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                //keep track of the current playing song then play the next from it
                string currentSong = axWindowsMediaPlayer1.URL;
                string nextSong = mySongs.Find(currentSong).Next.Value;
                PlaySong(nextSong);
            }
            catch
            {
                MessageBox.Show("Couldn't play next song");
            }
        }
        //method of playing previous song
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                //keep track of the current playing song then play the previous from it
                string currentSong = axWindowsMediaPlayer1.URL;
                string prevSong = mySongs.Find(currentSong).Previous.Value;
                PlaySong(prevSong);

            }
            catch
            {
                MessageBox.Show("Couldn't play previous song");
            }
        }
        //method of play last song of the list
        private void BtnLast_Click(object sender, EventArgs e)
        {
            try
            {
                song = mySongs.Last();
                PlaySong(song);
            }
            catch(Exception ex)
            {
                MessageBox.Show("No last song in the list");
            }                        
        }
        //method to add song into linked list
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            OpenFileDialog = new OpenFileDialog();
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = OpenFileDialog.FileName;
                string newSong = filePath.ToString();
                mySongs.AddLast(newSong);
                DisplaySong();
            }
        }


        //method to remove song in the list
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxSong.SelectedIndex != -1)
            {
                string deleteSong = listBoxSong.GetItemText(listBoxSong.SelectedItem);
                mySongs.Remove(deleteSong);
                DisplaySong();
            }
            else
            {
                MessageBox.Show("Please select a song from the list box to delete.");
            }
        }

        //Open Music Library Form
        private void BtnLibrary_Click(object sender, EventArgs e)
        {
            MusicLibrary ml = new MusicLibrary();
            ml.Show();
        }
    }
}
