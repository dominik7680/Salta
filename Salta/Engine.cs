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
		public ArrayList findValidmoves(Point currentSelect, ObservableCollection<SaltaPiece> Pieces)
		{
			ArrayList validMoves = new ArrayList();
			var currentSelectedPiece = Pieces.Where(z => z.Pos.X == currentSelect.X && z.Pos.Y == currentSelect.Y).FirstOrDefault();

			if (currentSelectedPiece.Player == Player.Green)
			{
				//jezeli na polu obok stoi pionek przeciwnika wlasciwym ruchem jest przeskoczenie go - Salta!
				if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault() != null)
				{
					Point valid = new Point(currentSelectedPiece.Pos.X - 2, currentSelectedPiece.Pos.Y - 2);
					if(valid.X>=0 && valid.X<10 && valid.Y > 0)
                    {
						validMoves.Add(valid);
					}
				}
				else if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault() != null)
				{
					Point valid = new Point(currentSelectedPiece.Pos.X + 2, currentSelectedPiece.Pos.Y - 2);
					if (valid.X >= 0 && valid.X < 10 && valid.Y > 0)
					{
						validMoves.Add(valid);
					}
				}
				else
				{
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault() == null)
					{
						Point valid = new Point(currentSelectedPiece.Pos.X - 1, currentSelectedPiece.Pos.Y - 1);
						if (valid.X >= 0 && valid.X < 10 && valid.Y > 0)
						{
							validMoves.Add(valid);
						}
					}
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault() == null)
					{
						Point valid = new Point(currentSelectedPiece.Pos.X + 1, currentSelectedPiece.Pos.Y - 1);
						if (valid.X >= 0 && valid.X < 10 && valid.Y > 0)
						{
							validMoves.Add(valid);
						}
					}
				}
				Console.WriteLine("----------");
			}
			else if (currentSelectedPiece.Player == Player.Red)
			{
				if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault() != null)
				{
					Point valid = new Point(currentSelectedPiece.Pos.X + 2, currentSelectedPiece.Pos.Y + 2);
					if (valid.X >= 0 && valid.X < 10 && valid.Y < 10)
					{
						validMoves.Add(valid);
					}
				}
				else if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault() != null)
				{
					Point valid = new Point(currentSelectedPiece.Pos.X - 2, currentSelectedPiece.Pos.Y + 2);
					if (valid.X >= 0 && valid.X < 10 && valid.Y < 10)
					{
						validMoves.Add(valid);
					}
				}
				else
				{
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault() == null)
					{
						Point valid = new Point(currentSelectedPiece.Pos.X + 1, currentSelectedPiece.Pos.Y + 1);
						if (valid.X >= 0 && valid.X < 10 && valid.Y < 10)
						{
							validMoves.Add(valid);
						}
					}
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault() == null)
					{
						Point valid = new Point(currentSelectedPiece.Pos.X - 1, currentSelectedPiece.Pos.Y + 1);
						if (valid.X >= 0 && valid.X < 10 && valid.Y < 10)
						{
							validMoves.Add(valid);
						}
					}
				}
				Console.WriteLine("----------");
			}
			return validMoves;
		}
	}
}
