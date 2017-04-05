using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using Wembassy;

namespace WeatherApp.Droid.Scripts.net
{
    class ApiCall
    {
      
        // Initialized Methods
        public enum httpverb
        {
            GET,
            PUT,
            POST,
            DELETE
        }
     
        // Return Seven Days Forecast.
        public static FiveDaysForecast.RootObject SevenDays(string value)
        {

            FiveDaysForecast.RootObject sevendays = new FiveDaysForecast.RootObject();
            HttpWebRequest request = WebRequest.CreateHttp("");
            request.Method = httpverb.GET.ToString();
            var response = request.GetResponse();

            var dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            object objReader = reader.ReadToEnd();

            sevendays = Newtonsoft.Json.JsonConvert.DeserializeObject<FiveDaysForecast.RootObject>(objReader.ToString());
            response.Close();

            return sevendays;          
        }

        // Returns the Current Day Forecast
        public static WeatherAPI.RootObject CurrentDay(string value)
        {
            HttpWebRequest request = WebRequest.CreateHttp(Urls.baseUrl + value + Urls.APP_ID);
            request.Method = httpverb.GET.ToString();
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {                    
                    var dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    object objReader = reader.ReadToEnd();

                    WeatherAPI.RootObject currentday = JsonConvert.DeserializeObject<WeatherAPI.RootObject>(objReader.ToString());
                    response.Close();
                    return currentday;
                }
            }
            catch (System.Net.WebException e)
            {

                // We should display an error modal here.;
                return new WeatherAPI.RootObject();
            }
                             
        }
        
    }
}