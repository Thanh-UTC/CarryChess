﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryChess
{
    class CheckMove
    {
        //
        // Check the move
        //
        public bool LegalMove(Point startCoord, Point desCoord)
        {
            //find the coordinates of start Point and destination Point
            int startX = startCoord.X;
            int startY = startCoord.Y ;
            int desX = desCoord.X ;
            int desY = desCoord.Y;
            //check the move
            if ((startX + startY) % 2 != 0 && (desX + desY) % 2 != 0)
            {
                return false;
            }
            return true;
        }
        //
        //Check game status
        //
        public int CheckStatus(int[,] map)

        {
            int black = 0;
            int white = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (map[i, j] == 1)
                    {
                        black++;
                    }
                    else if (map[i, j] == 2)
                    {
                        white++;
                    }
                }
            }
            if (black == 16)
            {
                return 1;
            }
            else if (white == 16)
            {
                return 2;
            }
            return -1;
        }
        //
        //Check the move make a eat move or not
        //
        public int[,] EatCheck(Point Coord, int[,] tempmap)
        {
            int x = Coord.X + CONS.STD_DEVI;
            int y = Coord.Y + CONS.STD_DEVI;
            int[,] maps = tempmap;
            //  map
            //  (b)  (b)  (b)   (b)   (b)   (b)   (b)   (b)  (b)  
            //  (b)  (b)  (b)   (b)   (b)   (b)   (b)   (b)  (b)  
            //  (b)  (b)  (21)  (22)  (23)  (24)  (25)  (b)  (b)
            //  (b)  (b)  (20)  (19)  (18)  (17)  (16)  (b)  (b)
            //  (b)  (b)  (11)  (12)  (*)   (14)  (15)  (b)  (b)
            //  (b)  (b)  (10)  (9)   (8)   (7)   (6)   (b)  (b)  
            //  (b)  (b)  (1)   (2)   (3)   (4)   (5)   (b)  (b)
            //  (b)  (b)  (b)   (b)   (b)   (b)   (b)   (b)  (b)
            //  (b)  (b)  (b)   (b)   (b)   (b)   (b)   (b)  (b)
            //  map

            //
            // Dieu kien ganh
            //

            //
            //  point  18/12/8/14
            //
            if ((x == 3 && y == 4) || (x == 4 && y == 3)
                || (x == 5 && y == 4) || (x == 4 && y == 5))
            {
                if ((maps[y, x] == 2) && (maps[y, x] != maps[y, x - 1])
                    && (maps[y, x] != maps[y, x + 1]) && (maps[y, x + 1] != 0)
                    && (maps[y, x - 1] != 0) && (maps[y, x + 1] != -1) && (maps[y, x - 1] != -1))
                {
                    maps[y, x + 1] = 2; maps[y, x - 1] = 2;
                }
                else if ((maps[y, x] == 2) && (maps[y, x] != maps[y - 1, x])
                    && (maps[y, x] != maps[y + 1, x]) && (maps[y + 1, x] != 0)
                    && (maps[y - 1, x] != 0) && (maps[y + 1, x] != -1) && (maps[y - 1, x] != -1))
                {
                    maps[y + 1, x] = 2; maps[y - 1, x] = 2;
                }
                else if ((maps[y, x] == 1) && (maps[y, x] != maps[y, x - 1])
                    && (maps[y, x] != maps[y, x + 1]) && (maps[y, x + 1] != 0)
                    && (maps[y, x - 1] != 0) && (maps[y, x + 1] != -1) && (maps[y, x - 1] != -1))
                {
                    maps[y, x + 1] = 1; maps[y, x - 1] = 1;
                }
                else if ((maps[y, x] == 1) && (maps[y, x] != maps[y - 1, x])
                    && (maps[y, x] != maps[y + 1, x]) && (maps[y + 1, x] != 0)
                    && (maps[y - 1, x] != 0) && (maps[y + 1, x] != -1) && (maps[y - 1, x] != -1))
                {
                    maps[y + 1, x] = 1; maps[y - 1, x] = 1;
                }
            }
            //
            // other point
            //
            else
            {
                if ((maps[y, x] == 2) && (maps[y, x] != maps[y, x - 1])
                    && (maps[y, x] != maps[y, x + 1]) && (maps[y, x + 1] != 0)
                    && (maps[y, x - 1] != 0) && (maps[y, x + 1] != -1) && (maps[y, x - 1] != -1))
                {
                    maps[y, x + 1] = 2; maps[y, x - 1] = 2;
                }
                else if ((maps[y, x] == 2) && (maps[y, x] != maps[y - 1, x])
                    && (maps[y, x] != maps[y + 1, x]) && (maps[y + 1, x] != 0)
                    && (maps[y - 1, x] != 0) && (maps[y + 1, x] != -1) && (maps[y - 1, x] != -1))
                {
                    maps[y + 1, x] = 2; maps[y - 1, x] = 2;
                }
                else if ((maps[y, x] == 2) && (maps[y, x] != maps[y - 1, x - 1])
                    && (maps[y, x] != maps[y + 1, x + 1]) && (maps[y + 1, x + 1] != 0)
                    && (maps[y - 1, x - 1] != 0) && (maps[y + 1, x + 1] != -1) && (maps[y - 1, x - 1] != -1))
                {
                    maps[y + 1, x + 1] = 2; maps[y - 1, x - 1] = 2;
                }
                else if ((maps[y, x] == 2) && (maps[y, x] != maps[y + 1, x - 1])
                    && (maps[y, x] != maps[y - 1, x + 1]) && (maps[y - 1, x + 1] != 0)
                    && (maps[y + 1, x - 1] != 0) && (maps[y - 1, x + 1] != -1) && (maps[y + 1, x - 1] != -1))
                {
                    maps[y + 1, x - 1] = 2; maps[y - 1, x + 1] = 2;
                }
                else if ((maps[y, x] == 1) && (maps[y, x] != maps[y, x - 1])
                    && (maps[y, x] != maps[y, x + 1]) && (maps[y, x + 1] != 0)
                    && (maps[y, x - 1] != 0) && (maps[y, x + 1] != -1) && (maps[y, x - 1] != -1))
                {
                    maps[y, x + 1] = 1; maps[y, x - 1] = 1;
                }
                else if ((maps[y, x] == 1) && (maps[y, x] != maps[y - 1, x])
                    && (maps[y, x] != maps[y + 1, x]) && (maps[y + 1, x] != 0)
                    && (maps[y - 1, x] != 0) && (maps[y + 1, x] != -1) && (maps[y - 1, x] != -1))
                {
                    maps[y + 1, x] = 1; maps[y - 1, x] = 1;
                }
                else if ((maps[y, x] == 1) && (maps[y, x] != maps[y - 1, x - 1])
                    && (maps[y, x] != maps[y + 1, x + 1]) && (maps[y + 1, x + 1] != 0)
                    && (maps[y - 1, x - 1] != 0) && (maps[y + 1, x + 1] != -1) && (maps[y - 1, x - 1] != -1))
                {
                    maps[y + 1, x + 1] = 1; maps[y - 1, x - 1] = 1;
                }
                else if ((maps[y, x] == 1) && (maps[y, x] != maps[y + 1, x - 1])
                    && (maps[y, x] != maps[y - 1, x + 1]) && (maps[y - 1, x + 1] != 0)
                    && (maps[y + 1, x - 1] != 0) && (maps[y - 1, x + 1] != -1) && (maps[y + 1, x - 1] != -1))
                {
                    maps[y + 1, x - 1] = 1; maps[y - 1, x + 1] = 1;
                }
            }

            //
            // dieu kien vay
            //
            //  map
            //  (b)  (b)  (b)   (b)   (b)   (b)   (b)   (b)  (b)  
            //  (b)  (b)  (b)   (b)   (b)   (b)   (b)   (b)  (b)  
            //  (b)  (b)  (21)  (22)  (23)  (24)  (25)  (b)  (b)
            //  (b)  (b)  (20)  (19)  (18)  (17)  (16)  (b)  (b)
            //  (b)  (b)  (11)  (12)  (*)   (14)  (15)  (b)  (b)
            //  (b)  (b)  (10)  (9)   (8)   (7)   (6)   (b)  (b)  
            //  (b)  (b)  (1)   (2)   (3)   (4)   (5)   (b)  (b)
            //  (b)  (b)  (b)   (b)   (b)   (b)   (b)   (b)  (b)
            //  (b)  (b)  (b)   (b)   (b)   (b)   (b)   (b)  (b)
            //  map

            
          //  #region
          //  if (maps[y, x] == 2)
          //  {
          //      #region center point with big square - each point is center of the square
          //      // point 9
          //      if (maps[y + 1,x-1]==1 && maps[y + 2, x - 2] == 2 && maps[y + 2, x - 1] == 2 && maps[y + 2, x] == 2 
          //          && maps[y + 1, x] == 2 && maps[y + 1, x - 2] == 2 && maps[y, x - 2] == 2 && maps[y, x - 1] == 2)
          //      {
          //          maps[y + 1, x - 1] = 2;
          //      }
          //      // point 7
          //      else if(maps[y + 1, x + 1] == 1 && maps[y + 2, x - 2] == 2 && maps[y + 2, x - 1] == 2 && maps[y + 2, x] == 2 && maps[y + 1, x] == 2
          //          && maps[y + 1, x - 2] == 2 && maps[y, x - 2] == 2 && maps[y, x - 1] == 2)
          //      {
          //          maps[y + 1, x + 1] = 2;
          //      }
          //      // point 17
          //      else if(maps[y - 1, x + 1] == 1 && maps[y - 2, x + 2] == 2 && maps[y - 2, x + 1] == 2 && maps[y - 2, x] == 2 && maps[y - 1, x] == 2
          //          && maps[y - 1, x + 2] == 2 && maps[y, x + 2] == 2 && maps[y, x + 1] == 2)
          //      {
          //          maps[y - 1, x + 1] = 2;
          //      }
          //      //point 19
          //      else if (maps[y - 1, x - 1] == 1 && maps[y - 2, x - 2] == 2 && maps[y - 2, x - 1] == 2 && maps[y - 2, x] == 2 && maps[y - 1, x] == 2
          //          && maps[y - 1, x - 2] == 2 && maps[y, x - 2] == 2 && maps[y, x - 1] == 2)
          //      {
          //          maps[y - 1, x - 1] = 2;
          //      }
          //      // point 8
          //      else if (maps[y+1,x] ==1 && maps[y,x+1]==2 && maps[y+1,x+1]==2 && maps[y+2,x+1]==2 && maps[y+2,x]==2 && maps[y+2,x-1]==2 
          //          &&maps[y+1,x-1]==2 && maps[y,x-1]==2)
          //      {
          //          maps[y + 1, x] = 2;
          //      }
          //      // point 14
          //      else if (maps[y,x+1]==1 && maps[y-1,x]==2 && maps[y-1,x+1]==2 && maps[y-1,x+2]==2 && maps[y,x+2]==2 && maps[y+1,x+2]==2 
          //          && maps[y+1,x+1]==2 && maps[y + 1, x] == 2)
          //      {
          //          maps[y, x + 1]=2;
          //      }
          //      // point 18
          //      else if (maps[y-1,x]==1 && maps[y,x-1]==2 && maps[y-1,x-1]==2 && maps[y-2,x-1]==2 && maps[y-2,x]==2 && maps[y-2,x-1]==2
          //          && maps[y-1,x+1]==2 && maps[y,x+1]==2)    
          //      {
          //          maps[y - 1, x] = 2;
          //      }
          //      //point 12
          //      else if (maps[y,x-1]==1 && maps[y+1,x]==2 && maps[y+1,x-1]==2 && maps[y+1,x-2]==2 && maps[y, x-2]==2&& maps[y-1,x-2 ]==2
          //          && maps[y-1,x-1]==2 && maps[y-1,x]==2 )
          //      {
          //          maps[y, x - 1] = 2;
          //      }
          //      #endregion
          //      //
          //      //rectangle 
          //      //
          //      #region rectangle- each point is the corner of the rectangle or the middle point- 5 surrounded chessmen
          //      // 
          //      if (maps[y,x+1]==1 && maps[y-1, x]==2 && maps[y-1, x+1]==2 && maps[y-1, x+2]==2 && maps[y,x+2]==2
          //          && maps[y+1,x+2]==-1 && maps[y+1, x+1]==-1 && maps[y+1,x]==-1)
          //      {
          //          maps[y,x+1] = 2;
          //      }else if (maps[y+1,x+1]==1 && maps[y,x+1]==2 && maps[y, x+2]==2 && maps[y+1,x+2]==2 && maps[y+1,x]==2 
          //          && maps[y+2,x+2]==-1 && maps[y+2,x+1]==-1 && maps[y+2,x]==-1)
          //      {
          //          maps[y + 1, x + 1] = 2;
          //      }else if (maps[y+1,x]==1 && maps[y,x+1]==2 && maps[y+1,x+1]==2 && maps[y+1,x-1]==2 && maps[y,x-1]==2 
          //          && maps[y+2, x+1]==-1 && maps[y+2,x]==-1 && maps[y+2,x-1]==-1)
          //      {
          //          maps[y + 1, x] = 2;
          //      }else if (maps[y+1,x-1]==1 && maps[y+1,x]==2 && maps[y+1,x-2]==2 && maps[y,x-2]==2 && maps[y,x-1]==2 
          //          && maps[y+2,x]==-1 && maps[y+2,x-1]==-1 && maps[y+2, x-2]==-1)
          //      {
          //          maps[y + 1, x - 1] = 2;
          //      }else if(maps[y,x-1]==1 && maps[y, x-2]==2 && maps[y-1,x-2]==2 && maps[y-1,x-1]==2 && maps[y-1,x]==2
          //          && maps[y+1,x]==-1 && maps[y+1,x-1]==-1 && maps[y+1, x - 2] == -1)
          //      {
          //          maps[y, x - 1] = 2;
          //      }
          //      //
          //      else if (maps[y-1,x]==1 && maps[y,x-1]==2 && maps[y-1,x-1]==2 && maps[y-2, x-1]==2 && maps[y-2,x]==2
          //          && maps[y,x+1]==-1 && maps[y-1,x+1]==-1 && maps[y-2,x+1]==-1)
          //      {
          //          maps[y - 1, x] = 2;
          //      }else if (maps[y - 1, x + 1] == 1&& maps[y - 1, x] == 2&& maps[y - 2, x] == 2&& maps[y - 2, x + 1] == 2&& maps[y, x + 1] == 2
          //          && maps[y, x + 2] == -1&& maps[y - 1, x + 2] == -1&& maps[y - 1, x + 2] == -1)
          //      {
          //          maps[y - 1, x + 1] = 2;
          //      }else if (maps[y, x + 1] == 1&& maps[y - 1, x] == 2&& maps[y - 1, x + 1] == 2&& maps[y + 1, x + 1] == 2&& maps[y + 1, x] == 2
          //          && maps[y - 1, x + 2] == -1&& maps[y, x + 2] == -1&& maps[y + 1, x + 2] == -1)
          //      {
          //          maps[y, x + 1] = 2;
          //      }else if (maps[y + 1, x + 1] == 1 && maps[y, x + 1] == 2 && maps[y + 2, x + 1] == 2 && maps[y + 2, x] == 2 && maps[y + 1, x] == 2
          //          && maps[y, x + 2] == -1 && maps[y + 1, x + 2] == -1 && maps[y + 2, x + 2] == -1)
          //      {
          //          maps[y + 1, x + 1] = 2;
          //      }else if (maps[y + 1, x] == 1 && maps[y + 2, x] == 2 && maps[y + 2, x - 1] == 2 && maps[y + 1, x - 1] == 2 && maps[y, x - 1] == 2
          //          && maps[y, x + 1] == -1 && maps[y + 1, x + 1] == -1 && maps[y + 2, x + 1] == -1)
          //      {
          //          maps[y + 1, x] = 2;
          //      }
          //      //
          //      else if (maps[y, x - 1] == 1 && maps[y + 1, x] == 2 && maps[y + 1, x - 1] == 2 && maps[y + 1, x - 2] == 2 && maps[y, x - 2] == 2
          //          && maps[y - 1, x] == -1 && maps[y - 1, x - 1] == -1 && maps[y - 1, x - 2] == -1)
          //      {
          //          maps[y, x - 1] = 2;
          //      }else if (maps[y - 1, x - 1] == 1 && maps[y, x - 1] == 2 && maps[y, x - 2] == 2 && maps[y - 1, x - 2] == 2 && maps[y - 1, x - 1] == 2
          //&& maps[y - 2, x] == -1 && maps[y - 2, x - 1] == -1 && maps[y - 2, x - 2] == -1)
          //      {
          //          maps[y - 1, x - 1] = 2;
          //      }
          //          #endregion
          //  }
          //  #endregion   
            
           
            //
            //  point (9), (7), (17), (19) with small square
            //
            
            return maps;

        }
    }
}
