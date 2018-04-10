using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace MsPaint
{

    class Triangle
    {
        public Point prev, cur;

        public Triangle(Point prev, Point cur)
        {
            this.prev = prev;
            this.cur = cur;
        }
        public void Draw(Graphics e, Pen pen)
        {
            if (prev.X < cur.X && prev.Y < cur.Y)
            {
                e.DrawLine(pen, prev.X, cur.Y, cur.X, cur.Y);
                e.DrawLine(pen, cur.X, cur.Y, (cur.X + prev.X) / 2, prev.Y);
                e.DrawLine(pen, prev.X, cur.Y, (cur.X + prev.X) / 2, prev.Y);
            }
            if (prev.X > cur.X && prev.Y > cur.Y)
            {
                e.DrawLine(pen, prev.X, prev.Y, cur.X, prev.Y);
                e.DrawLine(pen, cur.X, prev.Y, (cur.X + prev.X) / 2, cur.Y);
                e.DrawLine(pen, prev.X, prev.Y, (cur.X + prev.X) / 2, cur.Y);
            }
            if (prev.X < cur.X && prev.Y > cur.Y)
            {
                e.DrawLine(pen, prev.X, prev.Y, cur.X, prev.Y);
                e.DrawLine(pen, cur.X, prev.Y, (cur.X + prev.X) / 2, cur.Y);
                e.DrawLine(pen, prev.X, prev.Y, (cur.X + prev.X) / 2, cur.Y);
            }
            if (prev.X > cur.X && prev.Y < cur.Y)
            {
                e.DrawLine(pen, prev.X, cur.Y, cur.X, cur.Y);
                e.DrawLine(pen, cur.X, cur.Y, (cur.X + prev.X) / 2, prev.Y);
                e.DrawLine(pen, prev.X, cur.Y, (cur.X + prev.X) / 2, prev.Y);
            }
        }
    }
}
