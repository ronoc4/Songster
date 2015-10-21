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

namespace MusicInventoryManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Create list of albums
        List<Album> Albums = new List<Album>();

        //Creating album object
        private void btnAdd_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            Album toAdd = new Album();
            toAdd.Artist = txtArtist.Text;
            toAdd.Title = txtAlbum.Text;
            toAdd.Genre = txtGenre.Text;
            openFile.ShowDialog();
            toAdd.ImagePath = openFile.FileName;

            //Adding new album to list of albums
            Albums.Add(toAdd);
            UpdateList();

        }

        //Adds image from file to picture box
        private void UpdateAlbumArt()
        {
            if (lstInventory.SelectedIndices.Count > 0)
            {
                pctAlbumArt.ImageLocation = "";
                int index = lstInventory.FocusedItem.Index;
                pctAlbumArt.ImageLocation = Albums[index].ImagePath;
            }
        }

        //Method to add row in List Box
        private void UpdateList()
        {
            //Clear rows 
            lstInventory.Items.Clear();

            foreach (var album in Albums)
            {
                ListViewItem row = new ListViewItem(album.Artist, 1);
                row.SubItems.Add(album.Title);
                row.SubItems.Add(album.Genre);
                row.SubItems.Add(album.DateAdded.ToShortDateString());

                lstInventory.Items.Add(row);
            }
        }

        private void lstInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAlbumArt();
        }

        //On close create file with our Albums
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Build a string for the loop
            StringBuilder sb = new StringBuilder();

            foreach (var album in Albums)
            {
                //Add new line with appendlne method, referencing Album class
                sb.AppendLine(album.ToString());
            }

            File.WriteAllText("MusicStorage.txt", sb.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            StreamReader sr = new StreamReader("MusicStorage.txt");

            string line;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] album = line.Split('|');
                Album toAdd = new Album();
                toAdd.Artist = album[0];
                toAdd.Title = album[1];
                toAdd.Genre = album[2];
                toAdd.DateAdded = DateTime.Parse(album[3]);
                toAdd.ImagePath = album[4];
                Albums.Add(toAdd);
                
            }
            sr.Close();
            UpdateList();
        }
    }
}
