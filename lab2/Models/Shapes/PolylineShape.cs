using System.Collections.Generic;
using System.Drawing;
using lab2.Interfaces;

namespace lab2.Models.Shapes
{
    public class PolylineShape : BaseShape
    {
        public List<Point> Points { get; } = new List<Point>();

        public override void Draw(Graphics graphics)
        {
            if (Points.Count < 2) return;

            using (var pen = CreatePen())
            {
                graphics.DrawLines(pen, Points.ToArray());
            }
        }
    }
}