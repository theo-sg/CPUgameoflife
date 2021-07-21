using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class GameOfLife
    {
        int[,] grid;
        int height;
        int width;

        public bool running;

        public GameOfLife(int height = 20, int width = 60)
        {           
            this.height = height;
            this.width = width;
            grid = new int[height, width];
            running = true;
            Randomise();
        }

        public void Generate()
        {
            int[,] newGrid = new int[height, width];

            //for each cell
            if (grid != null)
                for (int i = 1; i < height - 1; i++)
                    for (int j = 1; j < width - 1; j++)
                    {
                        int k = 0;
                        //check its neighbours
                        for (int x = -1; x <= 1; x++)
                            for (int y = -1; y <= 1; y++)
                                k += grid[i+x, j+y];

                        //don't include this cell
                        k -= grid[i, j];

                        //for living cells with less than 2 neighbours, die (loneliness)
                        if (grid[i, j] == 1 && k < 2)
                            newGrid[i, j] = 0;
                        //for living cells with more than 3 neighbours, die (overcrowding)
                        else if (grid[i, j] == 1 && k > 3)
                            newGrid[i, j] = 0;
                        //for dead cells with 3 neighbours, come to life (spawning)
                        else if (grid[i, j] == 0 && k == 3)
                            newGrid[i, j] = 1;
                        //otherwise no change;
                        else
                            newGrid[i, j] = grid[i, j];
                    }
            grid = newGrid;
        }

        /// <summary>
        /// randomises input grid
        /// </summary>
        void Randomise()
        {
            Random r = new Random();
            if (grid != null)
                for (int i = 0; i < height; i++)
                    for (int j = 0; j < width; j++)                     
                        grid[i, j] = r.Next(2);
                        
        }

        /// <summary>
        /// converts grid to string
        /// </summary>
        /// <returns>the string to be displayed</returns>
        public string StateMap()
        {
            StringBuilder sb = new StringBuilder();
            if (grid != null)
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                        sb.Append(grid[i, j] == 1 ? '■' : ' ');
                    sb.Append("\n");
                }
            return sb.ToString();
                    
        }
    }
}
