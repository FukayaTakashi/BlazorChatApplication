using System.Text.Json;

namespace ChatApplication.Domain.Helperes
{
    public static class JsonHelper
    {
        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static T Deserialize<T>(string jsonString)
        {
            var obj = JsonSerializer.Deserialize<T>(jsonString);
            if (obj == null)
                throw new FormatException();
            return obj;
        }
    }
}
