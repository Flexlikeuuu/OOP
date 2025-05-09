using System.Collections.Generic;
using System.Drawing;
using lab2.Interfaces;
using System.Collections.Generic;

namespace lab2.Models.Shapes
{
    public class PolylineShape : BaseShape
    {
        public List<Point> Points { get; } = new List<Point>();

        public override string Type => "Polyline";

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
            if (Points.Count < 2) return;

            using (var pen = CreatePen())
            {
                graphics.DrawLines(pen, Points.ToArray());
            }
        }
    }
}