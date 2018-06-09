using System;
using System.IO;
using System.Windows.Forms;

using Soulstone.Network;
using Soulstone.Data;
using Soulstone.Mp3;

namespace Soulstone.Searcher
{
    public partial class Form1 : Form
    {
        #region private members
        private NetworkSearcher _networkSearcher;
        private DataLayerBase _dataLayer;
        private int _totalFileFound;
        ConfigurationInfo _configurationInfo;
        private DateTime _totalTime;
        private string _selectedNetwork;
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
            _configurationInfo = new ConfigurationInfo();
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

        private DataLayerBase DBLayer
        {
            get
            {
                if (_dataLayer == null)
                {
                    _dataLayer = DataLayerFactory.Instance.GetDataLayer(DataLayerType.SqlServer);
                }
                return _dataLayer;
            }
        }
        #endregion

        #region private methods
        private void ShowDomains()
        {
            bwDomains.RunWorkerAsync();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gbSearch.Enabled = false;
            lbConsole.Items.Clear();
            lbConsole.Items.Add("Scan started");
            gbProcessing.Enabled = true;
            lnkSaveToFile.Enabled = false;
            _selectedNetwork = cmbDomains.SelectedItem.ToString();
            bwComputers.RunWorkerAsync();
        }

        private void bwDomains_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            CompEnum ce = NSearcher.GetDomainNames();
            cmbDomains.Invoke(new MethodInvoker(delegate() { cmbDomains.Items.Clear(); }));            
            foreach (CompEnum.NetworkComputers nc in ce)
            {
                cmbDomains.Invoke(new MethodInvoker(delegate() { cmbDomains.Items.Add(nc.Name); }));                
            }
            lnkConfiguration.Invoke(new MethodInvoker(delegate() { lnkConfiguration.Enabled = true; }));
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
            string hostName;
            _totalFileFound = 0;
            try
            {
                //Computers on Domain
                CompEnum computers = NSearcher.GetComputersOnDomain(_selectedNetwork);
                _totalTime = DateTime.Now;
                int currentComputer = 1;
                DateTime hostScanTime;
                int totalComputerCount = computers.Length;
                if (_configurationInfo.SelectedHostList != null && _configurationInfo.SelectedHostList.Count > 0)
                {
                    totalComputerCount = _configurationInfo.SelectedHostList.Count;
                }
                foreach (CompEnum.NetworkComputers nc in computers)
                {
                    hostName = nc.Name;
                    hostScanTime = DateTime.Now;
                    if (_configurationInfo.SelectedHostList == null || _configurationInfo.SelectedHostList.Count == 0 || _configurationInfo.SelectedHostList.Contains(hostName))
                    {
                        if (!_configurationInfo.ScanOnlyNewHosts || (_configurationInfo.ScanOnlyNewHosts && !DBLayer.HostExists(hostName)))
                        {
                            lblHostProgress.Invoke(new MethodInvoker(delegate() { lblHostProgress.Text = string.Format("{0} of {1}", currentComputer++, totalComputerCount); }));
                            lbConsole.Invoke(new MethodInvoker(delegate() { lbConsole.Items.Add(string.Format("{0} - {1} scan started", hostScanTime.ToShortTimeString(), hostName)); }));
                            txtCurrentHost.Invoke(new MethodInvoker(delegate(){ txtCurrentHost.Text = hostName;}));
                            DBLayer.CreateHost(hostName);
                            string sharePath;
                            //Shares for computer
                            foreach (Share s in NSearcher.GetSharesForComputer(hostName))
                            {
                                if (s.ShareType == ShareType.Device || s.ShareType == ShareType.Disk)
                                {
                                    sharePath = s.Root.FullName;
                                    ScanFolder(sharePath, "   ", hostName, sharePath, 1);
                                }
                            }
                            TimeSpan hostScanSpan = DateTime.Now.Subtract(hostScanTime);
                            lbConsole.Invoke(new MethodInvoker(delegate() { lbConsole.Items.Add(string.Format("{0} - {1} scan finished, took {2} minutes {3} seconds {4} milliseconds", DateTime.Now.ToShortTimeString(), hostName, hostScanSpan.Minutes, hostScanSpan.Seconds, hostScanSpan.Milliseconds)); }));
                        }
                    }
                }
                TimeSpan totalTimeSpan = DateTime.Now.Subtract(_totalTime);
                lbConsole.Invoke(new MethodInvoker(delegate() { lbConsole.Items.Add(string.Format("Total: {0} files, took {1} minutes, {2} seconds, {3} milliseconds",_totalFileFound, totalTimeSpan.Minutes, totalTimeSpan.Seconds, totalTimeSpan.Milliseconds)); }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.StackTrace);
            }
            gbSearch.Invoke(new MethodInvoker(delegate() { gbSearch.Enabled = true;}));
            lbConsole.Invoke(new MethodInvoker(delegate() { lbConsole.Items.Add(string.Format("Scan finished")); }));
        }

