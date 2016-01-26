namespace MobileWorkshop.Pages
{
    using System.Collections.ObjectModel;
    using Shared;
    using System.Collections.Generic;
	using Xamarin.Forms;
	using System.Windows.Input;

    public partial class CustomGridPage
    {
        public CustomGridPage(FeedService feedService)
        {
            FeedService = feedService;
			RefreshCommand = new Command (() => LoadAsync ());

			Items = new ObservableCollection<Category> ();
            InitializeComponent();

			LoadAsync ();
        }

        private async void LoadAsync()
        {
			IsBusy = true;
			Items.Clear ();
			var result = await FeedService.GetCategories().ConfigureAwait(false);

			foreach (var item in result) {
				Items.Add (item);
			}
			this.IsBusy = false;
        }

		public ICommand RefreshCommand { get; set; }
        protected FeedService FeedService { get; set; }
		public ObservableCollection<Category> Items { get; set; }
    }
}