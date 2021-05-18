
namespace GUI
{
    partial class MoreInfoOfFlight
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
            this.trackMap = new GMap.NET.WindowsForms.GMapControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.callsignLabel = new System.Windows.Forms.Label();
            this.mlatLabel = new System.Windows.Forms.Label();
            this.adsbLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trackMap
            // 
            this.trackMap.Bearing = 0F;
            this.trackMap.CanDragMap = true;
            this.trackMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.trackMap.GrayScaleMode = false;
            this.trackMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.trackMap.LevelsKeepInMemory = 5;
            this.trackMap.Location = new System.Drawing.Point(329, 12);
            this.trackMap.MarkersEnabled = true;
            this.trackMap.MaxZoom = 15;
            this.trackMap.MinZoom = 4;
            this.trackMap.MouseWheelZoomEnabled = true;
            this.trackMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.ViewCenter;
            this.trackMap.Name = "trackMap";
            this.trackMap.NegativeMode = false;
            this.trackMap.PolygonsEnabled = true;
            this.trackMap.RetryLoadTile = 0;
            this.trackMap.RoutesEnabled = true;
            this.trackMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.trackMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.trackMap.ShowTileGridLines = false;
            this.trackMap.Size = new System.Drawing.Size(702, 634);
            this.trackMap.TabIndex = 0;
            this.trackMap.Zoom = 8D;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Focus on LEBL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(74, 521);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Focus on Spain Coast";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(74, 567);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(169, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "Focus on West Mediterranean";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(74, 475);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(169, 40);
            this.button4.TabIndex = 4;
            this.button4.Text = "Focus on Catalonia And Pyrenees";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "CallSign:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of MLAT Packets:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of ADS-B Packets:";
            // 
            // callsignLabel
            // 
            this.callsignLabel.AutoSize = true;
            this.callsignLabel.Location = new System.Drawing.Point(128, 139);
            this.callsignLabel.Name = "callsignLabel";
            this.callsignLabel.Size = new System.Drawing.Size(25, 13);
            this.callsignLabel.TabIndex = 8;
            this.callsignLabel.Text = "aaa";
            // 
            // mlatLabel
            // 
            this.mlatLabel.AutoSize = true;
            this.mlatLabel.Location = new System.Drawing.Point(213, 175);
            this.mlatLabel.Name = "mlatLabel";
            this.mlatLabel.Size = new System.Drawing.Size(25, 13);
            this.mlatLabel.TabIndex = 9;
            this.mlatLabel.Text = "aaa";
            // 
            // adsbLabel
            // 
            this.adsbLabel.AutoSize = true;
            this.adsbLabel.Location = new System.Drawing.Point(216, 211);
            this.adsbLabel.Name = "adsbLabel";
            this.adsbLabel.Size = new System.Drawing.Size(25, 13);
            this.adsbLabel.TabIndex = 10;
            this.adsbLabel.Text = "aaa";
            // 
            // MoreInfoOfFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 658);
            this.Controls.Add(this.adsbLabel);
            this.Controls.Add(this.mlatLabel);
            this.Controls.Add(this.callsignLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackMap);
            this.Name = "MoreInfoOfFlight";
            this.Text = "Selected Flight";
            this.Load += new System.EventHandler(this.MoreInfoOfFlight_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl trackMap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label callsignLabel;
        private System.Windows.Forms.Label mlatLabel;
        private System.Windows.Forms.Label adsbLabel;
    }
}