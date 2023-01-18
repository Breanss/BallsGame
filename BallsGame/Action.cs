using GameOfLife;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsGame
{
    internal class Action
    {
        private Board plansza;
       
        private Color selectedColor;
        private List<Point> points = new List<Point>();
        private GraphAlgorithm graphAlgorithm;
        private Tools tools = new Tools();
        private RandomPoints randomPoints = new RandomPoints();
        private Label resultLabel;
        private Panel panel;
        private Point selected;
        private RandomColors randomColors;
        private List<int> colorsStart;
        private Button c1;
        private Button c2;
        private Button c3; 

        public Action(Board plansza, List<Point> points, GraphAlgorithm graphAlgorithm, Label resultLabel, Panel panel, RandomColors randomColors,Point selected ,List<int> colorsStart, Button c1, Button c2, Button c3) { 
            this.plansza = plansza;
            this.points = points;
            this.graphAlgorithm = graphAlgorithm;
            this.resultLabel = resultLabel;
            this.panel = panel;
            this.randomColors = randomColors;
            this.colorsStart = colorsStart;
            this.selected= selected;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        public void cell_Click(object sender, EventArgs e)
        {
            Button b = (sender as Button);
            int[,] tab = plansza.getCells();
            Point p = (Point)b.Tag;


            if (selected.X == -1 && b.BackColor != Color.FromArgb(-9999726))
            {
                tab[p.Y, p.X] = 0;
                selected = (Point)b.Tag;
                selectedColor = b.BackColor;
                points.Add(p);
                b.BackColor = Color.FromArgb(-9999726);
            }else if(selected == (Point)b.Tag)
            {
                tab[p.Y, p.X] = tools.numberColor(selectedColor);
                points.Add((Point)b.Tag);
                b.BackColor = selectedColor;
                selected = new Point(-1, -1);
            }
            else if (selected.X > -1 && b.BackColor == Color.FromArgb(-9999726) && points.Count>3)
            {
                Point tmp = (Point)b.Tag;
                if (graphAlgorithm.isPath(plansza.getCells(), selected, tmp))
                {
                    tab[p.Y, p.X] = tools.numberColor(selectedColor);
                    b.BackColor = selectedColor;
                    points.Remove(p);

                    selected = new Point(-1, -1);
                    selectedColor = Color.Empty;
                    plansza.setCellsTab(tab);
                    List<Point> list = graphAlgorithm.whetherAddPoints(tab);
                    if (list != null)
                    {
                        if (list.Count >= 5)
                        {
                            String[] res = resultLabel.Text.Split(separator: ' ');
                            if (Int32.Parse(res[2]) < 9)
                            {
                                resultLabel.Text = res[0] + " " + res[1] + " " + (Int32.Parse(res[2]) + 1).ToString() + " " + res[3];
                            }
                            else if (Int32.Parse(res[2]) == 9)
                            {
                                resultLabel.Text = res[0] + " " + (Int32.Parse(res[1]) + 1).ToString() + " 0 " + res[3];

                            }

                            int[,] t = plansza.getCells();
                            int i = 0;
                            foreach (Point point in list)
                            {
                                if (i < 5)
                                {
                                    t[point.Y, point.X] = 0;

                                    foreach (Control button in panel.Controls)
                                    {
                                        if ((Point)button.Tag == point)
                                        {
                                            points.Add(point);
                                            button.BackColor = Color.FromArgb(-9999726);
                                        }
                                    }
                                }
                                i++;
                            }
                            plansza.setCellsTab(t);
                        }
                    }
                    else
                        ruch();
                }

            }


        }

        public void ruch()
        {
            int[,] tab = plansza.getCells();


            List<Color> colors = new List<Color>() { Color.Yellow, Color.Orange, Color.Brown, Color.Aqua, Color.Green, Color.Pink, Color.Blue };

            Point point1 = randomPoints.randomPoint(points);

            Point point2 = randomPoints.randomPoint(points);

            Point point3 = randomPoints.randomPoint(points);

            foreach (Control p in panel.Controls)
            {
                Point po = (Point)p.Tag;
                if (po == point1)
                {
                    tab[po.Y, po.X] = tools.numberColor(colors[colorsStart[0]]);
                    p.BackColor = colors[colorsStart[0]];
                }
                else if (po == point2)
                {
                    tab[po.Y, po.X] = tools.numberColor(colors[colorsStart[1]]);
                    p.BackColor = colors[colorsStart[1]];

                }
                else if (po == point3)
                {
                    tab[po.Y, po.X] = tools.numberColor(colors[colorsStart[2]]);
                    p.BackColor = colors[colorsStart[2]];
                }
            }

            plansza.setCellsTab(tab);
            colorsStart = randomColors.randomColors();

            this.c1.BackColor = colors[colorsStart[0]];
            this.c2.BackColor = colors[colorsStart[1]];
            this.c3.BackColor = colors[colorsStart[2]];
        }
    }
}
