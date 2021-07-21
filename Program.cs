using System;
using System.Threading;

namespace GameOfLife
{
    public static class Program
    {
        static GameOfLife game;
        static bool running = true;
        public static void Main(string[] args)
        {
            //assume args are height & width
            try
            {
                if (args.Length == 2)
                {
                    int a = int.Parse(args[0]);
                    int b = int.Parse(args[1]);
                    if(a > 2 && b > 2 && a < 60 && b < 60)
                    game = new GameOfLife(a, b);
                }            
                else 
                    game = new GameOfLife();
            }
            catch(Exception e) 
            { 
                Console.WriteLine("Invalid arguments - Usage: .\\GameOfLife <rows> <columns>");
                running = false;
            }          
            
            while(running)
            {
                Render();
            }
        }

        public static void Render(int step = 200)
        {
            Console.Clear();
            Console.Write(game.StateMap());
            game.Generate();
            Thread.Sleep(step);
        }
    }
}
