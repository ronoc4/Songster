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
    public partial class frmConfirm : Form
    {
        List<Artist> artists;

        public frmConfirm(List<Artist> passedResults)
        {
            InitializeComponent();
            artists = passedResults;
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
    }
}
