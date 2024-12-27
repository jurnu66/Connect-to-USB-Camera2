namespace Connect_to_USB_Camera2
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private System.Windows.Forms.PictureBox pictureBoxCamera;
        private System.Windows.Forms.PictureBox pictureBoxGray;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.NumericUpDown numericSnapshotInterval;
        private System.Windows.Forms.TextBox textSnapshotFolder;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label lblRecordStatus;
        private System.Windows.Forms.Label labelFaces;
        private System.Windows.Forms.TextBox textLog;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Initialize controls
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.pictureBoxGray = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.numericSnapshotInterval = new System.Windows.Forms.NumericUpDown();
            this.textSnapshotFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.lblRecordStatus = new System.Windows.Forms.Label();
            this.labelFaces = new System.Windows.Forms.Label();
            this.textLog = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSnapshotInterval)).BeginInit();

            this.SuspendLayout();

            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCamera.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCamera.TabIndex = 0;
            this.pictureBoxCamera.TabStop = false;

            // 
            // pictureBoxGray
            // 
            this.pictureBoxGray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGray.Location = new System.Drawing.Point(660, 12);
            this.pictureBoxGray.Name = "pictureBoxGray";
            this.pictureBoxGray.Size = new System.Drawing.Size(240, 240);
            this.pictureBoxGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGray.TabIndex = 1;
            this.pictureBoxGray.TabStop = false;

            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 500);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 30);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);

            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(130, 500);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(100, 30);
            this.btnRecord.TabIndex = 3;
            this.btnRecord.Text = "Play";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);

            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Location = new System.Drawing.Point(240, 500);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(120, 30);
            this.btnSnapshot.TabIndex = 4;
            this.btnSnapshot.Text = "Enable Snapshot";
            this.btnSnapshot.UseVisualStyleBackColor = true;
            this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);

            // 
            // numericSnapshotInterval
            // 
            this.numericSnapshotInterval.Location = new System.Drawing.Point(370, 506);
            this.numericSnapshotInterval.Name = "numericSnapshotInterval";
            this.numericSnapshotInterval.Size = new System.Drawing.Size(60, 22);
            this.numericSnapshotInterval.Minimum = 1;
            this.numericSnapshotInterval.Maximum = 60;
            this.numericSnapshotInterval.Value = 3; // Default value
            this.numericSnapshotInterval.TabIndex = 5;

            // 
            // textSnapshotFolder
            // 
            this.textSnapshotFolder.Location = new System.Drawing.Point(12, 460);
            this.textSnapshotFolder.Name = "textSnapshotFolder";
            this.textSnapshotFolder.Size = new System.Drawing.Size(620, 22);
            this.textSnapshotFolder.ReadOnly = true;
            this.textSnapshotFolder.TabIndex = 6;

            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(640, 460);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(75, 22);
            this.btnBrowseFolder.TabIndex = 7;
            this.btnBrowseFolder.Text = "Browse";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);

            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(12, 550);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(117, 17);
            this.lblConnectionStatus.TabIndex = 8;
            this.lblConnectionStatus.Text = "Camera Status: ";

            // 
            // lblRecordStatus
            // 
            this.lblRecordStatus.AutoSize = true;
            this.lblRecordStatus.Location = new System.Drawing.Point(130, 550);
            this.lblRecordStatus.Name = "lblRecordStatus";
            this.lblRecordStatus.Size = new System.Drawing.Size(94, 17);
            this.lblRecordStatus.TabIndex = 9;
            this.lblRecordStatus.Text = "Recording: ";

            // 
            // labelFaces
            // 
            this.labelFaces.AutoSize = true;
            this.labelFaces.Location = new System.Drawing.Point(660, 260);
            this.labelFaces.Name = "labelFaces";
            this.labelFaces.Size = new System.Drawing.Size(44, 17);
            this.labelFaces.TabIndex = 10;
            this.labelFaces.Text = "Faces";

            // 
            // textLog
            // 
            this.textLog.Location = new System.Drawing.Point(12, 580);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.Size = new System.Drawing.Size(888, 80);
            this.textLog.TabIndex = 11;
            this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 680);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.labelFaces);
            this.Controls.Add(this.lblRecordStatus);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.textSnapshotFolder);
            this.Controls.Add(this.numericSnapshotInterval);
            this.Controls.Add(this.btnSnapshot);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.pictureBoxGray);
            this.Controls.Add(this.pictureBoxCamera);
            this.Name = "MainForm";
            this.Text = "Camera Recorder";

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSnapshotInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
