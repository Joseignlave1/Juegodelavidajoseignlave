using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PII_Game_Of_Life
{
    public class Tablero 
    {
        private Celula[,] gameBoard;
        private int boardWidth;
        private int boardHeight;
        private Tablero cloneboard;
        private Tablero initialBoard;

        public Tablero(int boardWidth, int boardHeight) 
        {
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            gameBoard = new Celula[boardWidth, boardHeight];
            for (int i = 0; i < boardWidth; i++) 
            {
                for (int j = 0; j < boardHeight; j++) 
                {
                    gameBoard[i, j] = new Celula(false);
                }
            }
        }

        public void SetCelula(int x, int y, bool estado) 
        {
            gameBoard[x, y].SetEstado(estado);
        }

        public Celula GetCelula(int x, int y) 
        {
            return gameBoard[x, y];
        }

        public Celula[,] GetGameBoard() 
        {
            return gameBoard;
        }

        public void SetGameBoard(Celula[,] newGameBoard) 
        {
            gameBoard = newGameBoard;
        }

        public int GetLength() 
        {
            return boardWidth * boardHeight;
        }

        public int GetWidth() 
        {
            return boardWidth;
        }

        public int GetHeight() 
        {
            return boardHeight;
        }

        public void SetInitialBoard(Tablero initialBoard) 
        {
            this.initialBoard = initialBoard;
        }
    }

    public class Celula 
    {
        private bool alive;

        public Celula(bool state) 
        {
            alive = state;
        }

        public bool IsAlive() 
        {
            return alive;
        }

        public void SetEstado(bool estado) 
        {
            alive = estado;
        }
    }



}