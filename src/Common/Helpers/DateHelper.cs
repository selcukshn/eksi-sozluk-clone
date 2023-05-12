namespace Common.Helpers
{
    public class DateHelper
    {
        /// <summary>
        /// Şuanın zaman damgasını(timestamp) verir.
        /// </summary>
        /// <returns></returns>
        public static long TimestampNow() => new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }
}