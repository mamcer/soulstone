using System;
using System.Data;

namespace Soulstone.Data
{
    public abstract class DBLayerBase
    {
        #region private fields
        private string _connString;
        #endregion

        #region public properties
        public string ConnString
        {
            set
            {
                _connString = value;
            }
            get
            {
                return _connString;
            }
        }
        #endregion

        #region public abstract methods
        public abstract bool TestConnection();
        public abstract void CreateOrUpdateHost(string hostName);
        public abstract void CreateOrUpdateHostShare(string hostName, string sharePath);
        public abstract void CreateOrUpdateMp3File(string hostName, string sharePath, string filePath, string album, string artist, string title, int year, string genre);
        public abstract void DeleteObsoleteHosts();
        public abstract void DeleteObsoleteHostShares();
        public abstract void DeleteObsoleteMp3Files();
        public abstract DataTable Search(string album, string artist, string title, int year, string genre);
        #endregion
    }
}