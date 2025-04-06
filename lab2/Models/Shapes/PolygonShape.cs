using System.Collections.Generic;
using System.Drawing;
using lab2.Interfaces;

namespace lab2.Models.Shapes
{
    public class PolygonShape : BaseShape
    {
        public List<Point> Points { get; } = new List<Point>();

        public override void Draw(Graphics graphics)
        {
            if (Points.Count < 3) return;

            using (var pen = CreatePen())
            {
                graphics.DrawPolygon(pen, Points.ToArray());
                if (FillColor != Color.Transparent)
                {
                    using (var brush = new SolidBrush(FillColor))
                    {
                        graphics.FillPolygon(brush, Points.ToArray());
                    }
                }
            }
        }
    }
}