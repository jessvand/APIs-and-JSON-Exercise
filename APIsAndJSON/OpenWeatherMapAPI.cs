using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        //http://api.openweathermap.org/data/2.5/weather?q=Albuquerque&appid=15f019e27c6c133cbc816e10a5462387&units=imperial
        public static void GetTemerature()
        {
            var appsettingsTxt = File.ReadAllText("appsettings.json");

            var apiKey = JObject.Parse(appsettingsTxt).GetValue("key").ToString();

            //user enters city
            Console.WriteLine("In which city in New Mexico would you like to check the weather?");

            var city = Console.ReadLine();
                        
            //build url for api call
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=imperial";

            var client = new HttpClient();
            var jsonTxt = client.GetStringAsync(url).Result;

            
            var tempObject = JObject.Parse(jsonTxt);

            //parsed string as j object - can be indexed***

            Console.WriteLine($"Temperature:{tempObject["main"]["temp"]}");


        }

       
    }
}
