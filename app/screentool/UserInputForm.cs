using System;
using System.Windows.Forms;

namespace screentool
{
    public partial class UserInputForm : Form
    {
        public string title { get; set; }
        public UserInputForm()
        {
            InitializeComponent();
            this.TopMost = true;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.title = this.userInputText.Text;
            this.Close();
        }
    }
}