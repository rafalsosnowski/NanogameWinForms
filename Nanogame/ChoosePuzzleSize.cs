using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pigelab
{
    public partial class ChoosePuzzleSize : Form
    {
        public int height { set; get; }
        public int width { set; get; }
        public ChoosePuzzleSize()
        {

            InitializeComponent();
        }

        private void ChoosePuzzleSize_Load(object sender, EventArgs e)
        {
            HeighttextBox.Text = height.ToString();
            WidthtextBox.Text = width.ToString();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            height = 0;
            width = 0;
            Close();
        }
        private void Ok_Click(object sender, EventArgs e)
        {           
            if(ValidateChildren())
            {
                height = int.Parse(HeighttextBox.Text);
                width = int.Parse(WidthtextBox.Text);
                Close();
            }         
            
        }

        private void WidthtextBox_Validating(object sender, CancelEventArgs e)
        {
            int w;
            if (!int.TryParse(WidthtextBox.Text,out w) ||w <2 || w > 15)
            {
                 errorProvider1.SetError(WidthtextBox,
                 "Width must be integer number in range 2-15");
                 e.Cancel = true;
                 return;
            }
             errorProvider1.SetError(WidthtextBox, string.Empty);
             e.Cancel = false;
        }

        private void HeighttextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void HeighttextBox_Validating(object sender, CancelEventArgs e)
        {
            int w;
            if (!int.TryParse(HeighttextBox.Text, out w) || w < 2 || w > 15)
            {
                errorProvider1.SetError(HeighttextBox,
                "Width must be integer number in range 2-15");
                e.Cancel = true;
                return;
            }
            errorProvider1.SetError(HeighttextBox, string.Empty);
            e.Cancel = false;
        }
    }
}
