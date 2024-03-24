using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guessTheNumber
{
    public partial class Menu : Form
    {
        // Flag to indicate whether the game needs to be opened
        public bool NeedsToOpenGame { get; private set; }

        // Selected difficulty level
        public string SelectedDifficulty { get; private set; }

        public Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void openGameButton()
        {
            NeedsToOpenGame = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = null;

            foreach (Control control in this.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Checked)
                    {
                        selectedRadioButton = radioButton;
                        break;
                    }
                }
            }

            if (selectedRadioButton == null)
            {
                MessageBox.Show("Избери трудност.");
            }
            else
            {
                SelectedDifficulty = selectedRadioButton.Text;
                openGameButton();
                MessageBox.Show(selectedRadioButton.Text);
            }
        }

        // Property to indicate whether the form was closed by the user
        public bool ClosedByUser { get; private set; }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // Check if the form was closed by the user
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ClosedByUser = true;
            }
        }
    }
}
