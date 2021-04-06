
namespace pigelab
{
    partial class ChoosePuzzle
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ChooseDirectory = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Title = new System.Windows.Forms.ColumnHeader();
            this.Width = new System.Windows.Forms.ColumnHeader();
            this.Height = new System.Windows.Forms.ColumnHeader();
            this.Difficulty = new System.Windows.Forms.ColumnHeader();
            this.Refresh = new System.Windows.Forms.Button();
            this.loadPuzzle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(495, 27);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ChooseDirectory
            // 
            this.ChooseDirectory.Location = new System.Drawing.Point(513, 12);
            this.ChooseDirectory.Name = "ChooseDirectory";
            this.ChooseDirectory.Size = new System.Drawing.Size(162, 29);
            this.ChooseDirectory.TabIndex = 1;
            this.ChooseDirectory.Text = "Choose directory";
            this.ChooseDirectory.UseVisualStyleBackColor = true;
            this.ChooseDirectory.Click += new System.EventHandler(this.ChooseDirectory_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Width,
            this.Height,
            this.Difficulty});
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.listView1.Location = new System.Drawing.Point(12, 63);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(663, 304);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 300;
            // 
            // Width
            // 
            this.Width.Text = "Width";
            this.Width.Width = 100;
            // 
            // Height
            // 
            this.Height.Text = "Height";
            this.Height.Width = 100;
            // 
            // Difficulty
            // 
            this.Difficulty.Text = "Difficulty";
            this.Difficulty.Width = 100;
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(12, 394);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(94, 29);
            this.Refresh.TabIndex = 3;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // loadPuzzle
            // 
            this.loadPuzzle.Location = new System.Drawing.Point(558, 394);
            this.loadPuzzle.Name = "loadPuzzle";
            this.loadPuzzle.Size = new System.Drawing.Size(117, 29);
            this.loadPuzzle.TabIndex = 4;
            this.loadPuzzle.Text = "Load Puzzle";
            this.loadPuzzle.UseVisualStyleBackColor = true;
            this.loadPuzzle.Click += new System.EventHandler(this.loadPuzzle_Click);
            // 
            // ChoosePuzzle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 450);
            this.Controls.Add(this.loadPuzzle);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ChooseDirectory);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChoosePuzzle";
            this.RightToLeftLayout = true;
            this.Text = "Choose one of the puzzzles";
            this.Load += new System.EventHandler(this.ChoosePuzzle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ChooseDirectory;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Width;
        private System.Windows.Forms.ColumnHeader Height;
        private System.Windows.Forms.ColumnHeader Difficulty;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button loadPuzzle;
    }
}