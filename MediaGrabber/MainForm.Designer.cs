namespace MediaGrabber
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabDownloader = new TabPage();
            tabSettings = new TabPage();
            urlLabel = new Label();
            urlTextBox = new TextBox();
            typeGroupBox = new GroupBox();
            videoRadio = new RadioButton();
            audioRadio = new RadioButton();
            bothRadio = new RadioButton();
            formatLabel = new Label();
            formatCombo = new ComboBox();
            qualityLabel = new Label();
            qualityCombo = new ComboBox();
            saveLabel = new Label();
            outputFolderTextBox = new TextBox();
            browseButton = new Button();
            downloadButton = new Button();
            cancelButton = new Button();
            logTextBox = new TextBox();
            ytDlpLabel = new Label();
            ytDlpPathTextBox = new TextBox();
            ytDlpBrowseButton = new Button();
            ffmpegLabel = new Label();
            ffmpegPathTextBox = new TextBox();
            ffmpegBrowseButton = new Button();
            saveSettingsButton = new Button();
            settingsStatusLabel = new Label();
            settingsHelpLabel = new Label();
            tabControl.SuspendLayout();
            tabDownloader.SuspendLayout();
            tabSettings.SuspendLayout();
            typeGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabDownloader);
            tabControl.Controls.Add(tabSettings);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(600, 500);
            tabControl.TabIndex = 0;
            // 
            // tabDownloader
            // 
            tabDownloader.Controls.Add(urlLabel);
            tabDownloader.Controls.Add(urlTextBox);
            tabDownloader.Controls.Add(typeGroupBox);
            tabDownloader.Controls.Add(formatLabel);
            tabDownloader.Controls.Add(formatCombo);
            tabDownloader.Controls.Add(qualityLabel);
            tabDownloader.Controls.Add(qualityCombo);
            tabDownloader.Controls.Add(downloadButton);
            tabDownloader.Controls.Add(cancelButton);
            tabDownloader.Controls.Add(logTextBox);
            tabDownloader.Location = new Point(4, 24);
            tabDownloader.Name = "tabDownloader";
            tabDownloader.Padding = new Padding(3);
            tabDownloader.Size = new Size(592, 472);
            tabDownloader.TabIndex = 0;
            tabDownloader.Text = "Downloader";
            tabDownloader.UseVisualStyleBackColor = true;
            // 
            // urlLabel
            // 
            urlLabel.AutoSize = true;
            urlLabel.Location = new Point(12, 12);
            urlLabel.Name = "urlLabel";
            urlLabel.Size = new Size(99, 15);
            urlLabel.TabIndex = 0;
            urlLabel.Text = "Video / page URL:";
            // 
            // urlTextBox
            // 
            urlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            urlTextBox.Location = new Point(12, 30);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.PlaceholderText = "https://...";
            urlTextBox.Size = new Size(568, 23);
            urlTextBox.TabIndex = 1;
            // 
            // typeGroupBox
            // 
            typeGroupBox.Controls.Add(videoRadio);
            typeGroupBox.Controls.Add(audioRadio);
            typeGroupBox.Controls.Add(bothRadio);
            typeGroupBox.Location = new Point(12, 64);
            typeGroupBox.Name = "typeGroupBox";
            typeGroupBox.Size = new Size(568, 54);
            typeGroupBox.TabIndex = 2;
            typeGroupBox.TabStop = false;
            typeGroupBox.Text = "Type";
            // 
            // videoRadio
            // 
            videoRadio.AutoSize = true;
            videoRadio.Checked = true;
            videoRadio.Location = new Point(14, 22);
            videoRadio.Name = "videoRadio";
            videoRadio.Size = new Size(55, 19);
            videoRadio.TabIndex = 0;
            videoRadio.TabStop = true;
            videoRadio.Text = "Video";
            videoRadio.UseVisualStyleBackColor = true;
            videoRadio.CheckedChanged += KindRadio_CheckedChanged;
            // 
            // audioRadio
            // 
            audioRadio.AutoSize = true;
            audioRadio.Location = new Point(110, 22);
            audioRadio.Name = "audioRadio";
            audioRadio.Size = new Size(57, 19);
            audioRadio.TabIndex = 1;
            audioRadio.Text = "Audio";
            audioRadio.UseVisualStyleBackColor = true;
            audioRadio.CheckedChanged += KindRadio_CheckedChanged;
            // 
            // bothRadio
            // 
            bothRadio.AutoSize = true;
            bothRadio.Location = new Point(206, 22);
            bothRadio.Name = "bothRadio";
            bothRadio.Size = new Size(50, 19);
            bothRadio.TabIndex = 2;
            bothRadio.Text = "Both";
            bothRadio.UseVisualStyleBackColor = true;
            bothRadio.CheckedChanged += KindRadio_CheckedChanged;
            // 
            // formatLabel
            // 
            formatLabel.AutoSize = true;
            formatLabel.Location = new Point(12, 134);
            formatLabel.Name = "formatLabel";
            formatLabel.Size = new Size(48, 15);
            formatLabel.TabIndex = 3;
            formatLabel.Text = "Format:";
            // 
            // formatCombo
            // 
            formatCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            formatCombo.FormattingEnabled = true;
            formatCombo.Location = new Point(66, 131);
            formatCombo.Name = "formatCombo";
            formatCombo.Size = new Size(180, 23);
            formatCombo.TabIndex = 4;
            // 
            // qualityLabel
            // 
            qualityLabel.AutoSize = true;
            qualityLabel.Location = new Point(12, 168);
            qualityLabel.Name = "qualityLabel";
            qualityLabel.Size = new Size(50, 15);
            qualityLabel.TabIndex = 5;
            qualityLabel.Text = "Quality:";
            // 
            // qualityCombo
            // 
            qualityCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            qualityCombo.FormattingEnabled = true;
            qualityCombo.Location = new Point(66, 165);
            qualityCombo.Name = "qualityCombo";
            qualityCombo.Size = new Size(180, 23);
            qualityCombo.TabIndex = 6;
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(12, 200);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(100, 32);
            downloadButton.TabIndex = 7;
            downloadButton.Text = "Download";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += DownloadButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Enabled = false;
            cancelButton.Location = new Point(120, 200);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 32);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // logTextBox
            // 
            logTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logTextBox.BackColor = Color.FromArgb(24, 26, 28);
            logTextBox.ForeColor = Color.FromArgb(220, 222, 225);
            logTextBox.Font = new Font("Consolas", 9F);
            logTextBox.Location = new Point(12, 242);
            logTextBox.Multiline = true;
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.ScrollBars = ScrollBars.Both;
            logTextBox.Size = new Size(568, 218);
            logTextBox.TabIndex = 9;
            logTextBox.WordWrap = false;
            // 
            // tabSettings
            // 
            tabSettings.Controls.Add(saveLabel);
            tabSettings.Controls.Add(outputFolderTextBox);
            tabSettings.Controls.Add(browseButton);
            tabSettings.Controls.Add(ytDlpLabel);
            tabSettings.Controls.Add(ytDlpPathTextBox);
            tabSettings.Controls.Add(ytDlpBrowseButton);
            tabSettings.Controls.Add(ffmpegLabel);
            tabSettings.Controls.Add(ffmpegPathTextBox);
            tabSettings.Controls.Add(ffmpegBrowseButton);
            tabSettings.Controls.Add(saveSettingsButton);
            tabSettings.Controls.Add(settingsStatusLabel);
            tabSettings.Controls.Add(settingsHelpLabel);
            tabSettings.Location = new Point(4, 24);
            tabSettings.Name = "tabSettings";
            tabSettings.Padding = new Padding(3);
            tabSettings.Size = new Size(592, 472);
            tabSettings.TabIndex = 1;
            tabSettings.Text = "Settings";
            tabSettings.UseVisualStyleBackColor = true;
            // 
            // saveLabel
            // 
            saveLabel.AutoSize = true;
            saveLabel.Location = new Point(12, 15);
            saveLabel.Name = "saveLabel";
            saveLabel.Size = new Size(50, 15);
            saveLabel.TabIndex = 0;
            saveLabel.Text = "Save to:";
            // 
            // outputFolderTextBox
            // 
            outputFolderTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            outputFolderTextBox.Location = new Point(12, 36);
            outputFolderTextBox.Name = "outputFolderTextBox";
            outputFolderTextBox.ReadOnly = true;
            outputFolderTextBox.Size = new Size(476, 23);
            outputFolderTextBox.TabIndex = 1;
            // 
            // browseButton
            // 
            browseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browseButton.Location = new Point(496, 35);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(84, 25);
            browseButton.TabIndex = 2;
            browseButton.Text = "Browse...";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += BrowseButton_Click;
            // 
            // ytDlpLabel
            // 
            ytDlpLabel.AutoSize = true;
            ytDlpLabel.Location = new Point(12, 73);
            ytDlpLabel.Name = "ytDlpLabel";
            ytDlpLabel.Size = new Size(66, 15);
            ytDlpLabel.TabIndex = 3;
            ytDlpLabel.Text = "yt-dlp path:";
            // 
            // ytDlpPathTextBox
            // 
            ytDlpPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ytDlpPathTextBox.Location = new Point(12, 94);
            ytDlpPathTextBox.Name = "ytDlpPathTextBox";
            ytDlpPathTextBox.PlaceholderText = "Leave blank to auto-detect";
            ytDlpPathTextBox.Size = new Size(476, 23);
            ytDlpPathTextBox.TabIndex = 4;
            // 
            // ytDlpBrowseButton
            // 
            ytDlpBrowseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ytDlpBrowseButton.Location = new Point(496, 93);
            ytDlpBrowseButton.Name = "ytDlpBrowseButton";
            ytDlpBrowseButton.Size = new Size(84, 25);
            ytDlpBrowseButton.TabIndex = 5;
            ytDlpBrowseButton.Text = "Browse...";
            ytDlpBrowseButton.UseVisualStyleBackColor = true;
            ytDlpBrowseButton.Click += YtDlpBrowseButton_Click;
            // 
            // ffmpegLabel
            // 
            ffmpegLabel.AutoSize = true;
            ffmpegLabel.Location = new Point(12, 131);
            ffmpegLabel.Name = "ffmpegLabel";
            ffmpegLabel.Size = new Size(72, 15);
            ffmpegLabel.TabIndex = 6;
            ffmpegLabel.Text = "ffmpeg path:";
            // 
            // ffmpegPathTextBox
            // 
            ffmpegPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ffmpegPathTextBox.Location = new Point(12, 152);
            ffmpegPathTextBox.Name = "ffmpegPathTextBox";
            ffmpegPathTextBox.PlaceholderText = "Leave blank to auto-detect";
            ffmpegPathTextBox.Size = new Size(476, 23);
            ffmpegPathTextBox.TabIndex = 7;
            // 
            // ffmpegBrowseButton
            // 
            ffmpegBrowseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ffmpegBrowseButton.Location = new Point(496, 151);
            ffmpegBrowseButton.Name = "ffmpegBrowseButton";
            ffmpegBrowseButton.Size = new Size(84, 25);
            ffmpegBrowseButton.TabIndex = 8;
            ffmpegBrowseButton.Text = "Browse...";
            ffmpegBrowseButton.UseVisualStyleBackColor = true;
            ffmpegBrowseButton.Click += FfmpegBrowseButton_Click;
            // 
            // saveSettingsButton
            // 
            saveSettingsButton.Location = new Point(12, 192);
            saveSettingsButton.Name = "saveSettingsButton";
            saveSettingsButton.Size = new Size(100, 32);
            saveSettingsButton.TabIndex = 9;
            saveSettingsButton.Text = "Save";
            saveSettingsButton.UseVisualStyleBackColor = true;
            saveSettingsButton.Click += SaveSettingsButton_Click;
            // 
            // settingsStatusLabel
            // 
            settingsStatusLabel.AutoSize = true;
            settingsStatusLabel.Location = new Point(120, 200);
            settingsStatusLabel.Name = "settingsStatusLabel";
            settingsStatusLabel.Size = new Size(0, 15);
            settingsStatusLabel.TabIndex = 10;
            // 
            // settingsHelpLabel
            // 
            settingsHelpLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            settingsHelpLabel.ForeColor = SystemColors.GrayText;
            settingsHelpLabel.Location = new Point(12, 242);
            settingsHelpLabel.Name = "settingsHelpLabel";
            settingsHelpLabel.Size = new Size(568, 60);
            settingsHelpLabel.TabIndex = 11;
            settingsHelpLabel.Text = "These paths override auto-detection. Leave a box blank to search PATH and the application folder for the tool.";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 500);
            Controls.Add(tabControl);
            MinimumSize = new Size(480, 420);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MediaGrabber \u2014 yt-dlp + ffmpeg";
            tabControl.ResumeLayout(false);
            tabDownloader.ResumeLayout(false);
            tabDownloader.PerformLayout();
            tabSettings.ResumeLayout(false);
            tabSettings.PerformLayout();
            typeGroupBox.ResumeLayout(false);
            typeGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabDownloader;
        private TabPage tabSettings;
        private Label urlLabel;
        private TextBox urlTextBox;
        private GroupBox typeGroupBox;
        private RadioButton videoRadio;
        private RadioButton audioRadio;
        private RadioButton bothRadio;
        private Label formatLabel;
        private ComboBox formatCombo;
        private Label qualityLabel;
        private ComboBox qualityCombo;
        private Label saveLabel;
        private TextBox outputFolderTextBox;
        private Button browseButton;
        private Button downloadButton;
        private Button cancelButton;
        private TextBox logTextBox;
        private Label ytDlpLabel;
        private TextBox ytDlpPathTextBox;
        private Button ytDlpBrowseButton;
        private Label ffmpegLabel;
        private TextBox ffmpegPathTextBox;
        private Button ffmpegBrowseButton;
        private Button saveSettingsButton;
        private Label settingsStatusLabel;
        private Label settingsHelpLabel;
    }
}
