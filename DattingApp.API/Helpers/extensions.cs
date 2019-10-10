using Microsoft.AspNetCore.Http;

namespace DattingApp.API.Helpers
{
    public static class extensions
    {
        public static void addApplicationError(this HttpResponse response , string message){
response.Headers.Add("Applcation-Error",message);
response.Headers.Add("Access-Control-Expose-Headers","Applcation-Error");
response.Headers.Add("Access-Control-Allow-Origin","*");
        }
    }
}