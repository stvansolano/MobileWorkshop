namespace Shared
{
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using System.Collections.ObjectModel;

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

            var parsed = await Get<Category>("/Categories/.json").ConfigureAwait(false);

            foreach (var item in parsed)
            {
                result.Add(item);
            }

            return result;
        }

    }
}
