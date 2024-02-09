﻿using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace IbsRestApi.Common;

public static class StringHelpers
{

    public static string FromAES(this string value, string key)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;

        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(value);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader(cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }

    }

    public static string ToAES(this string value, string key)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        byte[] iv = new byte[16];
        byte[] array;

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(value);
                    }

                    array = memoryStream.ToArray();
                }
            }
        }

        return Convert.ToBase64String(array);
    }

    public static string ToBase64(this string value)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;

        byte[] data = ASCIIEncoding.ASCII.GetBytes(value);

        return Convert.ToBase64String(data);
    }

    public static string FromBase64(this string value)
    {

        if (string.IsNullOrEmpty(value)) return string.Empty;

        byte[] data = Convert.FromBase64String(value);

        return ASCIIEncoding.ASCII.GetString(data);

    }


    /// <summary>
    /// Get substring of specified number of characters on the right.
    /// </summary>
    public static string Right(this string value, int length)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;

        return value.Length <= length ? value : value.Substring(value.Length - length);
    }

    /// <summary>
    /// Get substring of specified number of characters on the left.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string Left(this string value, int length)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;

        return value.Length <= length ? value : value.Substring(0, length);
    }

    /// <summary>
    /// Verifies that a string is in valid e-mail format
    /// </summary>
    /// <param name="email">Email to verify</param>
    /// <returns>true if the string is a valid e-mail address and false if it's not</returns>
    public static bool isValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;
        //we use EmailValidator from FluentValidation. So let's keep them sync - https://github.com/JeremySkinner/FluentValidation/blob/master/src/FluentValidation/Validators/EmailValidator.cs
        string emailRegex = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$";


        email = email.Trim();
        var result = Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
        return result;
    }


    public static string GetPhraseAfterWord(string sentenceToSearch, string wordBeforeTargetString, string wordAfterTargetString)
    {
        int searchStartPosition = 0;
        string searchResult = "";


        if (!string.IsNullOrEmpty(wordBeforeTargetString))
        {
            searchStartPosition = sentenceToSearch.ToLower().IndexOf(wordBeforeTargetString) + wordBeforeTargetString.Length;

            searchResult = sentenceToSearch.Substring(searchStartPosition, sentenceToSearch.Length - searchStartPosition).Trim();

            if (!string.IsNullOrEmpty(wordAfterTargetString))
            {

                searchResult = searchResult.Substring(0, searchResult.IndexOf(wordAfterTargetString)).Trim();

            }
        }
        else
        {
            searchResult = string.Empty;
        }
        return searchResult.Trim();
    }

    public static string RandomString(int length, bool lowerCase = true, bool upperCase = true, bool numbers = true, bool symbols = false)
    {
        RandomStringGenerator stringGenerator = new RandomStringGenerator();

        return stringGenerator.NextString(length, lowerCase, upperCase, numbers, symbols);
    }

    /// <summary>
    ///     Checks if date with dateFormat is parse-able to System.DateTime format returns boolean value if true else false
    /// </summary>
    /// <param name="data">String date</param>
    /// <param name="dateFormat">date format example dd/MM/yyyy HH:mm:ss</param>
    /// <returns>boolean True False if is valid System.DateTime</returns>
    public static bool IsDateTime(this string data, string dateFormat)
    {
        // ReSharper disable once RedundantAssignment
        return DateTime.TryParseExact(data, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
            out DateTime dateVal);
    }

    /// <summary>
    ///     Converts the string representation of a number to its 32-bit signed integer equivalent
    /// </summary>
    /// <param name="value">string containing a number to convert</param>
    /// <returns>System.Int32</returns>
    /// <remarks>
    ///     The conversion fails if the string parameter is null, is not of the correct format, or represents a number
    ///     less than System.Int32.MinValue or greater than System.Int32.MaxValue
    /// </remarks>
    public static int ToInt32(this string value)
    {
        int.TryParse(value, out int number);
        return number;
    }

    /// <summary>
    ///     Converts the string representation of a number to its 64-bit signed integer equivalent
    /// </summary>
    /// <param name="value">string containing a number to convert</param>
    /// <returns>System.Int64</returns>
    /// <remarks>
    ///     The conversion fails if the string parameter is null, is not of the correct format, or represents a number
    ///     less than System.Int64.MinValue or greater than System.Int64.MaxValue
    /// </remarks>
    public static long ToInt64(this string value)
    {
        long.TryParse(value, out long number);
        return number;
    }

    /// <summary>
    ///     Converts the string representation of a number to its 16-bit signed integer equivalent
    /// </summary>
    /// <param name="value">string containing a number to convert</param>
    /// <returns>System.Int16</returns>
    /// <remarks>
    ///     The conversion fails if the string parameter is null, is not of the correct format, or represents a number
    ///     less than System.Int16.MinValue or greater than System.Int16.MaxValue
    /// </remarks>
    public static short ToInt16(this string value)
    {
        short.TryParse(value, out short number);
        return number;
    }

    /// <summary>
    ///     Converts the string representation of a number to its System.Decimal equivalent
    /// </summary>
    /// <param name="value">string containing a number to convert</param>
    /// <returns>System.Decimal</returns>
    /// <remarks>
    ///     The conversion fails if the s parameter is null, is not a number in a valid format, or represents a number
    ///     less than System.Decimal.MinValue or greater than System.Decimal.MaxValue
    /// </remarks>
    public static decimal ToDecimal(this string value)
    {
        decimal.TryParse(value, out decimal number);
        return number;
    }

    /// <summary>
    ///     Converts string to its boolean equivalent
    /// </summary>
    /// <param name="value">string to convert</param>
    /// <returns>boolean equivalent</returns>
    /// <remarks>
    ///     <exception cref="ArgumentException">
    ///         thrown in the event no boolean equivalent found or an empty or whitespace
    ///         string is passed
    ///     </exception>
    /// </remarks>
    public static bool ToBoolean(this string value)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("value");
        }
        string val = value.ToLower().Trim();
        switch (val)
        {
            case "false":
                return false;
            case "f":
                return false;
            case "true":
                return true;
            case "t":
                return true;
            case "yes":
                return true;
            case "no":
                return false;
            case "y":
                return true;
            case "n":
                return false;
            default:
                throw new ArgumentException("Invalid boolean");
        }
    }

    /// <summary>
    ///     Returns an enumerable collection of the specified type containing the substrings in this instance that are
    ///     delimited by elements of a specified Char array
    /// </summary>
    /// <param name="str">The string.</param>
    /// <param name="separator">
    ///     An array of Unicode characters that delimit the substrings in this instance, an empty array containing no
    ///     delimiters, or null.
    /// </param>
    /// <typeparam name="T">
    ///     The type of the element to return in the collection, this type must implement IConvertible.
    /// </typeparam>
    /// <returns>
    ///     An enumerable collection whose elements contain the substrings in this instance that are delimited by one or more
    ///     characters in separator.
    /// </returns>
    public static IEnumerable<T> SplitTo<T>(this string str, params char[] separator) where T : IConvertible
    {
        return str.Split(separator, StringSplitOptions.None).Select(s => (T)Convert.ChangeType(s, typeof(T)));
    }

    /// <summary>
    ///     Returns an enumerable collection of the specified type containing the substrings in this instance that are
    ///     delimited by elements of a specified Char array
    /// </summary>
    /// <param name="str">The string.</param>
    /// <param name="options">StringSplitOptions <see cref="StringSplitOptions" /></param>
    /// <param name="separator">
    ///     An array of Unicode characters that delimit the substrings in this instance, an empty array containing no
    ///     delimiters, or null.
    /// </param>
    /// <typeparam name="T">
    ///     The type of the element to return in the collection, this type must implement IConvertible.
    /// </typeparam>
    /// <returns>
    ///     An enumerable collection whose elements contain the substrings in this instance that are delimited by one or more
    ///     characters in separator.
    /// </returns>
    public static IEnumerable<T> SplitTo<T>(this string str, StringSplitOptions options, params char[] separator)
        where T : IConvertible
    {
        return str.Split(separator, options).Select(s => (T)Convert.ChangeType(s, typeof(T)));
    }

    /// <summary>
    ///     Converts string to its Enum type
    ///     Checks of string is a member of type T enum before converting
    ///     if fails returns default enum
    /// </summary>
    /// <typeparam name="T">generic type</typeparam>
    /// <param name="value"> The string representation of the enumeration name or underlying value to convert</param>
    /// <param name="defaultValue"></param>
    /// <returns>Enum object</returns>
    /// <remarks>
    ///     <exception cref="ArgumentException">
    ///         enumType is not an System.Enum.-or- value is either an empty string ("") or
    ///         only contains white space.-or- value is a name, but not one of the named constants defined for the enumeration
    ///     </exception>
    /// </remarks>
    public static T ToEnum<T>(this string value, T defaultValue = default(T)) where T : struct
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("Type T Must of type System.Enum");
        }

        bool isParsed = Enum.TryParse(value, true, out T result);
        return isParsed ? result : defaultValue;
    }

    /// <summary>
    ///     Replaces one or more format items in a specified string with the string representation of a specified object.
    /// </summary>
    /// <param name="value">A composite format string</param>
    /// <param name="arg0">An System.Object to format</param>
    /// <returns>A copy of format in which any format items are replaced by the string representation of arg0</returns>
    /// <exception cref="ArgumentNullException">format or args is null.</exception>
    /// <exception cref="System.FormatException">
    ///     format is invalid.-or- The index of a format item is less than zero, or
    ///     greater than or equal to the length of the args array.
    /// </exception>
    public static string Format(this string value, object arg0)
    {
        return string.Format(value, arg0);
    }

    /// <summary>
    ///     Replaces the format item in a specified string with the string representation of a corresponding object in a
    ///     specified array.
    /// </summary>
    /// <param name="value">A composite format string</param>
    /// <param name="args">An object array that contains zero or more objects to format</param>
    /// <returns>
    ///     A copy of format in which the format items have been replaced by the string representation of the
    ///     corresponding objects in args
    /// </returns>
    /// <exception cref="ArgumentNullException">format or args is null.</exception>
    /// <exception cref="System.FormatException">
    ///     format is invalid.-or- The index of a format item is less than zero, or
    ///     greater than or equal to the length of the args array.
    /// </exception>
    public static string Format(this string value, params object[] args)
    {
        return string.Format(value, args);
    }

    /// <summary>
    ///     Gets empty String if passed value is of type Null/Nothing
    /// </summary>
    /// <param name="val">val</param>
    /// <returns>System.String</returns>
    /// <remarks></remarks>
    public static string GetEmptyStringIfNull(this string val)
    {
        return (val != null ? val.Trim() : "");
    }

    /// <summary>
    ///     Checks if a string is null and returns String if not Empty else returns null/Nothing
    /// </summary>
    /// <param name="myValue">String value</param>
    /// <returns>null/nothing if String IsEmpty</returns>
    /// <remarks></remarks>
    public static string GetNullIfEmptyString(this string myValue)
    {
        if (myValue == null || myValue.Length <= 0)
        {
            return null;
        }
        myValue = myValue.Trim();
        if (myValue.Length > 0)
        {
            return myValue;
        }
        return null;
    }

    /// <summary>
    ///     IsInteger Function checks if a string is a valid int32 value
    /// </summary>
    /// <param name="val">val</param>
    /// <returns>Boolean True if isInteger else False</returns>
    public static bool IsInteger(this string val)
    {
        // Variable to collect the Return value of the TryParse method.

        // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.

        // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
        // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
        bool isNum = int.TryParse(val, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out int retNum);
        return isNum;
    }

    /// <summary>
    ///     Read in a sequence of words from standard input and capitalize each
    ///     one (make first letter uppercase; make rest lowercase).
    /// </summary>
    /// <param name="s">string</param>
    /// <returns>Word with capitalization</returns>
    public static string Capitalize(this string s)
    {
        if (s.Length == 0)
        {
            return s;
        }
        return s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
    }

    /// <summary>
    ///     Gets first character in string
    /// </summary>
    /// <param name="val">val</param>
    /// <returns>System.string</returns>
    public static string FirstCharacter(this string val)
    {
        return (!string.IsNullOrEmpty(val))
            ? (val.Length >= 1)
                ? val.Substring(0, 1)
                : val
            : null;
    }

    /// <summary>
    ///     Gets last character in string
    /// </summary>
    /// <param name="val">val</param>
    /// <returns>System.string</returns>
    public static string LastCharacter(this string val)
    {
        return (!string.IsNullOrEmpty(val))
            ? (val.Length >= 1)
                ? val.Substring(val.Length - 1, 1)
                : val
            : null;
    }

    /// <summary>
    ///     Check a String ends with another string ignoring the case.
    /// </summary>
    /// <param name="val">string</param>
    /// <param name="suffix">suffix</param>
    /// <returns>true or false</returns>
    public static bool EndsWithIgnoreCase(this string val, string suffix)
    {
        if (val == null)
        {
            throw new ArgumentNullException("val", "val parameter is null");
        }
        if (suffix == null)
        {
            throw new ArgumentNullException("suffix", "suffix parameter is null");
        }
        if (val.Length < suffix.Length)
        {
            return false;
        }
        return val.EndsWith(suffix, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///     Check a String starts with another string ignoring the case.
    /// </summary>
    /// <param name="val">string</param>
    /// <param name="prefix">prefix</param>
    /// <returns>true or false</returns>
    public static bool StartsWithIgnoreCase(this string val, string prefix)
    {
        if (val == null)
        {
            throw new ArgumentNullException("val", "val parameter is null");
        }
        if (prefix == null)
        {
            throw new ArgumentNullException("prefix", "prefix parameter is null");
        }
        if (val.Length < prefix.Length)
        {
            return false;
        }
        return val.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///     Replace specified characters with an empty string.
    /// </summary>
    /// <param name="s">the string</param>
    /// <param name="chars">list of characters to replace from the string</param>
    /// <example>
    ///     string s = "Friends";
    ///     s = s.Replace('F', 'r','i','s');  //s becomes 'end;
    /// </example>
    /// <returns>System.string</returns>
    public static string Replace(this string s, params char[] chars)
    {
        return chars.Aggregate(s, (current, c) => current.Replace(c.ToString(CultureInfo.InvariantCulture), ""));
    }

    /// <summary>
    ///     Remove Characters from string
    /// </summary>
    /// <param name="s">string to remove characters</param>
    /// <param name="chars">array of chars</param>
    /// <returns>System.string</returns>
    public static string RemoveChars(this string s, params char[] chars)
    {
        var sb = new StringBuilder(s.Length);
        foreach (char c in s.Where(c => !chars.Contains(c)))
        {
            sb.Append(c);
        }
        return sb.ToString();
    }

    /// <summary>
    ///     Validate email address
    /// </summary>
    /// <param name="email">string email address</param>
    /// <returns>true or false if email if valid</returns>
    public static bool IsEmailAddress(this string email)
    {
        string pattern =
            "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
        return Regex.Match(email, pattern).Success;
    }

    /// <summary>
    ///     IsNumeric checks if a string is a valid floating value
    /// </summary>
    /// <param name="val"></param>
    /// <returns>Boolean True if isNumeric else False</returns>
    /// <remarks></remarks>
    public static bool IsNumeric(this string val)
    {
        // Variable to collect the Return value of the TryParse method.

        // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.

        // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
        // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
        bool isNum = double.TryParse(val, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out double retNum);
        return isNum;
    }

    /// <summary>
    ///     Truncate String and append ... at end
    /// </summary>
    /// <param name="s">String to be truncated</param>
    /// <param name="maxLength">number of chars to truncate</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static string Truncate(this string s, int maxLength)
    {
        if (string.IsNullOrEmpty(s) || maxLength <= 0)
        {
            return string.Empty;
        }
        if (s.Length > maxLength)
        {
            return s.Substring(0, maxLength) + "...";
        }
        return s;
    }

    /// <summary>
    ///     Function returns a default String value if given value is null or empty
    /// </summary>
    /// <param name="myValue">String value to check if isEmpty</param>
    /// <param name="defaultValue">default value to return if String value isEmpty</param>
    /// <returns>returns either String value or default value if IsEmpty</returns>
    /// <remarks></remarks>
    public static string GetDefaultIfEmpty(this string myValue, string defaultValue)
    {
        if (!string.IsNullOrEmpty(myValue))
        {
            myValue = myValue.Trim();
            return myValue.Length > 0 ? myValue : defaultValue;
        }
        return defaultValue;
    }

    /// <summary>
    ///     Convert a string to its equivalent byte array
    /// </summary>
    /// <param name="val">string to convert</param>
    /// <returns>System.byte array</returns>
    public static byte[] ToBytes(this string val)
    {
        var bytes = new byte[val.Length * sizeof(char)];
        Buffer.BlockCopy(val.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }

    /// <summary>
    ///     Reverse string
    /// </summary>
    /// <param name="val">string to reverse</param>
    /// <returns>System.string</returns>
    public static string Reverse(this string val)
    {
        var chars = new char[val.Length];
        for (int i = val.Length - 1, j = 0; i >= 0; --i, ++j)
        {
            chars[j] = val[i];
        }
        val = new string(chars);
        return val;
    }

    /// <summary>
    ///     Appends String quotes for type CSV data
    /// </summary>
    /// <param name="val">val</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static string ParseStringToCsv(this string val)
    {
        return '"' + GetEmptyStringIfNull(val).Replace("\"", "\"\"") + '"';
    }


    /// <summary>
    ///     Count number of occurrences in string
    /// </summary>
    /// <param name="val">string containing text</param>
    /// <param name="stringToMatch">string or pattern find</param>
    /// <returns></returns>
    public static int CountOccurrences(this string val, string stringToMatch)
    {
        return Regex.Matches(val, stringToMatch, RegexOptions.IgnoreCase).Count;
    }




    /// <summary>
    ///     Removes the first part of the string, if no match found return original string
    /// </summary>
    /// <param name="val">string to remove prefix</param>
    /// <param name="prefix">prefix</param>
    /// <param name="ignoreCase">Indicates whether the compare should ignore case</param>
    /// <returns>trimmed string with no prefix or original string</returns>
    public static string RemovePrefix(this string val, string prefix, bool ignoreCase = true)
    {
        if (!string.IsNullOrEmpty(val) && (ignoreCase ? val.StartsWithIgnoreCase(prefix) : val.StartsWith(prefix)))
        {
            return val.Substring(prefix.Length, val.Length - prefix.Length);
        }
        return val;
    }

    /// <summary>
    ///     Removes the end part of the string, if no match found return original string
    /// </summary>
    /// <param name="val">string to remove suffix</param>
    /// <param name="suffix">suffix</param>
    /// <param name="ignoreCase">Indicates whether the compare should ignore case</param>
    /// <returns>trimmed string with no suffix or original string</returns>
    public static string RemoveSuffix(this string val, string suffix, bool ignoreCase = true)
    {
        if (!string.IsNullOrEmpty(val) && (ignoreCase ? val.EndsWithIgnoreCase(suffix) : val.EndsWith(suffix)))
        {
            return val.Substring(0, val.Length - suffix.Length);
        }
        return null;
    }

    /// <summary>
    ///     Appends the suffix to the end of the string if the string does not already end in the suffix.
    /// </summary>
    /// <param name="val">string to append suffix</param>
    /// <param name="suffix">suffix</param>
    /// <param name="ignoreCase">Indicates whether the compare should ignore case</param>
    /// <returns></returns>
    public static string AppendSuffixIfMissing(this string val, string suffix, bool ignoreCase = true)
    {
        if (string.IsNullOrEmpty(val) || (ignoreCase ? val.EndsWithIgnoreCase(suffix) : val.EndsWith(suffix)))
        {
            return val;
        }
        return val + suffix;
    }

    /// <summary>
    ///     Appends the prefix to the start of the string if the string does not already start with prefix.
    /// </summary>
    /// <param name="val">string to append prefix</param>
    /// <param name="prefix">prefix</param>
    /// <param name="ignoreCase">Indicates whether the compare should ignore case</param>
    /// <returns></returns>
    public static string AppendPrefixIfMissing(this string val, string prefix, bool ignoreCase = true)
    {
        if (string.IsNullOrEmpty(val) || (ignoreCase ? val.StartsWithIgnoreCase(prefix) : val.StartsWith(prefix)))
        {
            return val;
        }
        return prefix + val;
    }

    /// <summary>
    ///     Checks if the String contains only Unicode letters.
    ///     null will return false. An empty String ("") will return false.
    /// </summary>
    /// <param name="val">string to check if is Alpha</param>
    /// <returns>true if only contains letters, and is non-null</returns>
    public static bool IsAlpha(this string val)
    {
        if (string.IsNullOrEmpty(val))
        {
            return false;
        }
        return val.Trim().Replace(" ", "").All(char.IsLetter);
    }

    /// <summary>
    ///     Checks if the String contains only Unicode letters, digits.
    ///     null will return false. An empty String ("") will return false.
    /// </summary>
    /// <param name="val">string to check if is Alpha or Numeric</param>
    /// <returns></returns>
    public static bool IsAlphaNumeric(this string val)
    {
        if (string.IsNullOrEmpty(val))
        {
            return false;
        }
        return val.Trim().Replace(" ", "").All(char.IsLetterOrDigit);
    }

    /// <summary>
    ///     Convert string to Hash using Sha512
    /// </summary>
    /// <param name="val">string to hash</param>
    /// <returns>Hashed string</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string CreateHashSha512(string val)
    {
        if (string.IsNullOrEmpty(val))
        {
            throw new ArgumentException("val");
        }
        var sb = new StringBuilder();
        using (SHA512 hash = SHA512.Create())
        {
            byte[] data = hash.ComputeHash(val.ToBytes());
            foreach (byte b in data)
            {
                sb.Append(b.ToString("x2"));
            }
        }
        return sb.ToString();
    }

    /// <summary>
    ///     Convert string to Hash using Sha256
    /// </summary>
    /// <param name="val">string to hash</param>
    /// <returns>Hashed string</returns>
    public static string CreateHashSha256(string val)
    {
        if (string.IsNullOrEmpty(val))
        {
            throw new ArgumentException("val");
        }
        var sb = new StringBuilder();
        using (SHA256 hash = SHA256.Create())
        {
            byte[] data = hash.ComputeHash(val.ToBytes());
            foreach (byte b in data)
            {
                sb.Append(b.ToString("x2"));
            }
        }
        return sb.ToString();
    }

    /// <summary>
    ///     Convert url query string to IDictionary value key pair
    /// </summary>
    /// <param name="queryString">query string value</param>
    /// <returns>IDictionary value key pair</returns>
    public static IDictionary<string, string> QueryStringToDictionary(this string queryString)
    {
        if (string.IsNullOrWhiteSpace(queryString))
        {
            return null;
        }
        if (!queryString.Contains("?"))
        {
            return null;
        }
        string query = queryString.Replace("?", "");
        if (!query.Contains("="))
        {
            return null;
        }
        return query.Split('&').Select(p => p.Split('=')).ToDictionary(
            key => key[0].ToLower().Trim(), value => value[1]);
    }

    /// <summary>
    ///     Reverse back or forward slashes
    /// </summary>
    /// <param name="val">string</param>
    /// <param name="direction">
    ///     0 - replace forward slash with back
    ///     1 - replace back with forward slash
    /// </param>
    /// <returns></returns>
    public static string ReverseSlash(this string val, int direction)
    {
        switch (direction)
        {
            case 0:
                return val.Replace(@"/", @"\");
            case 1:
                return val.Replace(@"\", @"/");
            default:
                return val;
        }
    }

    /// <summary>
    ///     Replace Line Feeds
    /// </summary>
    /// <param name="val">string to remove line feeds</param>
    /// <returns>System.string</returns>
    public static string ReplaceLineFeeds(this string val)
    {
        return Regex.Replace(val, @"^[\r\n]+|\.|[\r\n]+$", "");
    }

    /// <summary>
    ///     Validates if a string is valid IPv4
    ///     Regular expression taken from <a href="http://regexlib.com/REDetails.aspx?regexp_id=2035">Regex reference</a>
    /// </summary>
    /// <param name="val">string IP address</param>
    /// <returns>true if string matches valid IP address else false</returns>
    public static bool IsValidIPv4(this string val)
    {
        if (string.IsNullOrEmpty(val))
        {
            return false;
        }
        return Regex.Match(val,
            @"(?:^|\s)([a-z]{3,6}(?=://))?(://)?((?:25[0-5]|2[0-4]\d|[01]?\d\d?)\.(?:25[0-5]|2[0-4]\d|[01]?\d\d?)\.(?:25[0-5]|2[0-4]\d|[01]?\d\d?)\.(?:25[0-5]|2[0-4]\d|[01]?\d\d?))(?::(\d{2,5}))?(?:\s|$)")
            .Success;
    }

    /// <summary>
    ///     Calculates the amount of bytes occupied by the input string encoded as the encoding specified
    /// </summary>
    /// <param name="val">The input string to check</param>
    /// <param name="encoding">The encoding to use</param>
    /// <returns>The total size of the input string in bytes</returns>
    /// <exception cref="System.ArgumentNullException">input is null</exception>
    /// <exception cref="System.ArgumentNullException">encoding is null</exception>
    public static int GetByteSize(this string val, Encoding encoding)
    {
        if (val == null)
        {
            throw new ArgumentNullException("val");
        }
        if (encoding == null)
        {
            throw new ArgumentNullException("encoding");
        }
        return encoding.GetByteCount(val);
    }


    /// <summary>
    ///     ToTextElements
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static IEnumerable<string> ToTextElements(this string val)
    {
        if (val == null)
        {
            throw new ArgumentNullException("val");
        }
        TextElementEnumerator elementEnumerator = StringInfo.GetTextElementEnumerator(val);
        while (elementEnumerator.MoveNext())
        {
            string textElement = elementEnumerator.GetTextElement();
            yield return textElement;
        }
    }

    /// <summary>
    ///     Check if a string does not start with prefix
    /// </summary>
    /// <param name="val">string to evaluate</param>
    /// <param name="prefix">prefix</param>
    /// <returns>true if string does not match prefix else false, null values will always evaluate to false</returns>
    public static bool DoesNotStartWith(this string val, string prefix)
    {
        return val == null || prefix == null ||
               !val.StartsWith(prefix, StringComparison.InvariantCulture);
    }

    /// <summary>
    ///     Check if a string does not end with prefix
    /// </summary>
    /// <param name="val">string to evaluate</param>
    /// <param name="suffix">suffix</param>
    /// <returns>true if string does not match prefix else false, null values will always evaluate to false</returns>
    public static bool DoesNotEndWith(this string val, string suffix)
    {
        return val == null || suffix == null ||
               !val.EndsWith(suffix, StringComparison.InvariantCulture);
    }

    /// <summary>
    ///     Checks if a string is null
    /// </summary>
    /// <param name="val">string to evaluate</param>
    /// <returns>true if string is null else false</returns>
    public static bool IsNull(this string val)
    {
        return val == null;
    }

    /// <summary>
    ///     Checks if a string is null or empty
    /// </summary>
    /// <param name="val">string to evaluate</param>
    /// <returns>true if string is null or is empty else false</returns>
    public static bool IsNullOrEmpty(this string val)
    {
        return string.IsNullOrEmpty(val);
    }

    /// <summary>
    ///     Checks if string length is a certain minimum number of characters, does not ignore leading and trailing
    ///     white-space.
    ///     null strings will always evaluate to false.
    /// </summary>
    /// <param name="val">string to evaluate minimum length</param>
    /// <param name="minCharLength">minimum allowable string length</param>
    /// <returns>true if string is of specified minimum length</returns>
    public static bool IsMinLength(this string val, int minCharLength)
    {
        return val != null && val.Length >= minCharLength;
    }

    /// <summary>
    ///     Checks if string length is consists of specified allowable maximum char length. does not ignore leading and
    ///     trailing white-space.
    ///     null strings will always evaluate to false.
    /// </summary>
    /// <param name="val">string to evaluate maximum length</param>
    /// <param name="maxCharLength">maximum allowable string length</param>
    /// <returns>true if string has specified maximum char length</returns>
    public static bool IsMaxLength(this string val, int maxCharLength)
    {
        return val != null && val.Length <= maxCharLength;
    }

    /// <summary>
    ///     Checks if string length satisfies minimum and maximum allowable char length. does not ignore leading and
    ///     trailing white-space
    /// </summary>
    /// <param name="val">string to evaluate</param>
    /// <param name="minCharLength">minimum char length</param>
    /// <param name="maxCharLength">maximum char length</param>
    /// <returns>true if string satisfies minimum and maximum allowable length</returns>
    public static bool IsLength(this string val, int minCharLength, int maxCharLength)
    {
        return val != null && val.Length >= minCharLength && val.Length <= minCharLength;
    }

    /// <summary>
    ///     Gets the number of characters in string checks if string is null
    /// </summary>
    /// <param name="val">string to evaluate length</param>
    /// <returns>total number of chars or null if string is null</returns>
    public static int? GetLength(string val)
    {
        return val == null ? null : val.Length;
    }

    private static long lastTimeStamp = DateTime.UtcNow.Ticks;
    public static string UniqueDigits {
        get {
            long original, newValue;
            do
            {
                original = lastTimeStamp;
                long now = DateTime.UtcNow.Ticks;
                newValue = Math.Max(now, original + 1);
            } while (Interlocked.CompareExchange
                         (ref lastTimeStamp, newValue, original) != original);

            return newValue.ToString();
        }
    }



}
