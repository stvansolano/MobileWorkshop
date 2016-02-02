using System.Threading.Tasks;

namespace MobileWorkshop.Pages
{
    using System.Collections.ObjectModel;
    using Shared;
    using System.Collections.Generic;
	using Xamarin.Forms;
	using System.Windows.Input;

    public partial class CustomGridPage : ContentPage
    {
		public ICommand RefreshCommand { get; set; }
		protected FeedService FeedService { get; set; }
		public ObservableCollection<Category> Items { get; set; }
		public ICommand TappedCommand { get; set; }

        public CustomGridPage(FeedService feedService)
        {
            FeedService = feedService;
			RefreshCommand = new Command (async() => LoadAsync ());
			TappedCommand = new Command<Category> (category => BrowseCategory(category));
			Items = new ObservableCollection<Category> ();
            
			InitializeComponent();

			Load();

			CurrentItem.Completed += async (sender, args) =>
			{
				AddItem();
				await LoadAsync().ConfigureAwait(false);
			};
        }

		private async void AddItem()
		{
			if (string.IsNullOrEmpty(CurrentItem.Text))
			{
				return;
			}

			CurrentItem.Text = string.Empty;
			CurrentItem.Focus();

			await FeedService.Post(new Category { Title = CurrentItem.Text });
		}

        private async void Load()
        {
			IsBusy = true;
			Items.Clear ();

			var result = await FeedService.GetCategories().ConfigureAwait(false);

			foreach (Category item in result) {
				Items.Add (item);
			}
			IsBusy = false;
        }

		public Task LoadAsync()
		{
			return Task.Factory.StartNew(Load);
		}

		private void BrowseCategory(Category item)
		{
			base.Navigation.PushAsync (new CategoryPage (item));
		}
    }
}