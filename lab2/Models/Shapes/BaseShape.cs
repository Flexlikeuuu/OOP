using System.Drawing;
using System.Drawing.Drawing2D;
using lab2.Interfaces;
using System.Collections.Generic;

namespace lab2.Models.Shapes
{
    public abstract class BaseShape : IShape, ISerializableShape
    {
        public Color StrokeColor { get; set; } = Color.Black;
        public Color FillColor { get; set; } = Color.Transparent;
        public float StrokeWidth { get; set; } = 2f;
        public DashStyle LineStyle { get; set; } = DashStyle.Solid;
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public abstract void Draw(Graphics graphics);

        protected Pen CreatePen()
        {
            return new Pen(StrokeColor, StrokeWidth)
            {
                DashStyle = LineStyle
            };
        }
        public abstract string Type { get; }

        public virtual Dictionary<string, object> Serialize()
        {
            return new Dictionary<string, object>
            {
                ["Type"] = Type,
                ["StrokeColor"] = StrokeColor.ToArgb(),
                ["FillColor"] = FillColor.ToArgb(),
                ["StrokeWidth"] = StrokeWidth,
                ["LineStyle"] = (int)LineStyle,
                ["StartPoint"] = new { X = StartPoint.X, Y = StartPoint.Y },
                ["EndPoint"] = new { X = EndPoint.X, Y = EndPoint.Y }
            };
        }

        public virtual void Deserialize(Dictionary<string, object> data)
        {
            StrokeColor = Color.FromArgb(Convert.ToInt32(data["StrokeColor"]));
            FillColor = Color.FromArgb(Convert.ToInt32(data["FillColor"]));
            StrokeWidth = Convert.ToSingle(data["StrokeWidth"]);
            LineStyle = (DashStyle)Convert.ToInt32(data["LineStyle"]);

            var start = (dynamic)data["StartPoint"];
            StartPoint = new Point(Convert.ToInt32(start.X), Convert.ToInt32(start.Y));

            var end = (dynamic)data["EndPoint"];
            EndPoint = new Point(Convert.ToInt32(end.X), Convert.ToInt32(end.Y));
        }
    }
}
   