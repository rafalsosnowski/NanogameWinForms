using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace pigelab
{
    public partial class Form1 : Form
    {
        enum GameMode { PlayMode, CreateMode };
        GameMode gameMode = GameMode.PlayMode;

        public Form1()
        {
            InitializeComponent();
        }
        Button[,] buttons;
        Label[] labels;

        FieldStat[,] fieldstat;
        FieldStat[,] WinSeq;

        static int CELLSIZ = 30;
        int n = 10, m = 10;
        bool win = false;

        TableLayoutPanel LayoutPanel = null;
        GroupBox groupBox = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            Point LayoutPanelPoint = new Point(this.Width / 2, this.Height / 2);



            Random rd = new Random();

            CreatePuzzle.Click += CreatePuzzleHandler;
            random.Click += RandomHandler;
            LoadPuzzle.Click += LoadPuzzleHandler;
            ChoosePuzle.Click += ChoosePuzzleHandler;

            CreateLayoutPanel(LayoutPanelPoint);

            CreateButtons();

            DrawWinSeq();

            CreateLebels(LayoutPanelPoint);

        }

        private void CreateLayoutPanel(Point CentrePoint)
        {
            Controls.RemoveByKey("congratulation");
            Controls.Remove(groupBox);
            Controls.RemoveByKey("TableLayoutPanel");

            Point LayoutPanelPoint = new Point(CentrePoint.X - (30 * m) / 2, CentrePoint.Y - (30 * n) / 2);

            LayoutPanel = new TableLayoutPanel();
            LayoutPanel.Tag = LayoutPanelPoint;
            LayoutPanel.Location = LayoutPanelPoint;
            LayoutPanel.Name = "TableLayoutPanel";
            LayoutPanel.Size = new Size(30 * m, 30 * n);
            LayoutPanel.ColumnCount = m;
            LayoutPanel.RowCount = n;
            Controls.Add(LayoutPanel);

            for (int i = 0; i < m; i++)
            {
                LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            }
            for (int j = 0; j < n; j++)
            {
                LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            }
            fieldstat = new FieldStat[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    fieldstat[i, j] = FieldStat.Unpainted;
                }
            }
        }
        private void CreateButtons()
        {
            buttons = new Button[n, m];
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    Button tmp = new Button();
                    tmp.BackColor = Color.White;


                    int x = i * CELLSIZ + j;
                    tmp.Tag = x;
                    tmp.MouseDown += ButtonClick;
                    tmp.Paint += DrowCross;
                    tmp.FlatAppearance.BorderColor = Color.Black;
                    tmp.FlatStyle = FlatStyle.Flat;
                    tmp.Margin = new Padding(0, 0, 0, 0);
                    tmp.TabStop = false;
                    tmp.Dock = DockStyle.Fill;
                    LayoutPanel.Controls.Add(tmp, j, i);

                    buttons[i, j] = tmp;
                }
            }
        }
        private void CreateLebels(Point CentrePoint)
        {
            if (labels != null) for (int i = 0; i < labels.Length; i++) Controls.Remove(labels[i]);

            Point LayoutPanelPoint = new Point(CentrePoint.X - (30 * m) / 2, CentrePoint.Y - (30 * n) / 2);
            FieldStat[,] Stats;
            if (gameMode == GameMode.PlayMode)
            {
                win = false;
                Stats = WinSeq;
            }
            else Stats = fieldstat;
            labels = new Label[n + m];
            int ind = 0;
            string text = "";
            for (int i = 0; i < n; i++)
            {
                ind = 0;
                text = "";
                for (int j = 0; j < m; j++)
                {
                    if (Stats[i, j] == FieldStat.Filled)
                    {
                        ind++;
                    }
                    else
                    {
                        if (ind != 0)
                        {
                            text = text + " " + ind.ToString();
                            ind = 0;
                        }
                    }
                }
                if (ind != 0)
                {
                    text = text + " " + ind.ToString();
                    ind = 0;
                }
                Label lab = new Label();
                if (text.Length == 0) text = "0";
                lab.Text = text;
                lab.TextAlign = ContentAlignment.MiddleRight;
                lab.Location = new Point(LayoutPanelPoint.X - lab.PreferredWidth, LayoutPanelPoint.Y + CELLSIZ * i);
                lab.BackColor = Color.Transparent;
                lab.Size = new Size(lab.PreferredWidth, CELLSIZ);
                labels[i] = lab;
                this.Controls.Add(lab);
            }
            for (int j = 0; j < m; j++)
            {
                ind = 0;
                text = "";
                for (int i = 0; i < n; i++)
                {
                    if (Stats[i, j] == FieldStat.Filled)
                    {
                        ind++;
                    }
                    else
                    {
                        if (ind != 0)
                        {
                            text = text + '\n' + ind.ToString();
                            ind = 0;
                        }
                    }
                }
                if (ind != 0)
                {
                    text = text + '\n' + ind.ToString();
                    ind = 0;
                }
                Label mylab = new Label();
                if (text.Length == 0) text = "0";
                mylab.Text = text;
                mylab.Location = new Point(LayoutPanelPoint.X + j * CELLSIZ, LayoutPanelPoint.Y - mylab.PreferredHeight);
                mylab.BackColor = Color.Transparent;
                mylab.Size = new Size(CELLSIZ, mylab.PreferredHeight);
                mylab.TextAlign = ContentAlignment.BottomCenter;
                labels[n + j] = mylab;

                Controls.Add(mylab);
            }
        }
        private void DrawWinSeq()
        {
            WinSeq = new FieldStat[n, m];
            Random rd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (rd.Next(0, 3) == 0)
                    {
                        WinSeq[i, j] = FieldStat.Unpainted;
                    }
                    else
                    {
                        WinSeq[i, j] = FieldStat.Filled;
                    }
                }
            }
        }

        private void ButtonClick(object sender, MouseEventArgs e)
        {
            int x = (int)((Button)sender).Tag;
            int i = x / CELLSIZ, j = x % CELLSIZ;
            Button bt = (Button)sender;
            bool ex = false;


            if (gameMode == GameMode.PlayMode)
            {
                if (win == false)
                {
                    UpdateFieldStat(i, j, bt, e);
                    win = true;
                    for (i = 0; i < n; i++)
                    {
                        for (j = 0; j < m; j++)
                        {
                            if (WinSeq[i, j] == FieldStat.Filled && fieldstat[i, j] != FieldStat.Filled)
                            {
                                win = false;
                                break;
                            }
                        }
                        if (win == false) break;
                    }
                    if (win == true)
                    {
                        Label WinLab = new Label();
                        WinLab.Name = "congratulation";
                        WinLab.Text = "Congratulation!";
                        WinLab.Font = new Font("Arial", 30, FontStyle.Regular);
                        WinLab.TextAlign = ContentAlignment.MiddleCenter;
                        WinLab.Location = new Point((ClientSize.Width - WinLab.PreferredWidth) / 2, ClientSize.Height - WinLab.PreferredHeight);
                        WinLab.BackColor = Color.Transparent;
                        WinLab.Size = new Size(WinLab.PreferredWidth, WinLab.PreferredHeight);

                        Controls.Add(WinLab);
                    }
                }
            }
            else
            {
                UpdateFieldStat(i, j, bt, e);
                Point LayoutLocation = (Point)LayoutPanel.Tag;
                UpdateLabels(i, j, LayoutLocation);
            }
        }



        private void UpdateLabels(int I, int J, Point PanelLocation)
        {
            int ind = 0;
            string text = "";
            for (int j = 0; j < m; j++)
            {
                if (fieldstat[I, j] == FieldStat.Filled)
                {
                    ind++;
                }
                else
                {
                    if (ind != 0)
                    {
                        text = text + " " + ind.ToString();
                        ind = 0;
                    }
                }
            }
            if (ind != 0)
            {
                text = text + " " + ind.ToString();
                ind = 0;
            }
            Label lab = new Label();
            lab.Text = text;
            lab.TextAlign = ContentAlignment.MiddleRight;
            lab.Location = new Point(PanelLocation.X - lab.PreferredWidth, PanelLocation.Y + CELLSIZ * I);
            lab.BackColor = Color.Transparent;
            lab.Size = new Size(lab.PreferredWidth, CELLSIZ);
            this.Controls.Remove(labels[I]);
            labels[I] = lab;
            this.Controls.Add(lab);

            ind = 0;
            text = "";
            for (int i = 0; i < n; i++)
            {
                if (fieldstat[i, J] == FieldStat.Filled)
                {
                    ind++;
                }
                else
                {
                    if (ind != 0)
                    {
                        text = text + '\n' + ind.ToString();
                        ind = 0;
                    }
                }
            }
            if (ind != 0)
            {
                text = text + '\n' + ind.ToString();
                ind = 0;
            }
            Label mylab = new Label();
            mylab.Text = text;
            mylab.Location = new Point(PanelLocation.X + J * CELLSIZ, PanelLocation.Y - mylab.PreferredHeight);
            mylab.BackColor = Color.Transparent;
            mylab.Size = new Size(CELLSIZ, mylab.PreferredHeight);
            mylab.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Remove(labels[n + J]);
            labels[n + J] = mylab;
            Controls.Add(mylab);
        }
        private void UpdateFieldStat(int i, int j, Button bt, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (fieldstat[i, j] == FieldStat.Filled)
                {
                    fieldstat[i, j] = FieldStat.Unpainted;
                    bt.BackColor = Color.White;
                }
                else
                {
                    fieldstat[i, j] = FieldStat.Filled;
                    bt.BackColor = Color.Black;
                }

            }
            else if (e.Button == MouseButtons.Right)
            {
                if (fieldstat[i, j] == FieldStat.Filled)
                {
                    fieldstat[i, j] = FieldStat.Crossed;
                    bt.BackColor = Color.White;
                }

                else if (fieldstat[i, j] == FieldStat.Unpainted)
                    fieldstat[i, j] = FieldStat.Crossed;

                else if (fieldstat[i, j] == FieldStat.Crossed)
                    fieldstat[i, j] = FieldStat.Unpainted;
            }
            bt.Invalidate();
        }

        TextBox title, diff;


        private void CreatePuzzleHandler(object sender, EventArgs e)
        {
            ChoosePuzzleSize chooseSize = new ChoosePuzzleSize();
            chooseSize.width = m;
            chooseSize.height = n;
            chooseSize.ShowDialog();
            int height = chooseSize.height, width = chooseSize.width;
            if (height == 0) return;
            Controls.RemoveByKey("TableLayoutPanel");
            for (int i = 0; i < n + m; i++) Controls.Remove(labels[i]);
            n = height;
            m = width;
            gameMode = GameMode.CreateMode;
            fieldstat = new FieldStat[n, m];
            Point Pos = new Point(this.Width - 10 * CELLSIZ, this.Height - 11 * CELLSIZ);

            CreateLayoutPanel(Pos);
            CreateButtons();
            CreateLebels(Pos);

            groupBox = new GroupBox();
            groupBox.Text = "Puzzle Settings";
            groupBox.Size = new Size(275, 150);
            groupBox.Location = new Point(30, 60);

            Label puzzletitle = new Label();
            puzzletitle.Text = "Puzzle Title";
            puzzletitle.Size = new Size(puzzletitle.PreferredWidth, puzzletitle.PreferredHeight);
            puzzletitle.Location = new Point(10, 30);
            groupBox.Controls.Add(puzzletitle);

            title = new TextBox();
            title.Size = new Size(130, 27);
            title.Location = new Point(140, 30);
            groupBox.Controls.Add(title);

            Label difficulty = new Label();
            difficulty.Text = "Dificulty";
            difficulty.Size = new Size(difficulty.PreferredWidth, difficulty.PreferredHeight);
            difficulty.Location = new Point(10, 70);
            groupBox.Controls.Add(difficulty);

            diff = new TextBox();
            diff.Size = new Size(130, 27);
            diff.Location = new Point(140, 70);
            groupBox.Controls.Add(diff);

            Button save = new Button();
            save.Size = new Size(95, 30);
            save.Location = new Point(175, 115);
            save.Text = "Save";
            save.Click += SaveButtonClick;
            groupBox.Controls.Add(save);

            Controls.Add(groupBox);
        }
        private void SaveButtonClick(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "XML files (*.xml)|*.xml";

            saveFile.RestoreDirectory = true;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                // xml serialization of array of points
                SerializePuzzleClass serializePuzzle = new SerializePuzzleClass();
                serializePuzzle.Difficulty = diff.Text;
                serializePuzzle.Height = n;
                serializePuzzle.Width = m;
                serializePuzzle.Title = title.Text;
                serializePuzzle.wseq = new int[n][];
                List<int> list = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    list.Clear();
                    for (int j = 0; j < m; j++)
                    {
                        if (fieldstat[i, j] == FieldStat.Filled) list.Add(j);
                    }
                    serializePuzzle.wseq[i] = list.ToArray();
                }
                var fs = new FileStream(saveFile.FileName, FileMode.Create);
                XmlSerializer xs = new XmlSerializer(typeof(SerializePuzzleClass));
                xs.Serialize(fs, serializePuzzle);
                fs.Close();


            }

        }
        private void RandomHandler(object sender, EventArgs e)
        {
            ChoosePuzzleSize chooseSize = new ChoosePuzzleSize();
            chooseSize.Text = "New Random Puzzle";
            chooseSize.width = m;
            chooseSize.height = n;
            chooseSize.ShowDialog();
            int height = chooseSize.height, width = chooseSize.width;
            if (height == 0) return;


            n = height;
            m = width;
            gameMode = GameMode.PlayMode;
            fieldstat = new FieldStat[n, m];
            Point Pos = new Point(this.Width / 2, this.Height / 2);

            DrawWinSeq();
            CreateLayoutPanel(Pos);
            CreateButtons();
            CreateLebels(Pos);
        }
        private void LoadPuzzleHandler(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML files (*.xml)|*.xml";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open);
                XmlSerializer xs = new XmlSerializer(typeof(SerializePuzzleClass));
                SerializePuzzleClass spc = (SerializePuzzleClass)xs.Deserialize(fs);
                fs.Close();
                gameMode = GameMode.PlayMode;
                n = spc.Height;
                m = spc.Width;
                WinSeq = new FieldStat[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < spc.wseq[i].Length; j++)
                    {
                        WinSeq[i, spc.wseq[i][j]] = FieldStat.Filled;
                    }
                }
                Point centre = new Point(this.Width / 2, this.Height / 2);
                CreateLayoutPanel(centre);
                CreateButtons();
                CreateLebels(centre);

            }
        }
        private void ChoosePuzzleHandler(object sender, EventArgs e)
        {
            ChoosePuzzle chPuzzle = new ChoosePuzzle();
            DialogResult result = chPuzzle.ShowDialog();
            if (result == DialogResult.OK)
            {
                SerializePuzzleClass spc = chPuzzle.selectedPuzzle;
                gameMode = GameMode.PlayMode;

                n = spc.Height;
                m = spc.Width;
                WinSeq = new FieldStat[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < spc.wseq[i].Length; j++)
                    {
                        WinSeq[i, spc.wseq[i][j]] = FieldStat.Filled;
                    }
                }
                Point centre = new Point(this.Width / 2, this.Height / 2);
                CreateLayoutPanel(centre);
                CreateButtons();
                CreateLebels(centre);
            }
        }

        private void DrowCross(object sender, PaintEventArgs e)
        {
            int x = (int)((Button)sender).Tag;
            int i = x / CELLSIZ, j = x % CELLSIZ;
            if (fieldstat[i, j] == FieldStat.Crossed)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 3), 5, 5, CELLSIZ - 5, CELLSIZ - 5);

                e.Graphics.DrawLine(new Pen(Color.Black, 3), 5, CELLSIZ - 5, CELLSIZ - 5, 5);
            }
        }
    }
    public class SerializePuzzleClass
    {
        public string Title;
        public int Width;
        public int Height;
        public string Difficulty;
        public int[][] wseq;
    }
    public enum FieldStat { Unpainted, Filled, Crossed };
    
}
