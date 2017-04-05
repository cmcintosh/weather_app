using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Wembassy
{
   
    public class RestClient : WeatherAPI
    {           
        // Web Request Methods.
        public enum httpverb
        {
            GET,
            PUT,
            POST,
            DELETE
        }

        private static string baseUrl = "http://api.openweathermap.org/data/2.5/weather?q=";

        private static string forecastUrl = "http://samples.openweathermap.org/data/2.5/forecast?";

        public RestClient()
        {
           
        }

        // Returns the Weather Forecast today.        
        public static WeatherAPI.RootObject makeRequest(string value)
        {
            string actionUrl = baseUrl + value + "&appid=98d8eb3d190051551f5cdbb079b6670d";
            HttpWebRequest request = WebRequest.CreateHttp(actionUrl);
            request.Method = httpverb.GET.ToString();
            try { 
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) { 

                    var dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    object objResponse = reader.ReadToEnd();

                    WeatherAPI.RootObject weat = JsonConvert.DeserializeObject<WeatherAPI.RootObject>(objResponse.ToString());
                    response.Close();

                    return weat;
                }
            }
            catch (WebException ex)
            {
                return new WeatherAPI.RootObject();
            }
        }

        // Five days forecast.
        public static FiveDaysForecast.RootObject fiveDaysForecast(string id)
        {
            FiveDaysForecast.RootObject fdf = new FiveDaysForecast.RootObject();
            string url = forecastUrl + id + "&appid=98d8eb3d190051551f5cdbb079b6670d";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.Method = httpverb.GET.ToString();

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {

                    var dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    object objResponse = reader.ReadToEnd();

                    fdf = JsonConvert.DeserializeObject<FiveDaysForecast.RootObject>(objResponse.ToString());
                    response.Close();

                    return fdf;
                }
            }
            catch (WebException ex)
            {
               
                Console.Out.WriteLine(ex.Status);
                return new FiveDaysForecast.RootObject();
            }
        }
    }
}
