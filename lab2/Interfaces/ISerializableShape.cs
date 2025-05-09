using System.Collections.Generic;

namespace lab2.Interfaces
{
    public interface ISerializableShape
    {
        string Type { get; }
        Dictionary<string, object> Serialize();
        void Deserialize(Dictionary<string, object> data);
    }
}