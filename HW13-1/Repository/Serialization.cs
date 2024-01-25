using HW13_1.Entities;
using Newtonsoft.Json;
using System.Net;

namespace HW13_1.Repository;

public class Serialization
{
    public Serialization(string path)
    {
        this.path = path;
    }

    private readonly string path;

    public void SaveToFileWhitWrite<T>(List<T> obg)
    {
        var stringObg = JsonConvert.SerializeObject(obg, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
        File.WriteAllText(path, stringObg);
    }

    public List<T> ReadFromFile<T>()
    {
        if (File.Exists(path))
        {
            var fileData = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<List<T>>(fileData);
            return result;
        }
        else
        {
            File.Create(path).Close();
            var fileData = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<List<T>>(fileData);
            return result;
        }
    }
}
