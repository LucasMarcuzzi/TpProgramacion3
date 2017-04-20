using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPProgramacion3
{ 
    class Personaje
    {
        private int x;
        private int y;
        private int previousx;
        private int previousy;
        private char sprite;
        private int limitx = 75;
        private int limity = 24;
        private int vidas = 3;
        string vidasTexto = "♥♥♥";
        string direccion;

        public Personaje(int posx, int posy, char icon)
        {
            x = posx;
            y = posy;
            sprite = icon;
            previousx = -1;
            previousy = -1;
            direccion = "arriba";
            Draw();
        }
        
        public void MoveLeft()
        {
            if (x > 0)
            {
                previousy = y;
                previousx = x;
                x--;
                direccion = "izquierda";
                Draw();
            }
        }
        
        public void MoveRight()
        {
            if (x < limitx)
            {
                previousy = y;
                previousx = x;
                x++;
                direccion = "derecha";
                Draw();
            }
        }
        
        public void MoveUp()
        {
            if (y > 1)
            {
                previousy = y;
                previousx = x;
                y--;
                direccion = "arriba";
                Draw();
            }
        }
        
        public void MoveDown()
        {
            if (y < limity)
            {
                previousy = y;
                previousx = x;
                y++;
                direccion = "abajo";
                Draw();
            }
        }
        
        public void CleanLastSprite()
        {
            if (previousx != -1 && previousy != -1)
            {
                Console.SetCursorPosition(previousx, previousy);
                Console.Write(" ");
                Console.SetCursorPosition(limitx + 1, limity + 1);
            }
        }
        
        public int GetX()
        {
            return x;
        }
        
        public int GetY()
        {
            return y;
        }
        public int getVidas()
        {
            return vidas;
        }
        public void setVidas(int _vidas)
        {
            vidas = _vidas;
        }
        public void MostrarVidas()
        {
            //Console.Clear();
            Console.SetCursorPosition(1,1);
            Console.WriteLine(vidasTexto);
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sprite);
            Console.SetCursorPosition(limitx+1, limity+1);
        }
        public void perderVida()
        {
            Console.Clear();
            vidas--;
            if (vidas > 0)
            { 
                Respawn();
                switch(vidas)
                {
                    case 3:
                        vidasTexto = "♥♥♥";
                        break;
                    case 2:
                        vidasTexto = "♥♥";
                        break;
                    case 1:
                        vidasTexto = "♥";
                        break;
                    default:
                        vidasTexto = "";
                        break;
                }
            }
        }
        public string getDireccion()
        {
            return direccion;
        }
        public void Respawn()
        {
            x = 20;
            y = 20;
        }
    }  
}