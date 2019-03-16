using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using TranScript;
//
//    var listeCrypto = ListCrypto.FromJson(jsonString);

namespace TranScript
{
    public partial class ListCrypto
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
        public string Symbol { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class ListCrypto
    {
        public static List<ListCrypto> FromJson(string json) => JsonConvert.DeserializeObject<List<ListCrypto>>(json, TranScript.Converter2.Settings);
    }

    public static class Serialize2
    {
        public static string ToJson(this List<ListCrypto> self) => JsonConvert.SerializeObject(self, TranScript.Converter2.Settings);
    }

    internal static class Converter2
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
