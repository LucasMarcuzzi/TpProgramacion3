using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPProgramacion3
{
    class Trap
    {
        private int x;
        private int y;
        private char sprite;
        private int limitx = 75;
        private int limity = 24;

        public Trap(int posx, int posy, char icon)
        {
            x = posx;
            y = posy;
            sprite = icon;
            Draw();
        }
        public void Draw(){
            Console.SetCursorPosition(x, y);
            Console.Write(sprite);
            Console.SetCursorPosition(limitx + 1, limity + 1);
        }
        public bool Overlap(int charx, int chary)
        {
            if (charx == x && chary == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
