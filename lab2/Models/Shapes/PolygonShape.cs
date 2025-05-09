using System;
using System.Collections.Generic;
using System.Drawing;
using lab2.Interfaces;
using System.Linq;

namespace lab2.Models.Shapes
{
    public class PolygonShape : BaseShape
    {
        public override string Type => "Polygon";

        public List<Point> Points { get; } = new List<Point>();

        public override Dictionary<string, object> Serialize()
        {
            var dict = base.Serialize();
            dict["Points"] = Points.Select(p => new { X = p.X, Y = p.Y }).ToList();
            return dict;
        }

        public override void Deserialize(Dictionary<string, object> data)
        {
            base.Deserialize(data);
            Points.Clear();
            foreach (var point in (IEnumerable<dynamic>)data["Points"])
            {
                Points.Add(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)));
            }
        }

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