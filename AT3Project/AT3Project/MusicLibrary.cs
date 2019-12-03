using LumenWorks.Framework.IO.Csv; //Question 3 - Contain third party library
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
/*Name: Jun Yang LEE (Jayden)
 * ID: 30003668
 * Task: AT3 Final Project
 */
namespace AT3Project
{
    public partial class MusicLibrary : Form //Question 3 - Contain GUI
    {
        //Question 3 - Contain dynamic data structures
        //create a list to hold data from import csv data
        List<string> library = new List<string>();
        public MusicLibrary()
        {
            InitializeComponent();
        }

        //Browsing file method to import csv data file
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //Create a new instance of a OpenFileDialog Class

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) //Launch new File Dialog to select a directory
            {
                string filepath = ofd.FileName; //determine the variable value as the browsed file name
                tbBrowse.Text = filepath; //text box property represents the files that browsed from the openfiledialog
            }
        }

        //Read csv data file into listbox to display result
        private void BtnRead_Click(object sender, EventArgs e)
        {
            listBoxLibrary.Items.Clear(); //clear the list box in case there is previous data

            // using the file that browse from the openfiledialog in the textbox which is a CSV file with headers
            using (CsvReader csv = new CsvReader(new StreamReader(tbBrowse.Text), true))
            {
                //declare a variable that get the maximum number of fields to retrieve each record.
                int fieldCount = csv.FieldCount;

                //get the field header and insert into array.
                string[] headers = csv.GetFieldHeaders();
                while (csv.ReadNextRecord())
                {
                    for (int i = 0; i < fieldCount; i++)
                    {
                        listBoxLibrary.Items.Add(string.Format("{0};", csv[i])); // display every headers and records into the list box
                        library.Add(csv[i]); //add all csv data into list 
                    }
                }


            }
        }
        //Question 3 - Contain sorting algorithm 
        //Bubble Sort method algorithm
        private static void BubbleSort(List<string> array, int n)
        {
            String temp;

            for (int j = 0; j < n - 1; j++)
            {
                for (int i = j + 1; i < n; i++)
                {
                    if (array[j].CompareTo(array[i]) > 0)
                    {
                        temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
        }

        //Question 3 - Contain sorting algorithm 
        private void BtnSort_Click(object sender, EventArgs e)
        {
            int count = library.Count;
            BubbleSort(library, count); //sorting list           
            listBoxLibrary.Items.Clear();
            for (int i = 0; i < library.Count; i++) //display sorted result insert into listbox 
            {
                listBoxLibrary.Items.Add(library[i]);
            }

        }
        //Question 3 - Contain searching technique 
        //Binary Search method algorithm
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
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text; //capture search text from user input
            int result = binarySearch(library, search); //Question 3 - Contain searching technique
            //if result not found
            if (result == -1)
            {
                MessageBox.Show("Search not found in list");
                tbSearch.Clear();
            }
            else //result found
            {
                MessageBox.Show("Search found at " + result);
                listBoxLibrary.SelectedIndex = result; //select the index in listbox from search result
            }
        }
    }
}
