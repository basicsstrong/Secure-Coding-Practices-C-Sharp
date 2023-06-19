using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class VulnerableComponents{

    public static void Trigger()
    {
        Employee employee = new Employee
        {
            Name = "John",
            Age = 25
        };

        string serializedData = GetSerializeData(employee);
        object deserializedObject = DeserializeData(serializedData);

    }

    public static string GetSerializeData(Object obj)
    {       
        byte[] personBytes;
        BinaryFormatter formatter = new ();
        using (MemoryStream memoryStream = new ())
        {
            // formatter.Serialize(memoryStream, obj);
            personBytes = memoryStream.ToArray();
        }
        
        return Convert.ToBase64String(personBytes);
    }
    
    public static object DeserializeData(string serializedData)
    {
        BinaryFormatter formatter = new ();
        byte[] dataBytes = Convert.FromBase64String(serializedData);
        
        using (MemoryStream memoryStream = new (dataBytes))
        {
        //  object deserializedObject = formatter.Deserialize(memoryStream);
        //    return deserializedObject;
        return new();
        }
    }
    
    public static string GetSerializedDataFromUntrustedSource()
    {
        // In a real scenario, this data could come from an untrusted source,
        // such as user input or an external data source.
        return "{base64-encoded-serialized-data}";
    }

}