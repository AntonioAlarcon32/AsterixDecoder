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
            dataGrid.ColumnCount = 3;
            dataGrid.Columns[0].Name = "Num";
            dataGrid.Columns[1].Name = "Category";
            dataGrid.Columns[2].Name = "Length";
            for (int i = 0; i < dataBlockList.Count; i++)
            {
                if (dataBlockList[i].GetType() == typeof(CAT10))
                {
                    string[] row = new string[] { (i + 1).ToString(), "Cat 10", dataBlockList[i].GetLength().ToString() };
                    dataGrid.Rows.Add(row);
                }
                else if (dataBlockList[i].GetType() == typeof(CAT21))
                {
                    string[] row = new string[] { (i + 1).ToString(), "Cat 21", dataBlockList[i].GetLength().ToString() };
                    dataGrid.Rows.Add(row);
                }
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
    }
}

