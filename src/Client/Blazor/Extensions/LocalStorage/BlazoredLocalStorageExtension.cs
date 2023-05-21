using Blazored.LocalStorage;

namespace Blazor.Extensions.LocalStorage
{
    public static class BlazoredLocalStorageExtension
    {
        public const string JWTKey = "token";
        public static async Task<string> GetJWTAsync(this ILocalStorageService storage)
        {
            return await storage.GetItemAsStringAsync(JWTKey);
        }
        public static async Task SetJWTAsync(this ILocalStorageService storage, string token)
        {
            await storage.SetItemAsStringAsync(JWTKey, token);
        }
        public static async Task RemoveJWTAsync(this ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(JWTKey);
        }
    }
}