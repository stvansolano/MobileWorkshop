namespace MobileWorkshop.Pages
{
    using Xamarin.Forms;
    using System.Windows.Input;

    public partial class BasicControlsPage
    {
        public BasicControlsPage()
        {
            MessageCommand = new Command(SayMessage);

            InitializeComponent();

            BindingContext = this;
        }

        private async void SayMessage()
        {
            await DisplayAlert("Message", "Clicked button!", "Cancel");
        }

        public ICommand MessageCommand { get; set; }
    }
}
