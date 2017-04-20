
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TPProgramacion3
{
    class Juego
    {
        bool menustate = true;
        bool firsttime = true;
        bool clearconsole = false;
        bool playstate = false;
        bool game = true;
        int score = 0;
        int highscore = 0;
        Personaje p1;
        Enemy e1;
        Enemy e2;
        Trap t1;
        Trap t2;
        Trap t3;
        Cursor flechita;
        static List<Disparo> disparos;
            
        public Juego(){
            e1 = new Enemy(5, 5, '$');
            e2 = new Enemy(70, 20, '$');
            p1 = new Personaje(20, 20, '☺');
            t1 = new Trap(10, 10, 'X');
            t2 = new Trap(23, 23, 'X');
            t3 = new Trap(30, 15, 'X');
            flechita = new Cursor(32, 15, '→');
            disparos = new List<Disparo>();
        }

        public void Update(){
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //COMIENZA EL BUCLE
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
           while (game)
           {
               if (firsttime)
               {
                   if (!File.Exists("mensaje.txt"))
                   {
                       Console.Clear();
                       FileStream fs = File.Create("mensaje.txt");
                       StreamWriter sw = new StreamWriter(fs);
                       Console.SetCursorPosition(30, 3);
                       Console.WriteLine("Ingrese un mensaje de bienvenida");
                       Console.SetCursorPosition(34, 15);
                       sw.WriteLine(Convert.ToString(Console.ReadLine()));
                       sw.Close();
                       fs.Close();
                       Console.Clear();
                       firsttime = !firsttime;
                   }
               }
               while (menustate)
               {
                   if (!clearconsole)
                   {
                       Console.Clear();
                       FileStream fs = File.OpenRead("mensaje.txt");
                       StreamReader sr = new StreamReader(fs);
                       clearconsole = !clearconsole;
                       Console.SetCursorPosition(30, 0);
                       Console.WriteLine(sr.ReadLine());
                       Console.SetCursorPosition(30, 3);
                       Console.WriteLine("TP Programacion 3");
                       Console.SetCursorPosition(34, 15);
                       Console.WriteLine("Empezar");
                       Console.SetCursorPosition(35, 17);
                       Console.WriteLine("Salir");
                       Console.SetCursorPosition(30, 24);
                       if (File.Exists("highscore.txt"))
                       {
                           FileStream fs3 = File.OpenRead("highscore.txt");
                           BinaryReader br = new BinaryReader(fs3);
                           Console.WriteLine("Highscore: " + br.ReadInt32());
                           fs3.Close();
                           br.Close();
                       }
                       else
                       {
                           Console.WriteLine("Highscore: 0");
                       }
                       Console.SetCursorPosition(0, 0);
                       flechita.Draw();
                       p1.Respawn();
                       e1.Respawn();
                       e2.Respawn();
                       fs.Close();
                       sr.Close();
                       if(score>highscore){
                       FileStream fs2 = File.OpenWrite("highscore.txt");
                       BinaryWriter bw = new BinaryWriter(fs2);
                       bw.Write(score);
                       fs2.Close();
                       bw.Close();
                       }
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

                   p1.MostrarVidas();
                    t1.Draw();
                   t2.Draw();
                   t3.Draw();
                   for (int i = 0; i < disparos.Count; i++)
                   {
                       disparos[i].Update();
                   }
                    Console.SetCursorPosition(76, 23);
                   if (Console.KeyAvailable)
                   {
                       ConsoleKeyInfo Controles = Console.ReadKey();
                       switch (Controles.Key)
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
                           case ConsoleKey.J:
                                disparos.Add(new Disparo(p1.GetX(), p1.GetY(), p1.getDireccion()));
                                break;
                            case ConsoleKey.Escape:
                               game = !game;
                               playstate = !playstate;
                               break;
                            default:
                                break;
                       }
                        p1.CleanLastSprite();
                        p1.Draw();
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
                   for (int i = 0; i < disparos.Count; i++)
                   {
                        if (e1.GetX() == disparos[i].GetX() && e1.GetY() == disparos[i].getY())
                            {
                                e1.Respawn();
                                disparos.RemoveAt(i); //Hace que el disparo desaparezca al darle a un enemigo.
                                score++;
                            }
                    }
                    for (int i = 0; i < disparos.Count; i++)
                    {
                        if (e2.GetX() == disparos[i].GetX() && e2.GetY() == disparos[i].getY())
                        {
                            e2.Respawn();
                            disparos.RemoveAt(i); //Hace que el disparo desaparezca al darle a un enemigo.
                            score++;
                        }
                    }
                        if ((e1.GetX() == p1.GetX()) && (e1.GetY() == p1.GetY()))
                   {
                        //playstate = !playstate;
                        //menustate = !menustate;
                        //clearconsole = !clearconsole;
                        p1.perderVida();
                        e1.Respawn();
                        e2.Respawn();
                    }
                   if ((e2.GetX() == p1.GetX()) && (e2.GetY() == p1.GetY()))
                   {
                        //playstate = !playstate;
                        //menustate = !menustate;
                        //clearconsole = !clearconsole;
                        p1.perderVida();
                        e1.Respawn();
                        e2.Respawn();
                    }
                   if (t1.Overlap(p1.GetX(), p1.GetY()))
                   {
                        //playstate = !playstate;
                        //menustate = !menustate;
                        //clearconsole = !clearconsole;
                        p1.perderVida();
                        e1.Respawn();
                        e2.Respawn();
                    }
                   if (t1.Overlap(e1.GetX(), e1.GetY()))
                   {
                       e1.Respawn();
                       score++;
                   }
                   if (t1.Overlap(e2.GetX(), e2.GetY()))
                   {
                       e2.Respawn();
                       score++;
                   } if (t2.Overlap(p1.GetX(), p1.GetY()))
                   {
                        //playstate = !playstate;
                        //menustate = !menustate;
                        //clearconsole = !clearconsole;
                        p1.perderVida();
                        e1.Respawn();
                        e2.Respawn();
                    }
                   if (t2.Overlap(e1.GetX(), e1.GetY()))
                   {
                       e1.Respawn();
                       score++;
                   }
                   if (t2.Overlap(e2.GetX(), e2.GetY()))
                   {
                       e2.Respawn();
                       score++;
                   }
                   if (t3.Overlap(p1.GetX(), p1.GetY()))
                   {
                        //playstate = false;
                        //menustate = true;
                        //clearconsole = false;
                        p1.perderVida();
                        e1.Respawn();
                        e2.Respawn();
                    }
                   if (t3.Overlap(e1.GetX(), e1.GetY()))
                   {
                       e1.Respawn();
                       score++;
                   }
                   if (t3.Overlap(e2.GetX(), e2.GetY()))
                   {
                       e2.Respawn();
                       score++;
                   }
                   if(p1.getVidas() <= 0)
                    {
                        playstate = false;
                        menustate = true;
                        clearconsole = false;
                        p1.setVidas(3);
                    }

                    System.Threading.Thread.Sleep(80);
               }
           }
        }
    }
}
