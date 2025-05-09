using lab2.Interfaces;
using lab2.Models.Shapes;

namespace lab2.Factories
{
    public interface IShapeFactory
    {
        IShape CreateShape(string shapeType);
        void RegisterShape(string shapeType, System.Func<IShape> creator);
    }
}