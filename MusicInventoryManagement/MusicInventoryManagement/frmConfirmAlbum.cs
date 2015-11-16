using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicInventoryManagement
{
    public partial class frmConfirmAlbum : Form
    {
        private Artist Artist;
        private Album album;
        private frmMain mainForm { get; set; }
        public frmConfirmAlbum(Artist artist, frmMain f1)
        {
            InitializeComponent();
            Artist = artist;
            mainForm = f1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex > -2)
            {
                album = (Album) lstResults.SelectedItem;
                mainForm.setAlbum(album);
                Close();
            }
        }

        private void frmConfirmAlbum_Load(object sender, EventArgs e)
        {
            foreach (var album in Artist.Discography)
            {
                lstResults.Items.Add(album);
            }
        }
    }
}
