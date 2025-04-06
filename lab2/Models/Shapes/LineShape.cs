using System.Drawing;
using lab2.Interfaces;

namespace lab2.Models.Shapes
{
    public class LineShape : BaseShape
    {
        public override void Draw(Graphics graphics)
        {
            using (var pen = CreatePen())
            {
                graphics.DrawLine(pen, StartPoint, EndPoint);
            }
        }
    }
}