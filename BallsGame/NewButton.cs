
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GameOfLife
{
    internal class NewButton
    {

        Panel mainPanel;

        public NewButton(Panel mainPanel)
        {
            this.mainPanel = mainPanel;
        }

        public void addButton(int i, int j, int size)
        {
            Button b = new Button();
            b.Location = new Point(i * size, j * size);
            b.Size = new Size(size, size);
            b.TabIndex = 0;
            b.Tag = new Point(i, j);
            b.FlatStyle = FlatStyle.Flat;
            b.Name = new Point(i, j).ToString();
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = Color.FromArgb(-9999726);
            GraphicsPath grp = new GraphicsPath();
            grp.AddEllipse(0,0,b.Width-3,b.Height-3);
            b.Region=new Region(grp);
            mainPanel.Controls.Add(b);
        }

        
    }
       
}
