using System;
using System.Drawing;
using lab2.Interfaces;
using System.Collections.Generic;

namespace lab2.Models.Shapes
{
    public class EllipseShape : BaseShape
    {
        public override string Type => "Ellipse";

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

        private Rectangle GetBoundingRectangle()
        {
            return new Rectangle(
                Math.Min(StartPoint.X, EndPoint.X),
                Math.Min(StartPoint.Y, EndPoint.Y),
                Math.Abs(EndPoint.X - StartPoint.X),
                Math.Abs(EndPoint.Y - StartPoint.Y));
        }
    }
}