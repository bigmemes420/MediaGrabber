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
            urlLabel = new Label();
            urlTextBox = new TextBox();
            typeGroupBox = new GroupBox();
            videoRadio = new RadioButton();
            audioRadio = new RadioButton();
            bothRadio = new RadioButton();
            formatLabel = new Label();
            formatCombo = new ComboBox();
            saveLabel = new Label();
            outputFolderTextBox = new TextBox();
            browseButton = new Button();
            downloadButton = new Button();
            cancelButton = new Button();
            logTextBox = new TextBox();
            typeGroupBox.SuspendLayout();
            SuspendLayout();
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
            urlTextBox.Size = new Size(520, 23);
            urlTextBox.TabIndex = 1;
            // 
            // typeGroupBox
            // 
            typeGroupBox.Controls.Add(videoRadio);
            typeGroupBox.Controls.Add(audioRadio);
            typeGroupBox.Controls.Add(bothRadio);
            typeGroupBox.Location = new Point(12, 64);
            typeGroupBox.Name = "typeGroupBox";
            typeGroupBox.Size = new Size(520, 54);
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
            // saveLabel
            // 
            saveLabel.AutoSize = true;
            saveLabel.Location = new Point(12, 168);
            saveLabel.Name = "saveLabel";
            saveLabel.Size = new Size(50, 15);
            saveLabel.TabIndex = 5;
            saveLabel.Text = "Save to:";
            // 
            // outputFolderTextBox
            // 
            outputFolderTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            outputFolderTextBox.Location = new Point(66, 165);
            outputFolderTextBox.Name = "outputFolderTextBox";
            outputFolderTextBox.ReadOnly = true;
            outputFolderTextBox.Size = new Size(374, 23);
            outputFolderTextBox.TabIndex = 6;
            // 
            // browseButton
            // 
            browseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browseButton.Location = new Point(448, 164);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(84, 25);
            browseButton.TabIndex = 7;
            browseButton.Text = "Browse...";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += BrowseButton_Click;
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(12, 202);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(100, 32);
            downloadButton.TabIndex = 8;
            downloadButton.Text = "Download";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += DownloadButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Enabled = false;
            cancelButton.Location = new Point(120, 202);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 32);
            cancelButton.TabIndex = 9;
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
            logTextBox.Location = new Point(12, 244);
            logTextBox.Multiline = true;
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.ScrollBars = ScrollBars.Both;
            logTextBox.Size = new Size(520, 185);
            logTextBox.TabIndex = 10;
            logTextBox.WordWrap = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 441);
            Controls.Add(logTextBox);
            Controls.Add(cancelButton);
            Controls.Add(downloadButton);
            Controls.Add(browseButton);
            Controls.Add(outputFolderTextBox);
            Controls.Add(saveLabel);
            Controls.Add(formatCombo);
            Controls.Add(formatLabel);
            Controls.Add(typeGroupBox);
            Controls.Add(urlTextBox);
            Controls.Add(urlLabel);
            MinimumSize = new Size(440, 360);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MediaGrabber \u2014 yt-dlp + ffmpeg";
            typeGroupBox.ResumeLayout(false);
            typeGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label urlLabel;
        private TextBox urlTextBox;
        private GroupBox typeGroupBox;
        private RadioButton videoRadio;
        private RadioButton audioRadio;
        private RadioButton bothRadio;
        private Label formatLabel;
        private ComboBox formatCombo;
        private Label saveLabel;
        private TextBox outputFolderTextBox;
        private Button browseButton;
        private Button downloadButton;
        private Button cancelButton;
        private TextBox logTextBox;
    }
}
