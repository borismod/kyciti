using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace kyciti.CrunchBase
{
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var welcome = Welcome.FromJson(jsonString);

    namespace QuickType
    {
        public partial class Company
        {
            [JsonProperty("metadata")] public Metadata Metadata { get; set; }

            [JsonProperty("data")] public Data Data { get; set; }
        }

        public class Data
        {
            [JsonProperty("type")] public string Type { get; set; }

            [JsonProperty("uuid")] public string Uuid { get; set; }

            [JsonProperty("properties")] public DataProperties Properties { get; set; }

            [JsonProperty("relationships")] public DataRelationships Relationships { get; set; }
        }

        public class DataProperties
        {
            [JsonProperty("permalink")] public string Permalink { get; set; }

            [JsonProperty("api_path")] public string ApiPath { get; set; }

            [JsonProperty("web_path")] public string WebPath { get; set; }

            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("also_known_as")] public string[] AlsoKnownAs { get; set; }

            [JsonProperty("short_description")] public string ShortDescription { get; set; }

            [JsonProperty("description")] public string Description { get; set; }

            [JsonProperty("profile_image_url")] public string ProfileImageUrl { get; set; }

            [JsonProperty("primary_role")] public string PrimaryRole { get; set; }

            [JsonProperty("role_company")] public bool? RoleCompany { get; set; }

            [JsonProperty("role_investor")] public bool? RoleInvestor { get; set; }

            [JsonProperty("role_group")] public bool? RoleGroup { get; set; }

            [JsonProperty("role_school")] public object RoleSchool { get; set; }

            [JsonProperty("founded_on")] public DateTimeOffset FoundedOn { get; set; }

            [JsonProperty("founded_on_trust_code")]
            public long FoundedOnTrustCode { get; set; }

            [JsonProperty("is_closed")] public bool IsClosed { get; set; }

            [JsonProperty("closed_on")] public object ClosedOn { get; set; }

            [JsonProperty("closed_on_trust_code")] public long ClosedOnTrustCode { get; set; }

            [JsonProperty("num_employees_min")] public long? NumEmployeesMin { get; set; }

            [JsonProperty("num_employees_max")] public long? NumEmployeesMax { get; set; }

            [JsonProperty("stock_exchange")] public object StockExchange { get; set; }

            [JsonProperty("stock_symbol")] public object StockSymbol { get; set; }

            [JsonProperty("total_funding_usd")] public long TotalFundingUsd { get; set; }

            [JsonProperty("number_of_investments")]
            public long NumberOfInvestments { get; set; }

            [JsonProperty("homepage_url")] public string HomepageUrl { get; set; }

            [JsonProperty("created_at")] public long CreatedAt { get; set; }

            [JsonProperty("updated_at")] public long UpdatedAt { get; set; }
        }

        public class DataRelationships
        {
            [JsonProperty("primary_image")] public PrimaryImage PrimaryImage { get; set; }

            [JsonProperty("founders")] public Acquisitions Founders { get; set; }

            [JsonProperty("current_team")] public Acquisitions CurrentTeam { get; set; }

            [JsonProperty("past_team")] public Acquisitions PastTeam { get; set; }

            [JsonProperty("board_members_and_advisors")]
            public Acquisitions BoardMembersAndAdvisors { get; set; }

            [JsonProperty("investors")] public Acquisitions Investors { get; set; }

            [JsonProperty("owned_by")] public AcquiredBy OwnedBy { get; set; }

            [JsonProperty("sub_organizations")] public Acquisitions SubOrganizations { get; set; }

            [JsonProperty("offices")] public Acquisitions Offices { get; set; }

            [JsonProperty("headquarters")] public Headquarters Headquarters { get; set; }

            [JsonProperty("products")] public Acquisitions Products { get; set; }

            [JsonProperty("categories")] public Acquisitions Categories { get; set; }

            [JsonProperty("customers")] public Acquisitions Customers { get; set; }

            [JsonProperty("competitors")] public Acquisitions Competitors { get; set; }

            [JsonProperty("memberships")] public AcquiredBy Memberships { get; set; }

            [JsonProperty("members")] public Acquisitions Members { get; set; }

            [JsonProperty("funding_rounds")] public Acquisitions FundingRounds { get; set; }

            [JsonProperty("investments")] public Acquisitions Investments { get; set; }

            [JsonProperty("acquisitions")] public Acquisitions Acquisitions { get; set; }

            [JsonProperty("acquired_by")] public AcquiredBy AcquiredBy { get; set; }

            [JsonProperty("ipo")] public AcquiredBy Ipo { get; set; }

            [JsonProperty("funds")] public Acquisitions Funds { get; set; }

            [JsonProperty("websites")] public Acquisitions Websites { get; set; }

            [JsonProperty("images")] public Acquisitions Images { get; set; }

            [JsonProperty("videos")] public Acquisitions Videos { get; set; }

            [JsonProperty("news")] public Acquisitions News { get; set; }
        }

        public class AcquiredBy
        {
            [JsonProperty("cardinality")] public string Cardinality { get; set; }

            [JsonProperty("paging")] public Paging Paging { get; set; }
        }

        public class Paging
        {
            [JsonProperty("total_items")] public long TotalItems { get; set; }

            [JsonProperty("first_page_url")] public string FirstPageUrl { get; set; }

            [JsonProperty("sort_order")] public SortOrder SortOrder { get; set; }
        }

        public class Acquisitions
        {
            [JsonProperty("cardinality")] public Cardinality Cardinality { get; set; }

            [JsonProperty("paging")] public Paging Paging { get; set; }

            [JsonProperty("items")] public ItemElement[] Items { get; set; }
        }

        public class ItemElement
        {
            [JsonProperty("type")] public string Type { get; set; }

            [JsonProperty("uuid")] public string Uuid { get; set; }

            [JsonProperty("properties")] public PurpleProperties Properties { get; set; }

            [JsonProperty("relationships")] public ItemRelationships Relationships { get; set; }
        }

        public class PurpleProperties
        {
            [JsonProperty("permalink")] public string Permalink { get; set; }

            [JsonProperty("api_path")] public string ApiPath { get; set; }

            [JsonProperty("web_path")] public string WebPath { get; set; }

            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("also_known_as")] public string[] AlsoKnownAs { get; set; }

            [JsonProperty("short_description")] public string ShortDescription { get; set; }

            [JsonProperty("description")] public string Description { get; set; }

            [JsonProperty("profile_image_url")] public string ProfileImageUrl { get; set; }

            [JsonProperty("primary_role")] public string PrimaryRole { get; set; }

            [JsonProperty("role_company")] public bool? RoleCompany { get; set; }

            [JsonProperty("role_investor")] public bool? RoleInvestor { get; set; }

            [JsonProperty("role_group")] public bool? RoleGroup { get; set; }

            [JsonProperty("role_school")] public object RoleSchool { get; set; }

            [JsonProperty("founded_on")] public DateTimeOffset? FoundedOn { get; set; }

            [JsonProperty("founded_on_trust_code")]
            public long? FoundedOnTrustCode { get; set; }

            [JsonProperty("is_closed")] public bool? IsClosed { get; set; }

            [JsonProperty("closed_on")] public object ClosedOn { get; set; }

            [JsonProperty("closed_on_trust_code")] public long? ClosedOnTrustCode { get; set; }

            [JsonProperty("num_employees_min")] public long? NumEmployeesMin { get; set; }

            [JsonProperty("num_employees_max")] public long? NumEmployeesMax { get; set; }

            [JsonProperty("stock_exchange")] public object StockExchange { get; set; }

            [JsonProperty("stock_symbol")] public object StockSymbol { get; set; }

            [JsonProperty("total_funding_usd")] public long? TotalFundingUsd { get; set; }

            [JsonProperty("number_of_investments")]
            public long? NumberOfInvestments { get; set; }

            [JsonProperty("homepage_url")] public string HomepageUrl { get; set; }

            [JsonProperty("created_at")] public long CreatedAt { get; set; }

            [JsonProperty("updated_at")] public long UpdatedAt { get; set; }

            [JsonProperty("title")] public string Title { get; set; }

            [JsonProperty("started_on")] public DateTimeOffset? StartedOn { get; set; }

            [JsonProperty("started_on_trust_code")]
            public long? StartedOnTrustCode { get; set; }

            [JsonProperty("ended_on")] public DateTimeOffset? EndedOn { get; set; }

            [JsonProperty("ended_on_trust_code")] public long? EndedOnTrustCode { get; set; }

            [JsonProperty("author")] public string Author { get; set; }

            [JsonProperty("posted_on")] public DateTimeOffset? PostedOn { get; set; }

            [JsonProperty("posted_on_trust_code")] public object PostedOnTrustCode { get; set; }

            [JsonProperty("url")] public string Url { get; set; }

            [JsonProperty("funding_type")] public string FundingType { get; set; }

            [JsonProperty("series")] public string Series { get; set; }

            [JsonProperty("series_qualifier")] public object SeriesQualifier { get; set; }

            [JsonProperty("announced_on")] public DateTimeOffset? AnnouncedOn { get; set; }

            [JsonProperty("announced_on_trust_code")]
            public long? AnnouncedOnTrustCode { get; set; }

            [JsonProperty("money_raised")] public long? MoneyRaised { get; set; }

            [JsonProperty("money_raised_currency_code")]
            public string MoneyRaisedCurrencyCode { get; set; }

            [JsonProperty("money_raised_usd")] public long? MoneyRaisedUsd { get; set; }

            [JsonProperty("target_money_raised")] public object TargetMoneyRaised { get; set; }

            [JsonProperty("target_money_raised_currency_code")]
            public string TargetMoneyRaisedCurrencyCode { get; set; }

            [JsonProperty("target_money_raised_usd")]
            public object TargetMoneyRaisedUsd { get; set; }

            [JsonProperty("first_name")] public string FirstName { get; set; }

            [JsonProperty("last_name")] public string LastName { get; set; }

            [JsonProperty("gender")] public string Gender { get; set; }

            [JsonProperty("bio")] public string Bio { get; set; }

            [JsonProperty("born_on")] public DateTimeOffset? BornOn { get; set; }

            [JsonProperty("born_on_trust_code")] public long? BornOnTrustCode { get; set; }

            [JsonProperty("died_on")] public object DiedOn { get; set; }

            [JsonProperty("died_on_trust_code")] public long? DiedOnTrustCode { get; set; }

            [JsonProperty("street_1")] public string Street1 { get; set; }

            [JsonProperty("street_2")] public object Street2 { get; set; }

            [JsonProperty("postal_code")] public string PostalCode { get; set; }

            [JsonProperty("city")] public string City { get; set; }

            [JsonProperty("city_web_path")] public string CityWebPath { get; set; }

            [JsonProperty("region")] public string Region { get; set; }

            [JsonProperty("region_code2")] public string RegionCode2 { get; set; }

            [JsonProperty("region_web_path")] public string RegionWebPath { get; set; }

            [JsonProperty("country")] public string Country { get; set; }

            [JsonProperty("country_code2")] public string CountryCode2 { get; set; }

            [JsonProperty("country_code3")] public string CountryCode3 { get; set; }

            [JsonProperty("country_web_path")] public string CountryWebPath { get; set; }

            [JsonProperty("latitude")] public double? Latitude { get; set; }

            [JsonProperty("longitude")] public double? Longitude { get; set; }

            [JsonProperty("website_type")] public string WebsiteType { get; set; }

            [JsonProperty("website_name")] public string WebsiteName { get; set; }

            [JsonProperty("lifecycle_stage")] public string LifecycleStage { get; set; }

            [JsonProperty("launched_on")] public DateTimeOffset? LaunchedOn { get; set; }

            [JsonProperty("launched_on_trust_code")]
            public long? LaunchedOnTrustCode { get; set; }

            [JsonProperty("asset_path")] public string AssetPath { get; set; }

            [JsonProperty("asset_url")] public string AssetUrl { get; set; }

            [JsonProperty("content_type")] public string ContentType { get; set; }

            [JsonProperty("height")] public long? Height { get; set; }

            [JsonProperty("width")] public long? Width { get; set; }

            [JsonProperty("filesize")] public long? Filesize { get; set; }
        }

        public class ItemRelationships
        {
            [JsonProperty("person")] public Person Person { get; set; }
        }

        public class Person
        {
            [JsonProperty("type")] public PersonType Type { get; set; }

            [JsonProperty("uuid")] public string Uuid { get; set; }

            [JsonProperty("properties")] public PersonProperties Properties { get; set; }
        }

        public class PersonProperties
        {
            [JsonProperty("permalink")] public string Permalink { get; set; }

            [JsonProperty("api_path")] public string ApiPath { get; set; }

            [JsonProperty("web_path")] public string WebPath { get; set; }

            [JsonProperty("first_name")] public string FirstName { get; set; }

            [JsonProperty("last_name")] public string LastName { get; set; }

            [JsonProperty("gender")] public Gender Gender { get; set; }

            [JsonProperty("also_known_as")] public string[] AlsoKnownAs { get; set; }

            [JsonProperty("bio")] public string Bio { get; set; }

            [JsonProperty("profile_image_url")] public string ProfileImageUrl { get; set; }

            [JsonProperty("role_investor")] public bool? RoleInvestor { get; set; }

            [JsonProperty("born_on")] public DateTimeOffset? BornOn { get; set; }

            [JsonProperty("born_on_trust_code")] public long? BornOnTrustCode { get; set; }

            [JsonProperty("died_on")] public object DiedOn { get; set; }

            [JsonProperty("died_on_trust_code")] public long? DiedOnTrustCode { get; set; }

            [JsonProperty("created_at")] public long CreatedAt { get; set; }

            [JsonProperty("updated_at")] public long UpdatedAt { get; set; }
        }

        public class Headquarters
        {
            [JsonProperty("cardinality")] public string Cardinality { get; set; }

            [JsonProperty("paging")] public Paging Paging { get; set; }

            [JsonProperty("item")] public HeadquartersItem Item { get; set; }
        }

        public class HeadquartersItem
        {
            [JsonProperty("type")] public string Type { get; set; }

            [JsonProperty("uuid")] public string Uuid { get; set; }

            [JsonProperty("properties")] public FluffyProperties Properties { get; set; }
        }

        public class FluffyProperties
        {
            [JsonProperty("name")] public object Name { get; set; }

            [JsonProperty("street_1")] public string Street1 { get; set; }

            [JsonProperty("street_2")] public object Street2 { get; set; }

            [JsonProperty("postal_code")] public string PostalCode { get; set; }

            [JsonProperty("city")] public string City { get; set; }

            [JsonProperty("city_web_path")] public string CityWebPath { get; set; }

            [JsonProperty("region")] public string Region { get; set; }

            [JsonProperty("region_code2")] public string RegionCode2 { get; set; }

            [JsonProperty("region_web_path")] public string RegionWebPath { get; set; }

            [JsonProperty("country")] public string Country { get; set; }

            [JsonProperty("country_code2")] public string CountryCode2 { get; set; }

            [JsonProperty("country_code3")] public string CountryCode3 { get; set; }

            [JsonProperty("country_web_path")] public string CountryWebPath { get; set; }

            [JsonProperty("latitude")] public double Latitude { get; set; }

            [JsonProperty("longitude")] public double Longitude { get; set; }

            [JsonProperty("created_at")] public long CreatedAt { get; set; }

            [JsonProperty("updated_at")] public long UpdatedAt { get; set; }
        }

        public class PrimaryImage
        {
            [JsonProperty("cardinality")] public string Cardinality { get; set; }

            [JsonProperty("paging")] public Paging Paging { get; set; }

            [JsonProperty("item")] public PrimaryImageItem Item { get; set; }
        }

        public class PrimaryImageItem
        {
            [JsonProperty("type")] public string Type { get; set; }

            [JsonProperty("uuid")] public string Uuid { get; set; }

            [JsonProperty("properties")] public TentacledProperties Properties { get; set; }
        }

        public class TentacledProperties
        {
            [JsonProperty("asset_path")] public string AssetPath { get; set; }

            [JsonProperty("asset_url")] public string AssetUrl { get; set; }

            [JsonProperty("content_type")] public string ContentType { get; set; }

            [JsonProperty("height")] public long? Height { get; set; }

            [JsonProperty("width")] public long? Width { get; set; }

            [JsonProperty("filesize")] public long? Filesize { get; set; }

            [JsonProperty("created_at")] public long CreatedAt { get; set; }

            [JsonProperty("updated_at")] public long UpdatedAt { get; set; }
        }

        public class Metadata
        {
            [JsonProperty("version")] public long Version { get; set; }

            [JsonProperty("www_path_prefix")] public string WwwPathPrefix { get; set; }

            [JsonProperty("api_path_prefix")] public string ApiPathPrefix { get; set; }

            [JsonProperty("image_path_prefix")] public string ImagePathPrefix { get; set; }
        }

        public enum SortOrder
        {
            CreatedAtDesc
        }

        public enum Cardinality
        {
            ManyToMany,
            OneToMany
        }

        public enum Gender
        {
            Female,
            Male
        }

        public enum PersonType
        {
            Person
        }

        public partial class Company
        {
            public static Company FromJson(string json)
            {
                return JsonConvert.DeserializeObject<Company>(json, Converter.Settings);
            }
        }

        internal static class SortOrderExtensions
        {
            public static SortOrder? ValueForString(string str)
            {
                switch (str)
                {
                    case "created_at DESC": return SortOrder.CreatedAtDesc;
                    default: return null;
                }
            }

            public static SortOrder ReadJson(JsonReader reader, JsonSerializer serializer)
            {
                var str = serializer.Deserialize<string>(reader);
                var maybeValue = ValueForString(str);
                if (maybeValue.HasValue) return maybeValue.Value;
                throw new Exception("Unknown enum case " + str);
            }

            public static void WriteJson(this SortOrder value, JsonWriter writer, JsonSerializer serializer)
            {
                switch (value)
                {
                    case SortOrder.CreatedAtDesc:
                        serializer.Serialize(writer, "created_at DESC");
                        break;
                }
            }
        }

        internal static class CardinalityExtensions
        {
            public static Cardinality? ValueForString(string str)
            {
                switch (str)
                {
                    case "ManyToMany": return Cardinality.ManyToMany;
                    case "OneToMany": return Cardinality.OneToMany;
                    default: return null;
                }
            }

            public static Cardinality ReadJson(JsonReader reader, JsonSerializer serializer)
            {
                var str = serializer.Deserialize<string>(reader);
                var maybeValue = ValueForString(str);
                if (maybeValue.HasValue) return maybeValue.Value;
                throw new Exception("Unknown enum case " + str);
            }

            public static void WriteJson(this Cardinality value, JsonWriter writer, JsonSerializer serializer)
            {
                switch (value)
                {
                    case Cardinality.ManyToMany:
                        serializer.Serialize(writer, "ManyToMany");
                        break;
                    case Cardinality.OneToMany:
                        serializer.Serialize(writer, "OneToMany");
                        break;
                }
            }
        }

        internal static class GenderExtensions
        {
            public static Gender? ValueForString(string str)
            {
                switch (str)
                {
                    case "Female": return Gender.Female;
                    case "Male": return Gender.Male;
                    default: return null;
                }
            }

            public static Gender ReadJson(JsonReader reader, JsonSerializer serializer)
            {
                var str = serializer.Deserialize<string>(reader);
                var maybeValue = ValueForString(str);
                if (maybeValue.HasValue) return maybeValue.Value;
                throw new Exception("Unknown enum case " + str);
            }

            public static void WriteJson(this Gender value, JsonWriter writer, JsonSerializer serializer)
            {
                switch (value)
                {
                    case Gender.Female:
                        serializer.Serialize(writer, "Female");
                        break;
                    case Gender.Male:
                        serializer.Serialize(writer, "Male");
                        break;
                }
            }
        }

        internal static class PersonTypeExtensions
        {
            public static PersonType? ValueForString(string str)
            {
                switch (str)
                {
                    case "Person": return PersonType.Person;
                    default: return null;
                }
            }

            public static PersonType ReadJson(JsonReader reader, JsonSerializer serializer)
            {
                var str = serializer.Deserialize<string>(reader);
                var maybeValue = ValueForString(str);
                if (maybeValue.HasValue) return maybeValue.Value;
                throw new Exception("Unknown enum case " + str);
            }

            public static void WriteJson(this PersonType value, JsonWriter writer, JsonSerializer serializer)
            {
                switch (value)
                {
                    case PersonType.Person:
                        serializer.Serialize(writer, "Person");
                        break;
                }
            }
        }

        public static class Serialize
        {
            public static string ToJson(this Company self)
            {
                return JsonConvert.SerializeObject(self, Converter.Settings);
            }
        }

        internal class Converter : JsonConverter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new Converter(),
                    new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
                }
            };

            public override bool CanConvert(Type t)
            {
                return t == typeof(SortOrder) || t == typeof(Cardinality) || t == typeof(Gender) ||
                       t == typeof(PersonType) || t == typeof(SortOrder?) || t == typeof(Cardinality?) ||
                       t == typeof(Gender?) || t == typeof(PersonType?);
            }

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (t == typeof(SortOrder))
                    return SortOrderExtensions.ReadJson(reader, serializer);
                if (t == typeof(Cardinality))
                    return CardinalityExtensions.ReadJson(reader, serializer);
                if (t == typeof(Gender))
                    return GenderExtensions.ReadJson(reader, serializer);
                if (t == typeof(PersonType))
                    return PersonTypeExtensions.ReadJson(reader, serializer);
                if (t == typeof(SortOrder?))
                {
                    if (reader.TokenType == JsonToken.Null) return null;
                    return SortOrderExtensions.ReadJson(reader, serializer);
                }

                if (t == typeof(Cardinality?))
                {
                    if (reader.TokenType == JsonToken.Null) return null;
                    return CardinalityExtensions.ReadJson(reader, serializer);
                }

                if (t == typeof(Gender?))
                {
                    if (reader.TokenType == JsonToken.Null) return null;
                    return GenderExtensions.ReadJson(reader, serializer);
                }

                if (t == typeof(PersonType?))
                {
                    if (reader.TokenType == JsonToken.Null) return null;
                    return PersonTypeExtensions.ReadJson(reader, serializer);
                }

                throw new Exception("Unknown type");
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var t = value.GetType();
                if (t == typeof(SortOrder))
                {
                    ((SortOrder) value).WriteJson(writer, serializer);
                    return;
                }

                if (t == typeof(Cardinality))
                {
                    ((Cardinality) value).WriteJson(writer, serializer);
                    return;
                }

                if (t == typeof(Gender))
                {
                    ((Gender) value).WriteJson(writer, serializer);
                    return;
                }

                if (t == typeof(PersonType))
                {
                    ((PersonType) value).WriteJson(writer, serializer);
                    return;
                }

                throw new Exception("Unknown type");
            }
        }
    }
}