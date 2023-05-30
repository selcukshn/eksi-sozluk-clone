using Microsoft.AspNetCore.Components;

namespace Blazor.Extensions
{
    public static class NavigationManagerExtension
    {
        public static void NavigateToHomePage(this NavigationManager manager)
        {
            manager.NavigateTo("/");
        }
        public static void NavigateToPage(this NavigationManager manager, string url, int? page = null)
        {
            string query = page != null ? $"/{url}" : $"/{url}?page={page}";
            manager.NavigateTo(query);
        }
        public static void NavigateToProfilePage(this NavigationManager manager, string username)
        {
            manager.NavigateTo($"/biri/{username}");
        }
    }
}