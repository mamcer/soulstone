namespace Soulstone.Data
{
    using System;
    
    /// <summary>
    /// Define the different types of available data layers.
    /// </summary>
    public enum DataLayerType 
    {
        /// <summary>
        /// Represents a Sql Server DataLayer.
        /// </summary>
        SqlServer 
    }

    /// <summary>
    /// Allow create an instance of DataLayer objects.
    /// </summary>
    public sealed class DataLayerFactory
    {
        #region private members

        /// <summary>
        /// The unique instance of the DataLayerFactory class.
        /// </summary>
        private static DataLayerFactory instance;
        
        #endregion

        #region constructor
        /// <summary>
        /// Prevents a default instance of the DataLayerFactory class from being created.
        /// </summary>
        private DataLayerFactory() 
        { 
        }
        #endregion

        #region public properties

        /// <summary>
        /// Gets the unique instance of the DataLayerFactory class.
        /// </summary>
        public static DataLayerFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataLayerFactory();
                }

                return instance;
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Gets a DataLayer object of the specified type.
        /// </summary>
        /// <param name="type">The type of the DataLayer.</param>
        /// <returns>A DataLayer.</returns>
        public DataLayerBase GetDataLayer(DataLayerType type)
        {
            switch (type)
            {
                case DataLayerType.SqlServer:
                    {
                        return SqlServerDataLayer.Instance;
                    }

                default:
                    {
                        throw new Exception(string.Format("Unknown DataLayer type:{0}", type));
                    }
            }
        }

        #endregion
    }
}
