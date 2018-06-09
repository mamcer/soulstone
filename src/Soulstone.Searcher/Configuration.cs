using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

using Soulstone.Network;

namespace Soulstone.Searcher
{
    public struct ConfigurationInfo
    {
        public string NetworkName;
        public StringCollection SelectedHostList;
        public bool ScanOnlyNewHosts;
    }

    public partial class Configuration : Form
    {
        #region private members
        private ConfigurationInfo _configurationInfo = new ConfigurationInfo();
        private List<string> _hostCache;
        #endregion

        #region public properties
        public ConfigurationInfo ConfigInfo
        {
            get
            {
                return _configurationInfo;
            }
        }

        public string NetworkName
        {
            get 
            {
                return _configurationInfo.NetworkName;
            }
            set
            {
                _configurationInfo.NetworkName = value;
            }
        }
        #endregion

        #region constructor
        public Configuration()
        {
            InitializeComponent();
            tvConfiguration.SelectedNode = tvConfiguration.Nodes[0];
            _hostCache = new List<string>();
            tvConfiguration.ExpandAll();
        }
        #endregion

        #region private methods
        private void btnOk_Click(object sender, EventArgs e)
        {
            _configurationInfo.SelectedHostList = new StringCollection();
            foreach (object cbi in chklbNetworkExceptions.CheckedItems)
            {
                string hostName = cbi as string;
                ConfigInfo.SelectedHostList.Add(hostName);
            }
            _configurationInfo.ScanOnlyNewHosts = chkScanOnlyNewHosts.Checked;
            DialogResult = DialogResult.OK;
        }

        private void lnkSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < chklbNetworkExceptions.Items.Count; i++)
            {
                chklbNetworkExceptions.SetItemChecked(i, true);
            }
        }

        private void lnkSelectNone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < chklbNetworkExceptions.Items.Count; i++)
            {
                chklbNetworkExceptions.SetItemChecked(i, false);
            }
        }

        private void bwNetworkExceptions_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            CompEnum ce = NetworkSearcher.Instance.GetComputersOnDomain(ConfigInfo.NetworkName);
            chklbNetworkExceptions.Invoke(new MethodInvoker(delegate() { chklbNetworkExceptions.Items.Clear(); })); 
            foreach (CompEnum.NetworkComputers nc in ce)
            {
                chklbNetworkExceptions.Invoke(new MethodInvoker(delegate() { chklbNetworkExceptions.Items.Add(nc.Name); }));
                _hostCache.Add(nc.Name);
            }
        }

        private void tvConfiguration_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "Scan Options": { pnlScanOptions.BringToFront(); break; };
                case "Scan specific Hosts":
                    {
                        pnlNetworkExceptions.BringToFront();
                        chklbNetworkExceptions.Items.Clear();
                        if (_hostCache.Count > 0)
                        {
                            foreach (string movie in _hostCache)
                            {
                                chklbNetworkExceptions.Items.Add(movie);
                            }
                        }
                        else
                        {
                            ScanNetworkHosts();
                        }
                        break;
                    };
                default: { pnlScanOptions.BringToFront(); break; }
            }
        }

        private void ScanNetworkHosts()
        {
            chklbNetworkExceptions.Items.Add("Working...");
            chklbNetworkExceptions.Enabled = false;
            lnkSelectAll.Enabled = false;
            lnkSelectNone.Enabled = false;
            if (!bwNetworkExceptions.IsBusy)
            {
                bwNetworkExceptions.RunWorkerAsync();
            }
        }

        private void bwNetworkExceptions_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            chklbNetworkExceptions.Enabled = true;
            lnkSelectAll.Enabled = true;
            lnkSelectNone.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            chklbNetworkExceptions.Items.Clear();
            if (txtSearch.Text != "Search")
            {
                IEnumerable<string> query = from p in _hostCache
                                            where p.StartsWith(txtSearch.Text, true, null)
                                            orderby p
                                            select p;

                foreach (string movie in query)
                {
                    chklbNetworkExceptions.Items.Add(movie);
                }
            }
            else
            {
                foreach (string movie in _hostCache)
                {
                    chklbNetworkExceptions.Items.Add(movie);
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            imgSearch.Visible = false;
            imgCancel.Visible = true;
        }

        private void imgCancel_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "Search";
            txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            imgSearch.Visible = true;
            imgCancel.Visible = false;
        }

        #endregion
    }
}
