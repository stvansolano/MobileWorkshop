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
            var result = new List<Category>();

            if (Network.IsConnected == false)
            {
                return result;
            }
				
            try
            {
                var json = await Get("/Categories/.json").ConfigureAwait(false);
				var parsed = JsonConvert.DeserializeObject<List<Category>>(json);

				return parsed;
            }
            catch (Exception ex)
            {
				Debug.WriteLine(ex.Message);
            }
            
            return result;
        }
    }
}