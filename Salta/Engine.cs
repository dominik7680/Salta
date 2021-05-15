﻿using System;
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

		public Dictionary<SaltaPiece, List<Point>> allMoves(ObservableCollection<SaltaPiece> Pieces)
        {
			Dictionary<SaltaPiece, List<Point>> allMoves = new Dictionary<SaltaPiece, List<Point>>();

			foreach(SaltaPiece piece in Pieces)
            {
				if(piece.Player == Player.Green)
                {

                }
				else if(piece.Player == Player.Red)
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

		public Tuple<SaltaPiece, Point> chooseMove(Dictionary<SaltaPiece, List<Point>> allMoves)
        {
			Random rnd = new Random();
			int ranPieceNum = rnd.Next(0, allMoves.Count);
			SaltaPiece randomPiece = allMoves.Keys.ElementAt(ranPieceNum);

			int randomMove = rnd.Next(0, allMoves.Values.ElementAt(ranPieceNum).Count);

			Point move = new Point(allMoves.Values.ElementAt(ranPieceNum)[randomMove].X, allMoves.Values.ElementAt(ranPieceNum)[randomMove].Y);
			var tuple = new Tuple<SaltaPiece, Point>(randomPiece, move);
			return tuple;
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
					ObservableCollection<SaltaPiece> tempBoard = new ObservableCollection<SaltaPiece>(currentBoard);
					var pieceFromTempBoard = tempBoard.FirstOrDefault(x => x.Type == piece.Type);
					pieceFromTempBoard.Pos = move;
					boards.Add(tempBoard);
				}
			}

			return boards;
		}

		/// <summary>
		/// Minmax function
		/// </summary>
		/// <param name="saltaPieces">All salta pieces</param>
		/// <param name="depth">Depth of algorithm</param>
		/// <param name="max_player">Boolean value if we are maximizing or minimizing algorithm</param>
		public void minmax(ObservableCollection<SaltaPiece> saltaPieces, int depth, bool max_player)
        {
			if(depth == 0) // dodać warunek czy gra sie jeszcze toczy
            {
				//return evaluate();
            }

			if(max_player == true)
            {
				float maxEval = -100000;
				bool best_move = false;

				foreach(var move in this.allMoves(saltaPieces))
                {

                }
            }
            else
            {

            }
        }
	}
}
