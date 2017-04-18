using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPProgramacion3
{
    class Enemy
    {
        static Random rnd = new Random();
        private int respawnpointx;
        private int respawnpointy;
        private int x;
        private int y;
        private int previousx;
        private int previousy;
        private char sprite;
        private int limitx = 75;
        private int limity = 24;

        public Enemy(int posx, int posy, char icon)
        {
            x = posx;
            y = posy;
            respawnpointx = x;
            respawnpointy = y;
            sprite = icon;
        }
        public void GoLeft()
        {
            if (x > 0)
            {
                previousx = x;
                previousy = y;
                x-=1;
                Draw();
                ClearOldSprite();
            }
        }
        public void GoRight()
        {
            if (x < limitx)
            {
                previousx = x;
                previousy = y;
                x++;
                Draw();
                ClearOldSprite();
            }
        }
        public void GoUp()
        {
            if (y > 0)
            {
                previousx = x;
                previousy = y;
                y--;
                Draw();
                ClearOldSprite();
            }
        }
        public void GoDown()
        {
            if (y < limity)
            {
                previousx = x;
                previousy = y;
                y++;
                Draw();
                ClearOldSprite();
            }
        }
        public void ClearOldSprite()
        {
            Console.SetCursorPosition(previousx, previousy);
            Console.Write(" ");
            Console.SetCursorPosition(limitx + 1, limity + 1);
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sprite);
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public void Respawn()
        {
            ClearOldSprite();
            x = rnd.Next(75);
            y = rnd.Next(24);
        }
    }
}
