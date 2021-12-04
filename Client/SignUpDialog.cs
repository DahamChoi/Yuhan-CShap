using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SignUpDialog : Form
    {
        public SignUpDialog()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            string packet = $"SignUp;{IdTextBox.Text};{PasswordTextBox.Text};{NickNameTextBox.Text};<EOF>";
            AsynchronousClient.Send(AsynchronousClient.GetSocket(), packet);

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
