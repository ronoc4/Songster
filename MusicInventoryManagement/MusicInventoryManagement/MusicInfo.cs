﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;
using MusicInventoryManagement.Properties;


namespace MusicInventoryManagement
{
    class MusicInfo
    {

        public static XDocument getXML(Uri address)
        {
            //build a request of xml data and load it into an xml document oject
            HttpWebRequest web = (HttpWebRequest)WebRequest.Create(address);
            HttpWebResponse resp = (HttpWebResponse)web.GetResponse();
            Stream responseStream = resp.GetResponseStream();
            XDocument xdoc = XDocument.Load(responseStream);
            xdoc.Save("rovi2");
            return xdoc;
        }

        public static Uri buildArtistUri(string searchterm)
        {
            searchterm = searchterm.Replace(" ", "+");

            //the URI builder object will be used to construct the webaddress we will send our request to         
            UriBuilder ub = new UriBuilder();
            ub.Scheme = "http";
            ub.Host = "api.rovicorp.com";
            ub.Path = "search/v2.1/music/search";
            //this is used to construct the more complicated portion of the url, putting the seach, key and signature in the correct place
            ub.Query = string.Format("apikey={0}&sig={1}&query={2}&entitytype=artist&format=xml&include=discography&size=10&", Resources.RoviKey, getSignature(), searchterm);
            return ub.Uri;
        }

        /// <summary>
        /// This method is uesed to get artist information via a 
        /// search to the rovi API
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns>a list of XML node lists: artist names, artist IDs and album uris</returns>
        public static List<Artist> getArtistsInfo(string searchTerm)
        {
            Uri uri = buildArtistUri(searchTerm);
            XDocument xdoc = getXML(uri);
            List<Artist> results = new List<Artist>();

            var names = xdoc.Descendants()
                .Where(t => t.Name.LocalName == "name")
                .Where(p => p.Parent.Name.LocalName == "name");

            var ids = xdoc.Descendants()
                .Where(t => t.Name.LocalName == "id")
                .Where(t => t.Parent.Name.LocalName == "result");

            var infos = xdoc.Descendants()
                .Where(t => t.Name.LocalName == "headlineBio");

            for (int i = 0; i < ids.Count(); i++)
            {
                string nameToAdd = names.ElementAt(i).Value;
                string idToAdd = ids.ElementAt(i).Value;
                string infoToAdd = infos.ElementAt(i).Value;
                results.Add(new Artist(nameToAdd,idToAdd,infoToAdd));
            }
            return results;
        }

        /// <summary>
        /// this method uses gets the current unix time
        /// this is calculated by taking the current GMT
        /// then subtracts the total number of seconds since 
        /// January 1, 1970
        /// it then needs to remove the period at the end and returns
        /// the datetime object as a string
        /// </summary>
        /// <returns></returns>
        private static string getTime()
        {
            //string to store
            string time;

            //calculate unix time
            time = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();

            //remove the priod
            time = time.Substring(0, time.IndexOf("."));

            //return the tiem
            return time;

        }

        /// <summary>
        /// this method uses the key and secret provided by rovi
        /// to calculate the sig required for authenticating the api
        /// the sig is the MD5 hash of a concatination of the 
        /// rovi key + rovi secret + current unix time, this needs
        /// to be within 5 minutes of the server to return our search in xml
        /// </summary>
        /// <returns></returns>
        private static string getSignature()
        {
            //get key and secret from the resource file
            string key = Resources.RoviKey;
            string secret = Resources.RobiSecret;

            //create the full string to be MD5'd
            StringBuilder sb = new StringBuilder();
            sb.Append(key);
            sb.Append(secret);
            sb.Append(getTime());

            //create our md5 object
            MD5 mdFive = MD5.Create();
            //break our string into an array of ascii bytes
            byte[] inPutBytes = Encoding.ASCII.GetBytes(sb.ToString());
            //use the md5 object to calculate the hash
            byte[] hash = mdFive.ComputeHash(inPutBytes);

            //clear out our sb it get the has as a string
            sb.Clear();

            //loop over the hash array and add each character as a
            //hexidecimal with lowercase letters
            foreach (var b in hash)
            {
                //load the hash into a string builder with letters as lowercase
                sb.Append(b.ToString("x2"));
            }

            //finally return our hash as a string
            return sb.ToString();
        }
    }
}
