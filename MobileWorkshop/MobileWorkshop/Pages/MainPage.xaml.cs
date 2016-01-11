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
                Detail = HelloWorld;

                IsPresented = false;
            });
            DataCommand = new Command(() =>
            {
                Detail = DataView;

                IsPresented = false;
            });

            InitializeComponent();

            BindingContext = this;
            Detail = HelloWorld;
        }

        public ICommand DataCommand { get; set; }
        public ICommand HelloWorldCommand { get; set; }

        public ListViewPage DataView { get; set; }
        public Page HelloWorld { get; set; }
    }
}