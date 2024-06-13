using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {
        private static string RonQuote(HttpClient client)
        {
            var jsonTxt = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;

           var quote = jsonTxt.Replace('[', ' ').Replace(']',' ').Replace('"',' ').Trim();

            return quote;
        }

        private static string YeQuote(HttpClient client)
        {
            var jsonTxt = client.GetStringAsync("https://api.kanye.rest/").Result;

            var quote =  JObject.Parse(jsonTxt).GetValue("quote").ToString();

            return quote;
        }


        public static void Conversation()
        {
           var client = new HttpClient();
            
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Swanson says:\n {RonQuote(client)}");

                Console.WriteLine($"West says:\n {YeQuote(client)}");

            }
        }
    }
}
