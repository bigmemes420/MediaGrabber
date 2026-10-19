namespace MediaGrabber
{
    public partial class MainForm : Form
    {
        private static readonly string[] VideoFormats = { "mp4", "mkv", "webm" };
        private static readonly string[] AudioFormats = { "mp3", "m4a", "wav", "opus", "flac" };

        private CancellationTokenSource? _cts;

        public MainForm()
        {
            InitializeComponent();
            outputFolderTextBox.Text = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            PopulateFormats();
            Shown += (_, _) => ReportTools();
        }

        private void ReportTools()
        {
            var ytDlp = ToolLocator.FindYtDlp();
            var ffmpeg = ToolLocator.FindFfmpeg();
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
                OutputFolder = outputFolderTextBox.Text,
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
