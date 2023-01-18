using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsGame
{
    internal class GraphAlgorithm
    {
        private List<Point> points= new List<Point>();
        int planszaCount;
        public GraphAlgorithm(int planszaCount)
        {
            this.planszaCount= planszaCount;
        }


        //algorytm sprawdzający czy ścieżka od punktu {start} do punktu {stop} istnieje
        public bool isPath(int[,] matrix, Point start, Point stop)
        {
            int[,] tmp = new int [planszaCount, planszaCount];

            for (int i = 0; i < planszaCount; i++)
            {
                for (int j = 0; j < planszaCount; j++)
                {
                    tmp[i,j]= matrix[i,j];
                }
            }

            tmp[start.Y, start.X] = 3;
            tmp[stop.Y, stop.X] = 2;

            bool[,] visited = new bool[planszaCount, planszaCount];
            bool flag = false;

            for (int i = 0; i < planszaCount; i++)
            {
                for (int j = 0; j < planszaCount; j++)
                {

                    if (tmp[i, j] == 3 && !visited[i, j])

                        if (isPath(tmp, i, j, visited))
                        {
                            flag = true;
                            break;
                        }
                }
            }

            
            if (flag)
                return true;
            else
                return false;
        }

        private static bool isSafe(int i, int j, int[,] matrix)
        {
            if (i >= 0 && i < matrix.GetLength(0) && j >= 0
                && j < matrix.GetLength(1))
                return true;

            return false;
        }

        private static bool isPath(int[,] matrix, int i, int j,
                                  bool[,] visited)
        {

            if (isSafe(i, j, matrix) && matrix[i, j] < 4
                && !visited[i, j])
            {
                visited[i, j] = true;

                if (matrix[i, j] == 2)
                    return true;
                bool up = isPath(matrix, i - 1, j, visited);

                if (up)
                    return true;

                bool left = isPath(matrix, i, j - 1, visited);

       
                if (left)
                    return true;

                bool down = isPath(matrix, i + 1, j, visited);

            
                if (down)
                    return true;

              
                bool right = isPath(matrix, i, j + 1, visited);

          
                if (right)
                    return true;
            }

          
            return false;
        }




        //algorytm sprawdzający czy ścieżka kolorów o długości 5 istnieje
        public List<Point> whetherAddPoints(int[,] tab)
        {
            int[,] tmp = new int[planszaCount, planszaCount];
            int[,] tmp2 = new int[planszaCount, planszaCount];
            int[,] tmp3 = new int[planszaCount, planszaCount];
            int[,] tmp4 = new int[planszaCount, planszaCount];

            for (int i = 0; i < planszaCount; i++)
            {
                for (int j = 0; j < planszaCount; j++)
                {
                    tmp[i, j] = tab[i, j];
                    tmp2[i, j] = tab[i, j];
                    tmp3[i, j] = tab[i, j];
                    tmp4[i, j] = tab[i, j];
                }
            }
           
            for (int i = 0; i < planszaCount; ++i)
            {
                for (int j = 0; j < planszaCount; ++j)
                {
                    if (tmp[i, j] > 3)
                    {
                        points.Clear();
                        pom1(tmp, i, j, tmp[i, j]);
                        if (points.Count >= 5)
                            return points;
                    }
                    if (tmp2[i, j] > 3)
                    {
                        points.Clear();
                        pom2(tmp2, i, j, tmp2[i, j]);
                        if (points.Count >= 5)
                            return points;
                    }
                    if (tmp3[i, j] > 3)
                    {
                        points.Clear();
                        pom3(tmp3, i, j, tmp3[i, j]);
                        if (points.Count >= 5)
                        {
                            return points;
                        }
                    }
                    if (tmp4[i, j] > 3)
                    {
                        points.Clear();
                        pom4(tmp4, i, j, tmp4[i, j]);
                        if (points.Count >= 5)
                        {
                            return points;
                        }
                    }
                }
            }

            points.Clear();
            return null;
        }

        //pionowo
        private int pom1(int[,] tab, int i, int j, int find)
        {

            if (i < 0 || j < 0 || i >= planszaCount || j >= planszaCount || tab[i, j] != find)
                return 0;
            tab[i, j] = -1;
            points.Add(new Point(j, i));
            return (1 + pom1(tab, i + 1, j, find) + pom1(tab, i - 1, j, find));
        }

        //poziomo
        private int pom2(int[,] tab, int i, int j, int find)
        {

            if (i < 0 || j < 0 || i >= planszaCount || j >= planszaCount || tab[i, j] != find)
                return 0;
            tab[i, j] = -1;
            points.Add(new Point(j, i));
            return (1 + pom2(tab, i, j + 1, find) + pom2(tab, i, j - 1, find));
        }

        //lewa-prawa
        private int pom3(int[,] tab, int i, int j, int find)
        {

            if (i < 0 || j < 0 || i >= planszaCount || j >= planszaCount || tab[i, j] != find)
                return 0;
            tab[i, j] = -1;
            points.Add(new Point(j, i));
            return (1 + pom3(tab, i+1, j-1, find) + pom3(tab, i-1, j+1, find));
        }

        //prawa-lewa
        private int pom4(int[,] tab, int i, int j, int find)
        {

            if (i < 0 || j < 0 || i >= planszaCount || j >= planszaCount || tab[i, j] != find)
                return 0;
            tab[i, j] = -1;
            points.Add(new Point(j, i));
            return (1 + pom4(tab, i-1, j-1, find) + pom4(tab, i+1, j+1, find));
        }
    }
}
