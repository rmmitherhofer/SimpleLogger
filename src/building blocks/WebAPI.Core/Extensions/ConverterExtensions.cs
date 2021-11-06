using System.Collections.Generic;
using System.Text.Json;

namespace WebAPI.Core.Extensions
{
    public static class ConverterExtensions
    {
        public static string ToJson(this object obj)
        {
            if (obj == null) return null;

            return JsonSerializer.Serialize(obj);
        }

        public static IDictionary<string, string> ToDictionary(this string value){
            if (string.IsNullOrEmpty(value)) return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>>(value);
        }
    }
}
