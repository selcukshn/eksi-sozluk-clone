namespace Common.Helpers;

public static class StringHelper
{
    /// <summary>
    /// Girilen parametreyi URI formatına çevirir.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string CreateUrl(string text) => Uri.EscapeDataString(text.ToLower());

    /// <summary>
    /// Girilen parametreyi URI formatına çevirir ve sonuna şuanın zaman dalgasını(timestamp) ekler.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string CreateUniqueUrl(string text)
    {
        return $"{CreateUrl(text)}_{DateHelper.TimestampNow()}";
    }
}