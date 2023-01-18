using GameOfLife;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace BallsGame
{
    public partial class window : Form
    {
       
        private Board plansza;
        private int planszaCount = 9;
        private List<Point> points= new List<Point>();
        private List<int> colorsStart= new List<int>();
        private Action action;
        private RandomColors randomColor = new RandomColors();
        private GraphAlgorithm graphAlgorithm;
        private Point selected = new Point(-1, -1);
        public window()
        {
            InitializeComponent();
            start();
        }


        private void changePosition()
        {
            foreach (Control p in panel.Controls)
            {
                p.Click += new EventHandler(action.cell_Click);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start();

            String[] result = resultLabel.Text.Split(' ');
            String[] record = recordLabel.Text.Split(' ');
          
            if (Int32.Parse(result[1]) > Int32.Parse(record[1])) {
                recordLabel.Text= resultLabel.Text;
            }
            else
            {
                if(Int32.Parse(result[2]) > Int32.Parse(record[2]))
                {
                    recordLabel.Text= resultLabel.Text;
                }
            }

            resultLabel.Text = "0 0 0 0";
        }
        
        public void start()
        {
            points.Clear();
            colorsStart.Clear();
            graphAlgorithm = new GraphAlgorithm(planszaCount);
            GraphicsPath grp = new GraphicsPath();
            grp.AddEllipse(3, 2, c1.Width - 3, c1.Height - 3);
            c1.FlatStyle = FlatStyle.Flat;
            c1.FlatAppearance.BorderSize = 0;
            c1.Region = new Region(grp);

            c2.FlatStyle = FlatStyle.Flat;
            c2.FlatAppearance.BorderSize = 0;
            c2.Region = new Region(grp);

            c3.FlatStyle = FlatStyle.Flat;
            c3.FlatAppearance.BorderSize = 0;
            c3.Region = new Region(grp);


            colorsStart = randomColor.randomColors();
            this.plansza = new Board();

            this.panel.SuspendLayout();
            this.SuspendLayout();
            this.panel.Controls.Clear();

            int panelWidth = this.panel.Width;
            int panelHeight = this.panel.Height;

            int size = panelWidth / (planszaCount + 1) < panelHeight / (planszaCount + 1) ? panelWidth / (planszaCount + 1) : panelHeight / (planszaCount + 1);

            NewButton newButton = new NewButton(panel);

            Point pointButton;

            for (int i = 0; i < planszaCount; i++)
            {
                for (int j = 0; j < planszaCount; j++)
                {
                    pointButton = new Point(i, j);
                    points.Add(pointButton);
                    newButton.addButton(i, j, size);
                }
            }
            action = new Action(plansza, points, graphAlgorithm, resultLabel, panel, randomColor, selected, colorsStart, c1, c2, c3);
            action.ruch();
            changePosition();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
