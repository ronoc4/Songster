using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicInventoryManagement
{
    public class Artist
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Info { get; set; }

        public Artist()
        {
            
        }

        public Artist(string name, string id,string info)
        {
            Name = name;
            Id = id;
            Info = info;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
