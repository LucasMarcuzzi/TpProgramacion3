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

        public Personaje(int posx, int posy, char icon)
        {
            x = posx;
            y = posy;
            sprite = icon;
            previousx = -1;
            previousy = -1;
            Draw();
        }
        
        public void MoveLeft()
        {
            if (x > 0)
            {
                previousy = y;
                previousx = x;
                x--;
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

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sprite);
            Console.SetCursorPosition(limitx+1, limity+1);
        }
        public void Respawn()
        {
            x = 20;
            y = 20;
        }
    }
    
}
