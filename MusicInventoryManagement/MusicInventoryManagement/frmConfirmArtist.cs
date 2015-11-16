using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MusicInventoryManagement
{
    public partial class frmConfirmArtist : Form
    {
        List<Artist> artists;
        private frmMain mainForm { get; set; }

        public frmConfirmArtist(List<Artist> passedResults, frmMain f1)
        {
            InitializeComponent();
            artists = passedResults;
            mainForm = f1;

        }
        
        private void frmConfirm_Load(object sender, EventArgs e)
        {
            foreach (Artist artist in artists)
            {
                lstResults.Items.Add(artist);
            }
        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
                txtInfo.Clear();
            if (lstResults.SelectedIndex > -1)
            {
                Artist artist = (Artist)lstResults.SelectedItem;
                txtInfo.Text = artist.Info;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex > -1)
            {
                Artist artist = (Artist)lstResults.SelectedItem;
                artist.Discography = MusicInfo.getAlbums(artist.Id, artist.Name);
                frmConfirmAlbum frmConfirmAlbum = new frmConfirmAlbum(artist, mainForm);
                frmConfirmAlbum.Show();
                Close();
            }
        }
    }
}
