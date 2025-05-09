using System;
using System.Drawing;
using lab2.Interfaces;
using System.Collections.Generic;

namespace lab2.Models.Shapes
{
    public class LineShape : BaseShape
    {
        public override string Type => "Line";

        public override void Draw(Graphics graphics)
        {
            using (var pen = CreatePen())
            {
                graphics.DrawLine(pen, StartPoint, EndPoint);
            }
        }
    }
}