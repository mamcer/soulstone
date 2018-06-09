namespace Soulstone.Data
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// An implementation of the DataLayerBase class for MS SQL Server.
    /// </summary>
    public sealed class SqlServerDataLayer : DataLayerBase
    {
        #region static private fields

        /// <summary>
        /// Prevents a default instance of the SqlServerDataLayer class from being created.
        /// </summary>
        private static SqlServerDataLayer instance;

        #endregion

        #region private fields

        /// <summary>
        /// The connection string.
        /// </summary>
        private string connString;

        #endregion

        #region constructor

        /// <summary>
        /// Prevents a default instance of the SqlServerDataLayer class from being created.
        /// </summary>
        private SqlServerDataLayer()
        {
            if (ConfigurationManager.ConnectionStrings["SoulstoneDB"] != null)
            {
                this.ConnString = ConfigurationManager.ConnectionStrings["SoulstoneDB"].ConnectionString;
            }
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        public string ConnString
        {
            set
            {
                this.connString = value;
            }

            get
            {
                return this.connString;
            }
        }

        /// <summary>
        /// Gets the unique instance of the SqlServerDataLayer class.
        /// </summary>
        internal static SqlServerDataLayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SqlServerDataLayer();
                }

                return instance;
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Test the underlying connection.
        /// </summary>
        /// <returns>true or false.</returns>
        public override bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnString))
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

        /// <summary>
        /// Create a host with the given name.
        /// </summary>
        /// <param name="hostName">The name of the host.</param>
        public override void CreateHost(string hostName)
        {
            this.SPExecuteNonQuery("CreateHost", new SqlParameter[] { new SqlParameter("@hostName", hostName) });
        }

        /// <summary>
        /// Create or update the Music Track info.
        /// </summary>
        /// <param name="hostName">The host name where the Music Track belongs.</param>
        /// <param name="filePath">The path to the song.</param>
        /// <param name="album">The album of the song.</param>
        /// <param name="artist">The artist of the song.</param>
        /// <param name="title">The title of the song.</param>
        /// <param name="year">The year of the song.</param>
        /// <param name="genre">The genre.</param>
        public override void CreateOrUpdateMusicTrack(string hostName, string filePath, string album, string artist, string title, int year, string genre)
        {
            this.SPExecuteNonQuery("CreateOrUpdateMusicTrack", new SqlParameter[] { new SqlParameter("@hostName", hostName), new SqlParameter("@path", filePath), new SqlParameter("@artist", artist), new SqlParameter("@album", album), new SqlParameter("@title", title), new SqlParameter("@year", year), new SqlParameter("@genre", genre) });
        }

        /// <summary>
        /// Remove obsolete entries from the database.
        /// </summary>
        public override void DeleteObsoleteEntries()
        {
            int failedUpdateNumber = 5;
            if (ConfigurationManager.AppSettings["MaxFailedUpdateNumber"] != null)
            {
                failedUpdateNumber = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFailedUpdateNumber"]);
            }

            this.SPExecuteNonQuery("UpdateFailedEntries", null);
            this.SPExecuteNonQuery("DeleteObsoleteEntries", new SqlParameter[] { new SqlParameter("@failedUpdateNumber", failedUpdateNumber) });
        }

        /// <summary>
        /// Remove all obsolete entries from the database taking into account the given number of failed updates. 
        /// </summary>
        /// <param name="failedUpdateNumber">Over that number the entries will be removed.</param>
        public override void DeleteObsoleteEntries(int failedUpdateNumber)
        {
            this.SPExecuteNonQuery("DeleteObsoleteEntries", new SqlParameter[] { new SqlParameter("@failedUpdateNumber", failedUpdateNumber) });
        }

        /// <summary>
        /// Search for a file in the database.
        /// </summary>
        /// <param name="album">The album to be searched. Can be empty.</param>
        /// <param name="artist">The artist to be searched. Can be empty.</param>
        /// <param name="title">The title to be searched. Can be empty.</param>
        /// <param name="year">The year to be searched. 0 for nothing.</param>
        /// <param name="genre">The genre to be searched. Can be empty.</param>
        /// <returns>A datatable with the result.</returns>
        public override DataTable Search(string album, string artist, string title, int year, string genre)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "Search";
                if (album != string.Empty)
                {
                    command.Parameters.Add(new SqlParameter("@album", album));
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@album", DBNull.Value));
                }

                if (artist != string.Empty)
                {
                    command.Parameters.Add(new SqlParameter("@artist", artist));
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@artist", DBNull.Value));
                }

                if (title != string.Empty)
                {
                    command.Parameters.Add(new SqlParameter("@title", title));
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@title", DBNull.Value));
                }

                if (genre != string.Empty)
                {
                    command.Parameters.Add(new SqlParameter("@genre", genre));
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@genre", DBNull.Value));
                }

                if (year != 0)
                {
                    command.Parameters.Add(new SqlParameter("@year", year));
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@year", DBNull.Value));
                }

                DataTable dt = new DataTable("results");
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                sqlAdapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Check if a particular hosts exists.
        /// </summary>
        /// <param name="hostName">The name of the host to be searched.</param>
        /// <returns>True or false.</returns>
        public override bool HostExists(string hostName)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = string.Format("select dbo.GetHostIdFromName('{0}')", hostName);
                object obj = command.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    return obj.ToString() != string.Empty;
                }

                return false;
            }
        }

        /// <summary>
        /// Get the total file count and file fonts.
        /// </summary>
        /// <returns>A DataRow with the two values.</returns>
        public override DataRow GetTotalFileCount()
        {
            using (SqlConnection conn = new SqlConnection(this.ConnString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetFileFontCount";
                DataTable dt = new DataTable("results");
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                sqlAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }

                return null;
            }
        }

        /// <summary>
        /// Get all the info to create a MusicTrack object.
        /// </summary>
        /// <param name="musicTrackId">The id of the MusicTrack.</param>
        /// <returns>A DataRow with the info.</returns>
        public override DataRow GetMusicTrack(Guid musicTrackId)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetMusicTrack";
                command.Parameters.Add(new SqlParameter("@musicTrackId", musicTrackId.ToString()));
                DataTable dt = new DataTable("results");
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                sqlAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }

                return null;
            }
        }

        /// <summary>
        /// Get all hosts stored into the database.
        /// </summary>
        /// <returns>A DataTable with the hosts info.</returns>
        public override DataTable GetAllHosts()
        {
            using (SqlConnection conn = new SqlConnection(this.ConnString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetAllHosts";
                DataTable dt = new DataTable("results");
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                sqlAdapter.Fill(dt);
                return dt;
            }
        }

        #endregion

        #region private methods

        /// <summary>
        /// Executes a stored procedure with the given paramenters and return no value.
        /// </summary>
        /// <param name="name">The name of the stored procedure.</param>
        /// <param name="parameters">The parameters to call the stored procedure.</param>
        private void SPExecuteNonQuery(string name, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnString))
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

        /// <summary>
        /// Execute a store procedure with the given parameters and return a scalar value.
        /// </summary>
        /// <param name="name">The name of the stored procedure.</param>
        /// <param name="parameters">The parameters to execute the stored procedure.</param>
        /// <returns>A integer value.</returns>
        private int SPExecuteScalar(string name, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnString))
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

                object obj = command.ExecuteScalar();
                if (obj != null)
                {
                    return Convert.ToInt32(obj);
                }

                return 0;
            }
        }

        #endregion
    }
}
