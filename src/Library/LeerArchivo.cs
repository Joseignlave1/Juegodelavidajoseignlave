using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PII_Game_Of_Life
{

}
    public class LeerArchivo
    {
        public static Tablero LeerTableroDesdeArchivo(string url)//cumple con el patrón SRP ya que tiene una única responsabilidad
        {
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n');
             Tablero board = new Tablero(contentLines[0].Length, contentLines.Length);
            for (int y = 0; y < contentLines.Length; y++)
            {
                for (int x = 0; x < contentLines[y].Length; x++)
                {
                    if (contentLines[y][x] == '1')
                    {
                        board.SetCelula(x,y,true);
                    }
                }
            }
            return board;
        }
    }