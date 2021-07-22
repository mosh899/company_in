using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCompanyIn.Utils
{
    public static class Utils
    {
        public static string GetNestedObject(this Dictionary<string, object> parentObject, string parentKey, string childKey)
        {
            if (!parentObject.ContainsKey(parentKey))
                return string.Empty;

            var nestedObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(parentObject[parentKey].ToString());
            return GetKey(nestedObj, childKey)?.ToString();
        }

        public static object GetKey(this Dictionary<string, object> parentObject, string key) =>
            parentObject.ContainsKey(key) ? parentObject[key] : string.Empty;
    }
}
