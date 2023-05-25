using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame {
    public partial class Form1 : Form {
        // Use this Random object to choose random icons for the squares
        Random random = new Random();
        // Each of these letters is an interesting icon
        // in the Webdings font,
        // and each icon appears twice in this list
        List<string> icons = new List<string>()
        {
        "!" , "!", "N", "N", "," , ",", "K", "K",
        "b", "b", "v", "v", "w", "w", "z","z"
        };

        Label fristClciked, secondClick;

        public Form1() {
            InitializeComponent();
            AssignIconToSquares();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label1_Click_1(object sender, EventArgs e) {
            if (fristClciked != null && secondClick != null)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;

            if (clickedLabel.ForeColor == Color.Black)
                return;

            if (fristClciked == null) {
                fristClciked = clickedLabel;
                fristClciked.ForeColor = Color.Black;
                return;
            }

            secondClick = clickedLabel;
            secondClick.ForeColor = Color.Black;
            CheckForWinner();

            if (fristClciked.Text == secondClick.Text) {
                fristClciked = null;
                secondClick = null;
            }
            timer1.Start();
        }
        private void CheckForWinner() {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++) {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            MessageBox.Show("You matched all icons! Congrats!", "You Won!");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            timer1.Stop();

            if (fristClciked != null)
                fristClciked.ForeColor = fristClciked.BackColor;
            if (secondClick != null)
                secondClick.ForeColor = secondClick.BackColor;

            fristClciked = null;
            secondClick = null;
        }

        private void AssignIconToSquares() {
            Label label;
            int randomNumber;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++) {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];

                icons.RemoveAt(randomNumber);
            }
        }
    }
}
