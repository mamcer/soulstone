namespace Soulstone.Server
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
            this.pnlNetworkExceptions = new System.Windows.Forms.Panel();
            this.tvConfiguration = new System.Windows.Forms.TreeView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chklbNetworkExceptions = new System.Windows.Forms.CheckedListBox();
            this.pnlNetworkExceptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNetworkExceptions
            // 
            this.pnlNetworkExceptions.Controls.Add(this.chklbNetworkExceptions);
            this.pnlNetworkExceptions.Controls.Add(this.label1);
            this.pnlNetworkExceptions.Location = new System.Drawing.Point(224, 3);
            this.pnlNetworkExceptions.Name = "pnlNetworkExceptions";
            this.pnlNetworkExceptions.Size = new System.Drawing.Size(337, 396);
            this.pnlNetworkExceptions.TabIndex = 0;
            // 
            // tvConfiguration
            // 
            this.tvConfiguration.Location = new System.Drawing.Point(3, 3);
            this.tvConfiguration.Name = "tvConfiguration";
            this.tvConfiguration.Size = new System.Drawing.Size(215, 396);
            this.tvConfiguration.TabIndex = 1;
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Network Exceptions";
            // 
            // chklbNetworkExceptions
            // 
            this.chklbNetworkExceptions.FormattingEnabled = true;
            this.chklbNetworkExceptions.Location = new System.Drawing.Point(9, 38);
            this.chklbNetworkExceptions.Name = "chklbNetworkExceptions";
            this.chklbNetworkExceptions.Size = new System.Drawing.Size(320, 344);
            this.chklbNetworkExceptions.TabIndex = 1;
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
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.pnlNetworkExceptions.ResumeLayout(false);
            this.pnlNetworkExceptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNetworkExceptions;
        private System.Windows.Forms.CheckedListBox chklbNetworkExceptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvConfiguration;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}