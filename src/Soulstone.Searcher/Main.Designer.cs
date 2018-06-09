namespace Soulstone.Searcher
{
    partial class Form1
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
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.lnkConfiguration = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDomains = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbProcessing = new System.Windows.Forms.GroupBox();
            this.lnkSaveToFile = new System.Windows.Forms.LinkLabel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHostProgress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentHost = new System.Windows.Forms.TextBox();
            this.lbConsole = new System.Windows.Forms.ListBox();
            this.bwDomains = new System.ComponentModel.BackgroundWorker();
            this.bwComputers = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lnkAbout = new System.Windows.Forms.LinkLabel();
            this.gbSearch.SuspendLayout();
            this.gbProcessing.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.lnkConfiguration);
            this.gbSearch.Controls.Add(this.label2);
            this.gbSearch.Controls.Add(this.cmbDomains);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Location = new System.Drawing.Point(12, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(523, 74);
            this.gbSearch.TabIndex = 0;
            this.gbSearch.TabStop = false;
            // 
            // lnkConfiguration
            // 
            this.lnkConfiguration.AutoSize = true;
            this.lnkConfiguration.Location = new System.Drawing.Point(461, 54);
            this.lnkConfiguration.Name = "lnkConfiguration";
            this.lnkConfiguration.Size = new System.Drawing.Size(59, 13);
            this.lnkConfiguration.TabIndex = 3;
            this.lnkConfiguration.TabStop = true;
            this.lnkConfiguration.Text = "Configure";
            this.lnkConfiguration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Networks detected";
            // 
            // cmbDomains
            // 
            this.cmbDomains.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDomains.FormattingEnabled = true;
            this.cmbDomains.Location = new System.Drawing.Point(7, 38);
            this.cmbDomains.Name = "cmbDomains";
            this.cmbDomains.Size = new System.Drawing.Size(276, 21);
            this.cmbDomains.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(289, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbProcessing
            // 
            this.gbProcessing.Controls.Add(this.lnkSaveToFile);
            this.gbProcessing.Controls.Add(this.btnCancel);
            this.gbProcessing.Controls.Add(this.lblHostProgress);
            this.gbProcessing.Controls.Add(this.label1);
            this.gbProcessing.Controls.Add(this.txtCurrentHost);
            this.gbProcessing.Controls.Add(this.lbConsole);
            this.gbProcessing.Enabled = false;
            this.gbProcessing.Location = new System.Drawing.Point(12, 92);
            this.gbProcessing.Name = "gbProcessing";
            this.gbProcessing.Size = new System.Drawing.Size(522, 336);
            this.gbProcessing.TabIndex = 1;
            this.gbProcessing.TabStop = false;
            // 
            // lnkSaveToFile
            // 
            this.lnkSaveToFile.AutoSize = true;
            this.lnkSaveToFile.Location = new System.Drawing.Point(451, 314);
            this.lnkSaveToFile.Name = "lnkSaveToFile";
            this.lnkSaveToFile.Size = new System.Drawing.Size(65, 13);
            this.lnkSaveToFile.TabIndex = 5;
            this.lnkSaveToFile.TabStop = true;
            this.lnkSaveToFile.Text = "Save to File";
            this.lnkSaveToFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSaveToFile_LinkClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(441, 37);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblHostProgress
            // 
            this.lblHostProgress.AutoSize = true;
            this.lblHostProgress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostProgress.Location = new System.Drawing.Point(187, 47);
            this.lblHostProgress.Name = "lblHostProgress";
            this.lblHostProgress.Size = new System.Drawing.Size(34, 13);
            this.lblHostProgress.TabIndex = 3;
            this.lblHostProgress.Text = "1 of -";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Processing";
            // 
            // txtCurrentHost
            // 
            this.txtCurrentHost.Location = new System.Drawing.Point(7, 38);
            this.txtCurrentHost.Name = "txtCurrentHost";
            this.txtCurrentHost.ReadOnly = true;
            this.txtCurrentHost.Size = new System.Drawing.Size(174, 22);
            this.txtCurrentHost.TabIndex = 1;
            // 
            // lbConsole
            // 
            this.lbConsole.FormattingEnabled = true;
            this.lbConsole.Location = new System.Drawing.Point(7, 73);
            this.lbConsole.Name = "lbConsole";
            this.lbConsole.Size = new System.Drawing.Size(510, 238);
            this.lbConsole.TabIndex = 0;
            // 
            // bwDomains
            // 
            this.bwDomains.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDomains_DoWork);
            this.bwDomains.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDomains_RunWorkerCompleted);
            // 
            // bwComputers
            // 
            this.bwComputers.WorkerSupportsCancellation = true;
            this.bwComputers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwComputers_DoWork);
            this.bwComputers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwComputers_RunWorkerCompleted);
            // 
            // lnkAbout
            // 
            this.lnkAbout.AutoSize = true;
            this.lnkAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkAbout.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAbout.Location = new System.Drawing.Point(505, 3);
            this.lnkAbout.Name = "lnkAbout";
            this.lnkAbout.Size = new System.Drawing.Size(29, 12);
            this.lnkAbout.TabIndex = 2;
            this.lnkAbout.TabStop = true;
            this.lnkAbout.Text = "About";
            this.lnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAbout_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 443);
            this.Controls.Add(this.lnkAbout);
            this.Controls.Add(this.gbProcessing);
            this.Controls.Add(this.gbSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soulstone Searcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbProcessing.ResumeLayout(false);
            this.gbProcessing.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbProcessing;
        private System.Windows.Forms.ListBox lbConsole;
        private System.Windows.Forms.ComboBox cmbDomains;
        private System.ComponentModel.BackgroundWorker bwDomains;
        private System.ComponentModel.BackgroundWorker bwComputers;
        private System.Windows.Forms.TextBox txtCurrentHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHostProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkConfiguration;
        private System.Windows.Forms.LinkLabel lnkSaveToFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.LinkLabel lnkAbout;
    }
}

