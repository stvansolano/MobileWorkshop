using System.Windows.Input;
using MobileWorkshop.Views;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
namespace MobileWorkshop.Pages
{
    public partial class MainPage
    {
        public MainPage()
        {
            HelloWorld = new HelloWorldPage();
            DataView = new ListViewPage();
            BasicControls = new BasicControlsPage();

			HelloWorldCommand = new Command(() => SetCurrentPage(HelloWorld));
            DataCommand = new Command(() => SetCurrentPage(DataView));
            BasicControlsCommand = new Command(() => SetCurrentPage(BasicControls));

            InitializeComponent();

            BindingContext = this;

			SetCurrentPage(HelloWorld);
        }

		private void SetCurrentPage(Page page){
			page.Title = Title;

			Detail = new NavigationPage (page);

            IsPresented = false;
        }

        public ICommand BasicControlsCommand { get; set; }
        public ICommand DataCommand { get; set; }
        public ICommand HelloWorldCommand { get; set; }

        public Page BasicControls { get; set; }
        public ListViewPage DataView { get; set; }
		public Page HelloWorld { get; set; }
    }
}