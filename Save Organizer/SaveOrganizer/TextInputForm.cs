using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveOrganizer
{
    public partial class TextInputForm : Form
    {
        public string InputText
        {
            get
            {
                return InputTextBox.Text;
            }
            set
            {
                InputTextBox.Text = value;
            }
        }

        public TextInputForm()
        {
            InitializeComponent();
        }

        public TextInputForm(string title) : this()
        {
            this.Text = title;
        }

        public TextInputForm(string title, string promptText) : this(title)
        {
            TitleLabel.Text = promptText;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
