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
                        point.Add(new Point(j, i));

                    }
                }
            }

            return point;
        }

        public List<Point> findMove(Point startPoint, int[,] maps)
        {
            List<Point> PossibleMoves = new List<Point>();
            int i = startPoint.X;//j
            int j = startPoint.Y;//i

            //move to bottom-left point
            if ((i - 1 >= 1) && (j - 1 >=1 ) && (checkMethod.LegalMove(startPoint, new Point((i - 1)  , (j - 1)  ))) && maps[j - 1, i - 1] == 0)
            {
                PossibleMoves.Add(new Point((i - 1) * CONS.SQUARE_SIZE - 250, (j - 1) * CONS.SQUARE_SIZE - 250));
            }
            //move to bottom-right point
            if ((i + 1 <= 7) && (j - 1 >= 1) && (checkMethod.LegalMove(startPoint, new Point((i - 1)  , (j + 1)  ))) && maps[j - 1, i + 1] == 0)
            {
                PossibleMoves.Add(new Point((i - 1) * CONS.SQUARE_SIZE - 250, (j + 1) * CONS.SQUARE_SIZE - 250));
            }
            //move to top-right point 
            if ((i + 1 <= 7) && (j + 1 <= 7) && (checkMethod.LegalMove(startPoint, new Point((i + 1)  , (j + 1)  ))) && maps[j + 1, i + 1] == 0)
            {
                PossibleMoves.Add(new Point((i + 1) * CONS.SQUARE_SIZE - 250, (j + 1) * CONS.SQUARE_SIZE - 250));
            }
            //move to top-left point 
            if ((i - 1 >=1) && (j + 1 <=7) && (checkMethod.LegalMove(startPoint, new Point((i - 1)  , (j + 1)  ))) && maps[j + 1, i - 1] == 0)
            {
                PossibleMoves.Add(new Point((i - 1) * CONS.SQUARE_SIZE - 250, (j + 1) * CONS.SQUARE_SIZE - 250));
            }

            //move to top point
            if ((j + 1 <= 7) && (checkMethod.LegalMove(startPoint, new Point(i  , (j + 1)  ))) && maps[j+1 , i] == 0)
            {
                PossibleMoves.Add(new Point(i * CONS.SQUARE_SIZE - 250, (j + 1) * CONS.SQUARE_SIZE - 250));
            }
            //move to bottom point
            if ((j - 1 >= 1) && (checkMethod.LegalMove(startPoint, new Point(i  , (j - 1)  ))) && maps[j-1 , i] == 0)
            {
                PossibleMoves.Add(new Point(i * CONS.SQUARE_SIZE - 250, (j - 1) * CONS.SQUARE_SIZE - 250));
            }
            //move to right
            if ((i + 1 <= 7) && (checkMethod.LegalMove(startPoint, new Point((i + 1)  , j  ))) && maps[j , i +1] == 0)
            {
                PossibleMoves.Add(new Point((i + 1) * CONS.SQUARE_SIZE - 250, j * CONS.SQUARE_SIZE - 250));
            }
            //move to left
            if ((i - 1 >= 1) && (checkMethod.LegalMove(startPoint, new Point((i - 1)  , j  ))) && maps[j , i - 1] == 0)
            {
                PossibleMoves.Add(new Point((i - 1) * CONS.SQUARE_SIZE - 250, j * CONS.SQUARE_SIZE - 250));
            }
            return PossibleMoves;
        }
    }
}
