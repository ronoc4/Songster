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
    public partial class frmAddNew : Form
    {
        private frmMain mainForm { get; set; }

        public frmAddNew(frmMain f1)
        {
            InitializeComponent();
            mainForm = f1;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            List<Artist> artists = new List<Artist>();
            artists = MusicInfo.getArtistsInfo(txtArtist.Text);
            frmConfirmArtist frmConfirm = new frmConfirmArtist(artists, mainForm);
            frmConfirm.Show();
            Close();
        }
    }
}
