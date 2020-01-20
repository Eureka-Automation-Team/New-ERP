using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;

// useful set of Extension methods for Data Access purposes

public static class Extensions
{
    // transform object into Identity data type (integer).

    public static int AsId(this object item, int defaultId = -1)
    {
        if (item == null)
            return defaultId;

        int result;
        if (!int.TryParse(item.ToString(), out result))
            return defaultId;

        return result;
    }

    // transform object into integer data type.

    public static int AsInt(this object item, int defaultInt = default(int))
    {
        if (item == null)
            return defaultInt;

        int result;
        if (!int.TryParse(item.ToString(), out result))
            return defaultInt;

        return result;
    }

    // transform object into double data type

    public static double AsDouble(this object item, double defaultDouble = default(double))
    {
        if (item == null)
            return defaultDouble;

        double result;
        if (!double.TryParse(item.ToString(), out result))
            return defaultDouble;

        return result;
    }

    // transform object into string data type

    public static string AsString(this object item, string defaultString = default(string))
    {
        if (item == null || item.Equals(System.DBNull.Value))
            return defaultString;

        return item.ToString().Trim();
    }

    // transform object into DateTime data type.

    public static DateTime AsDateTime(this object item, DateTime defaultDateTime = default(DateTime))
    {
        if (item == null || string.IsNullOrEmpty(item.ToString()))
            return defaultDateTime;

        DateTime result;
        if (!DateTime.TryParse(item.ToString(), out result))
            return defaultDateTime;

        return result;
    }

    // transform object into bool data type

    public static bool AsBool(this object item, bool defaultBool = default(bool))
    {
        if (item == null)
            return defaultBool;

        return new List<string>() { "yes", "y", "true" }.Contains(item.ToString().ToLower());
    }

    // transform string into byte array

    public static byte[] AsByteArray(this string s)
    {
        if (string.IsNullOrEmpty(s))
            return null;

        return Convert.FromBase64String(s);
    }

    // transform object into base64 string.

    public static string AsBase64String(this object item)
    {
        if (item == null || item.Equals(System.DBNull.Value))
            return null;
        ;

        return Convert.ToBase64String((byte[])item);
    }

    // transform object into Guid data type

    public static Guid AsGuid(this object item)
    {
        try { return new Guid(item.ToString()); }
        catch { return Guid.Empty; }
    }

    // concatenates SQL and ORDER BY clauses into a single string

    public static string OrderBy(this string sql, string sortExpression)
    {
        if (string.IsNullOrEmpty(sortExpression))
            return sql;

        return sql + " ORDER BY " + sortExpression;
    }

    // takes an enumerable source and returns a comma separate string.
    // handy for building SQL Statements (for example with IN () statements) from object collections

    public static string CommaSeparate<T, U>(this IEnumerable<T> source, Func<T, U> func)
    {
        return string.Join(",", source.Select(s => func(s).ToString()).ToArray());
    }

    public static string AsNumberToWordsTH(this object item, string defaultString = default(string))
    {
        string Textreturn = "";
        double numbermoney = Convert.ToDouble(item);
        if (numbermoney == 0)
        {
            return "ศูนย์";
        }

        if (numbermoney < 0)
        {
            Textreturn = "ลบ";
            numbermoney = -(numbermoney);
        }

        if ((numbermoney / 1000000) > 0)
        {
            Textreturn += AsNumberToWordsTH(numbermoney / 1000000) + "ล้าน";
            numbermoney %= 1000000;
        }
        if ((numbermoney / 100000) > 0)
        {
            Textreturn += AsNumberToWordsTH(numbermoney / 100000) + "แสน";
            numbermoney %= 100000;
        }
        if ((numbermoney / 10000) > 0)
        {
            Textreturn += AsNumberToWordsTH(numbermoney / 10000) + "หมื่น";
            numbermoney %= 10000;
        }
        if ((numbermoney / 1000) > 0)
        {
            Textreturn += AsNumberToWordsTH(numbermoney / 1000) + "พัน";
            numbermoney %= 1000;
        }

        if ((numbermoney / 100) > 0)
        {
            Textreturn += AsNumberToWordsTH(numbermoney / 100) + "ร้อย";
            numbermoney %= 100;
        }

        if (numbermoney > 0)
        {
            if (Textreturn != "")
            {
                Textreturn += "";
            }

            var unitsMap = new[] { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "เเปด", "เก้า", "สิบ", "สิบเอ็ด", "สิบสอง", "สิบสาม", "สิบสี่", "สิบห้า", "สิบหก", "สิบเจ็ด", "สิบเเปด", "สิบเก้า" };
            var tensMap = new[] { "ศูนย์", "สิบ", "ยี่สิบ", "สามสิบ", "สี่สิบ", "ห้าสิบ", "หกสิบ", "เจ็ดสิบ", "แปดสิบ", "เก้าสิบ" };

            if (numbermoney < 20)
            {
                Textreturn += unitsMap[Convert.ToInt32(numbermoney)];
            }
            else
            {
                Textreturn += tensMap[Convert.ToInt32(numbermoney) / 10];
                if ((numbermoney % 10) > 0)
                {
                    Textreturn += "" + unitsMap[Convert.ToInt32(numbermoney) % 10];
                }
            }
        }

        return Textreturn;
    }

    public static string ThaiBaht(this object txt, string defaultString = default(string))
    {
        string bahtTxt, n, bahtTH = "";
        double amount;
        var amt = txt.ToString().Replace("-", "");
        try { amount = Convert.ToDouble(amt); }
        catch { amount = 0; }
        bahtTxt = amount.ToString("####.00");
        string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
        string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
        string[] temp = bahtTxt.Split('.');
        string intVal = temp[0];
        string decVal = temp[1];
        if (Convert.ToDouble(bahtTxt) == 0)
            bahtTH = "ศูนย์บาทถ้วน";
        else
        {
            for (int i = 0; i < intVal.Length; i++)
            {
                n = intVal.Substring(i, 1);
                if (n != "0")
                {
                    if ((i == (intVal.Length - 1)) && (n == "1"))
                        bahtTH += "เอ็ด";
                    else if ((i == (intVal.Length - 2)) && (n == "2"))
                        bahtTH += "ยี่";
                    else if ((i == (intVal.Length - 2)) && (n == "1"))
                        bahtTH += "";
                    else
                        bahtTH += num[Convert.ToInt32(n)];
                    bahtTH += rank[(intVal.Length - i) - 1];
                }
            }
            bahtTH += "บาท";
            if (decVal == "00")
                bahtTH += "ถ้วน";
            else
            {
                for (int i = 0; i < decVal.Length; i++)
                {
                    n = decVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == decVal.Length - 1) && (n == "1"))
                            bahtTH += "เอ็ด";
                        else if ((i == (decVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (decVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];
                        bahtTH += rank[(decVal.Length - i) - 1];
                    }
                }
                bahtTH += "สตางค์";
            }
        }
        return bahtTH;
    }
}