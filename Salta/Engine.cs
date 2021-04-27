using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salta
{
    class Engine
    {
		public void checkMove(Point currentSelect, ObservableCollection<SaltaPiece> Pieces)
		{
			var currentSelectedPiece = Pieces.Where(z => z.Pos.X == currentSelect.X && z.Pos.Y == currentSelect.Y).FirstOrDefault();

			if (currentSelectedPiece.Player == Player.Green)
			{
				//jezeli na polu obok stoi pionek przeciwnika wlasciwym ruchem jest przeskoczenie go - Salta!
				if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault() != null)
				{
					Console.WriteLine("valid move: " + (currentSelectedPiece.Pos.X - 2) + "," + (currentSelectedPiece.Pos.Y - 2));
				}
				else if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault() != null)
				{
					Console.WriteLine("valid move: " + (currentSelectedPiece.Pos.X + 2) + "," + (currentSelectedPiece.Pos.Y - 2));
				}
				else
				{
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault() == null)
					{
						Console.WriteLine("valid move: " + (currentSelectedPiece.Pos.X - 1) + "," + (currentSelectedPiece.Pos.Y - 1));
					}
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y - 1).FirstOrDefault() == null)
					{
						Console.WriteLine("valid move: " + (currentSelectedPiece.Pos.X + 1) + "," + (currentSelectedPiece.Pos.Y - 1));
					}
				}
				Console.WriteLine("----------");
			}

			if (currentSelectedPiece.Player == Player.Red)
			{
				if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault() != null)
				{
					Console.WriteLine("valid move: " + (currentSelectedPiece.Pos.X + 2) + "," + (currentSelectedPiece.Pos.Y + 2));
				}
				else if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault() != null)
				{
					Console.WriteLine("valid move: " + (currentSelectedPiece.Pos.X - 2) + "," + (currentSelectedPiece.Pos.Y + 2));
				}
				else
				{
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X + 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault() == null)
					{
						Console.WriteLine("valid move: " + (currentSelectedPiece.Pos.X + 1) + "," + (currentSelectedPiece.Pos.Y + 1));
					}
					if (Pieces.Where(z => z.Pos.X == currentSelectedPiece.Pos.X - 1 && z.Pos.Y == currentSelectedPiece.Pos.Y + 1).FirstOrDefault() == null)
					{
						Console.WriteLine("valid move: " + (currentSelectedPiece.Pos.X - 1) + "," + (currentSelectedPiece.Pos.Y + 1));
					}
				}
				Console.WriteLine("----------");
			}
		}
	}
}
