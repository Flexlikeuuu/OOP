using System.Drawing;
using System.Drawing.Drawing2D;
using lab2.Interfaces;

namespace lab2.Models.Shapes
{
    public abstract class BaseShape : IShape
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
    }
}