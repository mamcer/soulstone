namespace Soulstone.Mp3
{
    using System;

    /// <summary>
    /// Represents a link to a file, with some other information collected from the ID3 Tag. 
    /// </summary>
    public sealed class MusicTrack
    {
        /// <summary>
        /// The artist of the music track.
        /// </summary>
        private string artist;

        /// <summary>
        /// The album of the music track.
        /// </summary>
        private string album;

        /// <summary>
        /// The title of the music track.
        /// </summary>
        private string title;

        /// <summary>
        /// The year of the music track.
        /// </summary>
        private int year;

        /// <summary>
        /// The genre of the music track.
        /// </summary>
        private string genre;

        #region constructors
        
        /// <summary>
        /// Initializes a new instance of the MusicTrack class.
        /// </summary>
        public MusicTrack()
        {
            this.Title = string.Empty;
            this.Album = string.Empty;
            this.Artist = string.Empty;
            this.Year = DateTime.Now.Year;
            this.Genre = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the MusicTrack class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="album">The album.</param>
        /// <param name="artist">The artist.</param>
        /// <param name="year">The year 0 (for nothing).</param>
        /// <param name="genre">The genre.</param>
        public MusicTrack(string title, string album, string artist, int year, string genre)
        {
            this.Title = this.title;
            this.Album = this.album;
            this.Artist = this.artist;
            this.Year = this.year;
            this.Genre = this.genre;
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets or sets the title of the MusicTrack.
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }

        /// <summary>
        /// Gets or sets the album title of the MusicTrack.
        /// </summary>
        public string Album
        {
            get
            {
                return this.album;
            }

            set
            {
                this.album = value;
            }
        }

        /// <summary>
        /// Gets or sets the artist name of the MusicTrack.
        /// </summary>
        public string Artist
        {
            get
            {
                return this.artist;
            }

            set
            {
                this.artist = value;
            }
        }

        /// <summary>
        /// Gets or sets the year of the MusicTrack.
        /// </summary>
        public int Year
        {
            get
            {
                return this.year;
            }

            set
            {
                this.year = value;
            }
        }

        /// <summary>
        /// Gets or sets the genre of the MusicTrack.
        /// </summary>
        public string Genre
        {
            get
            {
                return this.genre;
            }

            set
            {
                this.genre = value;
            }
        }
        #endregion
    }
}
