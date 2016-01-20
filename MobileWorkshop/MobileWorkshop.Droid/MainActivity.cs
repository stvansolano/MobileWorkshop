using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MobileWorkshop.Droid
{
    [Activity(Label = "Mobile Workshop",
              //Theme = "@style/AppTheme",
              Icon = "@drawable/icon",
              MainLauncher = true,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
        //Xamarin.Forms.Platform.Android.FormsAppCompatActivity 

    {
        protected override void OnCreate(Bundle bundle)
        {
            //ToolbarResource = Resource.Layout.toolbar;
            //TabLayoutResource = Resource.Layout.tabs;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}