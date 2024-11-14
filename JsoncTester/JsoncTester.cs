using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Global;

public class JsoncTester
{
    public static bool JsonEquals(string json1, string json2)
    {
        var o1 = FromJson(json1);
        var o2 = FromJson(json2);
        return JObject.DeepEquals(o1, o2);
    }
    //
    public static bool DeepEquals(object x, object y)
    {
        var o1 = FromObject(x);
        var o2 = FromObject(y);
        return JObject.DeepEquals(o1, o2);
    }
    public static string ToJson(dynamic x, bool indent = false)
    {
        return JsonConvert.SerializeObject(x, indent ? Formatting.Indented : Formatting.None);
    }
    public static dynamic? FromJson(string json)
    {
        if (String.IsNullOrEmpty(json)) return null;
        return JsonConvert.DeserializeObject(json, new JsonSerializerSettings
        {
            DateParseHandling = DateParseHandling.None
        });
    }
    public static dynamic? FromObject(dynamic x)
    {
        if (x == null) return null;
        var o = (dynamic)JObject.FromObject(new { x = x },
            new JsonSerializer
            {
                DateParseHandling = DateParseHandling.None
            });
        return o.x;
    }
}
