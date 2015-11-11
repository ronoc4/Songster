using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace MusicInventoryManagement
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
#region GlobalVariables
        //Create dictionary of albums with int keys
        Dictionary<int, Album> Albums = new Dictionary<int, Album>();
        #endregion

#region EventHandlers
        //Creating album object
        private void btnAdd_Click(object sender, EventArgs e)
        {

            //Album toAdd = new Album();
            //toAdd.Artist = txtArtist.Text;
            //toAdd.Title = txtAlbum.Text;
            //toAdd.ImagePath = addAlbumArt();

            ////Adding new album to list of albums
            //Albums.Add(Albums.Count, toAdd);
            //UpdateList();

        }

        private void lstInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAlbumArt();
        }

        //On close create file with our Albums
        //if the file exists, overwrite it
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                saveAlbums("MusicStorage.txt");
            }
            catch (Exception)
            {
                //if an exception is caught, we prompt the user for input
                DialogResult dr = MessageBox.Show(
                    "Error saving file, would you like to try and save it somewhere else?", this.Text,
                    MessageBoxButtons.YesNo);
                //if the user selects yes, we allow them to choose a new save location
                //by passing '~~~~' to the salveAlbums method
                if (dr == DialogResult.Yes)
                {
                    saveAlbums("~~~~~");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                loadAlbums("MusicStorage.txt");
                //update the list view to account for these albums
                UpdateList();
            }
            catch (Exception)
            {
                //if an exception is caught, we prmopt the user for input
                DialogResult dr =
                    MessageBox.Show(
                        "Unable to load your albums from the album file, would you like to select another source?",
                        this.Text, MessageBoxButtons.YesNoCancel);
                //if the user chooses yes in our prompt, we allow them to choose a new
                //file name by passing '~~~~~' to the load albums method
                if (dr == DialogResult.Yes)
                {
                    loadAlbums("~~~~~");
                }
                //if cancel is selected the program will close
                if (dr == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
        }
        #endregion

#region Visualupdates

        /// <summary>
        /// this method is used to display the album art of a selected album
        /// </summary>
        private void UpdateAlbumArt()
        {
            if (lstInventory.SelectedIndices.Count > 0)
            {
                pctAlbumArt.ImageLocation = "";
                int index = lstInventory.FocusedItem.Index;
                pctAlbumArt.ImageLocation = Albums[index].ImagePath;
            }
        }

        /// <summary>
        /// this method is used to update the listview form control
        /// to be in sync with our dictionary
        /// </summary>
        private void UpdateList()
        {
            //Clear rows 
            lstInventory.Items.Clear();

            foreach (var album in Albums.Values)
            {
                ListViewItem row = new ListViewItem(album.Artist, 1);
                row.SubItems.Add(album.Title);
                row.SubItems.Add(album.Genre);
                row.SubItems.Add(album.DateAdded.ToShortDateString());

                lstInventory.Items.Add(row);
            }
        }
        #endregion

#region IOMethods

        /// <summary>
        /// this method will return a filepath for the album art
        /// property of an album object
        /// </summary>
        /// <returns></returns>
        private string addAlbumArt()
        {
            string path;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            path = openFile.FileName;
            return path;
        }

        /// <summary>
        /// this method attempts to save our albums in a txt file
        /// the filename parameter sets the file name for the 
        /// File.WriteAllText method
        /// </summary>
        /// <param name="fileName"></param>
        private void saveAlbums(string fileName)
        {
            //check if the source of this call is
            //from the exit exception
            if (fileName == "~~~~~")
            {
                OpenFileDialog of = new OpenFileDialog();
                of.ShowDialog();
                fileName = of.SafeFileName;
            }
            //Build a string for the loop
            StringBuilder sb = new StringBuilder();

            foreach (var album in Albums)
            {
                //Add new line with appendlne method, referencing Album class
                sb.AppendLine(album.ToString());
            }

            File.WriteAllText(fileName, sb.ToString());
        }
        
        /// <summary>
        /// this method attempts to load albums from a txt file
        /// the source parameter is used to define the source file
        /// in our streamreader object
        /// </summary>
        /// <param name="source"></param>
        private void loadAlbums(string source)
        {
            //check if this method was called from the exception in the
            //form load event
            if (source == "~~~~~")
            {
                //if it is, prompt the user for a new file
                //to try and read and set that to our source variable
                OpenFileDialog of = new OpenFileDialog();
                of.ShowDialog();
                source = of.SafeFileName;
            }

            //Create a streamreader opbject and set the source to
            //the txt file we have stored our albums in
            StreamReader sr = new StreamReader(source);

            //this string wil hold our line as a string 
            string line;
            //this will be the dictionary key
            int key = 0;
            //loop while we are not at the end of 
            //our streamreder
            while (!sr.EndOfStream)
            {
                //set the line to our current line
                line = sr.ReadLine();
                //create an array of the elements on our string
                //and split the string on the | char
                string[] album = line.Split('|');
                //initalize an album object to add
                Album toAdd = new Album();
                //set the elements of our string array
                //to the properties of our album
                toAdd.Artist = album[0];
                toAdd.Title = album[1];
                toAdd.Genre = album[2];
                toAdd.DateAdded = DateTime.Parse(album[3]);
                toAdd.ImagePath = album[4];
                //add this album to our dictionary
                Albums.Add(key, toAdd);
                //add one to our key
                key++;
            }
            //close the streamreader so we can overwrite
            //this file with any changes on exit
            sr.Close();
        }
        #endregion

        private void checkNames(object sender, EventArgs e)
        {
            frmAddNew frmAddNew = new frmAddNew();
            frmAddNew.ShowDialog();
        }
    }
}
    