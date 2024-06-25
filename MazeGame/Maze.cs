using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    internal class Maze
    {
        private int _Width { get; }
        private int _Height { get; }

        private Player _Player;
        private IMazeObject[,] IMazeObjetArray;
        private int _yExit;

        public Maze(int width, int height)
        {
            this._Width = width;
            this._Height = height;
            IMazeObjetArray = new IMazeObject[width, height];
            _Player = new Player()
            {
                X = 1,
                Y = 1,
            };

            Random random = new Random();
            _yExit = random.Next(2, this._Height - 1);
        }

        public void DrawMaze()
        {
            Console.Clear();
            Random random = new Random();
            Console.Write("\n\n\n\n\n\n\t\t\t");
            for (int y = 0; y < _Height; y++)
            {
                for (int x = 0; x < _Width; x++)
                {
                    // Player position
                    if (x == this._Player.X && y == this._Player.Y)
                    {
                        IMazeObjetArray[x, y] = this._Player;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(IMazeObjetArray[x, y].Icon);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    // Exit place
                    else if (x == this._Width-1 && y == _yExit)
                    {
                        IMazeObjetArray[x, y] = new Exit();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(IMazeObjetArray[x, y].Icon);
                        Console.ForegroundColor= ConsoleColor.White;
                    }
                    // Boundaries position
                    else if (x == 0 || y == 0 || x == this._Width - 1 || y == this._Height - 1)
                    {
                        IMazeObjetArray[x, y] = new Wall();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(IMazeObjetArray[x, y].Icon);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    // Inner walls
                    else if (x % 4 == 0 && y % 4 == 0)
                    {
                        IMazeObjetArray[x, y] = new Wall();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(IMazeObjetArray[x, y].Icon);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (x % 3 == 0 && y % 3 == 0)
                    {
                        IMazeObjetArray[x, y] = new Wall();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(IMazeObjetArray[x, y].Icon);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    // Empty spaces
                    else
                    {
                        IMazeObjetArray[x, y] = new EmptySpace();
                        Console.Write(IMazeObjetArray[x, y].Icon);
                    }
                }
                Console.WriteLine();
                Console.Write("\t\t\t");
            }
        }


        public void MovePlayer()
        {
            var userInput = Console.ReadKey();
            var key = userInput.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    UpdatePlayer(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    UpdatePlayer(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    UpdatePlayer(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    UpdatePlayer(1, 0);
                    break;
                default: throw new ArgumentException("the allowed characters is left,right,up,down");
            }
        }

        private void UpdatePlayer(int xd,int yd)
        {
            int newX = this._Player.X + xd;
            int newY = this._Player.Y + yd;

            if(newX<this._Width && newY<this._Height
                && newX>=0 && newY>=0 && IMazeObjetArray[newX,newY].isSolid==false)
            {
                this._Player.X = newX;
                this._Player.Y = newY;

                if (newX == this._Width - 1 && newY == _yExit)
                {
                    WinnerScreen();
                }
                else
                {
                    DrawMaze();
                }
                
            }
        }

        public void WinnerScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\tYou Are Winner Congratualtions");
            Environment.Exit(0);
        }
    }
}
