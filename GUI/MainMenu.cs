using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace GUI
{
    public partial class MainMenu : Form
    {
        string path;
        AsterixFile asterixFile = new AsterixFile();
        List<CAT10> cat10list;
        List<CAT21> cat21list;
        List<DataBlock> dataBlockList ;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void loadAsterixFile(string path)
        {
            asterixFile.ReadFile(path);
            cat10list = asterixFile.GetCAT10Blocks();
            cat21list = asterixFile.GetCAT21Blocks();
            dataBlockList = asterixFile.GetDataBlocks();
        }

        private void setDataTable(DataGridView dataGrid)
        {
            dataGrid.ColumnCount = 5;
            dataGrid.Columns[0].Name = "Num";
            dataGrid.Columns[1].Name = "Category";
            dataGrid.Columns[2].Name = "Length";
            dataGrid.Columns[3].Name = "Time";
            dataGrid.Columns[4].Name = "Type Of Message";
            for (int i = 0; i < dataBlockList.Count; i++)
            {
                    string[] row = new string[] { (i + 1).ToString(),"Cat " + dataBlockList[i].GetCategory().ToString() , dataBlockList[i].GetLength().ToString(), dataBlockList[i].GetTime().ToString(), dataBlockList[i].GetTypeOfMessage()};
                    dataGrid.Rows.Add(row);
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
{
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    path = openFileDialog.FileName;
                    loadAsterixFile(path);
                    setDataTable(packetGridView);
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void moreInfoOfPacket_Click(object sender, EventArgs e)
        {
            MoreInfoOfPacket newForm = new MoreInfoOfPacket();
            newForm.Show();
        }

        private void packetGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            moreInfoOfPacket.Enabled = true;
        }
    }
}

