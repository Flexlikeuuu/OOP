using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using lab2.Interfaces;
using lab2.Models.Shapes;

namespace lab2.Models
{
    public class DrawingModel
    {
        private readonly Stack<IShape> _shapes = new Stack<IShape>();
        private readonly Stack<IShape> _redoStack = new Stack<IShape>();

        public Color StrokeColor { get; set; } = Color.Black;
        public Color FillColor { get; set; } = Color.Transparent;
        public float StrokeWidth { get; set; } = 2f;
        public DashStyle LineStyle { get; set; } = DashStyle.Solid;
        public bool IsFilling { get; set; }

        public void AddShape(IShape shape)
        {
            shape.StrokeColor = StrokeColor;
            shape.FillColor = IsFilling ? FillColor : Color.Transparent;
            shape.StrokeWidth = StrokeWidth;
            shape.LineStyle = LineStyle;
            _shapes.Push(shape);
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_shapes.Count > 0)
            {
                _redoStack.Push(_shapes.Pop());
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                _shapes.Push(_redoStack.Pop());
            }
        }

        public void Clear()
        {
            _shapes.Clear();
            _redoStack.Clear();
        }

        public void DrawAll(Graphics graphics)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(graphics);
            }
        }
    }
}