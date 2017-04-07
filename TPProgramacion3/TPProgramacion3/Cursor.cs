using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPProgramacion3
{
    class Cursor
    {
        private int x;
        private int y;
        private char sprite;
        private int previousy = -1;
        
        public Cursor(int posx, int posy, char icon)
        {
            x = posx;
            y = posy;
            sprite = icon;
            Draw();
        }
        public void MoveUp()
        {
            previousy = y;
            y -= 2;
            Draw();
            if(previousy!=-1)
            CleanOldSprite();
        }
        public void MoveDown()
        {
            previousy = y;
            y += 2;
            Draw();
            if (previousy != -1)
            CleanOldSprite();
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sprite);
            Console.SetCursorPosition(0, 0);
        }
        public void CleanOldSprite()
        {
            Console.SetCursorPosition(x, previousy);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
    }
}
