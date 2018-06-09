using System;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

using Soulstone.Network;
using Soulstone.Data;
using Soulstone.Mp3;

namespace Soulstone.Server
{
    public partial class Form1 : Form
    {
        #region private members
        private NetworkSearcher _networkSearcher;
        private DBLayerBase _dataLayer;
        private int _totalFileFound;
        #endregion

        #region constructor
        public Form1()
        {
            InitializeComponent();
            if (!DBLayer.TestConnection())
            {
                MessageBox.Show("Cannot establish a connection with the database server",Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            ShowDomains();
        }
        #endregion

        #region private properties
        private NetworkSearcher NSearcher
        {
            get
            {
                if (_networkSearcher == null)
                {
                    _networkSearcher = NetworkSearcher.Instance;
                }
                return _networkSearcher;
            }
        }

        private DBLayerBase DBLayer
        {
            get
            {
                if (_dataLayer == null)
                {
                    _dataLayer = SqlServerDBLayer.Instance;
                    _dataLayer.ConnString = ConfigurationManager.ConnectionStrings["Soulstone"].ConnectionString;
                }
                return _dataLayer;
            }
        }
        #endregion

        #region private methods
        private void ShowDomains()
        {
            cmbDomains.Items.Clear();
            cmbDomains.Items.Add("Working...");
            cmbDomains.SelectedIndex = 0;
            btnSearch.Enabled = false;
            bwDomains.RunWorkerAsync();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bwComputers.RunWorkerAsync();
        }

        private void bwDomains_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            cmbDomains.Invoke(new MethodInvoker(delegate() { cmbDomains.Items.Clear(); }));            
            foreach (CompEnum.NetworkComputers nc in NSearcher.GetDomainNames())
            {
                cmbDomains.Invoke(new MethodInvoker(delegate() { cmbDomains.Items.Add(nc.Name); }));                
            }            
        }

        private void bwDomains_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (cmbDomains.Items.Count > 0)
            {
                cmbDomains.SelectedIndex = 0;
                btnSearch.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
            }
        }

        private void bwComputers_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            gbSearch.Enabled = false;
            lbConsole.Items.Clear();
            string hostName;
            _totalFileFound = 0;
            //CompEnum ce = NSearcher.GetComputersOnDomain(cmbDomains.SelectedItem.ToString());
            try
            {
                CompEnum computers = NSearcher.GetComputersOnDomain(cmbDomains.SelectedItem.ToString());
                int currentComputer = 1;
                foreach (CompEnum.NetworkComputers nc in computers)
                {
                    lblHostProgress.Text = string.Format("{0} of {1}", currentComputer++, computers.Length);
                    hostName = nc.Name;
                    lbConsole.Invoke(new MethodInvoker(delegate() { lbConsole.Items.Add(hostName); }));
                    txtCurrentHost.Text = hostName;
                    DBLayer.CreateOrUpdateHost(hostName);
                    string sharePath;
                    foreach (Share s in NSearcher.GetSharesForComputer(hostName))
                    {
                        if (s.ShareType == ShareType.Device || s.ShareType == ShareType.Disk)
                        {
                            sharePath = s.Root.FullName;
                            DBLayer.CreateOrUpdateHostShare(hostName, sharePath);
                            ScanFolder(sharePath, "   ", hostName, sharePath);
                        }
                    }
                }
                lbConsole.Invoke(new MethodInvoker(delegate() { lbConsole.Items.Add(string.Format("Total:{0}",_totalFileFound)); }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            gbSearch.Enabled = true;
        }
        #endregion

        private void ScanFolder(string folderPath, string separator, string hostName, string sharePath)
        {
            DirectoryInfo root = new DirectoryInfo(folderPath);
            lbConsole.Items.Add(separator + root.FullName);
            FileInfo[] mp3Files = root.GetFiles("*.mp3");
            foreach (FileInfo fi in mp3Files)
            {
                Mp3FileLink mp3FileLink = Id3Reader.Instance.GetMp3FileLink(fi.FullName);
                if (mp3FileLink != null)
                {
                    DBLayer.CreateOrUpdateMp3File(hostName, sharePath, fi.FullName, mp3FileLink.Album, mp3FileLink.Artist, mp3FileLink.Title, mp3FileLink.Year, mp3FileLink.Genre);
                    lbConsole.Items.Add(separator + "   " + fi.FullName);
                    _totalFileFound += 1;
                }
            }
            foreach (DirectoryInfo di in root.GetDirectories())
            {
                ScanFolder(di.FullName, separator + "   ", hostName, sharePath);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Configuration config = new Configuration();
            ConfigurationInfo c = config.ConfigInfo;
            .NetworkName = cmbDomains.SelectedItem.ToString();
            config.ShowDialog();
        }
    }
}
