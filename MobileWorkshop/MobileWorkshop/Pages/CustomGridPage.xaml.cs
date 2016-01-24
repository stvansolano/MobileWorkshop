namespace MobileWorkshop.Pages
{
    using System.Collections.ObjectModel;
    using Shared;
    using System.Collections.Generic;

    public partial class CustomGridPage
    {
        public CustomGridPage(FeedService feedService)
        {
            FeedService = feedService;


            InitializeComponent();

            BindingContext = this;

            LoadAsync();
        }

        private async void LoadAsync()
        {
            Items = await FeedService.GetCategories().ConfigureAwait(false);
        }

        protected FeedService FeedService { get; set; }

        public IEnumerable<Category> Items { get; set; }
    }
}