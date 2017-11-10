using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryChess
{
    class ChessMove
    {
        CheckMove checkMethod = new CheckMove();
        public List<Point> findMovableBlackChessMan(int[,] temp_map)
        {
            List<Point> point = new List<Point>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (temp_map[i, j] == 1)
                    {
                        point.Add(new Point(j-CONS.STD_DEVI, i-CONS.STD_DEVI));

                    }
                }
            }

            return point;
        }

        public List<Point> findMove(Point startPoint, int[,] maps)
        {
            List<Point> PossibleMoves = new List<Point>();
            int i = startPoint.X+CONS.STD_DEVI;
            int j = startPoint.Y+CONS.STD_DEVI;

            //move to bottom-left point
            if ((i - 1 >= 2) && (j - 1 >= 2) && (checkMethod.LegalMove(startPoint, new Point((i - 1) * CONS.SQUARE_SIZE - 125, (j - 1) * CONS.SQUARE_SIZE - 125))) && maps[j - 1, i - 1] == 0)
            {
                PossibleMoves.Add(new Point((i - 1) * CONS.SQUARE_SIZE - 125, (j - 1) * CONS.SQUARE_SIZE - 125));
            }
            //move to bottom-right point
            if ((i + 1 <= 8) && (j - 1 >= 2) && (checkMethod.LegalMove(startPoint, new Point((i - 1) * CONS.SQUARE_SIZE - 125, (j + 1) * CONS.SQUARE_SIZE - 125))) && maps[j - 1, i + 1] == 0)
            {
                PossibleMoves.Add(new Point((i - 1) * CONS.SQUARE_SIZE - 125, (j + 1) * CONS.SQUARE_SIZE - 125));
            }
            //move to top-right point 
            if ((i + 1 <= 8) && (j + 1 <= 8) && (checkMethod.LegalMove(startPoint, new Point((i + 1) * CONS.SQUARE_SIZE - 125, (j + 1) * CONS.SQUARE_SIZE - 125))) && maps[j + 1, i + 1] == 0)
            {
                PossibleMoves.Add(new Point((i + 1) * CONS.SQUARE_SIZE - 125, (j + 1) * CONS.SQUARE_SIZE - 125));
            }
            //move to top-left point 
            if ((i - 1 >= 2) && (j + 1 <= 8) && (checkMethod.LegalMove(startPoint, new Point((i - 1) * CONS.SQUARE_SIZE - 125, (j + 1) * CONS.SQUARE_SIZE - 125))) && maps[j + 1, i - 1] == 0)
            {
                PossibleMoves.Add(new Point((i - 1) * CONS.SQUARE_SIZE - 125, (j + 1) * CONS.SQUARE_SIZE - 125));
            }

            //move to top point
            if ((j + 1 <= 8) && (checkMethod.LegalMove(startPoint, new Point(i * CONS.SQUARE_SIZE - 125, (j + 1) * CONS.SQUARE_SIZE - 125))) && maps[j + 1, i] == 0)
            {
                PossibleMoves.Add(new Point(i * CONS.SQUARE_SIZE - 125, (j + 1) * CONS.SQUARE_SIZE - 125));
            }
            //move to bottom point
            if ((j - 1 >= 2) && (checkMethod.LegalMove(startPoint, new Point(i * CONS.SQUARE_SIZE - 125, (j - 1) * CONS.SQUARE_SIZE - 125))) && maps[j - 1, i] == 0)
            {
                PossibleMoves.Add(new Point(i * CONS.SQUARE_SIZE - 125, (j - 1) * CONS.SQUARE_SIZE - 125));
            }
            //move to right
            if ((i + 1 <= 8) && (checkMethod.LegalMove(startPoint, new Point((i + 1) * CONS.SQUARE_SIZE - 125, j * CONS.SQUARE_SIZE - 125))) && maps[j, i + 1] == 0)
            {
                PossibleMoves.Add(new Point((i + 1) * CONS.SQUARE_SIZE - 125, j * CONS.SQUARE_SIZE - 125));
            }
            //move to left
            if ((i - 1 >= 2) && (checkMethod.LegalMove(startPoint, new Point((i - 1) * CONS.SQUARE_SIZE - 125, j * CONS.SQUARE_SIZE - 125))) && maps[j, i - 1] == 0)
            {
                PossibleMoves.Add(new Point((i - 1) * CONS.SQUARE_SIZE - 125, j * CONS.SQUARE_SIZE - 125));
            }
            return PossibleMoves;
        }
    }
}
