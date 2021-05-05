
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
            this.trackMap.MinZoom = 8;
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
            this.trackMap.Size = new System.Drawing.Size(459, 433);
            this.trackMap.TabIndex = 0;
            this.trackMap.Zoom = 8D;
            // 
            // MoreInfoOfFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trackMap);
            this.Name = "MoreInfoOfFlight";
            this.Text = "MoreInfoOfFlight";
            this.Load += new System.EventHandler(this.MoreInfoOfFlight_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl trackMap;
    }
}