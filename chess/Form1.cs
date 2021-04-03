using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    public partial class Form1 : Form {
        ChessBoard chessBoard = new ChessBoard();
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            foreach (PictureBox element in chessBoard.cells) {
                Controls.Add(element);
            }
            Controls.Add(chessBoard.board);
            foreach (Label element in chessBoard.labels)
            {
                Controls.Add(element);
                element.BringToFront();
            }
            Width = chessBoard.board.Width + Size.Width - ClientSize.Width;
            Height = chessBoard.board.Height + Size.Height - ClientSize.Height;
            MinimumSize = new Size(Width, Height);

        }
    }

    public class ChessBoard {
        PictureBox place = new PictureBox();
        public List<Label> labels = new List<Label>();
        public List<PictureBox> cells = new List<PictureBox>();
        public PictureBox board = new PictureBox();
        string[] name = { "A", "B", "C", "D", "E", "F", "J", "H" };
        int step = 70;
        int boardSize = 30;

        public ChessBoard() {
            bool isWhiteCell = true;

            board.BackColor = Color.FromArgb(208, 203, 199);
            board.Size = new Size(step * 8 + boardSize * 2, step * 8 + boardSize * 2);
            board.Location = new Point(0, 0);

            place.Size = new Size(step * 8, step * 8);            
            place.Location = new Point(board.Location.X + boardSize, board.Location.Y + boardSize);
            
            for (int i = 0; i < 8; i++) {

                Label horisontalLabel = new Label();
                horisontalLabel.Size = new Size(step, boardSize);
                horisontalLabel.Location = new Point(board.Location.X + boardSize + i * step, board.Location.Y);
                horisontalLabel.Text = name[i];
                horisontalLabel.TextAlign = ContentAlignment.MiddleCenter;
                horisontalLabel.BackColor = Color.FromArgb(208, 203, 199);
                Label verticalLabel = new Label();
                verticalLabel.Size = new Size(boardSize, step);
                verticalLabel.Location = new Point(board.Location.X, board.Location.Y + boardSize + i * step);
                verticalLabel.Text = (i + 1).ToString();
                verticalLabel.TextAlign = ContentAlignment.MiddleCenter;
                verticalLabel.BackColor = Color.FromArgb(208, 203, 199);

                labels.Add(horisontalLabel);
                labels.Add(verticalLabel);

                if (i % 2 == 0) isWhiteCell = true;
                else isWhiteCell = false;
                
                for (int j = 0; j < 8; j++) {                    
                    PictureBox cell = new PictureBox();
                    cells.Add(cell);

                    if (isWhiteCell) {
                        cell.BackColor = Color.White;
                        isWhiteCell = false;
                    } else {
                        cell.BackColor = Color.Black;
                        isWhiteCell = true;
                    }

                    cell.Size = new Size(step, step);
                    cell.Location = new Point(place.Location.X + j * step, place.Location.Y + i * step);
                    cell.Name = name[j] + (i + 1).ToString();
                }
            }

        }

    }
}
