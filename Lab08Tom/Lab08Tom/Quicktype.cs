// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = GettingStarted.FromJson(jsonString);
//
// For POCOs visit quicktype.io?poco
//
namespace QuickType
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class GettingStarted
    {
        [JsonProperty("greeting")]
        public string Greeting { get; set; }

        [JsonProperty("instructions")]
        public string[] Instructions { get; set; }
    }


    public partial class GettingStarted
    {
        public static GettingStarted FromJson(string json)
        {
            return JsonConvert.DeserializeObject<GettingStarted>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this GettingStarted self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}