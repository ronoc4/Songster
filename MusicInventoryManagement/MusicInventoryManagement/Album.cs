using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInventoryManagement
{
    public class Album
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string IdCode { get; set; }
        public string ImagePath { get; set; }
        public string info { get; set; }
        public Album()
        {
        }


        public string storageText()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}", IdCode, Artist, Title, Genre, ImagePath);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Artist, Title);
        }
    }
}
