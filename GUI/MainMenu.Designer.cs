
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
            this.checkADSB = new System.Windows.Forms.CheckBox();
            this.checkMLAT = new System.Windows.Forms.CheckBox();
            this.checkSMR = new System.Windows.Forms.CheckBox();
            this.moreInfoOfPacket = new System.Windows.Forms.Button();
            this.packetGridView = new System.Windows.Forms.DataGridView();
            this.flightTable = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.flightGridView = new System.Windows.Forms.DataGridView();
            this.playButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.moreInfoOfFlight = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packetGridView)).BeginInit();
            this.flightTable.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flightGridView)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(851, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.salirToolStripMenuItem.Text = "Salir";
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
            this.tabTable.Size = new System.Drawing.Size(829, 555);
            this.tabTable.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkADSB);
            this.tabPage1.Controls.Add(this.checkMLAT);
            this.tabPage1.Controls.Add(this.checkSMR);
            this.tabPage1.Controls.Add(this.moreInfoOfPacket);
            this.tabPage1.Controls.Add(this.packetGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(821, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Packet Table";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkADSB
            // 
            this.checkADSB.AutoSize = true;
            this.checkADSB.Checked = true;
            this.checkADSB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkADSB.Enabled = false;
            this.checkADSB.Location = new System.Drawing.Point(332, 477);
            this.checkADSB.Name = "checkADSB";
            this.checkADSB.Size = new System.Drawing.Size(130, 17);
            this.checkADSB.TabIndex = 6;
            this.checkADSB.Text = "Show ADS-B Packets";
            this.checkADSB.UseVisualStyleBackColor = true;
            this.checkADSB.CheckedChanged += new System.EventHandler(this.checkADSB_CheckedChanged);
            // 
            // checkMLAT
            // 
            this.checkMLAT.AutoSize = true;
            this.checkMLAT.Checked = true;
            this.checkMLAT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMLAT.Enabled = false;
            this.checkMLAT.Location = new System.Drawing.Point(172, 477);
            this.checkMLAT.Name = "checkMLAT";
            this.checkMLAT.Size = new System.Drawing.Size(127, 17);
            this.checkMLAT.TabIndex = 5;
            this.checkMLAT.Text = "Show MLAT Packets";
            this.checkMLAT.UseVisualStyleBackColor = true;
            // 
            // checkSMR
            // 
            this.checkSMR.AutoSize = true;
            this.checkSMR.Checked = true;
            this.checkSMR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSMR.Enabled = false;
            this.checkSMR.Location = new System.Drawing.Point(30, 477);
            this.checkSMR.Name = "checkSMR";
            this.checkSMR.Size = new System.Drawing.Size(122, 17);
            this.checkSMR.TabIndex = 4;
            this.checkSMR.Text = "Show SMR Packets";
            this.checkSMR.UseVisualStyleBackColor = true;
            // 
            // moreInfoOfPacket
            // 
            this.moreInfoOfPacket.Enabled = false;
            this.moreInfoOfPacket.Location = new System.Drawing.Point(600, 477);
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
            this.packetGridView.Size = new System.Drawing.Size(809, 464);
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
            this.flightTable.Size = new System.Drawing.Size(821, 529);
            this.flightTable.TabIndex = 1;
            this.flightTable.Text = "Flight Table";
            this.flightTable.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.timeLabel);
            this.tabPage2.Controls.Add(this.playButton);
            this.tabPage2.Controls.Add(this.map);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(821, 529);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Map View";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.map.Size = new System.Drawing.Size(719, 521);
            this.map.TabIndex = 2;
            this.map.Zoom = 13D;
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
            this.flightGridView.Size = new System.Drawing.Size(809, 464);
            this.flightGridView.TabIndex = 1;
            this.flightGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flightGridView_CellClick);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(730, 68);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(88, 67);
            this.playButton.TabIndex = 3;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(727, 52);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(33, 13);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "Time:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // moreInfoOfFlight
            // 
            this.moreInfoOfFlight.Enabled = false;
            this.moreInfoOfFlight.Location = new System.Drawing.Point(604, 473);
            this.moreInfoOfFlight.Name = "moreInfoOfFlight";
            this.moreInfoOfFlight.Size = new System.Drawing.Size(212, 47);
            this.moreInfoOfFlight.TabIndex = 4;
            this.moreInfoOfFlight.Text = "Show More Info Of Flight";
            this.moreInfoOfFlight.UseVisualStyleBackColor = true;
            this.moreInfoOfFlight.Click += new System.EventHandler(this.moreInfoOfFlight_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 605);
            this.Controls.Add(this.tabTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabTable.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packetGridView)).EndInit();
            this.flightTable.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flightGridView)).EndInit();
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
        private System.Windows.Forms.CheckBox checkADSB;
        private System.Windows.Forms.CheckBox checkMLAT;
        private System.Windows.Forms.CheckBox checkSMR;
        private System.Windows.Forms.DataGridView flightGridView;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button moreInfoOfFlight;
    }
}

