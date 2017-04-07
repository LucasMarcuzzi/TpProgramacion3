
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPProgramacion3
{
    class Juego
    {
            bool menustate = true;
            bool clearconsole = false;
            bool playstate = false;
            bool game = true;
            Personaje p1;           
            Enemy e1;
            Enemy e2;         
            Trap t1;
            Trap t2;
            Trap t3;    
            Cursor flechita;
            
        public Juego(){
            e1 = new Enemy(5, 5, '$');
            e2 = new Enemy(70, 20, '$');
            p1 = new Personaje(20, 20, '☺');
            t1 = new Trap(10, 10, 'X');
            t2 = new Trap(23, 23, 'X');
            t3 = new Trap(30, 15, 'X');
            flechita = new Cursor(32, 15, '→');
        }

        public void Update(){
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //COMIENZA EL BUCLE
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
           while (game)
           {
               while (menustate)
               {
                   if (!clearconsole)
                   {
                       Console.Clear();
                       clearconsole = !clearconsole;
                       Console.SetCursorPosition(30, 3);
                       Console.WriteLine("TP Programacion 3");
                       Console.SetCursorPosition(34, 15);
                       Console.WriteLine("Empezar");
                       Console.SetCursorPosition(35, 17);
                       Console.WriteLine("Salir");
                       Console.SetCursorPosition(0, 0);
                       flechita.Draw();
                   }
                   ConsoleKeyInfo Movimiento = Console.ReadKey();
                   switch (Movimiento.Key)
                   {
                       case ConsoleKey.W:
                           if (flechita.GetY() > 15) { 
                           flechita.MoveUp();
                   }
                           Console.SetCursorPosition(0, 0);
                           break;
                       case ConsoleKey.S:
                           if (flechita.GetY() < 17)
                           {
                               flechita.MoveDown();
                           }
                           Console.SetCursorPosition(0, 0);
                           break;
                      case ConsoleKey.Spacebar:
                           if (flechita.GetY()==15)
                           {
                               playstate = true;
                               menustate = false;
                               Console.Clear();
                           }
                           if (flechita.GetY() == 17)
                           {
                               playstate = false;
                               menustate = false;
                               game = false;
                           }
                           break;
                       default:
                           Console.SetCursorPosition(0, 0);
                           break;
                   }
               }
               while (playstate)
               {
                   t1.Draw();
                   t2.Draw();
                   t3.Draw();
                   Console.SetCursorPosition(76, 23);
                   if (Console.KeyAvailable)
                   {
                       ConsoleKeyInfo Movimiento = Console.ReadKey();
                       switch (Movimiento.Key)
                       {
                           case ConsoleKey.W:
                               p1.MoveUp();
                               break;
                           case ConsoleKey.S:
                               p1.MoveDown();
                               break;
                           case ConsoleKey.A:
                               p1.MoveLeft();
                               break;
                           case ConsoleKey.D:
                               p1.MoveRight();
                               break;
                           case ConsoleKey.Escape:
                               game = !game;
                               playstate = !playstate;
                               break;
                       }
                       p1.CleanLastSprite();
                   }
                   ///////////////////////////////////////////////////////////////////////////////////////////////////////
                   //INTERACCIONES ENTRE ENTIDADES
                   ///////////////////////////////////////////////////////////////////////////////////////////////////////
                   if (e1.GetX() > p1.GetX())
                   {
                       e1.GoLeft();
                   }
                   if (e1.GetX() < p1.GetX())
                   {
                       e1.GoRight();
                   }
                   if (e1.GetY() > p1.GetY())
                   {
                       e1.GoUp();
                   }
                   if (e1.GetY() < p1.GetY())
                   {
                       e1.GoDown();
                   }
                   if (e2.GetX() > p1.GetX())
                   {
                       e2.GoLeft();
                   }
                   if (e2.GetX() < p1.GetX())
                   {
                       e2.GoRight();
                   }
                   if (e2.GetY() > p1.GetY())
                   {
                       e2.GoUp();
                   }
                   if (e2.GetY() < p1.GetY())
                   {
                       e2.GoDown();
                   }
                   if ((e1.GetX() == p1.GetX()) && (e1.GetY() == p1.GetY()))
                   {
                       p1.Respawn();
                   }
                   if ((e2.GetX() == p1.GetX()) && (e2.GetY() == p1.GetY()))
                   {
                       p1.Respawn();
                   }
                   if (t1.Overlap(p1.GetX(), p1.GetY()))
                   {
                       p1.Respawn();
                   }
                   if (t1.Overlap(e1.GetX(), e1.GetY()))
                   {
                       e1.Respawn();
                   }
                   if (t1.Overlap(e2.GetX(), e2.GetY()))
                   {
                       e2.Respawn();
                   } if (t2.Overlap(p1.GetX(), p1.GetY()))
                   {
                       p1.Respawn();
                   }
                   if (t2.Overlap(e1.GetX(), e1.GetY()))
                   {
                       e1.Respawn();
                   }
                   if (t2.Overlap(e2.GetX(), e2.GetY()))
                   {
                       e2.Respawn();
                   }
                   if (t3.Overlap(p1.GetX(), p1.GetY()))
                   {
                       p1.Respawn();
                   }
                   if (t3.Overlap(e1.GetX(), e1.GetY()))
                   {
                       e1.Respawn();
                   }
                   if (t3.Overlap(e2.GetX(), e2.GetY()))
                   {
                       e2.Respawn();
                   }
                   System.Threading.Thread.Sleep(80);
               }
           }
        }
    }
}
