using System;
using System.Data;
using System.Data.SqlClient;

namespace Soulstone.Data
{
    public sealed class SqlServerDBLayer : DBLayerBase
    {
        #region private fields
        private static SqlServerDBLayer _instance;
        #endregion

        #region constructor
        private SqlServerDBLayer() {}
        #endregion

        #region public properties
        public static SqlServerDBLayer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SqlServerDBLayer();
                }
                return _instance;
            }
        }
        #endregion

        #region private methods
        private void SPExecuteNonQuery(string name, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = name;
                foreach (SqlParameter p in parameters)
                {
                    command.Parameters.Add(p);
                }
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region public methods
        public override bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void CreateOrUpdateHost(string hostName)
        {
            SPExecuteNonQuery("CreateOrUpdateHost", new SqlParameter[]{new SqlParameter("@hostName", hostName)} );
        }

        public override void CreateOrUpdateHostShare(string hostName, string sharePath)
        {
            SPExecuteNonQuery("CreateOrUpdateHostShare", new SqlParameter[] { new SqlParameter("@hostName", hostName), new SqlParameter("@sharePath", sharePath) });
        }

        public override void CreateOrUpdateMp3File(string hostName, string sharePath, string filePath, string album, string artist, string title, int year, string genre)
        {
            SPExecuteNonQuery("CreateOrUpdateMp3FileLink", new SqlParameter[] { new SqlParameter("@hostName", hostName), new SqlParameter("@sharePath", sharePath), new SqlParameter("@filePath", filePath), new SqlParameter("@album", album), new SqlParameter("@artist", artist), new SqlParameter("@title", title), new SqlParameter("@year", year), new SqlParameter("@genre", genre) });
        }

        public override void DeleteObsoleteHosts()
        {
            throw new NotImplementedException();
        }

        public override void DeleteObsoleteHostShares()
        {
            throw new NotImplementedException();
        }

        public override void DeleteObsoleteMp3Files()
        {
            throw new NotImplementedException();
        }

        public override DataTable Search(string album, string artist, string title, int year, string genre)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
