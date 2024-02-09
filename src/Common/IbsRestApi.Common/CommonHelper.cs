using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace IbsRestApi.Common;

public class CommonHelper
{
    public static string FormatException(Exception ex)
    {
        var message = ex.Message;
        //Add the inner exception if present (showing only the first 50 characters of the first exception)
        if (ex.InnerException == null) return message;
        if (message.Length > 150)
            message = message.Substring(0, 150);

        message += "...->" + ex.InnerException.Message + "...->" + (ex.InnerException.InnerException != null ? ex.InnerException.InnerException.Message : "");

        return message;
    }
    public static DateTime CoverrtDate(string getdate)
    {
        try
        {
            string[] dateTokens = getdate.Split('/', '-');
            string strYear = dateTokens[2];
            string strDay = dateTokens[0];
            string strMonth = dateTokens[1];
            string date = strMonth + "/" + strDay + "/" + strYear;
            var newDate = new DateTime(int.Parse(strYear), int.Parse(strMonth), int.Parse(strDay));
            return newDate;
        }
        catch (Exception)
        {
            return DateTime.Now;
        }
    }

    public static DateTime CoverrtDateFromComma(string getdate)
    {
        try
        {
            string[] dateTokens = getdate.Split(',', '-');
            string strYear = dateTokens[0];
            string strDay = dateTokens[2];
            string strMonth = dateTokens[1];
            string date = strMonth + "/" + strDay + "/" + strYear;
            var newDate = new DateTime(int.Parse(strYear), int.Parse(strMonth), int.Parse(strDay));
            return newDate;
        }
        catch (Exception)
        {
            return DateTime.Now;
        }
    }

    public static string MapPath(string path)
    {
        //if (HostingEnvironment.IsHosted)
        //{
        //    //hosted
        //    return HostingEnvironment.MapPath(path);
        //}

        //not hosted. For example, run in unit tests
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
        return Path.Combine(baseDirectory, path);
    }
    public static bool IsValidEmail(string email)
    {
        if (email.Trim().EndsWith("."))
        {
            return false; // suggested by @TK-421
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    public static bool IsValidEmailAddress(string emailaddress)
    {
        try
        {
            Regex rx = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(emailaddress);
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        try
        {
            Regex rx = new Regex(@"[0][7-9][0-1][0-9]{8}");
            return rx.IsMatch(phoneNumber);
        }
        catch (FormatException)
        {
            return false;
        }
    }
    public static bool IsPasswordStrong(string password)
    {
        return Regex.IsMatch(password, @"^.*(?=.{7,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).*$");
    }

    public static string GenerateRandomString(int length, bool uppercase = false, bool specialXter = false)
    {
        RandomStringGenerator stringGenerator = new RandomStringGenerator();

        return stringGenerator.NextString(length, true, uppercase, true, specialXter);
    }

    public static decimal ConvertToNaira(decimal amount, decimal rate)
    {
        return amount * rate;
    }

    public static byte[] GetBytes(IFormFile file)
    {
        using (var stream = file.OpenReadStream())
        {
            var bytes = new byte[file.Length];
            stream.Read(bytes, 0, bytes.Length);
            return bytes;
        }
    }

    public static string GetFileExtension(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            return string.Empty;

        var fileExtension = Path.GetExtension(fileName);
        if (string.IsNullOrEmpty(fileExtension))
            return string.Empty;

        return fileExtension.ToLower();
    }

   
}
