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
        public frmAddNew()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            List<Artist> artists = new List<Artist>();
            artists = MusicInfo.getArtistsInfo(txtArtist.Text);
            frmConfirm frmConfirm = new frmConfirm(artists);
            frmConfirm.Show();
            Close();
        }
    }
}
