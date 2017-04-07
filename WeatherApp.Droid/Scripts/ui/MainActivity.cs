using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Wembassy;
using System;
using Android.Views;

namespace WeatherApp.Droid
{
    [Activity(Label = "Wembassy Weather Application", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EditText et1 = FindViewById<EditText>(Resource.Id.editText1);
            Button btn1 = FindViewById<Button>(Resource.Id.button1);

            btn1.Click += delegate
            {
                CurrentDay(et1.Text);
            };
         }


        // Create a Call to CurrentDay Class in ApiCall
        public void CurrentDay(string location)
        {
            WeatherAPI.RootObject currentForecast = RestClient.makeRequest(location);
            List<WeatherAPI.Weather> waw = currentForecast.weather;
            if (waw != null)
            {
                waw.ForEach(delegate (WeatherAPI.Weather todaysForecast)
                {
                    TextView tv1 = FindViewById<TextView>(Resource.Id.tvTemp);
                    tv1.Text = todaysForecast.description;
                });
            }
            else
            {
                TextView tv1 = FindViewById<TextView>(Resource.Id.tvTemp);
                tv1.Text = "could not connect to the service City or Location not found.";
            }
        }

       
    }   
    
     
}

