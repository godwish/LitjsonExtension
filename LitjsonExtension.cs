using System;

namespace LitJson
{
    internal static class LitjsonExtension
    {
        public static bool IsNumber(this JsonData? jd) => jd != null ? jd.IsInt || jd.IsDouble || jd.IsLong : false;
        public static bool GetBool(this JsonData? jd)
        {
            if (jd == null) return false;
            if (jd.IsString) return Convert.ToBoolean((string)jd);
            else if (jd.IsInt) return Convert.ToBoolean((int)jd);
            else if (jd.IsLong) return Convert.ToBoolean((long)jd);
            else if (jd.IsDouble) return Convert.ToBoolean((double)jd);
            return false;
        }
        public static int GetInt(this JsonData? jd)
        {
            if (jd == null) return 0;
            if (jd.IsString) return Convert.ToInt32((string)jd);
            else if (jd.IsInt) return (int)jd;
            else if (jd.IsLong) return Convert.ToInt32((long)jd);
            else if (jd.IsDouble) return Convert.ToInt32((double)jd);
            else if (jd.IsBoolean) return Convert.ToInt32((bool)jd);
            return 0;
        }
        public static long GetLong(this JsonData? jd)
        {
            if (jd == null) return 0;
            if (jd.IsString) return Convert.ToInt64((string)jd);
            else if (jd.IsInt) return Convert.ToInt64((int)jd);
            else if (jd.IsLong) return (long)jd;
            else if (jd.IsDouble) return Convert.ToInt64((double)jd);
            else if (jd.IsBoolean) return Convert.ToInt64((bool)jd);
            return 0;
        }
        public static double GetDouble(this JsonData? jd)
        {
            if (jd == null) return 0;
            if (jd.IsString) return Convert.ToDouble((string)jd);
            else if (jd.IsInt) return Convert.ToDouble((int)jd);
            else if (jd.IsLong) return Convert.ToDouble((long)jd);
            else if (jd.IsDouble) return (double)jd;
            else if (jd.IsBoolean) return Convert.ToDouble((bool)jd);
            return 0;
        }
        public static string? GetString(this JsonData? jd)
        {
            if (jd == null) return null;
            if (jd.IsObject || jd.IsArray) return jd.ToJson();
            if (jd.IsString) return (string)jd;
            else if (jd.IsInt) return Convert.ToString((int)jd);
            else if (jd.IsLong) return Convert.ToString((long)jd);
            else if (jd.IsDouble) return Convert.ToString((double)jd);
            else if (jd.IsBoolean) return Convert.ToString((bool)jd);
            return null;
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
        public static bool GetBool(this JsonData? jd, string key) => jd == null ? false : jd.ContainsKey(key) ? jd[key].GetBool() : false;
        public static int GetInt(this JsonData? jd, string key) => jd == null ? 0 : jd.ContainsKey(key) ? jd[key].GetInt() : 0;
        public static long GetLong(this JsonData? jd, string key) => jd == null ? 0 : jd.ContainsKey(key) ? jd[key].GetLong() : 0;
        public static double GetDouble(this JsonData? jd, string key) => jd == null ? 0 : jd.ContainsKey(key) ? jd[key].GetDouble() : 0;
        public static string? GetString(this JsonData? jd, string key) => jd == null ? null : jd.ContainsKey(key) ? jd[key].GetString() : null;
        public static bool GetBool(this JsonData? jd, int idx) => jd == null ? false : jd.IsArray ? jd[idx].GetBool() : false;
        public static int GetInt(this JsonData? jd, int idx) => jd == null ? 0 : jd.IsArray ? jd[idx].GetInt() : 0;
        public static long GetLong(this JsonData? jd, int idx) => jd == null ? 0 : jd.IsArray ? jd[idx].GetLong() : 0;
        public static double GetDouble(this JsonData? jd, int idx) => jd == null ? 0 : jd.IsArray ? jd[idx].GetDouble() : 0;
        public static string? GetString(this JsonData? jd, int idx) => jd == null ? null : jd.IsArray ? jd[idx].GetString() : null;
        public static int[]? GetArrayInt(this JsonData? arr, string key) => arr == null ? null : arr.ContainsKey(key) ? arr[key].GetArrayInt() : null;
        public static long[]? GetArrayLong(this JsonData? arr, string key) => arr == null ? null : arr.ContainsKey(key) ? arr[key].GetArrayLong() : null;
        public static string?[]? GetArrayString(this JsonData? arr, string key) => arr == null ? null : arr.ContainsKey(key) ? arr[key].GetArrayString() : null;
        public static double[]? GetArrayDouble(this JsonData? arr, string key) => arr == null ? null : arr.ContainsKey(key) ? arr[key].GetArrayDouble() : null;
    }
}