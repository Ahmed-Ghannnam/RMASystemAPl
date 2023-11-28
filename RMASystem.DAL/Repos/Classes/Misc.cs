//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;

//namespace RMASystem.DAL;

//public class Misc
//{
//    public class DateOnlyConverter : IsoDateTimeConverter
//    {
//        public DateOnlyConverter()
//        {
//            DateTimeFormat = "yyyy-MM-dd";
//        }
//    }

//    public class TimeOnlyConverter : IsoDateTimeConverter
//    {
//        public TimeOnlyConverter()
//        {
//            DateTimeFormat = "HH:mm:ss";
//        }
//    }

//    public class DateTimeConverter : IsoDateTimeConverter
//    {
//        public DateTimeConverter()
//        {
//            DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
//        }
//    }

//    public static JsonSerializerSettings SERIALIZER_SETTINGS = new JsonSerializerSettings
//    {
//        FloatFormatHandling = FloatFormatHandling.String,
//        FloatParseHandling = FloatParseHandling.Decimal,
//        DateFormatHandling = DateFormatHandling.IsoDateFormat,
//        DateParseHandling = DateParseHandling.None
//    };
//}

//public enum API_TYPE
//{
//    REGISTER = 0,
//    GET_TOKEN = 1,
//    CHANGE_PASSWORD = 2,
//    CREATE_ARTICLE = 3,
//    GET_PRODUCT_INFO = 4,
//    UPDATE_PRODUCT_AS_SYNCED = 5,
//    CREATE_UPDATE_RETAIL_CUSTOMER = 6,
//    GET_RETAIL_CUSTOMER_POINTS = 7,
//}


