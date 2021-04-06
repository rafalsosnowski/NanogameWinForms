
namespace pigelab
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.NewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.random = new System.Windows.Forms.ToolStripMenuItem();
            this.ChoosePuzle = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPuzzle = new System.Windows.Forms.ToolStripMenuItem();
            this.Create = new System.Windows.Forms.ToolStripMenuItem();
            this.CreatePuzzle = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGame,
            this.Create});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // NewGame
            // 
            this.NewGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.random,
            this.ChoosePuzle,
            this.LoadPuzzle});
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(96, 24);
            this.NewGame.Text = "New Game";
            // 
            // random
            // 
            this.random.Name = "random";
            this.random.Size = new System.Drawing.Size(197, 26);
            this.random.Text = "Random";
            // 
            // ChoosePuzle
            // 
            this.ChoosePuzle.Name = "ChoosePuzle";
            this.ChoosePuzle.Size = new System.Drawing.Size(197, 26);
            this.ChoosePuzle.Text = "Choose puzzle...";
            // 
            // LoadPuzzle
            // 
            this.LoadPuzzle.Name = "LoadPuzzle";
            this.LoadPuzzle.Size = new System.Drawing.Size(197, 26);
            this.LoadPuzzle.Text = "Load puzzle";
            // 
            // Create
            // 
            this.Create.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreatePuzzle});
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(75, 24);
            this.Create.Text = "Create...";
            // 
            // CreatePuzzle
            // 
            this.CreatePuzzle.Name = "CreatePuzzle";
            this.CreatePuzzle.Size = new System.Drawing.Size(182, 26);
            this.CreatePuzzle.Text = "Create puzzle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nomogram";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem NewGame;
        private System.Windows.Forms.ToolStripMenuItem ChoosePuzzle;
        private System.Windows.Forms.ToolStripMenuItem Create;
        private System.Windows.Forms.ToolStripMenuItem CreatePuzzle;
        private System.Windows.Forms.ToolStripMenuItem random;
        private System.Windows.Forms.ToolStripMenuItem ChoosePuzle;
        private System.Windows.Forms.ToolStripMenuItem LoadPuzzle;
    }
}

