namespace LitJson
{
    internal static class LitjsonExtension
    {
        public static bool IsNumber(this JsonData? jd) => jd != null ? jd.IsInt || jd.IsDouble || jd.IsLong : false;
        public static bool GetBool(this JsonData? jd)
        {
            if (jd == null) return false;
            switch(jd.GetJsonType()){
                case JsonType.Boolean: return (bool)jd;
                case JsonType.None:
                case JsonType.Object:
                case JsonType.Array: return false;
                default: return Convert.ToBoolean(jd);
            }
        }
        public static int GetInt(this JsonData? jd)
        {
            if (jd == null) return 0;
            switch(jd.GetJsonType()){
                case JsonType.Int: return (int)jd;
                case JsonType.None:
                case JsonType.Object:
                case JsonType.Array: return 0;
                default: return Convert.ToInt32(jd);
            }
        }
        public static long GetLong(this JsonData? jd)
        {
            if (jd == null) return 0;
            switch(jd.GetJsonType()){
                case JsonType.Long: return (long)jd;
                case JsonType.None:
                case JsonType.Object:
                case JsonType.Array: return 0;
                default: return Convert.ToInt32(jd);
            }
        }
        public static double GetDouble(this JsonData? jd)
        {
            if (jd == null) return 0;
            switch(jd.GetJsonType()){
                case JsonType.Double: return (double)jd;
                case JsonType.None:
                case JsonType.Object:
                case JsonType.Array: return 0;
                default: return Convert.ToDouble(jd);
            }
        }
        public static decimal GetDecimal(this JsonData jd)
        {
            string? v = GetString(jd);
            if( v == null ) return 0;
            if (decimal.TryParse(v, out var ret)) return ret;
            return 0;
        }
        public static string? GetString(this JsonData? jd)
        {
            if (jd == null) return null;
            switch(jd.GetJsonType()){
                case JsonType.String: return (string)jd;
                case JsonType.None:
                case JsonType.Object:
                case JsonType.Array: return null;
                default: return Convert.ToString(jd);
            }
        }
        public static int[]? GetArrayInt(this JsonData? arr)
        {
            if (arr == null) return null;
            int[] ret = new int[arr.Count];
            for (int i = 0; i < ret.Length; ++i) ret[i] = arr[i].GetInt();
            return ret;
        }
        public static long[]? GetArrayLong(this JsonData? arr)
        {
            if (arr == null) return null;
            long[] ret = new long[arr.Count];
            for (int i = 0; i < ret.Length; ++i) ret[i] = arr[i].GetLong();
            return ret;
        }
        public static string?[]? GetArrayString(this JsonData? arr)
        {
            if (arr == null) return null;
            string?[] ret = new string[arr.Count];
            for (int i = 0; i < ret.Length; ++i) ret[i] = arr[i].GetString();
            return ret;
        }
        public static double[]? GetArrayDouble(this JsonData? arr)
        {
            if (arr == null) return null;
            double[] ret = new double[arr.Count];
            for (int i = 0; i < ret.Length; ++i) ret[i] = arr[i].GetDouble();
            return ret;
        }
        public static decimal[] GetArrayDecimal(this JsonData arr)
        {
            decimal[] ret = new decimal[arr.Count];
            for (int i = 0; i < ret.Length; ++i) ret[i] = arr[i].GetDecimal();
            return ret;
        }
        public static bool GetBool(this JsonData? jd, string key) => jd == null ? false : jd.ContainsKey(key) ? jd[key].GetBool() : false;
        public static int GetInt(this JsonData? jd, string key) => jd == null ? 0 : jd.ContainsKey(key) ? jd[key].GetInt() : 0;
        public static long GetLong(this JsonData? jd, string key) => jd == null ? 0 : jd.ContainsKey(key) ? jd[key].GetLong() : 0;
        public static double GetDouble(this JsonData? jd, string key) => jd == null ? 0 : jd.ContainsKey(key) ? jd[key].GetDouble() : 0;
        public static string? GetString(this JsonData? jd, string key) => jd == null ? null : jd.ContainsKey(key) ? jd[key].GetString() : null;
        public static decimal GetDecimal(this JsonData jd, string key) => jd == null ? 0 : jd.ContainsKey(key) ? jd[key].GetDecimal() : 0;
        public static bool GetBool(this JsonData? jd, int idx) => jd == null ? false : jd.IsArray ? jd[idx].GetBool() : false;
        public static int GetInt(this JsonData? jd, int idx) => jd == null ? 0 : jd.IsArray ? jd[idx].GetInt() : 0;
        public static long GetLong(this JsonData? jd, int idx) => jd == null ? 0 : jd.IsArray ? jd[idx].GetLong() : 0;
        public static double GetDouble(this JsonData? jd, int idx) => jd == null ? 0 : jd.IsArray ? jd[idx].GetDouble() : 0;
        public static decimal GetDecimal(this JsonData? jd, int idx) => jd == null ? 0 : jd.IsArray ? jd[idx].GetDecimal() : 0;
        public static string? GetString(this JsonData? jd, int idx) => jd == null ? null : jd.IsArray ? jd[idx].GetString() : null;
        public static int[]? GetArrayInt(this JsonData? arr, string key) => arr == null ? null : arr.ContainsKey(key) ? arr[key].GetArrayInt() : null;
        public static long[]? GetArrayLong(this JsonData? arr, string key) => arr == null ? null : arr.ContainsKey(key) ? arr[key].GetArrayLong() : null;
        public static string?[]? GetArrayString(this JsonData? arr, string key) => arr == null ? null : arr.ContainsKey(key) ? arr[key].GetArrayString() : null;
        public static double[]? GetArrayDouble(this JsonData? arr, string key) => arr == null ? null : arr.ContainsKey(key) ? arr[key].GetArrayDouble() : null;
        public static decimal[]? GetArrayDecimal(this JsonData arr, string key) => arr.ContainsKey(key) ? arr[key].GetArrayDecimal() : null;
        public static bool ContainKeys(this JsonData? jd, params string[] args)
        {
            if (jd == null) return false;
            foreach (var key in args)
            {
                if (!jd.ContainsKey(key)) return false;
            }
            return true;
        }
    }
}