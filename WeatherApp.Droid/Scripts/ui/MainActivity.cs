using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
namespace WeatherApp.Droid
{
    [Activity(Label = "Wembassy Weather App", MainLauncher = true, Icon = "@drawable/icon")]
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
            Scripts.net.CurrentDayForecast.RootObject currentForecast = Scripts.net.ApiCall.CurrentDay(location);
            List<Scripts.net.CurrentDayForecast.Weather> waw = currentForecast.weather;
            if (waw != null)
            {
                waw.ForEach(delegate (Scripts.net.CurrentDayForecast.Weather todaysForecast)
                {
                    TextView tv1 = FindViewById<TextView>(Resource.Id.tvTemp);
                    tv1.Text = todaysForecast.description;
                });
            }
            else
            {
                TextView tv1 = FindViewById<TextView>(Resource.Id.tvTemp);
                tv1.Text = "City or Location not found.";
            }
        } 
    }
}

