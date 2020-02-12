using KingNetwork7.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KingNetwork7.Helpers
{
    public static class DisposableEmailHelpers
    {
        static HttpClient client;
        static string apiAddress;

        static DisposableEmailHelpers()
        {
            client = new HttpClient();
            apiAddress = "http://212.227.175.36/Api/Tools/";
        }

        public static string GetNewRandomDisposableEmailUserName()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);
        }

        public static async Task<List<ListEmail>> GetEmails()
        {
            try
            {
                var jsonBody = JsonConvert.SerializeObject(App.MainViewModel.CurrentDisposableEmailUserName);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                var req = await client.PostAsync(new Uri(apiAddress+ "GetEmails/"), content);
                var res = await req.Content.ReadAsStringAsync();
                using (var sReader = new StringReader(res))
                {
                    using (var jReader = new JsonTextReader(sReader))
                    {
                        return JsonSerializer.CreateDefault().Deserialize<List<ListEmail>>(jReader);
                    }
                }
            }
            catch
            {
                Helpers.AlertsHelper.ShowAlert("Unexpected Error on Receive Data", "An unexpected error occurred on receive data from server.\nPlease Try Again & Report this Problem .", "OK");
                return new List<ListEmail>();
            }
        }

        public static async Task<Email> GetEmail(int id)
        {
            try
            {
                var jsonBody = JsonConvert.SerializeObject(App.MainViewModel.CurrentDisposableEmailUserName);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                var req = await client.PostAsync(new Uri(apiAddress + $"GetEmail/{id}"), content);
                var res = await req.Content.ReadAsStringAsync();
                using (var sReader = new StringReader(res))
                {
                    using (var jReader = new JsonTextReader(sReader))
                    {
                        return JsonSerializer.CreateDefault().Deserialize<Email>(jReader);
                    }
                }
            }
            catch 
            {
                Helpers.AlertsHelper.ShowAlert("Unexpected Error on Receive Data", "An unexpected error occurred on receive data from server.\nPlease Try Again & Report this Problem .", "OK");
                return new Email();
            }
        }
    }
}
