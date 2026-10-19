namespace MediaGrabber
{
    public partial class MainForm : Form
    {
        private static readonly string[] VideoFormats = { "mp4", "mkv", "webm" };
        private static readonly string[] AudioFormats = { "mp3", "m4a", "wav", "opus", "flac" };
        private static readonly string[] VideoQualities = { "Best", "2160p", "1440p", "1080p", "720p", "480p" };
        private static readonly string[] AudioQualities = { "Best", "Lossless", "320k", "256k", "192k", "128k" };

        private CancellationTokenSource? _cts;

        public MainForm()
        {
            InitializeComponent();
            PopulateFormats();
            PopulateQuality();

            var settings = SettingsStore.Load();
            ytDlpPathTextBox.Text = settings.YtDlpPath ?? "";
            ffmpegPathTextBox.Text = settings.FfmpegPath ?? "";
            outputFolderTextBox.Text = string.IsNullOrWhiteSpace(settings.OutputFolder)
                ? DefaultOutputFolder()
                : settings.OutputFolder;

            Shown += (_, _) => ReportTools();
        }

        private void ReportTools()
        {
            var settings = SettingsStore.Load();
            var ytDlp = ToolLocator.FindYtDlp(settings.YtDlpPath);
            var ffmpeg = ToolLocator.FindFfmpeg(settings.FfmpegPath);
            AppendLog(ytDlp != null ? $"yt-dlp found: {ytDlp}" : "yt-dlp not found. Install it or put it on PATH.");
            AppendLog(ffmpeg != null ? $"ffmpeg found: {ffmpeg}" : "ffmpeg not found. Install it or put it on PATH.");
        }

        private MediaKind CurrentKind()
        {
            if (audioRadio.Checked)
            {
                return MediaKind.Audio;
            }

            if (bothRadio.Checked)
            {
                return MediaKind.Both;
            }

            return MediaKind.Video;
        }

        private void KindRadio_CheckedChanged(object? sender, EventArgs e)
        {
            // Both Checked events fire on a switch (one off, one on); only react to the one turning on.
            if (sender is RadioButton { Checked: true })
            {
                PopulateFormats();
                PopulateQuality();
            }
        }

        private void PopulateFormats()
        {
            var formats = CurrentKind() == MediaKind.Audio ? AudioFormats : VideoFormats;
            formatCombo.BeginUpdate();
            formatCombo.Items.Clear();
            formatCombo.Items.AddRange(formats);
            formatCombo.SelectedIndex = 0;
            formatCombo.EndUpdate();
        }

        private void PopulateQuality()
        {
            var qualities = CurrentKind() == MediaKind.Audio ? AudioQualities : VideoQualities;
            qualityCombo.BeginUpdate();
            qualityCombo.Items.Clear();
            qualityCombo.Items.AddRange(qualities);
            qualityCombo.SelectedIndex = 0;
            qualityCombo.EndUpdate();
        }

        private void BrowseButton_Click(object? sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog
            {
                Description = "Choose where downloads are saved",
                UseDescriptionForTitle = true,
            };

            if (Directory.Exists(outputFolderTextBox.Text))
            {
                dialog.SelectedPath = outputFolderTextBox.Text;
            }

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                outputFolderTextBox.Text = dialog.SelectedPath;
            }
        }

        private void YtDlpBrowseButton_Click(object? sender, EventArgs e)
        {
            BrowseForExecutable(ytDlpPathTextBox);
        }

        private void FfmpegBrowseButton_Click(object? sender, EventArgs e)
        {
            BrowseForExecutable(ffmpegPathTextBox);
        }

        private void BrowseForExecutable(TextBox target)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Executables (*.exe)|*.exe|All files (*.*)|*.*",
                CheckFileExists = true,
            };

            if (File.Exists(target.Text))
            {
                dialog.InitialDirectory = Path.GetDirectoryName(target.Text);
                dialog.FileName = Path.GetFileName(target.Text);
            }

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                target.Text = dialog.FileName;
            }
        }

        private void SaveSettingsButton_Click(object? sender, EventArgs e)
        {
            var settings = new AppSettings
            {
                YtDlpPath = NullIfBlank(ytDlpPathTextBox.Text),
                FfmpegPath = NullIfBlank(ffmpegPathTextBox.Text),
                OutputFolder = NullIfBlank(outputFolderTextBox.Text),
            };

            try
            {
                SettingsStore.Save(settings);
                settingsStatusLabel.ForeColor = SystemColors.ControlText;
                settingsStatusLabel.Text = "Saved.";
                ReportTools();
            }
            catch (Exception ex)
            {
                settingsStatusLabel.ForeColor = Color.Firebrick;
                settingsStatusLabel.Text = ex.Message;
            }
        }

        private static string? NullIfBlank(string value)
        {
            var trimmed = value.Trim();
            return trimmed.Length == 0 ? null : trimmed;
        }

        private static string DefaultOutputFolder() => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

        private async void DownloadButton_Click(object? sender, EventArgs e)
        {
            var url = urlTextBox.Text.Trim();
            if (url.Length == 0)
            {
                MessageBox.Show(this, "Enter a video or page URL first.", "MediaGrabber",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                urlTextBox.Focus();
                return;
            }

            var request = new DownloadRequest
            {
                Url = url,
                Kind = CurrentKind(),
                Format = (string)formatCombo.SelectedItem!,
                Quality = (string)qualityCombo.SelectedItem!,
                OutputFolder = NullIfBlank(outputFolderTextBox.Text) ?? DefaultOutputFolder(),
            };

            _cts = new CancellationTokenSource();
            downloadButton.Enabled = false;
            cancelButton.Enabled = true;
            logTextBox.Clear();

            try
            {
                var exitCode = await new DownloadService().RunAsync(request, AppendLog, _cts.Token);
                AppendLog(exitCode == 0
                    ? "Completed successfully."
                    : $"Failed (exit code {exitCode}).");
            }
            catch (OperationCanceledException)
            {
                AppendLog("Canceled.");
            }
            catch (Exception ex)
            {
                AppendLog($"Error: {ex.Message}");
            }
            finally
            {
                downloadButton.Enabled = true;
                cancelButton.Enabled = false;
                _cts.Dispose();
                _cts = null;
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            cancelButton.Enabled = false;
            _cts?.Cancel();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Don't leave yt-dlp/ffmpeg running orphaned if the window is closed mid-download.
            _cts?.Cancel();
            base.OnFormClosing(e);
        }

        private void AppendLog(string line)
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired)
            {
                try
                {
                    BeginInvoke(() => AppendLog(line));
                }
                catch (ObjectDisposedException)
                {
                }
                catch (InvalidOperationException)
                {
                }

                return;
            }

            logTextBox.AppendText(line + Environment.NewLine);
        }
    }
}
