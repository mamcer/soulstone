using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Data;

using Soulstone.Mp3;
using Soulstone.Data;

namespace Soulstone.WebUI
{
    // NOTE: If you change the class name "SoulstoneService" here, you must also update the reference to "SoulstoneService" in Web.config.
    public class SoulstoneService : ISoulstoneService
    {
        #region ISoulstoneService Members

        public SearchResultSet Search(string album, string artist, string title, int year, string genre)
        {
            DateTime timeNow = DateTime.Now;
            DataTable dtResult = MusicTrackManager.Instance.Search(album, artist, title, year, genre);
            SearchResultSet resultSet = new SearchResultSet();
            int i = 1;
            SearchResult sr = null;
            foreach (DataRow dr in dtResult.Rows)
            {
                Guid currentMusicTrackId = new Guid(dr[DBConstants.MusicTrackId].ToString());
                if (sr == null || sr.MusicTrackId != currentMusicTrackId)
                {
                    sr = new SearchResult(currentMusicTrackId, string.Format("{0}. {1} - {2}", i, dr[DBConstants.Artist], dr[DBConstants.Title]));
                    resultSet.SearchResults.Add(i++, sr);
                }
                sr.ResultPath.Add(new MusicTrackLocation(new Guid(dr[DBConstants.HostId].ToString()), dr[DBConstants.Path].ToString()));
            }
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = now - timeNow;
            double seconds = timeSpan.Seconds;
            seconds += timeSpan.Milliseconds / 1000d;
            resultSet.SearchSeconds = seconds;
            return resultSet;
        }

        public MusicTrack GetMusicTrack(Guid musicTrackId)
        {
            DataRow dr = MusicTrackManager.Instance.GetMusicTrack(musicTrackId);
            if (dr != null)
            {
                MusicTrack musicTrack = new MusicTrack();
                if (dr[DBConstants.Title] != DBNull.Value)
                {
                    musicTrack.Title = dr[DBConstants.Title].ToString();
                }
                else
                {
                    musicTrack.Title = string.Empty;
                }
                if (dr[DBConstants.Artist] != DBNull.Value)
                {
                    musicTrack.Artist = dr[DBConstants.Artist].ToString();
                }
                else
                {
                    musicTrack.Artist = string.Empty;
                }
                if (dr[DBConstants.Album] != DBNull.Value)
                {
                    musicTrack.Album = dr[DBConstants.Album].ToString();
                }
                else
                {
                    musicTrack.Album = string.Empty;
                }
                if (dr[DBConstants.Genre] != DBNull.Value)
                {
                    musicTrack.Genre = dr[DBConstants.Genre].ToString();
                }
                else
                {
                    musicTrack.Genre = string.Empty;
                }
                if (dr[DBConstants.Year] != DBNull.Value && dr[DBConstants.Year].ToString() != "0")
                {
                    musicTrack.Year = dr[DBConstants.Year].ToString();
                }
                else
                {
                    musicTrack.Year = string.Empty;
                }
                return musicTrack;
            }
            else
            {
                return null;
            }
        }

        public FileCountInfo GetTotalFileCount()
        {
            DataRow dr = MusicTrackManager.Instance.GetTotalFileCount();
            if (dr != null)
            {
                return new FileCountInfo(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]));
            }
            return null;
        }

        #endregion

    }

    [DataContract]
    public struct MusicTrackLocation
    {
        [DataMember]
        public Guid hostId;
        [DataMember]
        public string path;
        [DataMember]
        public bool isValid;

        public MusicTrackLocation(Guid hi, string p)
        {
            hostId = hi;
            path = p;
            isValid = true;
        }
    }

    [DataContract]
    public class SearchResult
    {
        private Guid musicTrackId;
        private string trackString;
        List<MusicTrackLocation> resultPath;

        #region constructor

        public SearchResult(Guid mti, string ts)
        {
            MusicTrackId = mti;
            TrackString = ts;
            resultPath = new List<MusicTrackLocation>();
        }

        #endregion

        #region public properties

        [DataMember]
        public Guid MusicTrackId
        {
            get
            {
                return musicTrackId;
            }
            private set
            {
                musicTrackId = value;
            }
        }

        [DataMember]
        public string TrackString
        {
            get
            {
                return trackString;
            }
            private set
            {
                trackString = value;
            }
        }

        [DataMember]
        public List<MusicTrackLocation> ResultPath
        {
            get
            {
                return resultPath;
            }
        }

        #endregion
    }

    [DataContract]
    public class SearchResultSet
    {
        [DataMember]
        public double SearchSeconds;
        [DataMember]
        public Dictionary<int, SearchResult> SearchResults;

        public SearchResultSet()
        {
            SearchResults = new Dictionary<int, SearchResult>();
        }
    }

    [DataContract]
    public class FileCountInfo
    {
        [DataMember]
        public int FileCount;
        [DataMember]
        public int FileFontCount;

        public FileCountInfo(int fc, int ffc)
        {
            FileCount = fc;
            FileFontCount = ffc;
        }
    }

    [DataContract]
    /// <summary>
    /// Represents a link to a file, with some other information collected from the ID3 Tag 
    /// </summary>
    public sealed class MusicTrack
    {
        private string _artist;
        private string _album;
        private string _title;
        private string _year;
        private string _genre;

        #region constructors
        /// <summary>
        /// Create an empty instance of a Mp3FileLink
        /// </summary>
        public MusicTrack()
        {
            Title = string.Empty;
            Album = string.Empty;
            Artist = string.Empty;
            Year = string.Empty;
            Genre = string.Empty;
        }

        /// <summary>
        /// Create and initialize an instance of a Mp3FileLink
        /// </summary>
        /// <param name="title"></param>
        /// <param name="album"></param>
        /// <param name="artist"></param>
        /// <param name="year"></param>
        /// <param name="genre"></param>
        public MusicTrack(string title, string album, string artist, string year, string genre)
        {
            Title = title;
            Album = album;
            Artist = artist;
            Year = year;
            Genre = genre;
        }
        #endregion

        #region properties

        [DataMember]
        /// <summary>
        /// Returns the title of the song
        /// </summary>
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

        [DataMember]
        /// <summary>
        /// Returns the album title of the song
        /// </summary>
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

        [DataMember]
        /// <summary>
        /// Returns the artist of the song
        /// </summary>
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

        [DataMember]
        /// <summary>
        /// Returns the year of the song
        /// </summary>
        public string Year
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

        [DataMember]
        /// <summary>
        /// Returns the genre of the song
        /// </summary>
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
