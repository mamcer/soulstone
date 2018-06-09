using System;
using System.Data;

using Soulstone.Data;

namespace Soulstone.Mp3
{
    public sealed class Mp3FileLinkManager
    {
        #region private fields
        private static Mp3FileLinkManager _instance;
        private DBLayerBase _dataLayer;
        #endregion

        #region constructor
        private Mp3FileLinkManager(){ }
        #endregion

        #region private properties
        private DBLayerBase DBLayer
        {
            get
            {
                if (_dataLayer == null)
                {
                    _dataLayer = SqlServerDBLayer.Instance;
                }
                return _dataLayer;
            }
        }
        #endregion

        #region public properties
        public static Mp3FileLinkManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Mp3FileLinkManager();
                }
                return _instance;
            }
        }
        #endregion

        #region public methods
        public void InitializeConnectionString(string conn)
        {
            DBLayer.ConnString = conn;
        }
        #endregion
    }
}
