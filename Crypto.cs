using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using TranScript;
//
//    var crypto = Crypto.FromJson(jsonString);

namespace TranScript
{
    public partial class Crypto
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
        public string Symbol { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("localization", NullValueHandling = NullValueHandling.Ignore)]
        public Localization Localization { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Image Image { get; set; }

        [JsonProperty("market_data", NullValueHandling = NullValueHandling.Ignore)]
        public MarketData MarketData { get; set; }

        [JsonProperty("community_data", NullValueHandling = NullValueHandling.Ignore)]
        public CommunityData CommunityData { get; set; }

        [JsonProperty("developer_data", NullValueHandling = NullValueHandling.Ignore)]
        public DeveloperData DeveloperData { get; set; }

        [JsonProperty("public_interest_stats", NullValueHandling = NullValueHandling.Ignore)]
        public PublicInterestStats PublicInterestStats { get; set; }
    }

    public partial class CommunityData
    {
        [JsonProperty("facebook_likes", NullValueHandling = NullValueHandling.Ignore)]
        public object FacebookLikes { get; set; }

        [JsonProperty("twitter_followers", NullValueHandling = NullValueHandling.Ignore)]
        public long TwitterFollowers { get; set; }

        [JsonProperty("reddit_average_posts_48h", NullValueHandling = NullValueHandling.Ignore)]
        public decimal RedditAveragePosts48H { get; set; }

        [JsonProperty("reddit_average_comments_48h", NullValueHandling = NullValueHandling.Ignore)]
        public decimal RedditAverageComments48H { get; set; }

        [JsonProperty("reddit_subscribers", NullValueHandling = NullValueHandling.Ignore)]
        public long RedditSubscribers { get; set; }

        [JsonProperty("reddit_accounts_active_48h", NullValueHandling = NullValueHandling.Ignore)]
        public string RedditAccountsActive48H { get; set; }
    }

    public partial class DeveloperData
    {
        [JsonProperty("forks", NullValueHandling = NullValueHandling.Ignore)]
        public long Forks { get; set; }

        [JsonProperty("stars", NullValueHandling = NullValueHandling.Ignore)]
        public long Stars { get; set; }

        [JsonProperty("subscribers", NullValueHandling = NullValueHandling.Ignore)]
        public long Subscribers { get; set; }

        [JsonProperty("total_issues", NullValueHandling = NullValueHandling.Ignore)]
        public long TotalIssues { get; set; }

        [JsonProperty("closed_issues", NullValueHandling = NullValueHandling.Ignore)]
        public long ClosedIssues { get; set; }

        [JsonProperty("pull_requests_merged", NullValueHandling = NullValueHandling.Ignore)]
        public long PullRequestsMerged { get; set; }

        [JsonProperty("pull_request_contributors", NullValueHandling = NullValueHandling.Ignore)]
        public long PullRequestContributors { get; set; }

