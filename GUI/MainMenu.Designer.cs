
namespace GUI
{
    partial class MainMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabTable = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.moreInfoOfPacket = new System.Windows.Forms.Button();
            this.packetGridView = new System.Windows.Forms.DataGridView();
            this.flightTable = new System.Windows.Forms.TabPage();
            this.moreInfoOfFlight = new System.Windows.Forms.Button();
            this.flightGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mapADSBCheck = new System.Windows.Forms.CheckBox();
            this.mapMLATCheck = new System.Windows.Forms.CheckBox();
            this.mapSMRCheck = new System.Windows.Forms.CheckBox();
            this.x16Button = new System.Windows.Forms.Button();
            this.x4Button = new System.Windows.Forms.Button();
            this.x1Button = new System.Windows.Forms.Button();
            this.x2Button = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.selectedMarker = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packetGridView)).BeginInit();
            this.flightTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flightGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1070, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.archivoToolStripMenuItem.Text = "File";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.abrirToolStripMenuItem.Text = "Open";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.salirToolStripMenuItem.Text = "Exit";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.tabPage1);
            this.tabTable.Controls.Add(this.flightTable);
            this.tabTable.Controls.Add(this.tabPage2);
            this.tabTable.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabTable.Location = new System.Drawing.Point(11, 29);
            this.tabTable.Margin = new System.Windows.Forms.Padding(2);
            this.tabTable.Name = "tabTable";
            this.tabTable.SelectedIndex = 0;
            this.tabTable.Size = new System.Drawing.Size(1048, 633);
            this.tabTable.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.moreInfoOfPacket);
            this.tabPage1.Controls.Add(this.packetGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1040, 607);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Packet Table";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // moreInfoOfPacket
            // 
            this.moreInfoOfPacket.Enabled = false;
            this.moreInfoOfPacket.Location = new System.Drawing.Point(823, 555);
            this.moreInfoOfPacket.Name = "moreInfoOfPacket";
            this.moreInfoOfPacket.Size = new System.Drawing.Size(212, 47);
            this.moreInfoOfPacket.TabIndex = 3;
            this.moreInfoOfPacket.Text = "Show More Info Of Packet";
            this.moreInfoOfPacket.UseVisualStyleBackColor = true;
            this.moreInfoOfPacket.Click += new System.EventHandler(this.moreInfoOfPacket_Click);
            // 
            // packetGridView
            // 
            this.packetGridView.AllowUserToAddRows = false;
            this.packetGridView.AllowUserToDeleteRows = false;
            this.packetGridView.AllowUserToResizeColumns = false;
            this.packetGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.packetGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packetGridView.Location = new System.Drawing.Point(3, 3);
            this.packetGridView.Margin = new System.Windows.Forms.Padding(2);
            this.packetGridView.MultiSelect = false;
            this.packetGridView.Name = "packetGridView";
            this.packetGridView.RowHeadersWidth = 82;
            this.packetGridView.RowTemplate.Height = 33;
            this.packetGridView.Size = new System.Drawing.Size(1033, 547);
            this.packetGridView.TabIndex = 0;
            this.packetGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.packetGridView_CellClick);
            // 
            // flightTable
            // 
            this.flightTable.Controls.Add(this.moreInfoOfFlight);
            this.flightTable.Controls.Add(this.flightGridView);
            this.flightTable.Location = new System.Drawing.Point(4, 22);
            this.flightTable.Margin = new System.Windows.Forms.Padding(2);
            this.flightTable.Name = "flightTable";
            this.flightTable.Padding = new System.Windows.Forms.Padding(2);
            this.flightTable.Size = new System.Drawing.Size(1040, 607);
            this.flightTable.TabIndex = 1;
            this.flightTable.Text = "Flight Table";
            this.flightTable.UseVisualStyleBackColor = true;
            // 
            // moreInfoOfFlight
            // 
            this.moreInfoOfFlight.Enabled = false;
            this.moreInfoOfFlight.Location = new System.Drawing.Point(823, 555);
            this.moreInfoOfFlight.Name = "moreInfoOfFlight";
            this.moreInfoOfFlight.Size = new System.Drawing.Size(212, 47);
            this.moreInfoOfFlight.TabIndex = 4;
            this.moreInfoOfFlight.Text = "Show More Info Of Flight";
            this.moreInfoOfFlight.UseVisualStyleBackColor = true;
            this.moreInfoOfFlight.Click += new System.EventHandler(this.moreInfoOfFlight_Click);
            // 
            // flightGridView
            // 
            this.flightGridView.AllowUserToAddRows = false;
            this.flightGridView.AllowUserToDeleteRows = false;
            this.flightGridView.AllowUserToResizeColumns = false;
            this.flightGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.flightGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flightGridView.Location = new System.Drawing.Point(8, 4);
            this.flightGridView.Margin = new System.Windows.Forms.Padding(2);
            this.flightGridView.MultiSelect = false;
            this.flightGridView.Name = "flightGridView";
            this.flightGridView.RowHeadersWidth = 82;
            this.flightGridView.RowTemplate.Height = 33;
            this.flightGridView.Size = new System.Drawing.Size(1027, 546);
            this.flightGridView.TabIndex = 1;
            this.flightGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flightGridView_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.mapADSBCheck);
            this.tabPage2.Controls.Add(this.mapMLATCheck);
            this.tabPage2.Controls.Add(this.mapSMRCheck);
            this.tabPage2.Controls.Add(this.x16Button);
            this.tabPage2.Controls.Add(this.x4Button);
            this.tabPage2.Controls.Add(this.x1Button);
            this.tabPage2.Controls.Add(this.x2Button);
            this.tabPage2.Controls.Add(this.stopButton);
            this.tabPage2.Controls.Add(this.selectedMarker);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.timeLabel);
            this.tabPage2.Controls.Add(this.playButton);
            this.tabPage2.Controls.Add(this.map);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1040, 607);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Map View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mapADSBCheck
            // 
            this.mapADSBCheck.AutoSize = true;
            this.mapADSBCheck.Checked = true;
            this.mapADSBCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapADSBCheck.Location = new System.Drawing.Point(949, 487);
            this.mapADSBCheck.Name = "mapADSBCheck";
            this.mapADSBCheck.Size = new System.Drawing.Size(88, 17);
            this.mapADSBCheck.TabIndex = 17;
            this.mapADSBCheck.Text = "Show ADS-B";
            this.mapADSBCheck.UseVisualStyleBackColor = true;
            // 
            // mapMLATCheck
            // 
            this.mapMLATCheck.AutoSize = true;
            this.mapMLATCheck.Checked = true;
            this.mapMLATCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapMLATCheck.Location = new System.Drawing.Point(949, 464);
            this.mapMLATCheck.Name = "mapMLATCheck";
            this.mapMLATCheck.Size = new System.Drawing.Size(85, 17);
            this.mapMLATCheck.TabIndex = 16;
            this.mapMLATCheck.Text = "Show MLAT";
            this.mapMLATCheck.UseVisualStyleBackColor = true;
            // 
            // mapSMRCheck
            // 
            this.mapSMRCheck.AutoSize = true;
            this.mapSMRCheck.Checked = true;
            this.mapSMRCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapSMRCheck.Location = new System.Drawing.Point(949, 441);
            this.mapSMRCheck.Name = "mapSMRCheck";
            this.mapSMRCheck.Size = new System.Drawing.Size(80, 17);
            this.mapSMRCheck.TabIndex = 15;
            this.mapSMRCheck.Text = "Show SMR";
            this.mapSMRCheck.UseVisualStyleBackColor = true;
            // 
            // x16Button
            // 
            this.x16Button.Location = new System.Drawing.Point(1005, 554);
            this.x16Button.Name = "x16Button";
            this.x16Button.Size = new System.Drawing.Size(32, 34);
            this.x16Button.TabIndex = 14;
            this.x16Button.Text = "x16";
            this.x16Button.UseVisualStyleBackColor = true;
            this.x16Button.Click += new System.EventHandler(this.x16Button_Click);
            // 
            // x4Button
            // 
            this.x4Button.Location = new System.Drawing.Point(952, 554);
            this.x4Button.Name = "x4Button";
            this.x4Button.Size = new System.Drawing.Size(32, 34);
            this.x4Button.TabIndex = 13;
            this.x4Button.Text = "x4";
            this.x4Button.UseVisualStyleBackColor = true;
            this.x4Button.Click += new System.EventHandler(this.x4Button_Click);
            // 
            // x1Button
            // 
            this.x1Button.Location = new System.Drawing.Point(952, 514);
            this.x1Button.Name = "x1Button";
            this.x1Button.Size = new System.Drawing.Size(32, 34);
            this.x1Button.TabIndex = 12;
            this.x1Button.Text = "x1";
            this.x1Button.UseVisualStyleBackColor = true;
            this.x1Button.Click += new System.EventHandler(this.x1Button_Click);
            // 
            // x2Button
            // 
            this.x2Button.Location = new System.Drawing.Point(1005, 514);
            this.x2Button.Name = "x2Button";
            this.x2Button.Size = new System.Drawing.Size(32, 34);
            this.x2Button.TabIndex = 11;
            this.x2Button.Text = "x2";
            this.x2Button.UseVisualStyleBackColor = true;
            this.x2Button.Click += new System.EventHandler(this.x2Button_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(949, 146);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(88, 67);
            this.stopButton.TabIndex = 10;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // selectedMarker
            // 
            this.selectedMarker.AutoSize = true;
            this.selectedMarker.Location = new System.Drawing.Point(949, 420);
            this.selectedMarker.Name = "selectedMarker";
            this.selectedMarker.Size = new System.Drawing.Size(0, 13);
            this.selectedMarker.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(949, 285);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 40);
            this.button4.TabIndex = 8;
            this.button4.Text = "Focus on Catalonia And Pyrenees";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(949, 377);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 40);
            this.button3.TabIndex = 7;
            this.button3.Text = "Focus on West Mediterranean";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(949, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "Focus on Spain Coast";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(949, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Focus on LEBL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(946, 57);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(33, 13);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "Time:";
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(949, 73);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(88, 67);
            this.playButton.TabIndex = 3;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemory = 5;
            this.map.Location = new System.Drawing.Point(5, 5);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 18;
            this.map.MinZoom = 5;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(938, 599);
            this.map.TabIndex = 2;
            this.map.Zoom = 13D;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.redMarker;
            this.pictureBox1.Location = new System.Drawing.Point(952, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 14);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GUI.Properties.Resources.yellowMarker;
            this.pictureBox2.Location = new System.Drawing.Point(952, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(13, 14);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::GUI.Properties.Resources.blueMarker;
            this.pictureBox3.Location = new System.Drawing.Point(952, 40);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(13, 14);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(971, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "SMR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(971, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "MLAT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(972, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "ADS-B";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 673);
            this.Controls.Add(this.tabTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.Text = "Asterix Decoder";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabTable.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.packetGridView)).EndInit();
            this.flightTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flightGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.TabControl tabTable;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView packetGridView;
        private System.Windows.Forms.TabPage flightTable;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button moreInfoOfPacket;
        private System.Windows.Forms.TabPage tabPage2;
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.DataGridView flightGridView;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button moreInfoOfFlight;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label selectedMarker;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button x1Button;
        private System.Windows.Forms.Button x2Button;
        private System.Windows.Forms.Button x16Button;
        private System.Windows.Forms.Button x4Button;
        private System.Windows.Forms.CheckBox mapADSBCheck;
        private System.Windows.Forms.CheckBox mapMLATCheck;
        private System.Windows.Forms.CheckBox mapSMRCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

