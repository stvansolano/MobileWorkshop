namespace Shared
{
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using System.Collections.ObjectModel;
	using System.Diagnostics;

    public class FeedService : RestService
    {
        private const string ApiAddress = "https://xamarin-workshop.firebaseio.com/";

        public FeedService(NetworkService networkService) : base(ApiAddress, networkService)
        {
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var result = new ObservableCollection<Category>();

            if (Network.IsConnected == false)
            {
                return result;
            }
				
            try
            {
                var json = await Get("/Categories/.json").ConfigureAwait(false);
				dynamic dictionary = JsonConvert.DeserializeObject<object>(json);

				foreach (var item in dictionary) {
					var category = new Category { 
						Title = item.Category.Title
					};

					var articles = new List<Article>();

					foreach (var child in item.Category.Articles) {
						articles.Add(new Article { Title = child.Title, Text = child.Text});
					}

					category.Articles = articles.ToArray();
					result.Add(category);
				}
            }
            catch (Exception ex)
            {
				Debug.WriteLine(ex.Message);
            }
            
            return result;
        }
    }
}
