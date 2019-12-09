using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
/*Name: Jun Yang LEE (Jayden)
 * ID: 30003668
 * Task: AT3 Final Project
 */


namespace AT3Project
{
    public partial class MusicPlayer : Form //Question 7 - Contain GUI
    {
        public MusicPlayer()
        {
            InitializeComponent();
        }
        //Question 1 - Contain dynamic data structures
        //create a linked list for song list        
        LinkedList<string> mySongs = new LinkedList<string>();
        //create a list to display songs 
        List<string> displayList = new List<string>();
        //declare empty value for the song;
        string song = "";
        //create a field value for OpenFileDialog;
        private OpenFileDialog OpenFileDialog;

        //method of playing song
        private void PlaySong(string playsong)
        {
            try
            {
                axWindowsMediaPlayer1.URL = playsong; // play song by URL from the Open File Dialog file name

            }
            catch
            {
                MessageBox.Show("Song couldn't play");
            }
        }


        //method to display song in list box
        private void DisplaySong()
        {
            listBoxSong.Items.Clear();//clear all list box items

            foreach (var songs in displayList) //loop thru the display list and add every songs back into list box
            {
                listBoxSong.Items.Add(songs);
            }

            tbNoSongs.Text = NumberOfSongs().ToString(); // show total songs
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
                song = mySongs.First();//get song from first node of the linked list
                PlaySong(song); // play song
            }
            catch
            {
                MessageBox.Show("There is not song in the list"); // no song in linked list
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
                MessageBox.Show("Couldn't play next song"); // error message if no value from the current song
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
                MessageBox.Show("Couldn't play previous song");// error message if no value from the previous song
            }
        }
        //method of play last song of the list
        private void BtnLast_Click(object sender, EventArgs e)
        {
            try
            {
                song = mySongs.Last();//get song from last node of the linked list
                PlaySong(song);// play song
            }

            catch (Exception ex)
            {
                MessageBox.Show("No last song in the list");
            }
        }
        //method to add song into linked list
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty; // declare empty value variable
            OpenFileDialog = new OpenFileDialog(); // browse file dialog box
            OpenFileDialog.Filter = "Audio files (*.mp3, *.wav) | *.mp3; , *.wav;"; // filter only show mp3 and wav audio format file for selection
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = OpenFileDialog.FileName; //get the full path file name
                var fileWOExt = Path.GetFileNameWithoutExtension(OpenFileDialog.SafeFileName); // declare another variable to get only file name without extension and file path 
                string newSong = filePath.ToString(); //convert the file into String variable 
                mySongs.AddLast(newSong); // add the full path file name into linked list in order to play song
                displayList.Add(fileWOExt); // add the only file name to display list
                listBoxSong.Items.Add(fileWOExt); //dispaly in the listbox

            }
            else
            {
                MessageBox.Show("Couldnt add songs");
            }
        }


        //method to remove song in the list
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxSong.SelectedIndex != -1) //if nothing is selected in listbox
            {
                string deleteSong = listBoxSong.GetItemText(listBoxSong.SelectedItem);//get the selected item in listbox and declare as string variable
                int index = listBoxSong.SelectedIndex; //declare the selected index as integer for removal in linked list element
                mySongs.Remove(mySongs.ElementAt(index));//remove songs in linked list by selected index 
                displayList.Remove(deleteSong); // remove the song name from listbox
                DisplaySong();


            }
            else
            {
                MessageBox.Show("Please select a song from the list box to delete.");// error message if nothing selected from list box
            }
        }


        //Question 3 - Contain sorting algorithm
        //Method of bubblesort a linked list https://www.codeproject.com/Questions/1080544/Linked-list-bubble-sort-not-giving-correct-output
        private static void bubbleSortLinkedList(LinkedList<string> a, int s)
        {
            int i, j;
            for (i = 0; i < s; i++)
            {
                for (j = 0; j < s - 1; j++)
                {
                    if (a.ElementAt(j).CompareTo(a.ElementAt(j + 1)) > 0)
                    {
                        LinkedListNode<string> current = a.Find(a.ElementAt(j));
                        var temp = current.Next.Value;
                        current.Next.Value = current.Value;
                        current.Value = temp;
                    }
                }
            }
        }
        //Question 3 - Contain sorting algorithm
        //Method of bubblesort a list https://www.geeksforgeeks.org/sorting-strings-using-bubble-sort-2/
        private static void bubbleSortList(List<string> arr, int n)
        {
            string temp;

            // Sorting strings using bubble sort 
            for (int j = 0; j < n - 1; j++)
            {
                for (int i = j + 1; i < n; i++)
                {
                    if (arr[j].CompareTo(arr[i]) > 0)
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }
        //Question 3 - Contain sorting algorithm
        private void btnSort_Click(object sender, EventArgs e)
        {
            int count = displayList.Count; // list length size
            int count2 = mySongs.Count;  //linked list length size

            //implement bubble sort method
            bubbleSortList(displayList, count);
            bubbleSortLinkedList(mySongs, count2);

            listBoxSong.Items.Clear();
            //add the sorted song into list box
            foreach (var songs in displayList)
            {
                listBoxSong.Items.Add(songs);
            }
        }
        //Question 4 - Contain searching technique 
        //Binary Search method algorithm for list
        static int binarySearch(List<string> arr, string x)
        {
            int l = 0, r = arr.Count - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;

                int res = x.CompareTo(arr[m]);

                // Check if x is present at mid  
                if (res == 0)
                    return m;

                // If x greater, ignore left half  
                if (res > 0)
                    l = m + 1;

                // If x is smaller, ignore right half  
                else
                    r = m - 1;
            }

            return -1;
        }

        //Search button using binary search method  
        private void BtnSearch_Click_1(object sender, EventArgs e)
        {
            string search = tbSearch.Text; //capture search text from user input
            int result = binarySearch(displayList, search); //Question 4 - Contain searching technique implement binarySearch

            //if result not found
            if (result == -1)
            {
                MessageBox.Show("Search not found in list");
                tbSearch.Clear();
            }
            else //result found
            {
                MessageBox.Show("Search found at " + result);
                listBoxSong.SelectedIndex = result; //select the index in listbox from search result
            }
        }

        //Question 5 - Contain third party library (CsvHelper) https://joshclose.github.io/CsvHelper/
        private void BtnExport_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var writer = new StreamWriter(@"D:\Programming III\Final Project\AT3Project\data.csv")) //path location to save the data.csv file
                {
                    using (var csv = new CsvHelper.CsvWriter(writer)) // using third party library csv writer
                    {

                        foreach (var songs in displayList)
                        {
                            csv.WriteField(songs);// add song in cell
                            csv.NextRecord(); // add in every row if has next record
                        }
                        MessageBox.Show("Exported succefully!");
                        writer.Flush();//clear buffer
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

    }
}
