﻿using System;
using System.Text; 
using System.Threading; 
using System.IO;

namespace PII_Game_Of_Life
{
    class Program
    
    {
        static void Main(string[] args) // Necesitamos el método Main
        {
            int width = 10; // Necesitamos inicializar el ancho del tablero
            int height = 10; // Necesitamos inicializar la altura del tablero
            Tablero b = new Tablero(width, height); // Necesitamos inicializar el tablero

            while (true)
            {
                Console.Clear();
                StringBuilder s = new StringBuilder();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (b(x, y))
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