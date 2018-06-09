namespace Soulstone.Searcher
{
    partial class Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Scan specific Hosts");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Scan Options", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.pnlNetworkExceptions = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lnkSelectNone = new System.Windows.Forms.LinkLabel();
            this.lnkSelectAll = new System.Windows.Forms.LinkLabel();
            this.chklbNetworkExceptions = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvConfiguration = new System.Windows.Forms.TreeView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlScanOptions = new System.Windows.Forms.Panel();
            this.chkScanOnlyNewHosts = new System.Windows.Forms.CheckBox();
            this.bwNetworkExceptions = new System.ComponentModel.BackgroundWorker();
            this.imgCancel = new System.Windows.Forms.PictureBox();
            this.imgSearch = new System.Windows.Forms.PictureBox();
            this.pnlNetworkExceptions.SuspendLayout();
            this.pnlScanOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNetworkExceptions
            // 
            this.pnlNetworkExceptions.Controls.Add(this.imgCancel);
            this.pnlNetworkExceptions.Controls.Add(this.imgSearch);
            this.pnlNetworkExceptions.Controls.Add(this.txtSearch);
            this.pnlNetworkExceptions.Controls.Add(this.lnkSelectNone);
            this.pnlNetworkExceptions.Controls.Add(this.lnkSelectAll);
            this.pnlNetworkExceptions.Controls.Add(this.chklbNetworkExceptions);
            this.pnlNetworkExceptions.Controls.Add(this.label1);
            this.pnlNetworkExceptions.Location = new System.Drawing.Point(224, 3);
            this.pnlNetworkExceptions.Name = "pnlNetworkExceptions";
            this.pnlNetworkExceptions.Size = new System.Drawing.Size(337, 396);
            this.pnlNetworkExceptions.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSearch.Location = new System.Drawing.Point(9, 36);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(320, 22);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.Text = "Search";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            // 
            // lnkSelectNone
            // 
            this.lnkSelectNone.AutoSize = true;
            this.lnkSelectNone.Location = new System.Drawing.Point(65, 381);
            this.lnkSelectNone.Name = "lnkSelectNone";
            this.lnkSelectNone.Size = new System.Drawing.Size(68, 13);
            this.lnkSelectNone.TabIndex = 3;
            this.lnkSelectNone.TabStop = true;
            this.lnkSelectNone.Text = "Select None";
            this.lnkSelectNone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectNone_LinkClicked);
            // 
            // lnkSelectAll
            // 
            this.lnkSelectAll.AutoSize = true;
            this.lnkSelectAll.Location = new System.Drawing.Point(6, 381);
            this.lnkSelectAll.Name = "lnkSelectAll";
            this.lnkSelectAll.Size = new System.Drawing.Size(53, 13);
            this.lnkSelectAll.TabIndex = 2;
            this.lnkSelectAll.TabStop = true;
            this.lnkSelectAll.Text = "Select All";
            this.lnkSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectAll_LinkClicked);
            // 
            // chklbNetworkExceptions
            // 
            this.chklbNetworkExceptions.FormattingEnabled = true;
            this.chklbNetworkExceptions.Location = new System.Drawing.Point(9, 66);
            this.chklbNetworkExceptions.Name = "chklbNetworkExceptions";
            this.chklbNetworkExceptions.Size = new System.Drawing.Size(320, 310);
            this.chklbNetworkExceptions.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hosts to Scan";
            // 
            // tvConfiguration
            // 
            this.tvConfiguration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvConfiguration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvConfiguration.HotTracking = true;
            this.tvConfiguration.Location = new System.Drawing.Point(3, 3);
            this.tvConfiguration.Name = "tvConfiguration";
            treeNode3.Name = "Node4";
            treeNode3.Text = "Scan specific Hosts";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Scan Options";
            this.tvConfiguration.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.tvConfiguration.ShowLines = false;
            this.tvConfiguration.Size = new System.Drawing.Size(215, 396);
            this.tvConfiguration.TabIndex = 1;
            this.tvConfiguration.TabStop = false;
            this.tvConfiguration.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvConfiguration_BeforeSelect);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(486, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(405, 405);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlScanOptions
            // 
            this.pnlScanOptions.Controls.Add(this.chkScanOnlyNewHosts);
            this.pnlScanOptions.Location = new System.Drawing.Point(224, 3);
            this.pnlScanOptions.Name = "pnlScanOptions";
            this.pnlScanOptions.Size = new System.Drawing.Size(337, 396);
            this.pnlScanOptions.TabIndex = 4;
            // 
            // chkScanOnlyNewHosts
            // 
            this.chkScanOnlyNewHosts.AutoSize = true;
            this.chkScanOnlyNewHosts.Location = new System.Drawing.Point(9, 13);
            this.chkScanOnlyNewHosts.Name = "chkScanOnlyNewHosts";
            this.chkScanOnlyNewHosts.Size = new System.Drawing.Size(136, 17);
            this.chkScanOnlyNewHosts.TabIndex = 0;
            this.chkScanOnlyNewHosts.Text = "Scan only news hosts";
            this.chkScanOnlyNewHosts.UseVisualStyleBackColor = true;
            // 
            // bwNetworkExceptions
            // 
            this.bwNetworkExceptions.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwNetworkExceptions_DoWork);
            this.bwNetworkExceptions.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwNetworkExceptions_RunWorkerCompleted);
            // 
            // imgCancel
            // 
            this.imgCancel.Image = global::Soulstone.Searcher.Properties.Resources.cancel;
            this.imgCancel.Location = new System.Drawing.Point(307, 39);
            this.imgCancel.Name = "imgCancel";
            this.imgCancel.Size = new System.Drawing.Size(18, 17);
            this.imgCancel.TabIndex = 6;
            this.imgCancel.TabStop = false;
            this.imgCancel.Visible = false;
            this.imgCancel.Click += new System.EventHandler(this.imgCancel_Click);
            // 
            // imgSearch
            // 
            this.imgSearch.Image = global::Soulstone.Searcher.Properties.Resources.search;
            this.imgSearch.Location = new System.Drawing.Point(305, 38);
            this.imgSearch.Name = "imgSearch";
            this.imgSearch.Size = new System.Drawing.Size(22, 19);
            this.imgSearch.TabIndex = 5;
            this.imgSearch.TabStop = false;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 440);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tvConfiguration);
            this.Controls.Add(this.pnlNetworkExceptions);
            this.Controls.Add(this.pnlScanOptions);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Configuration";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.pnlNetworkExceptions.ResumeLayout(false);
            this.pnlNetworkExceptions.PerformLayout();
            this.pnlScanOptions.ResumeLayout(false);
            this.pnlScanOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNetworkExceptions;
        private System.Windows.Forms.CheckedListBox chklbNetworkExceptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvConfiguration;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.LinkLabel lnkSelectNone;
        private System.Windows.Forms.LinkLabel lnkSelectAll;
        private System.Windows.Forms.Panel pnlScanOptions;
        private System.Windows.Forms.CheckBox chkScanOnlyNewHosts;
        private System.ComponentModel.BackgroundWorker bwNetworkExceptions;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox imgSearch;
        private System.Windows.Forms.PictureBox imgCancel;
    }
}