        private void ScanFolder(string folderPath, string separator, string hostName, string sharePath, int level)
        {
            if (level == 5)
                return;
            DirectoryInfo root = new DirectoryInfo(folderPath);
            FileInfo[] mp3Files;
            try
            {
                mp3Files = root.GetFiles("*.mp3");
                lbConsole.Invoke(new MethodInvoker(delegate() { lbConsole.Items.Add(separator + root.FullName); }));
            }
            catch(Exception ex)
            {
                lbConsole.Invoke(new MethodInvoker(delegate() { lbConsole.Items.Add(separator + root.FullName + " - " + ex.Message); }));
                return;
            }
            foreach (FileInfo fi in mp3Files)
            {
                MusicTrack musicTrack = Id3Reader.Instance.GetMusicTrackFromID3(fi.FullName);
                if (musicTrack != null)
                {
                    try
                    {
                        DBLayer.CreateOrUpdateMusicTrack(hostName, fi.FullName, musicTrack.Album, musicTrack.Artist, musicTrack.Title, musicTrack.Year, musicTrack.Genre);
                    }
                    catch (Exception ex)
                    {
                        lbConsole.Invoke(new MethodInvoker(delegate() { lbConsole.Items.Add(separator + fi.FullName + " - " + ex.Message); }));
                        continue;
                    }
                    lbConsole.Invoke(new MethodInvoker(delegate() { lbConsole.Items.Add(separator + "   " + fi.FullName); }));
                    _totalFileFound += 1;
                }
            }
            foreach (DirectoryInfo di in root.GetDirectories())
            {
                ScanFolder(di.FullName, separator + "   ", hostName, sharePath, level + 1);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmbDomains.SelectedItem != null)
            {
                Configuration config = new Configuration();
                config.NetworkName = cmbDomains.SelectedItem.ToString();
                config.ShowDialog();
                _configurationInfo = config.ConfigInfo;
            }
        }

        private void lnkSaveToFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextWriter tw = new StreamWriter(saveFileDialog.FileName);
                try
                {
                    for (int i = 0; i < lbConsole.Items.Count; i++)
                    {
                        tw.WriteLine(lbConsole.Items[i]);
                    }
                }
                finally
                {
                    tw.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bwComputers.IsBusy)
            {
                bwComputers.CancelAsync();
                TimeSpan totalTimeSpan = DateTime.Now.Subtract(_totalTime);
                lbConsole.Items.Add(string.Format("Total:{0}, took {1} minutes, {2} seconds, {3} milliseconds", _totalFileFound, totalTimeSpan.Minutes, totalTimeSpan.Seconds, totalTimeSpan.Milliseconds));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDomains.Items.Clear();
            cmbDomains.Items.Add("Working...");
            cmbDomains.SelectedIndex = 0;
            btnSearch.Enabled = false;
            lnkConfiguration.Enabled = false;
            ShowDomains();
        }

        private void bwComputers_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lnkSaveToFile.Enabled = true;
        }

        private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        #endregion
    }
}
