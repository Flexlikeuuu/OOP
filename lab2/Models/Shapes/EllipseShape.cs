using System.Drawing;
using lab2.Interfaces;

namespace lab2.Models.Shapes
{
    public class EllipseShape : BaseShape
    {
        public override void Draw(Graphics graphics)
        {
            var rect = GetBoundingRectangle();
            using (var pen = CreatePen())
            {
                graphics.DrawEllipse(pen, rect);
                if (FillColor != Color.Transparent)
                {
                    using (var brush = new SolidBrush(FillColor))
                    {
                        graphics.FillEllipse(brush, rect);
                    }
                }
            }
        }
    }
}