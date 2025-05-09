using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using lab2.Interfaces;
using lab2.Models.Shapes;
using Newtonsoft.Json;
using System.Collections.Generic;

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
            shape.FillColor = FillColor; 
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
        public void SaveToFile(string filePath)
        {
            var shapesData = _shapes.Reverse()
                .OfType<ISerializableShape>()
                .Select(s => s.Serialize())
                .ToList();

            string json = JsonConvert.SerializeObject(shapesData, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return;

            string json = File.ReadAllText(filePath);
            var shapesData = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

            if (shapesData == null) return;

            Clear();

            foreach (var shapeData in shapesData)
            {
                IShape shape = CreateShapeFromData(shapeData);
                if (shape != null)
                {
                    AddShape(shape);
                }
            }
        }

        private IShape CreateShapeFromData(Dictionary<string, object> data)
        {
            if (!data.ContainsKey("Type")) return null;

            IShape shape = null;
            switch (data["Type"].ToString())
            {
                case "Line": shape = new LineShape(); break;
                case "Rectangle": shape = new RectangleShape(); break;
                case "Ellipse": shape = new EllipseShape(); break;
                case "Polyline": shape = new PolylineShape(); break;
                case "Polygon": shape = new PolygonShape(); break;
            }

            if (shape is ISerializableShape serializableShape)
            {
                serializableShape.Deserialize(data);
            }

            return shape;
        }
    }
}