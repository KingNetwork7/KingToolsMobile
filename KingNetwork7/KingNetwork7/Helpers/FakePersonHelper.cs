using KingNetwork7.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FakePerson = KingNetwork7.Models.FakePerson;

namespace KingNetwork7.Helpers
{
    public static class FakePersonHelper
    {
        static HttpClient client;
        static string reqAddress;

        static FakePersonHelper()
        {
            client = new HttpClient();
            reqAddress = "Http://212.227.175.36/Api/Tools/GetFakePerson/";
        }

        public static async Task<FakePerson> GetNewRawFakePerson(FakePersonCountries country)
        {
            try
            {
                var req = await client.PostAsync(new Uri(reqAddress + country.ToString()), null);
                var res = await req.Content.ReadAsStringAsync();
                using (var sReader = new StringReader(res))
                {
                    using (var jReader = new JsonTextReader(sReader))
                    {
                        return JsonSerializer.CreateDefault().Deserialize<FakePerson>(jReader);
                    }
                }
            }
            catch (Exception e)
            {
                Helpers.AlertsHelper.ShowAlert("Unexpected Error on Receive Data", "An unexpected error occurred on receive data from server.\nPlease Try Again & Report this Problem .", "OK");
                //Helpers.AlertsHelper.ShowAlert("Error", e.Message, "Fuck This Shit Error");
                return null;
            }
        }

        public static string GetCountryFullName(this FakePersonCountries country)
        {
            switch (country)
            {
                case FakePersonCountries.de:
                    return "Germany";
                case FakePersonCountries.br:
                    return "Brazil";
                case FakePersonCountries.nl:
                    return "Netherlands";
                case FakePersonCountries.us:
                    return "United States";
                case FakePersonCountries.es:
                    return "Spain";
                case FakePersonCountries.au:
                    return "Australia";
                case FakePersonCountries.ph:
                    return "Philippines";
                case FakePersonCountries.ro:
                    return "Romania";
                case FakePersonCountries.it:
                    return "Italia";
                case FakePersonCountries.ca:
                    return "Canada";
                case FakePersonCountries.se:
                    return "Sweden";
                default:
                    return "Unknown";
            }
        }
    }
}
