using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PII_Game_Of_Life
{

    public class dibujartablero //cumple con el patrón SRP ya que tiene una única responsabilidad
    {
        private int width; // variable que representa el ancho del tablero
        private int height; // variable que representa altura del tablero
        private Tablero initialBoard; // instancia de la clase Tablero

        public dibujartablero(Tablero tablero)
        {
            this.initialBoard = tablero.GetCloneBoard();
            this.width = tablero.GetWidth();
            this.height = tablero.GetHeight();
        }

        public int getDibujarTableroHeight()
        {
            return height;
        }

        public int getDibujarTableroWidth()
        {
            return width;
        }

        public void Dibujar() //cumple con el patrón SRP ya que tiene una única responsabilidad
        {
            while (true)
            {
                Console.Clear();
                StringBuilder s = new StringBuilder();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (initialBoard[x, y])
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
    }
}