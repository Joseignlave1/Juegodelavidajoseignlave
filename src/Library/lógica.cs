using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PII_Game_Of_Life
{
    public class Logica //cumple con el patrón SRP ya que tiene una única responsabilidad
    {
        public void UpdateBoard(Tablero gameBoard, Tablero cloneboard)
        {
            int boardWidth = gameBoard.GetWidth();
            int boardHeight = gameBoard.GetHeight();
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && cloneboard.GetCelula(i, j).IsAlive())
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if (cloneboard.GetCelula(x, y).IsAlive())
                    {
                        aliveNeighbors--;
                    }
                    if (cloneboard.GetCelula(x, y).IsAlive() && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneboard.SetCelula(x, y, false);
                    }
                    else if (cloneboard.GetCelula(x, y).IsAlive() && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        cloneboard.SetCelula(x, y, false);
                    }
                    else if (!cloneboard.GetCelula(x, y).IsAlive() && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneboard.SetCelula(x, y, true);
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneboard.SetCelula(x, y, gameBoard.GetCelula(x, y).IsAlive());
                    }
                        gameBoard.SetGameBoard(cloneboard.GetGameBoard());
                }
            }    
        }
    }
}