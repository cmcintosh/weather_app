using Android.App;
using Android.Widget;
using Android.OS;

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

            // Get each input EditBox (for entering longitude and latitude) and
            // the button from the layout resource:

            TextView tempname = FindViewById<TextView>(Resource.Id.tempText);
            
        }
       
        
    }
}

