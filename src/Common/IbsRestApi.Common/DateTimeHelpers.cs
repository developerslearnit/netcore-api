namespace IbsRestApi.Common;
public static class DateTimeHelpers
{
    public static DateTime ToDateWithoutTime(this DateTime value)
    {
        var strDate = value.ToString("dd/MM/yyyy").Split('/');

        return new DateTime(int.Parse(strDate[2]), int.Parse(strDate[1]), int.Parse(strDate[1]));

    }
}
