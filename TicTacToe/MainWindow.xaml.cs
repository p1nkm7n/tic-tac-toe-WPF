using ControlzEx.Native;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Button = System.Windows.Controls.Button;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public const string O_SYMBOL = "O";
        public const string X_SYMBOL = "X";
        public static bool XTurn = true;

        public MainWindow()
        {
            InitializeComponent();
            WinnerTextBox.Text = "Current Turn : " + X_SYMBOL; 
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            DisableGame();

            Button pressedButton = (Button)sender;
            pressedButton.IsEnabled = false;

            if (XTurn)
            {
                pressedButton.Content = X_SYMBOL;
                WinnerTextBox.Text = "Current Turn : " + O_SYMBOL;
                XTurn = false;
            }
            else
            {
                pressedButton.Content = O_SYMBOL;
                WinnerTextBox.Text = "Current Turn : " + X_SYMBOL;
                XTurn = true;
            }

            if(CheckForWinner())
            {
                return;
            }

            EnableGame();
        }

        private void DisableGame()
        {
            GameGrid.IsEnabled = false;
        }

        private void EnableGame()
        {
            GameGrid.IsEnabled = true;
        }

        private bool CheckForWinner() 
        {
            var horizontal = CheckHorizontalWinner();
            if(horizontal.Item1)
            {
                WinnerTextBox.Text = "Player " + horizontal.Item2 + " Wins!!!";
                return true;
            }

            var vertical = CheckVerticalWinner();
            if (vertical.Item1)
            {
                WinnerTextBox.Text = "Player " + vertical.Item2 + " Wins!!!";
                return true;
            }

            var diagonal = CheckDiagonalWinner();
            if (diagonal.Item1)
            {
                WinnerTextBox.Text = "Player " + diagonal.Item2 + " Wins!!!";
                return true;
            }

            if (CheckForTie())
            {
                WinnerTextBox.Text = "It's a tie!!!";
                return true;
            }

            return false;
        }


        private Tuple<bool,string> CheckHorizontalWinner()
        {
            bool gameOver = false;
            string winner = string.Empty;

            if (!A1.Content.Equals("")
                && A1.Content.Equals(A2.Content)
                && A1.Content.Equals(A3.Content)
                && A2.Content.Equals(A3.Content)
                )
            {
                gameOver = true;
                winner = A1.Content.ToString();
            }
            else if (!B1.Content.Equals("")
                     && B1.Content.Equals(B2.Content)
                     && B1.Content.Equals(B3.Content)
                     && B2.Content.Equals(B3.Content)
                    )
            {
                gameOver = true;
                winner = B1.Content.ToString();
            }
            else if (!C1.Content.Equals("")
                     && C1.Content.Equals(C2.Content)
                     && C1.Content.Equals(C3.Content)
                     && C2.Content.Equals(C3.Content)
                     )
            {
                gameOver = true;
                winner = C1.Content.ToString();
            }

            return Tuple.Create(gameOver,winner);
        }

        private Tuple<bool, string> CheckVerticalWinner()
        {
            bool gameOver = false;
            string winner = string.Empty;

            if (!A1.Content.Equals("")
                && A1.Content.Equals(B1.Content)
                && A1.Content.Equals(C1.Content)
                && B1.Content.Equals(C1.Content)
                )
            {
                gameOver = true;
                winner = A1.Content.ToString();
            }
            else if (!A2.Content.Equals("")
                && A2.Content.Equals(B2.Content)
                && A2.Content.Equals(C2.Content)
                && B2.Content.Equals(C2.Content)
                    )
            {
                gameOver = true;
                winner = A2.Content.ToString();
            }
            else if (!A3.Content.Equals("")
                && A3.Content.Equals(B3.Content)
                && A3.Content.Equals(C3.Content)
                && B3.Content.Equals(C3.Content)
                    )
            {
                gameOver = true;
                winner = A3.Content.ToString();
            }

            return Tuple.Create(gameOver, winner);
        }

        private Tuple<bool,string> CheckDiagonalWinner()
        {
            bool gameOver = false;
            string winner = string.Empty;

            if (!A1.Content.Equals("")
                && A1.Content.Equals(B2.Content)
                && A1.Content.Equals(C3.Content)
                && B2.Content.Equals(C3.Content)
                )
            { 
                gameOver = true;
                winner = A1.Content.ToString();
            }
            else if (!C1.Content.Equals("")
                && C1.Content.Equals(B2.Content)
                && C1.Content.Equals(A3.Content)
                && B2.Content.Equals(A3.Content)
                    )
            {
                gameOver = true;
                winner = C1.Content.ToString();
            }

            return Tuple.Create(gameOver, winner);
        }

        private bool CheckForTie()
        {
            bool tie = false;
            if(!string.IsNullOrWhiteSpace(A1.Content.ToString()) 
                && !string.IsNullOrWhiteSpace(A2.Content.ToString())
                && !string.IsNullOrWhiteSpace(A3.Content.ToString())
                && !string.IsNullOrWhiteSpace(B1.Content.ToString())
                && !string.IsNullOrWhiteSpace(B2.Content.ToString())
                && !string.IsNullOrWhiteSpace(B3.Content.ToString())
                && !string.IsNullOrWhiteSpace(C1.Content.ToString())
                && !string.IsNullOrWhiteSpace(C2.Content.ToString())
                && !string.IsNullOrWhiteSpace(C3.Content.ToString())
                )
            {
                tie = true;
            }
            return tie;
        }

        private void ResetGame(object sender, RoutedEventArgs e)
        {
            DisableGame();

            WinnerTextBox.Text = "Current Turn : " + X_SYMBOL;
            XTurn = true;

            foreach (var child in GameGrid.Children)
            {
                var button = child as Button;
                button.IsEnabled = true;
                button.Content = string.Empty;
            }

            EnableGame();
        }
    }
}
