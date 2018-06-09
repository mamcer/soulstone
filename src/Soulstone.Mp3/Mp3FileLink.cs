using System;

namespace Soulstone.Mp3
{
    public sealed class Mp3FileLink
    {
        private string _path;
        private string _artist;
        private string _album;
        private string _title;
        private int _year;
        private string _genre;

        #region constructors
        public Mp3FileLink()
        {
            Title = string.Empty;
            Album = string.Empty;
            Artist = string.Empty;
            Path = string.Empty;
            Year = DateTime.Now.Year;
            Genre = string.Empty;
        }

        public Mp3FileLink(string t, string al, string ar, string h, string p)
        {
            Title = t;
            Album = al;
            Artist = ar;
            Path = p;

        }
        #endregion

        #region properties
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public string Album
        {
            get
            {
                return _album;
            }
            set
            {
                _album = value;
            }
        }

        public string Artist
        {
            get
            {
                return _artist;
            }
            set
            {
                _artist = value;
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
            }
        }

        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
            }
        }
        #endregion
    }
}
