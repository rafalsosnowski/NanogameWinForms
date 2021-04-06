using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Collections;
using System.Xml.Serialization;

namespace pigelab
{
    public partial class ChoosePuzzle : Form
    {
        private List<SerializePuzzleClass> PuzzlesList;
        public SerializePuzzleClass selectedPuzzle=null;
        public ChoosePuzzle()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChoosePuzzle_Load(object sender, EventArgs e)
        {
            PuzzlesList = new List<SerializePuzzleClass>();
            listView1.Items.Clear();
        }

        private void ChooseDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowser.SelectedPath;
                if (textBox1.Text.Length != 0)
                {
                    foreach (string fpath in Directory.GetFiles(textBox1.Text, "*.xml"))
                    {
                        FileStream fs = new FileStream(fpath, FileMode.Open);
                        XmlSerializer xs = new XmlSerializer(typeof(SerializePuzzleClass));
                        SerializePuzzleClass spc = (SerializePuzzleClass)xs.Deserialize(fs);
                        fs.Close();

                        PuzzlesList.Add(spc);

                        ListViewItem newItem = new ListViewItem(new[] { spc.Title, spc.Width.ToString(), spc.Height.ToString(), spc.Difficulty });
                        listView1.Items.Add(newItem);
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length != 0)
            {
                listView1.Items.Clear();
                foreach (string fpath in Directory.GetFiles(textBox1.Text, "*.xml"))
                {
                    FileStream fs = new FileStream(fpath, FileMode.Open);
                    XmlSerializer xs = new XmlSerializer(typeof(SerializePuzzleClass));
                    SerializePuzzleClass spc = (SerializePuzzleClass)xs.Deserialize(fs);
                    fs.Close();

                    PuzzlesList.Add(spc);

                    ListViewItem newItem = new ListViewItem(new[] { spc.Title, spc.Width.ToString(), spc.Height.ToString(), spc.Difficulty });
                    listView1.Items.Add(newItem);
                }
            }
        }

        private void loadPuzzle_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView1.SelectedItems)
            {
                foreach(var puzzle in PuzzlesList)
                {
                    if(item.Text==puzzle.Title)
                    {
                        selectedPuzzle = puzzle;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }
    }
}
