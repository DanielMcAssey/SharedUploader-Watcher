namespace SharedUploader_Watcher
{
	partial class frmMain
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.txtUploadText = new System.Windows.Forms.TextBox();
			this.gbFileUpload = new System.Windows.Forms.GroupBox();
			this.btnBrowseUploadFile = new System.Windows.Forms.Button();
			this.btnUploadFile = new System.Windows.Forms.Button();
			this.lblPath = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.gbTextUpload = new System.Windows.Forms.GroupBox();
			this.btnUploadText = new System.Windows.Forms.Button();
			this.gbSettings = new System.Windows.Forms.GroupBox();
			this.btnBrowsePostman = new System.Windows.Forms.Button();
			this.lblPostmanPath = new System.Windows.Forms.Label();
			this.txtPostmanPath = new System.Windows.Forms.TextBox();
			this.lblApiKeyWarning = new System.Windows.Forms.Label();
			this.btnSaveSettings = new System.Windows.Forms.Button();
			this.lblApiKey = new System.Windows.Forms.Label();
			this.txtApiKey = new System.Windows.Forms.TextBox();
			this.niWatcher = new System.Windows.Forms.NotifyIcon(this.components);
			this.gbConsoleOutput = new System.Windows.Forms.GroupBox();
			this.txtConsoleProgressBar = new System.Windows.Forms.TextBox();
			this.txtConsoleOutput = new System.Windows.Forms.TextBox();
			this.contextMenuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripExit = new System.Windows.Forms.ToolStripMenuItem();
			this.gbFileUpload.SuspendLayout();
			this.gbTextUpload.SuspendLayout();
			this.gbSettings.SuspendLayout();
			this.gbConsoleOutput.SuspendLayout();
			this.contextMenuNotifyIcon.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtUploadText
			// 
			this.txtUploadText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUploadText.Location = new System.Drawing.Point(6, 19);
			this.txtUploadText.Multiline = true;
			this.txtUploadText.Name = "txtUploadText";
			this.txtUploadText.Size = new System.Drawing.Size(504, 137);
			this.txtUploadText.TabIndex = 0;
			this.txtUploadText.TextChanged += new System.EventHandler(this.txtUploadText_TextChanged);
			// 
			// gbFileUpload
			// 
			this.gbFileUpload.Controls.Add(this.btnBrowseUploadFile);
			this.gbFileUpload.Controls.Add(this.btnUploadFile);
			this.gbFileUpload.Controls.Add(this.lblPath);
			this.gbFileUpload.Controls.Add(this.txtPath);
			this.gbFileUpload.Location = new System.Drawing.Point(12, 92);
			this.gbFileUpload.Name = "gbFileUpload";
			this.gbFileUpload.Size = new System.Drawing.Size(516, 46);
			this.gbFileUpload.TabIndex = 1;
			this.gbFileUpload.TabStop = false;
			this.gbFileUpload.Text = "File Upload";
			// 
			// btnBrowseUploadFile
			// 
			this.btnBrowseUploadFile.Location = new System.Drawing.Point(378, 17);
			this.btnBrowseUploadFile.Name = "btnBrowseUploadFile";
			this.btnBrowseUploadFile.Size = new System.Drawing.Size(29, 23);
			this.btnBrowseUploadFile.TabIndex = 3;
			this.btnBrowseUploadFile.Text = "...";
			this.btnBrowseUploadFile.UseVisualStyleBackColor = true;
			this.btnBrowseUploadFile.Click += new System.EventHandler(this.btnBrowseUploadFile_Click);
			// 
			// btnUploadFile
			// 
			this.btnUploadFile.Location = new System.Drawing.Point(413, 17);
			this.btnUploadFile.Name = "btnUploadFile";
			this.btnUploadFile.Size = new System.Drawing.Size(97, 23);
			this.btnUploadFile.TabIndex = 2;
			this.btnUploadFile.Text = "Upload File";
			this.btnUploadFile.UseVisualStyleBackColor = true;
			this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
			// 
			// lblPath
			// 
			this.lblPath.AutoSize = true;
			this.lblPath.Location = new System.Drawing.Point(6, 22);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(51, 13);
			this.lblPath.TabIndex = 1;
			this.lblPath.Text = "File Path:";
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(88, 19);
			this.txtPath.Name = "txtPath";
			this.txtPath.ReadOnly = true;
			this.txtPath.Size = new System.Drawing.Size(284, 20);
			this.txtPath.TabIndex = 1;
			// 
			// gbTextUpload
			// 
			this.gbTextUpload.Controls.Add(this.btnUploadText);
			this.gbTextUpload.Controls.Add(this.txtUploadText);
			this.gbTextUpload.Location = new System.Drawing.Point(12, 144);
			this.gbTextUpload.Name = "gbTextUpload";
			this.gbTextUpload.Size = new System.Drawing.Size(516, 191);
			this.gbTextUpload.TabIndex = 2;
			this.gbTextUpload.TabStop = false;
			this.gbTextUpload.Text = "Text Upload";
			// 
			// btnUploadText
			// 
			this.btnUploadText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnUploadText.Location = new System.Drawing.Point(6, 162);
			this.btnUploadText.Name = "btnUploadText";
			this.btnUploadText.Size = new System.Drawing.Size(504, 23);
			this.btnUploadText.TabIndex = 1;
			this.btnUploadText.Text = "Upload Text";
			this.btnUploadText.UseVisualStyleBackColor = true;
			this.btnUploadText.Click += new System.EventHandler(this.btnUploadText_Click);
			// 
			// gbSettings
			// 
			this.gbSettings.Controls.Add(this.btnBrowsePostman);
			this.gbSettings.Controls.Add(this.lblPostmanPath);
			this.gbSettings.Controls.Add(this.txtPostmanPath);
			this.gbSettings.Controls.Add(this.lblApiKeyWarning);
			this.gbSettings.Controls.Add(this.btnSaveSettings);
			this.gbSettings.Controls.Add(this.lblApiKey);
			this.gbSettings.Controls.Add(this.txtApiKey);
			this.gbSettings.Location = new System.Drawing.Point(12, 12);
			this.gbSettings.Name = "gbSettings";
			this.gbSettings.Size = new System.Drawing.Size(516, 74);
			this.gbSettings.TabIndex = 3;
			this.gbSettings.TabStop = false;
			this.gbSettings.Text = "Settings";
			// 
			// btnBrowsePostman
			// 
			this.btnBrowsePostman.Location = new System.Drawing.Point(400, 43);
			this.btnBrowsePostman.Name = "btnBrowsePostman";
			this.btnBrowsePostman.Size = new System.Drawing.Size(29, 23);
			this.btnBrowsePostman.TabIndex = 7;
			this.btnBrowsePostman.Text = "...";
			this.btnBrowsePostman.UseVisualStyleBackColor = true;
			this.btnBrowsePostman.Click += new System.EventHandler(this.btnBrowsePostman_Click);
			// 
			// lblPostmanPath
			// 
			this.lblPostmanPath.AutoSize = true;
			this.lblPostmanPath.Location = new System.Drawing.Point(6, 48);
			this.lblPostmanPath.Name = "lblPostmanPath";
			this.lblPostmanPath.Size = new System.Drawing.Size(76, 13);
			this.lblPostmanPath.TabIndex = 6;
			this.lblPostmanPath.Text = "Postman Path:";
			// 
			// txtPostmanPath
			// 
			this.txtPostmanPath.Location = new System.Drawing.Point(88, 45);
			this.txtPostmanPath.Name = "txtPostmanPath";
			this.txtPostmanPath.ReadOnly = true;
			this.txtPostmanPath.Size = new System.Drawing.Size(306, 20);
			this.txtPostmanPath.TabIndex = 5;
			// 
			// lblApiKeyWarning
			// 
			this.lblApiKeyWarning.AutoSize = true;
			this.lblApiKeyWarning.ForeColor = System.Drawing.Color.Red;
			this.lblApiKeyWarning.Location = new System.Drawing.Point(57, 0);
			this.lblApiKeyWarning.Name = "lblApiKeyWarning";
			this.lblApiKeyWarning.Size = new System.Drawing.Size(63, 13);
			this.lblApiKeyWarning.TabIndex = 4;
			this.lblApiKeyWarning.Text = "WARNING:";
			// 
			// btnSaveSettings
			// 
			this.btnSaveSettings.Location = new System.Drawing.Point(435, 19);
			this.btnSaveSettings.Name = "btnSaveSettings";
			this.btnSaveSettings.Size = new System.Drawing.Size(75, 47);
			this.btnSaveSettings.TabIndex = 2;
			this.btnSaveSettings.Text = "Save";
			this.btnSaveSettings.UseVisualStyleBackColor = true;
			this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
			// 
			// lblApiKey
			// 
			this.lblApiKey.AutoSize = true;
			this.lblApiKey.Location = new System.Drawing.Point(6, 22);
			this.lblApiKey.Name = "lblApiKey";
			this.lblApiKey.Size = new System.Drawing.Size(48, 13);
			this.lblApiKey.TabIndex = 1;
			this.lblApiKey.Text = "API Key:";
			// 
			// txtApiKey
			// 
			this.txtApiKey.Location = new System.Drawing.Point(88, 19);
			this.txtApiKey.Name = "txtApiKey";
			this.txtApiKey.Size = new System.Drawing.Size(341, 20);
			this.txtApiKey.TabIndex = 2;
			// 
			// niWatcher
			// 
			this.niWatcher.ContextMenuStrip = this.contextMenuNotifyIcon;
			this.niWatcher.Icon = ((System.Drawing.Icon)(resources.GetObject("niWatcher.Icon")));
			this.niWatcher.Text = "SharedUploader Watcher";
			this.niWatcher.Click += new System.EventHandler(this.niWatcher_Click);
			this.niWatcher.MouseUp += new System.Windows.Forms.MouseEventHandler(this.niWatcher_MouseUp);
			// 
			// gbConsoleOutput
			// 
			this.gbConsoleOutput.Controls.Add(this.txtConsoleProgressBar);
			this.gbConsoleOutput.Controls.Add(this.txtConsoleOutput);
			this.gbConsoleOutput.Location = new System.Drawing.Point(534, 12);
			this.gbConsoleOutput.Name = "gbConsoleOutput";
			this.gbConsoleOutput.Size = new System.Drawing.Size(331, 323);
			this.gbConsoleOutput.TabIndex = 5;
			this.gbConsoleOutput.TabStop = false;
			this.gbConsoleOutput.Text = "Console Output";
			// 
			// txtConsoleProgressBar
			// 
			this.txtConsoleProgressBar.Location = new System.Drawing.Point(6, 297);
			this.txtConsoleProgressBar.Name = "txtConsoleProgressBar";
			this.txtConsoleProgressBar.ReadOnly = true;
			this.txtConsoleProgressBar.Size = new System.Drawing.Size(319, 20);
			this.txtConsoleProgressBar.TabIndex = 1;
			// 
			// txtConsoleOutput
			// 
			this.txtConsoleOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConsoleOutput.Location = new System.Drawing.Point(6, 19);
			this.txtConsoleOutput.Multiline = true;
			this.txtConsoleOutput.Name = "txtConsoleOutput";
			this.txtConsoleOutput.ReadOnly = true;
			this.txtConsoleOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtConsoleOutput.Size = new System.Drawing.Size(319, 272);
			this.txtConsoleOutput.TabIndex = 0;
			this.txtConsoleOutput.WordWrap = false;
			// 
			// contextMenuNotifyIcon
			// 
			this.contextMenuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripExit});
			this.contextMenuNotifyIcon.Name = "contextMenuNotifyIcon";
			this.contextMenuNotifyIcon.Size = new System.Drawing.Size(93, 26);
			// 
			// toolStripExit
			// 
			this.toolStripExit.Name = "toolStripExit";
			this.toolStripExit.Size = new System.Drawing.Size(92, 22);
			this.toolStripExit.Text = "Exit";
			this.toolStripExit.ToolTipText = "Text";
			this.toolStripExit.Click += new System.EventHandler(this.toolStripExit_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(877, 347);
			this.Controls.Add(this.gbConsoleOutput);
			this.Controls.Add(this.gbSettings);
			this.Controls.Add(this.gbTextUpload);
			this.Controls.Add(this.gbFileUpload);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "SharedUploader - Watcher";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.gbFileUpload.ResumeLayout(false);
			this.gbFileUpload.PerformLayout();
			this.gbTextUpload.ResumeLayout(false);
			this.gbTextUpload.PerformLayout();
			this.gbSettings.ResumeLayout(false);
			this.gbSettings.PerformLayout();
			this.gbConsoleOutput.ResumeLayout(false);
			this.gbConsoleOutput.PerformLayout();
			this.contextMenuNotifyIcon.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtUploadText;
		private System.Windows.Forms.GroupBox gbFileUpload;
		private System.Windows.Forms.Button btnBrowseUploadFile;
		private System.Windows.Forms.Button btnUploadFile;
		private System.Windows.Forms.Label lblPath;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.GroupBox gbTextUpload;
		private System.Windows.Forms.Button btnUploadText;
		private System.Windows.Forms.GroupBox gbSettings;
		private System.Windows.Forms.Label lblApiKey;
		private System.Windows.Forms.TextBox txtApiKey;
		private System.Windows.Forms.Button btnSaveSettings;
		private System.Windows.Forms.Label lblApiKeyWarning;
		private System.Windows.Forms.TextBox txtPostmanPath;
		private System.Windows.Forms.Button btnBrowsePostman;
		private System.Windows.Forms.Label lblPostmanPath;
		private System.Windows.Forms.NotifyIcon niWatcher;
		private System.Windows.Forms.GroupBox gbConsoleOutput;
		private System.Windows.Forms.TextBox txtConsoleOutput;
		private System.Windows.Forms.TextBox txtConsoleProgressBar;
		private System.Windows.Forms.ContextMenuStrip contextMenuNotifyIcon;
		private System.Windows.Forms.ToolStripMenuItem toolStripExit;

	}
}

