using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace SharedUploader_Watcher
{
	public partial class frmMain : Form
	{
		// Properties
		bool __isFileUpload = false;
		bool __isTextUpload = false;

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
#if !DEBUG
			this.WindowState = FormWindowState.Minimized;
#endif
		}

		private void frmMain_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				txtConsoleOutput.Text = "";
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

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				this.WindowState = FormWindowState.Minimized;
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

		private void niWatcher_MouseUp(object sender, MouseEventArgs e)
		{
			// FIX FOR KB-135788
			if (e.Button == MouseButtons.Right)
			{
				MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
				mi.Invoke(niWatcher, null);
			}
		}
		#endregion

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
			if (Properties.Settings.Default.API_KEY.Length > 0 && Properties.Settings.Default.POSTMAN_PATH.Length > 0)
			{
				if (File.Exists(Properties.Settings.Default.POSTMAN_PATH) && File.Exists(fileLocation))
				{
					//Reset Console output
					txtConsoleOutput.Text = "";

					// Set process up
					Process uploaderPostman = new Process();
					uploaderPostman.StartInfo.FileName = Properties.Settings.Default.POSTMAN_PATH;
					uploaderPostman.StartInfo.Arguments = Properties.Settings.Default.API_KEY + " \"" + fileLocation + "\"";
					uploaderPostman.StartInfo.UseShellExecute = false;
					
					// Setup output redirection
					uploaderPostman.StartInfo.RedirectStandardOutput = true;
					uploaderPostman.StartInfo.RedirectStandardError = true;
					uploaderPostman.EnableRaisingEvents = true;
					uploaderPostman.StartInfo.CreateNoWindow = true;

					// Data received handlers
					uploaderPostman.ErrorDataReceived += proc_DataReceived;
					uploaderPostman.OutputDataReceived += proc_DataReceived;

					// Exit handler
					uploaderPostman.Exited += proc_Exited;

					// Start process
					uploaderPostman.Start();
					uploaderPostman.BeginErrorReadLine();
					uploaderPostman.BeginOutputReadLine();
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

		delegate void UploadResetCallback();

		private void UploadedReset()
		{
			if(InvokeRequired)
			{
				this.Invoke(new UploadResetCallback(UploadedReset));
			}
			else
			{
				this.txtConsoleProgressBar.Text = "";
				if (this.__isFileUpload)
				{
					this.btnUploadFile.Enabled = false;
					this.txtPath.Text = "";
					this.__isFileUpload = false;
				}

				if (this.__isTextUpload)
				{
					this.btnUploadText.Enabled = false;
					this.txtUploadText.Text = "";
					this.__isTextUpload = false;
				}
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

		private void proc_Exited(object sender, EventArgs e)
		{
			Process uploaderPostman = (Process)sender;
			if(uploaderPostman.ExitCode == 0)
			{
				this.UploadedReset();
			}
			uploaderPostman.Close();
		}

		private void proc_DataReceived(object sender, DataReceivedEventArgs e)
		{
			if (e.Data != null)
			{
				this.AppendConsoleOutput(e.Data);
			}
		}

		delegate void AppendTextCallback(string textToAdd);

		private void AppendConsoleOutput(string textToAdd)
		{
			if (this.txtConsoleOutput.InvokeRequired)
			{
				AppendTextCallback d = new AppendTextCallback(AppendConsoleOutput);
				this.Invoke(d, new object[] { textToAdd });
			}
			else
			{
				if(textToAdd.StartsWith("UPLOADING:"))
				{
					this.txtConsoleProgressBar.Text = (textToAdd + Environment.NewLine).Replace("UPLOADING: ", "");
				}
				else
				{
					this.txtConsoleOutput.AppendText(textToAdd + Environment.NewLine);
				}
			}
		}
		#endregion

		#region "Buttons (Click)"
		private void btnSaveSettings_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.API_KEY = txtApiKey.Text;
			Properties.Settings.Default.POSTMAN_PATH = txtPostmanPath.Text;
			Properties.Settings.Default.Save();
			CheckAPIKey();
		}

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
			__isFileUpload = true;
			UploadItem(txtPath.Text);
		}

		private void btnUploadText_Click(object sender, EventArgs e)
		{
			__isTextUpload = true;
			UploadText(txtUploadText.Text);
		}

		private void toolStripExit_Click(object sender, EventArgs e)
		{
			DialogResult exitDialog = MessageBox.Show("Are you sure you want to quit the application?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if(exitDialog == System.Windows.Forms.DialogResult.Yes)
			{
				Application.Exit();
			}
		}
		#endregion

	}
}
