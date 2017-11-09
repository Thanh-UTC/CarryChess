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
        public List<Point> findMovableBlackChessMan(int[,] temp_map)
        {
            List<Point> point = new List<Point>();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
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
            return PossibleMoves;
        }
}
