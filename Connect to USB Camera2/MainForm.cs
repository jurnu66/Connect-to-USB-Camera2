using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Connect_to_USB_Camera2
{
    public partial class MainForm : Form
    {
        private VideoCapture _camera;
        private VideoWriter _videoWriter;
        private CascadeClassifier _faceDetector;
        private System.Windows.Forms.Timer _snapshotTimer;
        private bool _isRecording = false;
        private bool _isSnapshotEnabled = false;
        private int _snapshotInterval = 3; // Default snapshot interval in seconds
        private string _snapshotFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Snapshots");

        public MainForm()
        {
            InitializeComponent();
            UpdateConnectionStatus("Disconnected");
            UpdateRecordStatus("Pause");
            textSnapshotFolder.Text = _snapshotFolder;

            // Load Haarcascade model
            try
            {
                string haarcascadePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "haarcascade_frontalface_default.xml");
                if (!File.Exists(haarcascadePath))
                {
                    throw new FileNotFoundException("Haarcascade model file not found.", haarcascadePath);
                }
                _faceDetector = new CascadeClassifier(haarcascadePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Haarcascade model: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_camera == null)
            {
                try
                {
                    _camera = new VideoCapture(0); // Camera index 
                    _camera.ImageGrabbed += ProcessFrame;
                    _camera.Start();

                    UpdateConnectionStatus("Connected");
                    btnConnect.Text = "Disconnect";
                }
                catch (Exception ex)
                {
                    UpdateConnectionStatus("Disconnected");
                    MessageBox.Show($"Error connecting to camera: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _camera.Dispose();
                _camera = null;
                UpdateConnectionStatus("Disconnected");
                btnConnect.Text = "Connect";
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (_isSnapshotEnabled)
            {
                MessageBox.Show("Disable snapshot before starting recording!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_camera == null)
            {
                MessageBox.Show("Please connect the camera first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isRecording = !_isRecording;
            UpdateRecordStatus(_isRecording ? "Play" : "Pause");
            btnRecord.Text = _isRecording ? "Pause" : "Play";

            if (_isRecording)
            {
                string filePath = Path.Combine(_snapshotFolder, $"recorded_{DateTime.Now:yyyyMMdd_HHmmss}.avi");
                int frameWidth = _camera.Width;
                int frameHeight = _camera.Height;
                _videoWriter = new VideoWriter(filePath, VideoWriter.Fourcc('M', 'J', 'P', 'G'), 30, new Size(frameWidth, frameHeight), true);
                AppendToLog($"Recording started: {filePath}");
            }
            else
            {
                _videoWriter?.Dispose();
                _videoWriter = null;
                AppendToLog("Recording stopped.");
            }
        }

        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            if (_isRecording)
            {
                MessageBox.Show("Cannot enable snapshot while recording!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isSnapshotEnabled = !_isSnapshotEnabled;
            btnSnapshot.Text = _isSnapshotEnabled ? "Disable Snapshot" : "Enable Snapshot";

            if (_isSnapshotEnabled)
            {
                _snapshotInterval = (int)numericSnapshotInterval.Value;
                _snapshotTimer = new System.Windows.Forms.Timer
                {
                    Interval = _snapshotInterval * 1000
                };
                _snapshotTimer.Tick += TakeSnapshot;
                _snapshotTimer.Start();
            }
            else
            {
                _snapshotTimer?.Stop();
                _snapshotTimer = null;
            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    _snapshotFolder = folderDialog.SelectedPath;
                    textSnapshotFolder.Text = _snapshotFolder;
                }
            }
        }

        private void TakeSnapshot(object sender, EventArgs e)
        {
            try
            {
                if (_camera != null && _camera.Ptr != IntPtr.Zero)
                {
                    var frame = new Mat();
                    _camera.Retrieve(frame);
                    var image = frame.ToImage<Bgr, byte>();
                    var grayImage = image.Convert<Gray, byte>();

                    if (_faceDetector != null)
                    {
                        var faces = _faceDetector.DetectMultiScale(grayImage, 1.1, 10, Size.Empty);
                        if (faces.Length > 0)
                        {
                            var faceRect = faces[0];
                            var faceImage = grayImage.Copy(faceRect);

                            // Generate unique filename
                            string filename = Path.Combine(_snapshotFolder, $"Snapshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                            // Save the snapshot
                            faceImage.ToBitmap().Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                            AppendToLog($"Snapshot saved: {filename}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AppendToLog($"Error taking snapshot: {ex.Message}");
            }
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            try
            {
                if (_camera != null && _camera.Ptr != IntPtr.Zero)
                {
                    var frame = new Mat();
                    _camera.Retrieve(frame);
                    var image = frame.ToImage<Bgr, byte>();

                    // Convert to grayscale and display
                    var grayImage = image.Convert<Gray, byte>();

                    // Detect faces
                    if (_faceDetector != null)
                    {
                        var faces = _faceDetector.DetectMultiScale(grayImage, 1.1, 10, Size.Empty);

                        foreach (var face in faces)
                        {
                            image.Draw(face, new Bgr(Color.Red), 2);
                        }

                        if (faces.Length > 0)
                        {
                            var faceRect = faces[0];
                            var faceImage = grayImage.Copy(faceRect);
                            pictureBoxGray.Image = faceImage.ToBitmap();
                        }
                    }

                    pictureBoxCamera.Image = image.ToBitmap();

                    if (_isRecording && _videoWriter != null)
                    {
                        _videoWriter.Write(frame);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateConnectionStatus("Disconnected");
                MessageBox.Show($"Error processing frame: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateConnectionStatus(string status)
        {
            lblConnectionStatus.Text = $"Camera Status: {status}";
            lblConnectionStatus.ForeColor = status == "Connected" ? Color.Green : Color.Red;
        }

        private void UpdateRecordStatus(string status)
        {
            lblRecordStatus.Text = $"Recording: {status}";
            lblRecordStatus.ForeColor = status == "Play" ? Color.Green : Color.Red;
        }

        private void AppendToLog(string message)
        {
            textLog.AppendText($"{message}{Environment.NewLine}");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _camera?.Dispose();
            _videoWriter?.Dispose();
            _snapshotTimer?.Stop();
        }
    }
}
