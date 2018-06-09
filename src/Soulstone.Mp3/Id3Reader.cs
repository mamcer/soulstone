namespace Soulstone.Mp3
{
    using System;
    using System.IO;
    
    /// <summary>
    /// Allow scan a file for it's Id3 information.
    /// </summary>
    public sealed class Id3Reader
    {
        #region private members

        /// <summary>
        /// The unique instance on Id3Reader.
        /// </summary>
        private static Id3Reader instance = null;
        
        #endregion

        #region constuctor

        /// <summary>
        /// Prevents a default instance of the Id3Reader class from being created.
        /// </summary>
        private Id3Reader()
        {
        }

        #endregion

        #region properties
        /// <summary>
        /// Gets an instance of the ID3Reader class.
        /// </summary>
        public static Id3Reader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Id3Reader();
                }

                return instance;
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Scan the Id3 Tag of the file on fullPath Path, load and return an Mp3FileLink object.
        /// </summary>
        /// <param name="fullPath">The path of the file to create the MusicTrack.</param>
        /// <returns>Mp3FileLink object.</returns>
        public MusicTrack GetMusicTrackFromID3(string fullPath)
        {
            try
            {
                TagLib.File file = TagLib.File.Create(fullPath);

                string title = file.Tag.Title;
                string album = file.Tag.Album;
                string[] artists = file.Tag.AlbumArtists;
                int year = (int)file.Tag.Year;
                string[] genres = file.Tag.Genres;
                string artist = string.Empty;

                foreach (string a in artists)
                {
                    if (artist != string.Empty)
                    {
                        artist += string.Format("-{0}", a);
                    }
                    else
                    {
                        artist = a;
                    }
                }

                if (title == string.Empty && album == string.Empty && artist == string.Empty)
                {
                    return null;
                }

                if (title == string.Empty)
                {
                    title = Path.GetFileNameWithoutExtension(fullPath);
                }

                string genre = string.Empty;
                foreach (string g in genres)
                {
                    if (genre != string.Empty)
                    {
                        genre += string.Format("-{0}", g);
                    }
                    else
                    {
                        genre = g;
                    }
                }

                return new MusicTrack(title, album, artist, year, genre);
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
