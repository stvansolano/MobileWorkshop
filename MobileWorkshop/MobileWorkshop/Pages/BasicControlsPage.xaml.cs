namespace MobileWorkshop.Pages
{
    using Xamarin.Forms;
    using System.Windows.Input;
	using System.Collections.Generic;

    public partial class BasicControlsPage
    {
        public BasicControlsPage()
		{
			MessageCommand = new Command (SayMessage);

			InitializeComponent ();

			PickerControl.Items.Add("Item 1");
			PickerControl.Items.Add("Item 2");
			PickerControl.Items.Add("Item 3");

			BindingContext = this;
		}

        private async void SayMessage()
        {
            await DisplayAlert("Message", "Clicked button!", "Cancel");
        }

        public ICommand MessageCommand { get; set; }
    }
}