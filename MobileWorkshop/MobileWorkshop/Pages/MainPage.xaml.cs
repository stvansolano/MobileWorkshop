using System.Windows.Input;
using MobileWorkshop.Views;
using Xamarin.Forms;

namespace MobileWorkshop.Pages
{
    public partial class MainPage
    {
        public MainPage()
        {
            HelloWorld = new HelloWorldPage();
            DataView = new ListViewPage();
           
			HelloWorldCommand = new Command(() =>
			{
				SetCurrentPage(HelloWorld);

				IsPresented = false;
			});

            DataCommand = new Command(() =>
            {
				SetCurrentPage(DataView);

                IsPresented = false;
            });
			
            InitializeComponent();

            BindingContext = this;

			SetCurrentPage(HelloWorld);
        }

		private void SetCurrentPage(Page page){
			page.Title = Title;

			Detail = new NavigationPage (page);
		}

        public ICommand DataCommand { get; set; }
        public ICommand HelloWorldCommand { get; set; }

		public ListViewPage DataView { get; set; }
		public Page HelloWorld { get; set; }
    }
}