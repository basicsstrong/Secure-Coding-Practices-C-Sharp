using SecureCodingPractices;
using Newtonsoft.Json;

class InsecureDeserialization
{
    public static void Trigger()
    {
        Employee person = new Employee
        {
            Name = "John",
            Age = 25
        };

        string serializedData = SerializationDemo.Serialize(person);
        Employee deserializedObject = SerializationDemo.Deserialize<Employee>(serializedData);
        Console.WriteLine("here is the employee with name {0} and age {1}",deserializedObject.Name, deserializedObject.Age );

    }

    public static string Serialize(object obj) {
    return JsonConvert.SerializeObject(obj);
    }

    public static object Deserialize(string json)
    {
        return JsonConvert.DeserializeObject<object>(json,
            new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!; //$type
    }
    
}

[Serializable]
class Employee
{
    public string? Name { get; set; }
    public int Age { get; set; }
}
