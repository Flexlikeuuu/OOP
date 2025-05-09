using System;
using System.Collections.Generic;
using lab2.Interfaces;
using lab2.Models.Shapes;

namespace lab2.Factories
{
    public class ShapeFactory : IShapeFactory
    {
        private readonly Dictionary<string, Func<IShape>> _creators = new Dictionary<string, Func<IShape>>();

        public IShape CreateShape(string shapeType)
        {
            if (_creators.TryGetValue(shapeType, out var creator))
            {
                return creator();
            }
            throw new ArgumentException($"Unknown shape type: {shapeType}");
        }

        public void RegisterShape(string shapeType, Func<IShape> creator)
        {
            _creators[shapeType] = creator;
        }
    }
}