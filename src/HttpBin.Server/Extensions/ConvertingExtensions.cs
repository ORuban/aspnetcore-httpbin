using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;

namespace HttpBin.Server.Extensions
{
    public static class ConvertingExtensions
    {
        public static JObject ToJObject(this IEnumerable<KeyValuePair<string, StringValues>> collection)
        {
            JObject result = new JObject();
            
            foreach(var item in collection)
            {
                result.Add(item.Key, item.Value.ToString());
            }

            return result;
        }

        public static JObject ToJObject(this IEnumerable<KeyValuePair<string, string>> collection)
        {
            JObject result = new JObject();
            
            foreach(var item in collection)
            {
                result.Add(item.Key, item.Value);
            }

            return result;
        }
    }
}