using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInventoryManagement
{
    class Album
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime DateAdded { get; set; }
        public string ImagePath { get; set; }
        public Album()
        {
            DateAdded = DateTime.Now;
        }


        public string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}", Artist, Title, Genre, DateAdded.ToShortDateString(), ImagePath);
        }


    }
}
