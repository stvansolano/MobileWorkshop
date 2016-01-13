using Xamarin.Forms;

[assembly: Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
namespace MobileWorkshop
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application

			MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalOptions = LayoutOptions.Center,
                            Text = "Hello World, Xamarin Forms!"
                        }/*,
                        new Button
                        {
                            Text = "Click me"
                        },
                        new Entry
                        {
                            Text = "some text"
                        }*/
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}