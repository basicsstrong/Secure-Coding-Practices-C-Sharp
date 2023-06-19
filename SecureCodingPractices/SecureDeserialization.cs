using Newtonsoft.Json;

namespace SecureCodingPractices{
class SerializationDemo
{
        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None })!;
        }
}
}


