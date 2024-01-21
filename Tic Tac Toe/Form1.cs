using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         public struct stGameStatus
        {
           public enWinner Winner;
           public bool GameOver;
           public enTurn PlayTurn;
           public byte PlayCount;
        };

        public enum enWinner {Player1=1, computer =2, draw =3, inProgress = 4};
        public enum enTurn { player1 = 1, computer =2};

        stGameStatus GameStatus;
       



        private void Form1_Load(object sender, EventArgs e)
        {
            GameStatus.PlayTurn = enTurn.player1;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.inProgress;
            GameStatus.PlayCount = 0;

            lblTurn.Text = GameStatus.PlayTurn.ToString();
            lblWinner.Text = GameStatus.Winner.ToString();
        }

        void ResetButton(ref Button btn)
        {
            btn.Text = "?";
            btn.ForeColor = Color.Black;
            btn.BackColor = Color.RosyBrown;
        }
        void RestartGame()
        {
            Form1_Load(this, EventArgs.Empty);

            ResetButton(ref button1);
            ResetButton(ref button2);
            ResetButton(ref button3);
            ResetButton(ref button4);
            ResetButton(ref button5);
            ResetButton(ref button6);
            ResetButton(ref button7);
            ResetButton(ref button8);
            ResetButton(ref button9);


        }

        bool CheckTheButtons(Button btn1, Button btn2, Button btn3)
        {

            if (btn1.Text == "X" && btn2.Text == "X" && btn3.Text == "X")
            {
                btn1.BackColor = Color.Wheat;
                btn2.BackColor = Color.Wheat;
                btn3.BackColor = Color.Wheat;

                return true;
            }
            if (btn1.Text == "O" && btn2.Text == "O" && btn3.Text == "O")
            {
                btn1.BackColor = Color.Wheat;
                btn2.BackColor = Color.Wheat;
                btn3.BackColor = Color.Wheat;
                return true;
            }
            return false;
        }


        bool CheckTheWinner()
        {
            if(CheckTheButtons(button1, button2, button3))
                return true;

            if (CheckTheButtons(button4, button5, button6))
                return true;

            if(CheckTheButtons(button7, button8, button9))
                return true;

            if(CheckTheButtons(button1, button4, button7))
                return true;

            if(CheckTheButtons(button2, button5, button8))
                return true;

            if(CheckTheButtons(button3, button6, button9))
                return true;

            if(CheckTheButtons(button1, button5, button9))
                return true;

            if (CheckTheButtons(button3, button5, button7))
                return true;
            return false;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (GameStatus.GameOver || GameStatus.PlayCount == 9)
            {
                MessageBox.Show("Restart the game!","Not Allowed");
                return;
            }
            
            if (((Button)sender).Text != "?")
            {
                MessageBox.Show("its clicked");
                return;
            }

            if (GameStatus.PlayTurn == enTurn.player1)
            {
                ((Button)sender).Text = "X";
                ((Button)sender).ForeColor = Color.Green;
                GameStatus.PlayCount++;
                GameStatus.PlayTurn = enTurn.computer;
                lblTurn.Text = GameStatus.PlayTurn.ToString(); 

            }
            else if (GameStatus.PlayTurn == enTurn.computer)
            {
                ((Button)sender).Text = "O";
                ((Button)sender).ForeColor = Color.Red;
                GameStatus.PlayCount++;
               
                GameStatus.PlayTurn = enTurn.player1;
                lblTurn.Text = GameStatus.PlayTurn.ToString();


            }


            if (CheckTheWinner())
            {
                if (GameStatus.PlayTurn == enTurn.player1)
                GameStatus.Winner = enWinner.computer;
                else
                    GameStatus.Winner = enWinner.Player1;

                lblWinner.Text = GameStatus.Winner.ToString();
                lblWinner.ForeColor = Color.Green;
                GameStatus.GameOver = true;
                lblTurn.Text = "Game Over";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
 
}
