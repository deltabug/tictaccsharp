using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        Player currentPlayer;

        public Form1()
        {
            InitializeComponent();
        }

        public enum Player
        {
            X,
            O
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.LightGreen;
            Check();
            AITIMER.Start();
        }

        private void resetGame(object sender, EventArgs e)
        {
            //label1.Text = “??”; — change the label text to double question mark.
            label1.Text = "??";

            //foreach (Control x in this.Controls) — starting a for each loop,
            //inside the brackets we set the condition for the loop as in what to check,
            //we are creating a Control variable called X in this controls meaning in this form.
            //This will loop through each component active in form for example buttons, labels,
            //text boxes, picture boxes
            foreach (Control x in this.Controls)
            {
                //if (x is Button && x.Tag == “play”) — this line is checking if X is a button
                //AND it has the tag of play. The reason we are doing this is because we
                //have 10 buttons on the screen, 1 for reset and 9 for the game.
                if (x is Button && x.Tag == "play")
                {
                    ((Button)x).Enabled = true;
                    ((Button)x).Text = "?";
                    ((Button)x).BackColor = default(Color);
                }
            }
        }

        private void playAI(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is Button && x.Text == "?" && x.Enabled)
                {
                    x.Enabled = false;
                    currentPlayer = Player.O;
                    x.Text = currentPlayer.ToString();
                    x.BackColor = System.Drawing.Color.LightYellow;
                    AITIMER.Stop();
                    Check();
                    break;
                }
                else
                {
                    AITIMER.Stop();
                }
            }
        }

        private void Check()
        {
            if (
                button1.Text == "X" && button2.Text == "X" && button3.Text == "X" ||
                button4.Text == "X" && button5.Text == "X" && button6.Text == "X" ||
                button7.Text == "X" && button8.Text == "X" && button9.Text == "X" ||
                button1.Text == "X" && button4.Text == "X" && button7.Text == "X" ||
                button2.Text == "X" && button5.Text == "X" && button8.Text == "X" ||
                button3.Text == "X" && button6.Text == "X" && button9.Text == "X" ||
                button1.Text == "X" && button5.Text == "X" && button9.Text == "X" ||
                button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
                )
            {
                WON();
                label1.Text = "X wins";
            }
            else if (
                button1.Text == "O" && button2.Text == "O" && button3.Text == "O" ||
                button4.Text == "O" && button5.Text == "O" && button6.Text == "O" ||
                button7.Text == "O" && button8.Text == "O" && button9.Text == "O" ||
                button1.Text == "O" && button4.Text == "O" && button7.Text == "O" ||
                button2.Text == "O" && button5.Text == "O" && button8.Text == "O" ||
                button3.Text == "O" && button6.Text == "O" && button9.Text == "O" ||
                button1.Text == "O" && button5.Text == "O" && button9.Text == "O" ||
                button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
                )
            {
                WON();
                label1.Text = "O Wins";
            }
        }
        private void WON()
        {
            foreach (Control x in this.Controls)
            {
                if (x is Button && x.Tag == "play")
                {
                    ((Button)x).Enabled = false;
                    ((Button)x).BackColor = default(Color);
                }
            }
        }
    }

}