/*
 * Puprpose: Create 2 Player Tic Tac Toe Game
 * Revision History: Rutvi Mistry, 2023/09/26: Created
 */
namespace RMistryAssignment1
{
	public partial class Form1 : Form
	{
		// Variables to keep track of game state

		// Indicates if it's player X's turn
		private bool playerX = true;
		// Keeps track of the total moves in the game
		private int moves = 0;

		// Variables to store player scores
		private int playerXScore = 0;
		private int playerOScore = 0;

		// Variable to store images for X and O symbols (loaded through resources)
		Image xSymbol = RMistryAssignment1.Properties.Resources.X_symbol;
		Image oSymbol = RMistryAssignment1.Properties.Resources.download;


		public Form1()
		{
			InitializeComponent();

			// Initialize the game board when the form is created
			InitializeGame();
		}

		// Initializes the game board
		private void InitializeGame()
		{
			foreach (Control control in Controls)
			{
				if (control is PictureBox pictureBox)
				{
					// Clear all PictureBoxes on the form when form is created
					pictureBox.Image = null;
				}
			}

			// Set it to player X's turn when game start
			playerX = true;

			// Reset the moves count
			moves = 0;
		}

		// Event handler for when a PictureBox is clicked
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;

			// Check if the PictureBox is empty
			if (pictureBox.Image == null)
			{
				char currentPlayer = GetCurrentPlayer();

				// Set the PictureBox image based on the current player
				if (currentPlayer == 'X')
				{
					pictureBox.Image = xSymbol;
				}
				else
				{
					pictureBox.Image = oSymbol;
				}

				// Increment the moves count
				moves++;

				// Check if there is a winner or if it's a tie
				if (CheckForWinner())
				{
					// Show a message indicating the winner
					MessageBox.Show("Player " + currentPlayer + " wins!", "Game Over");

					// Update player scores
					UpdateScores(currentPlayer);

					// Restart the game
					InitializeGame();
				}
				else if (moves == 9)
				{
					// Show a message for a tie
					MessageBox.Show("It's a Tie!", "Game Over");

					//// Restart the game
					InitializeGame();
				}
			}
		}

		// Determine the current player based on the number of moves
		private char GetCurrentPlayer()
		{
			return (moves % 2 == 0) ? 'X' : 'O';
		}


		// Check if there is a winner on the game board
		private bool CheckForWinner()
		{
			// Create a 2D array to represent the game board
			PictureBox[,] board = new PictureBox[,]
			{
				{ pictureBox1, pictureBox2, pictureBox3 },
				{ pictureBox4, pictureBox5, pictureBox6 },
				{ pictureBox7, pictureBox8, pictureBox9 }
			};

			// Check rows, columns, and diagonals

			for (int i = 0; i < 3; i++)
			{
				// Check all rows
				if (board[i, 0].Image == board[i, 1].Image && board[i, 1].Image == board[i, 2].Image && board[i, 0].Image != null)
				{
					// A player has won
					return true;
				}

				// Check all columns
				if (board[0, i].Image == board[1, i].Image && board[1, i].Image == board[2, i].Image && board[0, i].Image != null)
				{
					// A player has won
					return true;
				}
			}

			// Check diagonaly (top-left to bottom-right)
			if (board[0, 0].Image == board[1, 1].Image && board[1, 1].Image == board[2, 2].Image && board[0, 0].Image != null)
			{
				// A player has won
				return true;
			}

			// Check diagonaly (top-right to bottom-left)
			if (board[0, 2].Image == board[1, 1].Image && board[1, 1].Image == board[2, 0].Image && board[0, 2].Image != null)
			{
				// A player has won
				return true;
			}

			// No winner yet
			return false;
		}

		// Update player scores and display them
		private void UpdateScores(char currentPlayer)
		{
			if (currentPlayer == 'X')
			{
				playerXScore++;

				// Display X's score
				lblPlayerXScore.Text = playerXScore.ToString();
			}
			else
			{
				playerOScore++;

				// Display O's score
				lblPlayerOScore.Text = playerOScore.ToString();
			}
		}

		// Event handler for the reset button
		private void btnReset_Click(object sender, EventArgs e)
		{
			// Restart the game
			InitializeGame();

			// Reset player X's score
			playerXScore = 0;

			// Reset player O's score
			playerOScore = 0;

			// Update the score display for both player X and 0
			lblPlayerXScore.Text = "0";
			lblPlayerOScore.Text = "0";
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}