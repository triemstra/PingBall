using System;
using System.Drawing;
using System.Windows.Forms;

using PingBallWorkspace;

namespace ObjectMoving
{
    public partial class FormView : Form
    {
        private int _x;
        private int _y;

        private PingBall _pingBall = new PingBall();

        public FormView()
        {
            InitializeComponent();
        }

        private void FormView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, _x, _y, 5, 5);
        }

        private void tmrMoving_Tick(object sender, EventArgs e)
        {
            Point p = _pingBall.GetNewPosition();

            _x = p.X;
            _y = p.Y;

            Invalidate();
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            
        }
    }
}