        [JsonProperty("commit_count_4_weeks", NullValueHandling = NullValueHandling.Ignore)]
        public long CommitCount4_Weeks { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("thumb", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Thumb { get; set; }

        [JsonProperty("small", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Small { get; set; }
    }

    public partial class Localization
    {
        [JsonProperty("en", NullValueHandling = NullValueHandling.Ignore)]
        public string En { get; set; }

        [JsonProperty("es", NullValueHandling = NullValueHandling.Ignore)]
        public string Es { get; set; }

        [JsonProperty("de", NullValueHandling = NullValueHandling.Ignore)]
        public string De { get; set; }

        [JsonProperty("nl", NullValueHandling = NullValueHandling.Ignore)]
        public string Nl { get; set; }

        [JsonProperty("pt", NullValueHandling = NullValueHandling.Ignore)]
        public string Pt { get; set; }

        [JsonProperty("fr", NullValueHandling = NullValueHandling.Ignore)]
        public string Fr { get; set; }

        [JsonProperty("it", NullValueHandling = NullValueHandling.Ignore)]
        public string It { get; set; }

        [JsonProperty("hu", NullValueHandling = NullValueHandling.Ignore)]
        public string Hu { get; set; }

        [JsonProperty("ro", NullValueHandling = NullValueHandling.Ignore)]
        public string Ro { get; set; }

        [JsonProperty("sv", NullValueHandling = NullValueHandling.Ignore)]
        public string Sv { get; set; }

        [JsonProperty("pl", NullValueHandling = NullValueHandling.Ignore)]
        public string Pl { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("zh", NullValueHandling = NullValueHandling.Ignore)]
        public string Zh { get; set; }

        [JsonProperty("zh-tw", NullValueHandling = NullValueHandling.Ignore)]
        public string ZhTw { get; set; }

        [JsonProperty("ja", NullValueHandling = NullValueHandling.Ignore)]
        public string Ja { get; set; }

        [JsonProperty("ko", NullValueHandling = NullValueHandling.Ignore)]
        public string Ko { get; set; }

        [JsonProperty("ru", NullValueHandling = NullValueHandling.Ignore)]
        public string Ru { get; set; }

        [JsonProperty("ar", NullValueHandling = NullValueHandling.Ignore)]
        public string Ar { get; set; }

        [JsonProperty("th", NullValueHandling = NullValueHandling.Ignore)]
        public string Th { get; set; }

        [JsonProperty("vi", NullValueHandling = NullValueHandling.Ignore)]
        public string Vi { get; set; }

        [JsonProperty("tr", NullValueHandling = NullValueHandling.Ignore)]
        public string Tr { get; set; }
    }

    public partial class MarketData
    {
        [JsonProperty("current_price", NullValueHandling = NullValueHandling.Ignore)]
        public CurrentPrice CurrentPrice { get; set; }

        [JsonProperty("market_cap", NullValueHandling = NullValueHandling.Ignore)]
        public CurrentPrice MarketCap { get; set; }

        [JsonProperty("total_volume", NullValueHandling = NullValueHandling.Ignore)]
        public CurrentPrice TotalVolume { get; set; }
    }

    public partial class CurrentPrice
    {
        [JsonProperty("aed", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Aed { get; set; }

        [JsonProperty("ars", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Ars { get; set; }

        [JsonProperty("aud", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Aud { get; set; }

        [JsonProperty("bch", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Bch { get; set; }

        [JsonProperty("bdt", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Bdt { get; set; }

        [JsonProperty("bhd", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Bhd { get; set; }

        [JsonProperty("bmd", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Bmd { get; set; }

        [JsonProperty("bnb", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Bnb { get; set; }

        [JsonProperty("brl", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Brl { get; set; }

        [JsonProperty("btc", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Btc { get; set; }

        [JsonProperty("cad", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Cad { get; set; }

        [JsonProperty("chf", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Chf { get; set; }

        [JsonProperty("clp", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Clp { get; set; }

        [JsonProperty("cny", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Cny { get; set; }

        [JsonProperty("czk", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Czk { get; set; }

        [JsonProperty("dkk", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Dkk { get; set; }

        [JsonProperty("eos", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Eos { get; set; }

        [JsonProperty("eth", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Eth { get; set; }

        [JsonProperty("eur", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Eur { get; set; }

        [JsonProperty("gbp", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Gbp { get; set; }

        [JsonProperty("hkd", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Hkd { get; set; }

        [JsonProperty("huf", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Huf { get; set; }

        [JsonProperty("idr", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Idr { get; set; }

        [JsonProperty("ils", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Ils { get; set; }

        [JsonProperty("inr", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Inr { get; set; }

        [JsonProperty("jpy", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Jpy { get; set; }

        [JsonProperty("krw", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Krw { get; set; }

        [JsonProperty("kwd", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Kwd { get; set; }

        [JsonProperty("lkr", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Lkr { get; set; }

        [JsonProperty("ltc", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Ltc { get; set; }

        [JsonProperty("mmk", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Mmk { get; set; }

        [JsonProperty("mxn", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Mxn { get; set; }

        [JsonProperty("myr", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Myr { get; set; }

        [JsonProperty("nok", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Nok { get; set; }

        [JsonProperty("nzd", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Nzd { get; set; }

        [JsonProperty("php", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Php { get; set; }

        [JsonProperty("pkr", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Pkr { get; set; }

        [JsonProperty("pln", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Pln { get; set; }

        [JsonProperty("rub", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Rub { get; set; }

        [JsonProperty("sar", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Sar { get; set; }

        [JsonProperty("sek", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Sek { get; set; }

        [JsonProperty("sgd", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Sgd { get; set; }

        [JsonProperty("thb", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Thb { get; set; }

        [JsonProperty("try", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Try { get; set; }

        [JsonProperty("twd", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Twd { get; set; }

        [JsonProperty("usd", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Usd { get; set; }

        [JsonProperty("vef", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Vef { get; set; }

        [JsonProperty("vnd", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Vnd { get; set; }

        [JsonProperty("xag", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Xag { get; set; }

        [JsonProperty("xau", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Xau { get; set; }

        [JsonProperty("xdr", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Xdr { get; set; }

        [JsonProperty("xlm", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Xlm { get; set; }

        [JsonProperty("xrp", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Xrp { get; set; }

        [JsonProperty("zar", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Zar { get; set; }
    }

    public partial class PublicInterestStats
    {
        [JsonProperty("alexa_rank", NullValueHandling = NullValueHandling.Ignore)]
        public long AlexaRank { get; set; }

        [JsonProperty("bing_matches", NullValueHandling = NullValueHandling.Ignore)]
        public long BingMatches { get; set; }
    }

    public partial class Crypto
    {
        public static Crypto FromJson(string json) => JsonConvert.DeserializeObject<Crypto>(json, TranScript.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Crypto self) => JsonConvert.SerializeObject(self, TranScript.Converter.Settings);
    }

    internal static class Converter
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
