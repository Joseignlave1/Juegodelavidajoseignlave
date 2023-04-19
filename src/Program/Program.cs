using System;

namespace PII_Game_Of_Life
{
    class Program //cumple con el patrón SRP ya que tiene una única responsabilidadz
    {
        static void Main(string[] args)
        {
            // Crear instancia de la clase Tablero
            bool[,] initialBoard = LeerArchivo.LeerTableroDesdeArchivo("board.txt");
            Tablero tablero = new Tablero(initialBoard);

            // Mostrar contenido del tablero en la consola
            bool[,] gameBoard = tablero.GetGameBoard();
            for (int y = 0; y < gameBoard.GetLength(1); y++)
            {
                for (int x = 0; x < gameBoard.GetLength(0); x++)
                {
                    if (gameBoard[x, y])
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
