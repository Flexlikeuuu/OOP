using System;
using System.Drawing;
using lab2.Interfaces;
using System.Collections.Generic;

namespace lab2.Models.Shapes
{
    public class RectangleShape : BaseShape
    {
        public override string Type => "Rectangle";

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