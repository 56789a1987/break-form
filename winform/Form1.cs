using System;
using System.Drawing;
using System.Windows.Forms;

namespace winform
{
    public partial class Form1 : Form
    {
        Point defPos;
        double xspeed;
        int yspeed = -5;
        int score = 0;
        double ballx;

        public Form1()
        {
            InitializeComponent();
            defPos = new Point(ball.Location.X, ball.Location.Y);
            ballx = ball.Location.X;
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            Point curPos = panel.PointToClient(MousePosition);
            int x = curPos.X - (board.Size.Width / 2);
            if (x < 0) x = 0;
            if (x + board.Size.Width > panel.Size.Width) x = panel.Size.Width - board.Size.Width;
            Point bloc = new Point(x, board.Location.Y);
            board.Location = bloc;
            if (defTimer.Enabled == false) {
                ball.Location = new Point(x + (board.Size.Width / 2) - (ball.Size.Width / 2), defPos.Y);
                ballx = ball.Location.X;
            }
        }
        private void defTimer_Tick(object sender, EventArgs e)
        {
            bool end = false;
            double bx = ballx;
            int by = ball.Location.Y;
            int bh = ball.Size.Height;
            int bw = ball.Size.Width;
            int bdx = board.Location.X;
            int bdy = board.Location.Y;
            int bdw = board.Size.Width;
            if (by + yspeed < 0) yspeed = -yspeed;
            if (by + bh + yspeed > bdy)
            {
                if (bx + bw > bdx && bx < bdx + bdw && yspeed > 0)
                {
                    yspeed = -yspeed;
                    xspeed = (bx + bw / 2 - bdx - bdw / 2) * 0.1;
                }
            }
            if(by > panel.Size.Height)
            {
                defTimer.Stop();
                score = 0;
                scshow.Text = score.ToString();
                end = true;
                clearBlocks();
                addBlocks();
            }
            if (bx + xspeed < 0) xspeed = -xspeed;
            if (bx + bw + xspeed > panel.Size.Width) xspeed = -xspeed;
            int lth = 0;
            foreach (Control c in panel.Controls)
            {
                if (c.Name.IndexOf("block") != -1)
                {
                    lth++;
                    int tx = c.Location.X;
                    int ty = c.Location.Y;
                    if (bx + bw >= tx && bx <= tx + 14 && by + bh >= ty && by <= ty + 14)
                    {
                        if (bx - xspeed > tx + 14 && xspeed <= 0 || xspeed > 0 && bx + bw - xspeed < tx) xspeed = -xspeed;
                        if (by - yspeed > ty + 14 && yspeed <= 0 || yspeed > 0 && by + bh - yspeed < ty) yspeed = -yspeed;
                        System.Media.SystemSounds.Beep.Play();
                        score++;
                        scshow.Text = score.ToString();
                        if(c is CheckBox)
                        {
                            CheckBox cb = c as CheckBox;
                            cb.Checked = false;
                        }
                        if (c is RadioButton)
                        {
                            RadioButton rb = c as RadioButton;
                            rb.Checked = false;
                        }
                        c.BringToFront();
                        int r = new Random(int.Parse(c.Name.Replace("block", "")) + DateTime.Now.Millisecond + DateTime.Now.Second).Next(-3, 3);
                        c.Name = c.Name.Replace("block", "drop") + "," + r.ToString() + ",0";
                    }
                }
                if (c.Name.IndexOf("drop") != -1)
                {
                    string[] dl = c.Name.Split(',');
                    double xs = double.Parse(dl[1]);
                    double ys = double.Parse(dl[2]);
                    int cx = c.Location.X;
                    int cy = c.Location.Y;
                    ys += 0.3;
                    cx += (int)xs;
                    cy += (int)ys;
                    c.Name = dl[0] + "," + dl[1] + "," + ys.ToString();
                    c.Location = new Point(cx, cy);
                    if (cy > panel.Size.Height) panel.Controls.Remove(c);
                }
            }
            if (lth == 0) addBlocks();
            ballx += xspeed;
            Point newPos = new Point((int)ballx, by + yspeed);
            if (end == false)
            {
                ball.Location = newPos;
            }
            else
            {
                ball.Location = new Point(defPos.X, defPos.Y);
                yspeed = -5;
            }
        }

        private void panel_Click(object sender, EventArgs e)
        {
            board.Focus();
            if (defTimer.Enabled == false)
            { 
                xspeed = new Random().Next(-5, 5);
                defTimer.Start();
            }
        }

        void addBlocks()
        {
            int row = 0;
            for (int i = 0; i < 340; i++)
            {
                int type = new Random(i + DateTime.Now.Millisecond + DateTime.Now.Second).Next(10);
                if (i % 34 == 0 && i != 0) row++;
                if (type < 5)
                {
                    CheckBox elem = new CheckBox();
                    elem.Name = "block" + i.ToString();
                    elem.Checked = true;
                    elem.Margin = new Padding(0);
                    elem.Size = new Size(14, 14);
                    elem.TabIndex = 1;
                    elem.TabStop = false;
                    elem.Location = new Point(i % 34 * 16, row * 16);
                    elem.Click += new EventHandler(panel_Click);
                    elem.MouseMove += new MouseEventHandler(panel_MouseMove);
                    panel.Controls.Add(elem);
                }
                else
                {
                    RadioButton elem = new RadioButton();
                    elem.Name = "block" + i.ToString();
                    elem.Checked = true;
                    elem.Margin = new Padding(0);
                    elem.Size = new Size(14, 14);
                    elem.TabIndex = 1;
                    elem.TabStop = false;
                    elem.Location = new Point(i % 34 * 16, row * 16);
                    elem.Click += new EventHandler(panel_Click);
                    elem.MouseMove += new MouseEventHandler(panel_MouseMove);
                    panel.Controls.Add(elem);
                }
            }
        }
        void clearBlocks()
        {
            int l = 1;
            while(l > 0) {
                l = 0;
                foreach (Control c in this.panel.Controls)
                {
                    if (c.Name.IndexOf("block") != -1)
                    {
                        panel.Controls.Remove(c);
                        l++;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addBlocks();
        }
    }
}
