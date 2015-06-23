using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SharedUploader_Watcher
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		#region "Form Specific Events"
		private void frmMain_Load(object sender, EventArgs e)
		{
			lblApiKeyWarning.Visible = false;
			txtApiKey.Text = Properties.Settings.Default.API_KEY;
			txtPostmanPath.Text = Properties.Settings.Default.POSTMAN_PATH;
			if (Properties.Settings.Default.API_KEY.Length <= 0)
			{
				lblApiKeyWarning.Text = "WARNING: API Key is missing, nothing will function without it!";
				lblApiKeyWarning.Visible = true;
			}
			btnUploadFile.Enabled = false;
			btnUploadText.Enabled = false;
			this.ShowInTaskbar = false;
			this.WindowState = FormWindowState.Minimized;
		}

		private void frmMain_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				niWatcher.Visible = true;
				this.Hide();
			}
			else if (this.WindowState == FormWindowState.Normal)
			{
				niWatcher.Visible = false;
				if (!this.ShowInTaskbar)
				{
					this.ShowInTaskbar = true;
				}
			}
		}

		private void niWatcher_Click(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			if (me.Button == System.Windows.Forms.MouseButtons.Left)
			{
				this.Show();
				this.WindowState = FormWindowState.Normal;
			}
		}
		#endregion

		private void btnSaveSettings_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.API_KEY = txtApiKey.Text;
			Properties.Settings.Default.POSTMAN_PATH = txtPostmanPath.Text;
			Properties.Settings.Default.Save();
			CheckAPIKey();
		}

		#region "Helper Functions"
		private void UploadText(string txtToAdd)
		{
			string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";
			if(!File.Exists(fileName))
			{
				File.AppendAllText(fileName, txtToAdd);
				UploadItem(fileName);
			}
			else
			{
				MessageBox.Show("Could not create temp file, please try again.\r\nFILE: " + fileName, "Watcher - Temp File", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void UploadItem(string fileLocation)
		{
			pbMain.Value = 10;
			if (Properties.Settings.Default.API_KEY.Length > 0 && Properties.Settings.Default.POSTMAN_PATH.Length > 0)
			{
				pbMain.Value = 25;
				if (File.Exists(Properties.Settings.Default.POSTMAN_PATH) && File.Exists(fileLocation))
				{
					pbMain.Value = 50;
					Process uploaderPostman = new Process();
					uploaderPostman.StartInfo.FileName = Properties.Settings.Default.POSTMAN_PATH;
					uploaderPostman.StartInfo.Arguments = Properties.Settings.Default.API_KEY + " \"" + fileLocation + "\"";
					uploaderPostman.StartInfo.UseShellExecute = false;
					uploaderPostman.StartInfo.CreateNoWindow = true;
					uploaderPostman.StartInfo.RedirectStandardOutput = true;
					uploaderPostman.Start();
					txtConsoleOutput.Text = uploaderPostman.StandardOutput.ReadToEnd();
					uploaderPostman.WaitForExit();
					pbMain.Value = 100;
				}
				else
				{
					MessageBox.Show("Postman or Upload file could not be found, please try again.\r\nFILE: " + fileLocation, "Watcher - Missing Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("You are required to have the path to the Postman application and have a valid API key saved.", "Watcher - Missing Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			pbMain.Value = 0;
		}

		private void CheckAPIKey()
		{
			if (Properties.Settings.Default.API_KEY.Length <= 0)
			{
				lblApiKeyWarning.Visible = true;
			}
			else
			{
				lblApiKeyWarning.Visible = false;
			}
		}
		#endregion

		#region "Events"
		private void txtUploadText_TextChanged(object sender, EventArgs e)
		{
			if (txtUploadText.Text.Length > 0 && Properties.Settings.Default.API_KEY.Length > 0)
			{
				btnUploadText.Enabled = true;
			}
			else
			{
				btnUploadText.Enabled = false;
			}
		}
		#endregion

		private void btnBrowsePostman_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofdUploadFile = new OpenFileDialog();
			ofdUploadFile.CheckFileExists = true;
			ofdUploadFile.CheckPathExists = true;
			ofdUploadFile.Filter = "SharedUploader Postman|SharedUploader_Postman.exe";
			DialogResult uploadFileDialog = ofdUploadFile.ShowDialog();
			if (uploadFileDialog == DialogResult.OK)
			{
				txtPostmanPath.Text = ofdUploadFile.FileName;
			}
		}

		private void btnBrowseUploadFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofdUploadFile = new OpenFileDialog();
			ofdUploadFile.CheckFileExists = true;
			ofdUploadFile.CheckPathExists = true;
			DialogResult uploadFileDialog = ofdUploadFile.ShowDialog();
			if(uploadFileDialog == DialogResult.OK)
			{
				txtPath.Text = ofdUploadFile.FileName;
				btnUploadFile.Enabled = true;
			}
		}

		private void btnUploadFile_Click(object sender, EventArgs e)
		{
			UploadItem(txtPath.Text);
			btnUploadFile.Enabled = false;
			txtPath.Text = "";
		}

		private void btnUploadText_Click(object sender, EventArgs e)
		{
			UploadText(txtUploadText.Text);
			btnUploadText.Enabled = false;
			txtUploadText.Text = "";
		}
	}
}
