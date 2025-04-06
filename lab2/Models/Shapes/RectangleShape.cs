using System.Drawing;
using lab2.Interfaces;

namespace lab2.Models.Shapes
{
    public class RectangleShape : BaseShape
    {
        public override void Draw(Graphics graphics)
        {
            var rect = GetBoundingRectangle();
            using (var pen = CreatePen())
            {
                graphics.DrawRectangle(pen, rect);
                if (FillColor != Color.Transparent)
                {
                    using (var brush = new SolidBrush(FillColor))
                    {
                        graphics.FillRectangle(brush, rect);
                    }
                }
            }
        }
    }
}