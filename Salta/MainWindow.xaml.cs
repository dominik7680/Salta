using GalaSoft.MvvmLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Salta
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private ObservableCollection<SaltaPiece> Pieces;
		private List<SaltaPiece> DestinationPositionsForPieces = new List<SaltaPiece>();
		private Point LastSelectedPosition = new Point(-1,-1);
		private Engine engine = new Engine();
		private SaltaPiece lastSelectedPiece;
		private SaltaPiece currentSelectedPiece;

		public MainWindow()
        {
			InitializeComponent();
			//this.engine.IsWinner = false;

			this.Pieces = new ObservableCollection<SaltaPiece>() {
				new SaltaPiece{Pos=new Point(0, 9), Type=PieceType.Star_1, Player=Player.Green},
                new SaltaPiece{Pos=new Point(2, 9), Type=PieceType.Star_2, Player=Player.Green},
                new SaltaPiece{Pos=new Point(4, 9), Type=PieceType.Star_3, Player=Player.Green},
                new SaltaPiece{Pos=new Point(6, 9), Type=PieceType.Star_4, Player=Player.Green},
                new SaltaPiece{Pos=new Point(8, 9), Type=PieceType.Star_5, Player=Player.Green},
				new SaltaPiece{Pos=new Point(1, 8), Type=PieceType.Moon_1, Player=Player.Green},
				new SaltaPiece{Pos=new Point(3, 8), Type=PieceType.Moon_2, Player=Player.Green},
				new SaltaPiece{Pos=new Point(5, 8), Type=PieceType.Moon_3, Player=Player.Green},
				new SaltaPiece{Pos=new Point(7, 8), Type=PieceType.Moon_4, Player=Player.Green},
				new SaltaPiece{Pos=new Point(9, 8), Type=PieceType.Moon_5, Player=Player.Green},
				new SaltaPiece{Pos=new Point(0, 7), Type=PieceType.Point_1, Player=Player.Green},
				new SaltaPiece{Pos=new Point(2, 7), Type=PieceType.Point_2, Player=Player.Green},
				new SaltaPiece{Pos=new Point(4, 7), Type=PieceType.Point_3, Player=Player.Green},
				new SaltaPiece{Pos=new Point(6, 7), Type=PieceType.Point_4, Player=Player.Green},
				new SaltaPiece{Pos=new Point(8, 7), Type=PieceType.Point_5, Player=Player.Green},
				
				new SaltaPiece{Pos=new Point(9, 0), Type=PieceType.Star_1, Player=Player.Red},
				new SaltaPiece{Pos=new Point(7, 0), Type=PieceType.Star_2, Player=Player.Red},
				new SaltaPiece{Pos=new Point(5, 0), Type=PieceType.Star_3, Player=Player.Red},
				new SaltaPiece{Pos=new Point(3, 0), Type=PieceType.Star_4, Player=Player.Red},
				new SaltaPiece{Pos=new Point(1, 0), Type=PieceType.Star_5, Player=Player.Red},
				new SaltaPiece{Pos=new Point(8, 1), Type=PieceType.Moon_1, Player=Player.Red},
				new SaltaPiece{Pos=new Point(6, 1), Type=PieceType.Moon_2, Player=Player.Red},
				new SaltaPiece{Pos=new Point(4, 1), Type=PieceType.Moon_3, Player=Player.Red},
				new SaltaPiece{Pos=new Point(2, 1), Type=PieceType.Moon_4, Player=Player.Red},
				new SaltaPiece{Pos=new Point(0, 1), Type=PieceType.Moon_5, Player=Player.Red},
				new SaltaPiece{Pos=new Point(9, 2), Type=PieceType.Point_1, Player=Player.Red},
				new SaltaPiece{Pos=new Point(7, 2), Type=PieceType.Point_2, Player=Player.Red},
				new SaltaPiece{Pos=new Point(5, 2), Type=PieceType.Point_3, Player=Player.Red},
				new SaltaPiece{Pos=new Point(3, 2), Type=PieceType.Point_4, Player=Player.Red},
				new SaltaPiece{Pos=new Point(1, 2), Type=PieceType.Point_5, Player=Player.Red},

				new SaltaPiece{Pos=new Point(-1, -1), Type=PieceType.Selection, Player=Player.Special},
			};
			CalculateDestinationPositions();

			// Temporary. Uncomment to show destination position in the beginning of the Game.
			//Pieces.Clear();
			//DestinationPositionsForPieces.ForEach(Pieces.Add);

			this.ChessBoard.ItemsSource = this.Pieces;
		}

        private void ChessBoard_MouseDown(object sender, MouseButtonEventArgs e)
        {
			Point p = Mouse.GetPosition(ChessBoard);
			int x = (int)p.X;
			int y = (int)p.Y;

			var currentSelect = new Point(x, y);
			this.lastSelectedPiece = Pieces.Where(z => z.Pos.X == LastSelectedPosition.X && z.Pos.Y == LastSelectedPosition.Y).FirstOrDefault();
			this.currentSelectedPiece = Pieces.Where(z => z.Pos.X == currentSelect.X && z.Pos.Y == currentSelect.Y).FirstOrDefault();
			if (lastSelectedPiece != null && currentSelectedPiece == null)
            {
				lastSelectedPiece.Pos = currentSelect;
				//var tuple = this.engine.chooseMove(this.engine.allMoves(Pieces, Player.Red));
				//var pieceToMove = Pieces.Where(point => point.Type == tuple.Item1.Type && point.Player == Player.Red).FirstOrDefault();
				//pieceToMove.Pos = tuple.Item2;
				ObservableCollection<SaltaPiece> board = this.engine.minmax(Pieces, 3, true).Item2;
				Pieces.Clear();
				foreach (var piece in board)
					Pieces.Add(piece);
			}
			else
            {
				LastSelectedPosition = currentSelect;
			}
			var selection = Pieces.Where(z => z.Type == PieceType.Selection).FirstOrDefault();
			selection.Pos = currentSelect;
		}

		private void CalculateDestinationPositions()
        {
			var playerTypeToCalculate = new List<Player> { Player.Red, Player.Green };

			foreach(var playerType in playerTypeToCalculate)
            {
				foreach (var piece in Pieces.Where(x => x.Player == playerType))
				{
					double destinationX = piece.Pos.X % 2 == 0 ? piece.Pos.X + 1 : piece.Pos.X - 1;
					double destinationY = playerType == Player.Red ? piece.Pos.Y + 7 : piece.Pos.Y - 7;
					var pieceToInsert = new SaltaPiece { 
						Pos = new Point(destinationX, destinationY), 
						Type = piece.Type, 
						Player = piece.Player
                    };

					DestinationPositionsForPieces.Add(pieceToInsert);
				}
			}
		}
    }
}
