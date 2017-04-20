using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPProgramacion3
{
    class Disparo
    {
        private int x;
        private int y;
        private int previousx;
        private int previousy;
        string direccion;
        public Disparo(int _x, int _y, string _direccion)
        {
            x = _x;
            y = _y;

            direccion = _direccion;
            switch (direccion)
            {
                case "arriba":
                    y--;
                    break;
                case "abajo":
                    y++;
                    break;
                case "izquierda":
                    x--;
                    break;
                case "derecha":
                    x++;
                    break;
                default:
                    y--;
                    break;
            }
        }
        ~Disparo()
        {
        }
        private void Moverse()
        {
            if (x >= 0 && x < Console.WindowWidth && y > 0 && y < Console.WindowHeight)
            {
                previousx = x;
                previousy = y;
                switch (direccion)
                {
                    case "arriba":
                        y--;
                        break;
                    case "abajo":
                        y++;
                        break;
                    case "izquierda":
                        x--;
                        break;
                    case "derecha":
                        x++;
                        break;
                    default:
                        y--;
                        break;
                }
                CleanLastSprite();
            }
        }
        private void draw()
        {
            if (x > 0 && x < Console.WindowWidth && y > 0 && y < Console.WindowHeight)
            { 
                Console.SetCursorPosition(x, y);
                Console.WriteLine("O");
            }
        }
        public void CleanLastSprite()
        {
            if (previousx != -1 && previousy != -1)
            {
                Console.SetCursorPosition(previousx, previousy);
                Console.Write(" ");
            }
        }
        public int GetX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void Update()
        {
            Moverse();
            draw();
        }
    }
}
