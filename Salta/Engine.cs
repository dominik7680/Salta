using System;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salta
{
    class Engine
    {
		public List<Point> findValidmoves(Point currentSelect, ObservableCollection<SaltaPiece> Pieces)
		{
			List<Point> validMoves = new List<Point>();
			var currentSelectedPiece = Pieces.Where(z => z.Pos.X == currentSelect.X && z.Pos.Y == currentSelect.Y).FirstOrDefault();

			if (currentSelectedPiece.Player == Player.Green)
			{
				if(Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault() != null &&
					Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault().Player == Player.Red)
                {
					if(Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 2 && z.Pos.Y == currentSelectedPiece.Pos.Y - 2).FirstOrDefault() == null &&
						currentSelect.X - 2 >= 0 && currentSelect.Y - 2 >= 0)
                    {
						Point valid = new Point(currentSelectedPiece.Pos.X - 2, currentSelectedPiece.Pos.Y - 2);
						validMoves.Add(valid);
					}
                }
				else if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault() != null &&
							Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault().Player == Player.Red)
				{
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 2 && z.Pos.Y == currentSelectedPiece.Pos.Y - 2).FirstOrDefault() == null &&
						currentSelect.X + 2 < 10 && currentSelect.Y - 2 >= 0)
					{
						Point valid = new Point(currentSelectedPiece.Pos.X + 2, currentSelectedPiece.Pos.Y - 2);
						validMoves.Add(valid);
					}
				}
                else
                {
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault() == null &&
					currentSelect.X - 1 >= 0 && currentSelect.Y - 1 >= 0)
					{
						Point valid = new Point(currentSelectedPiece.Pos.X - 1, currentSelectedPiece.Pos.Y - 1);
						validMoves.Add(valid);
					}
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault() == null &&
						currentSelect.X + 1 < 10 && currentSelect.Y - 1 >= 0)
					{
						Point valid = new Point(currentSelectedPiece.Pos.X + 1, currentSelectedPiece.Pos.Y - 1);
						validMoves.Add(valid);
					}
				}
				
				Console.WriteLine("----------");
			}
			else if (currentSelectedPiece.Player == Player.Red)
			{
				if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault() != null &&
					Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault().Player == Player.Green)
				{
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 2 && z.Pos.Y == currentSelectedPiece.Pos.Y + 2).FirstOrDefault() == null &&
						currentSelect.X + 2 < 10 && currentSelect.Y + 2 <= 10)
					{
						Point valid = new Point(currentSelectedPiece.Pos.X + 2, currentSelectedPiece.Pos.Y + 2);
						validMoves.Add(valid);
					}
				}
				else if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault() != null &&
							Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault().Player == Player.Green)
				{
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 2 && z.Pos.Y == currentSelectedPiece.Pos.Y + 2).FirstOrDefault() == null &&
						currentSelect.X - 2 >= 0 && currentSelect.Y + 2 <= 10)
					{
						Point valid = new Point(currentSelectedPiece.Pos.X - 2, currentSelectedPiece.Pos.Y + 2);
						validMoves.Add(valid);
					}
				}
				else
				{
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault() == null &&
					currentSelect.X - 1 >= 0 && currentSelect.Y + 1 <= 10)
					{
						Point valid = new Point(currentSelectedPiece.Pos.X - 1, currentSelectedPiece.Pos.Y + 1);
						validMoves.Add(valid);
					}
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault() == null &&
						currentSelect.X + 1 < 10 && currentSelect.Y + 1 <= 10)
					{
						Point valid = new Point(currentSelectedPiece.Pos.X + 1, currentSelectedPiece.Pos.Y + 1);
						validMoves.Add(valid);
					}
				}
				Console.WriteLine("----------");
			}
			return validMoves;
		}

		public Dictionary<SaltaPiece, List<Point>> allMoves(ObservableCollection<SaltaPiece> Pieces, Player color)
        {
			Dictionary<SaltaPiece, List<Point>> allMoves = new Dictionary<SaltaPiece, List<Point>>();

			foreach(SaltaPiece piece in Pieces)
            {
				if(piece.Player == color)
                {
					List<Point> validMoves = new List<Point>();
					var currentSelect = new Point(piece.Pos.X, piece.Pos.Y);
					validMoves = this.findValidmoves(currentSelect, Pieces);

					if(validMoves.Count > 0)
                    {
						allMoves.Add(piece, validMoves);
					}
				}
            }

			return allMoves;
		}

		public List<ObservableCollection<SaltaPiece>> simulateMove(Dictionary<SaltaPiece, List<Point>> allMoves, ObservableCollection<SaltaPiece> currentBoard)
		{
			List<ObservableCollection<SaltaPiece>> boards = new List<ObservableCollection<SaltaPiece>>();

			for (int i = 0; i < allMoves.Keys.Count; i++)
            {
				SaltaPiece piece = allMoves.Keys.ElementAt(i);
				List<Point> pieceMoves = allMoves.Values.ElementAt(i);

				foreach(Point move in pieceMoves)
                {
					ObservableCollection<SaltaPiece> tempBoard = cloneBoard(currentBoard);
					var pieceFromTempBoard = tempBoard.FirstOrDefault(x => x.Type == piece.Type && x.Player == piece.Player);
					pieceFromTempBoard.Pos = move;

					boards.Add(tempBoard);
				}
			}

			return boards;
		}

		public float evaluate(ObservableCollection<SaltaPiece> board)
        {
			Random random = new Random();
			int rand = random.Next(-10, 10);

			return rand;
		}

		

		/// <summary>
		/// Minmax function
		/// </summary>
		/// <param name="saltaPieces">All salta pieces</param>
		/// <param name="depth">Depth of algorithm</param>
		/// <param name="max_player">Boolean value if we are maximizing or minimizing algorithm</param>
		public Tuple<float, ObservableCollection<SaltaPiece>> minmax(ObservableCollection<SaltaPiece> saltaPieces, int depth, bool max_player)
        {
			if(depth == 0) // dodać warunek czy gra sie jeszcze toczy
            {
				return new Tuple<float, ObservableCollection<SaltaPiece>>(evaluate(saltaPieces), saltaPieces);
            }

			if(max_player == true)
            {
				float maxEval = -10;
				ObservableCollection<SaltaPiece> best_board = new ObservableCollection<SaltaPiece>();

				Dictionary<SaltaPiece, List<Point>> allMovesBoard = this.allMoves(saltaPieces, Player.Red);
				List<ObservableCollection<SaltaPiece>> boards = this.simulateMove(allMovesBoard, saltaPieces);

				foreach (var board in boards)
                {
					float evaluation = minmax(board, depth - 1, false).Item1;
					maxEval = Math.Max(maxEval, evaluation);
					if (maxEval == evaluation)
						best_board = cloneBoard(board);
                }

				return new Tuple<float, ObservableCollection<SaltaPiece>>(maxEval, best_board);
            }
            else
            {
				float minEval = 10;
				ObservableCollection<SaltaPiece> best_board = new ObservableCollection<SaltaPiece>();

				Dictionary<SaltaPiece, List<Point>> allMovesBoard = this.allMoves(saltaPieces, Player.Green);
				List<ObservableCollection<SaltaPiece>> boards = this.simulateMove(allMovesBoard, saltaPieces);

				foreach (var board in boards)
				{
					float evaluation = minmax(board, depth - 1, true).Item1;
					minEval = Math.Min(minEval, evaluation);
                    if (minEval == evaluation)
                        best_board = cloneBoard(board);
				}

				return new Tuple<float, ObservableCollection<SaltaPiece>>(minEval, best_board);
			} 
        }

		private SaltaPiece clonePiece(SaltaPiece piece)
		{
			SaltaPiece newPiece = new SaltaPiece()
			{
				Type = piece.Type,
				Player = piece.Player,
				Pos = piece.Pos
			};
			return newPiece;
		}

		public ObservableCollection<SaltaPiece> cloneBoard(ObservableCollection<SaltaPiece> board)
		{
			ObservableCollection<SaltaPiece> newBoard = new ObservableCollection<SaltaPiece>();
			foreach (SaltaPiece piece in board)
			{
				newBoard.Add(clonePiece(piece));
			}
			return newBoard;
		}
	}
}
