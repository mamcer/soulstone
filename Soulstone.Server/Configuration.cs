using System;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Soulstone.Server
{
    public struct ConfigurationInfo
    {
        public string NetworkName;
        public StringCollection ExceptionList;
    }

    public partial class Configuration : Form
    {
        #region private members
        private ConfigurationInfo _configurationInfo;
        #endregion

        #region public properties
        public ConfigurationInfo ConfigInfo
        {
            get 
            {
                return _configurationInfo;
            }
        }
        #endregion

        #region constructor
        public Configuration()
        {
            InitializeComponent();
        }
        #endregion
    }
}
