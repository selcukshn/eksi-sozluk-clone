namespace Common.Helpers
{
    public static class WebConstants
    {
        public static int HttpPort { get; } = 1833;
        public static int HttpsPort { get; } = 18333;
        public static string ApiHttpBase { get; } = "http://localhost";
        public static string ApiHttpsBase { get; } = "https://localhost";
        public static string ApiHttpAddress { get; } = $"{ApiHttpBase}:{HttpPort}";
        public static string ApiHttpsAddress { get; } = $"{ApiHttpsBase}:{HttpsPort}";
    }
}