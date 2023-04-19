using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PII_Game_Of_Life
{

}
    public class Tablero //cumple con el patrón SRP ya que tiene una única responsabilidad
    {
        private bool[,] gameBoard; // contenido del tablero
        private int boardWidth;
        private int boardHeight;
        private bool[,] cloneboard;

        public Tablero(bool[,] initialBoard)
        {
            boardWidth = initialBoard.GetLength(0);
            boardHeight = initialBoard.GetLength(1);
            gameBoard = new bool[boardWidth, boardHeight];
            cloneboard = new bool[boardWidth, boardHeight];
            Array.Copy(initialBoard, gameBoard, initialBoard.Length);
        }

        public int GetCelula()
        {
            return boardWidth * boardHeight;
        }

        public bool[,] GetGameBoard()
        {
            return gameBoard;
        }

        public void SetGameBoard(bool[,] newGameBoard)
        {
            gameBoard = newGameBoard;
        }

        public bool[,] GetCloneBoard()
        {
            return cloneboard;
        }
    }

    public class Logica //cumple con el patrón SRP ya que tiene una única responsabilidad
    {
        public void UpdateBoard(bool[,] gameBoard, bool[,] cloneboard)
        {
            int boardWidth = gameBoard.GetLength(0);
            int boardHeight = gameBoard.GetLength(1);

            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && gameBoard[i, j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if (gameBoard[x, y])
                    {
                        aliveNeighbors--;
                    }
                    if (gameBoard[x, y] && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneboard[x, y] = false;
                    }
                    else if (gameBoard[x, y] && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        cloneboard[x, y] = false;
                    }
                    else if (!gameBoard[x, y] && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneboard[x, y] = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneboard[x, y] = gameBoard[x, y];
                    }
                }
            }
            Array.Copy(cloneboard, gameBoard, cloneboard.Length);
        }
    }

    public class LeerArchivo
    {
        public static bool[,] LeerTableroDesdeArchivo(string url)//cumple con el patrón SRP ya que tiene una única responsabilidad
        {
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n');
            bool[,] board = new bool[contentLines[0].Length, contentLines.Length];
            for (int y = 0; y < contentLines.Length; y++)
            {
                for (int x = 0; x < contentLines[y].Length; x++)
                {
                    if (contentLines[y][x] == '1')
                    {
                        board[x, y] = true;
                    }
                }
            }
            return board;
        }
    }

public class dibujartablero //cumple con el patrón SRP ya que tiene una única responsabilidad
{
    private int width; // variable que representa el ancho del tablero
    private int height; // variable que representa altura del tablero
    private Tablero tablero; // instancia de la clase Tablero

    public dibujartablero(int w, int h, Tablero t)
    {
        width = w;
        height = h;
        tablero = t;
    }

    public void Dibujar() //cumple con el patrón SRP ya que tiene una única responsabilidad
    {
        Console.Clear();
        StringBuilder s = new StringBuilder();
        bool[,] cloneboard = tablero.GetCloneBoard(); // Obtener el contenido de cloneboard
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (cloneboard[x, y])
                {
                    s.Append("|X|");
                }
                else
                {
                    s.Append("___");
                }
            }
            s.Append("\n");
        }
        Console.WriteLine(s.ToString());
        //=================================================
        //Invocar método para calcular siguiente generación
        //=================================================
        Thread.Sleep(300);
    }
}
