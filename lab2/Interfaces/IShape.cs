using System.Drawing;
using System.Drawing.Drawing2D;

namespace lab2.Interfaces
{
    public interface IShape : IDrawable
    {
        Color StrokeColor { get; set; }
        Color FillColor { get; set; }
        float StrokeWidth { get; set; }
        DashStyle LineStyle { get; set; }
        Point StartPoint { get; set; }
        Point EndPoint { get; set; }
    }
}