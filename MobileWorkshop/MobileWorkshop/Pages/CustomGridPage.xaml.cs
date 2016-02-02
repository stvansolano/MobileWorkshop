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
		public ICommand DeleteCommand { get; set; }

        public CustomGridPage(FeedService feedService)
        {
            FeedService = feedService;
			RefreshCommand = new Command (async() => await LoadAsync ());
			TappedCommand = new Command<Category> (category => BrowseCategory(category));
			DeleteCommand = new Command<Category> (category => DeleteCategory(category));
			Items = new ObservableCollection<Category> ();
            
			InitializeComponent();

			Load();

			CurrentItem.Completed += (sender, args) =>
			{
				AddItem();
			};
        }

		private async void AddItem()
		{
			if (string.IsNullOrEmpty(CurrentItem.Text))
			{
				return;
			}

			IsBusy = true;
			var posted = new Category { Title = CurrentItem.Text };
			await FeedService.Post(posted);
			IsBusy = false;

			Items.Add (posted);
			CurrentItem.Text = string.Empty;
			CurrentItem.Focus();
		}

        private async void Load()
        {
			IsBusy = true;

			var result = await FeedService.GetCategories().ConfigureAwait(false);

			Items.Clear ();
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
			
		private async void DeleteCategory(Category item)
		{
			var result = await base.DisplayAlert ("Confirm delete", "Delete selected item?", "Delete", "Cancel").ConfigureAwait (false);

			if (result == false) {
				return;
			}

			Items.Remove(item);

			IsBusy = true;
			await FeedService.Delete (item).ConfigureAwait(false);
			IsBusy = false;
		}
    }
}