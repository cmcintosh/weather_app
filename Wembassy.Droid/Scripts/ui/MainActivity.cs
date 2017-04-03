using Android.App;
using Android.Widget;
using Android.OS;
using Wembassy;

namespace Wembassy.Droid
{
    [Activity(Label = "Wembassy.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);     


            // Event Handlers.
            TextView temperature = FindViewById<TextView>(Resource.Id.tempText);

            temperature.Text = "Location";        
                
        }
       
        
    }
}

