using Microsoft.AspNetCore.Components;

namespace Kitabh_Chautari.Utilities
{
    public static class NavigationManagerExtensions
    {
        public static string GetQueryString(this NavigationManager navigationManager, string key)
        {
            var uri = navigationManager.ToAbsoluteUri(navigationManager.Uri);
            var queryStrings = System.Web.HttpUtility.ParseQueryString(uri.Query);
            return queryStrings[key];
        }
    }
}