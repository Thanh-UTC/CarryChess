﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarryChess
{
    public partial class Form1 : Form
    {
        //
        // Attributes
        //
        private int[,] tempmap = CONS.MAP;
        private PictureBox[,] listChess = new PictureBox[5, 5];
        private Point destinationPoint;
        private Point startPoint;
        private PictureBox tempPicBox;
        private CheckMove checkMethod = new CheckMove();
        private ChessMove MovingChess = new ChessMove();
        //
        //
        //
        public Form1()
        {
            InitializeComponent();
            DrawChessMan(tempmap);
        }
        //
        //Draw the chessboard
        //
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //
            // Create pen.
            //
            Pen blackPen = new Pen(Color.Black, 3);
            //
            //create point
            //
            Point[] point = new Point[2];
            //
            // vertical lines
            //
            for (int i = CONS.FIRST_COORD; i <= CONS.CHESS_SIZE; i += CONS.SQUARE_SIZE)
            {
                point[0] = new Point(i, 25);
                point[1] = new Point(i, 525);
                e.Graphics.DrawLines(blackPen, point);
            }
            //
            //horizontal lines
            //
            for (int i = 25; i <= 525; i += 125)
            {
                point[0] = new Point(25, i);
                point[1] = new Point(525, i);
                e.Graphics.DrawLines(blackPen, point);
            }
            //
            //italic lines
            //
            e.Graphics.DrawLine(blackPen, 275, 25, 25, 275);
            e.Graphics.DrawLine(blackPen, 525, 25, 25, 525);
            e.Graphics.DrawLine(blackPen, 525, 275, 275, 525);
            e.Graphics.DrawLine(blackPen, 25, 25, 525, 525);
            e.Graphics.DrawLine(blackPen, 275, 25, 525, 275);
            e.Graphics.DrawLine(blackPen, 25, 275, 275, 525);
        }
        //
        //Draw chessmen
        //
        public void DrawChessMan(int[,] _tempmap)
        {
            Point location;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    location = new Point(j * CONS.SQUARE_SIZE, i * CONS.SQUARE_SIZE);
                    if (_tempmap[i+CONS.STD_DEVI, j+CONS.STD_DEVI] == 1)
                    {
                        listChess[i, j] = new PictureBox
                        {
                            Location = location,
                            Image = CarryChess.Properties.Resources.QuanCoDen,
                            BackColor = Color.Transparent
                        };
                        panel1.Controls.Add(listChess[i, j]);
                        listChess[i, j].Click += ChessClick;
                    }
                    else if (_tempmap[i+CONS.STD_DEVI, j+CONS.STD_DEVI] == 2)
                    {
                        listChess[i, j] = new PictureBox
                        {
                            Location = location,
                            BackColor = Color.Transparent,
                            Image = CarryChess.Properties.Resources.QuanCoTrang
                        };
                        panel1.Controls.Add(listChess[i, j]);
                        listChess[i, j].Click += ChessClick;
                    }
                    else
                    {
                        listChess[i, j] = null;
                    }
                }
            }
        }
        //
        //Delete all chessmen picture on the chessboard
        //
        public void WipeOutChessmen()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    panel1.Controls.Remove(listChess[j, i]);
                }
            }
        }
        //
        // Picturebox click event
        //
        private void ChessClick(object sender, EventArgs e)
        {
            PictureBox chessPiece = sender as PictureBox;
            Console.WriteLine(chessPiece.Location.X + ";" + chessPiece.Location.Y);
            //
            // find the coord in map- set coord to startPoint
            //
            startPoint = new Point(chessPiece.Location.X, chessPiece.Location.Y);
            int i = (chessPiece.Location.X) / CONS.SQUARE_SIZE;
            int j = (chessPiece.Location.Y) / CONS.SQUARE_SIZE;
            Console.WriteLine(startPoint.X + ";" + startPoint.Y);
            tempPicBox = listChess[j, i];
            Console.WriteLine("current coord: " + tempPicBox.Location.X + ";" + tempPicBox.Location.Y);
            Console.WriteLine("start point coord: " + j + ";" + i);
            //
            //preset
            //
            chessPiece.BackColor = Color.PeachPuff;
            chessPiece.Size = new Size(50, 50);
        }
        //
        // Panel1 click event
        //
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (e.X) / CONS.SQUARE_SIZE;
            int y = (e.Y) / CONS.SQUARE_SIZE;
            Console.WriteLine(y + ";" + x);
            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    Console.Write(tempmap[a, b] + " ");
                }
                Console.WriteLine();
            }
            destinationPoint = new Point(x * CONS.SQUARE_SIZE, y*CONS.SQUARE_SIZE);

            int i = (startPoint.X) / CONS.SQUARE_SIZE;
            int j = (startPoint.Y) / CONS.SQUARE_SIZE;
            panel1.Controls.Remove(listChess[j, i]);
            int m;

            m = tempmap[j+CONS.STD_DEVI, i+CONS.STD_DEVI];
            tempmap[j+CONS.STD_DEVI, i+CONS.STD_DEVI] = 0;
            tempmap[y + CONS.STD_DEVI, x + CONS.STD_DEVI] = m;

            listChess[y,x] = tempPicBox;
            
            tempmap = checkMethod.EatCheck(destinationPoint, tempmap);
            WipeOutChessmen();
            Console.WriteLine();
            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    Console.Write(tempmap[a, b] + " ");
                }
                Console.WriteLine();
            }
            DrawChessMan(tempmap);
            //MoveBlackChessMan();
        }
        public void ResetChessmanImage(PictureBox image)
        {
            image.BackColor = Color.Transparent;

        }
        //
        //Move the black chessman
        //
        public void MoveBlackChessMan()
        {
            List<Point> listBlackChess = MovingChess.findMovableBlackChessMan(tempmap);
            Random t = new Random();
            int numberOfChess = listBlackChess.Count();
            Point nextChess = listBlackChess[t.Next(1, numberOfChess)];

            int i = nextChess.X;
            int j = nextChess.Y;

            List<Point> listMove = findMove(nextChess, tempmap);

            Point nextMove = listMove[0];
            int x = nextMove.X / CONSTANT.SQUARE_SIZE;
            int y = nextMove.Y / CONSTANT.SQUARE_SIZE;

            panel1.Controls.Remove(listChess[j, i]);
            int m;

            m = tempmap[j, i];
            tempmap[j, i] = 0;
            tempmap[y + 1, x + 1] = m;

            listChess[y + 1, x + 1] = tempPicBox;

            tempmap = EatCheck(destinationPoint, tempmap);
            WipeChessMan();
            DrawChessMan(tempmap);


        }
    }
}
