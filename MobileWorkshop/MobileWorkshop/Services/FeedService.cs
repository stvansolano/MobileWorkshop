using System.Net;
using Newtonsoft.Json.Linq;

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
				var json = await Get("/Categories.json").ConfigureAwait(false);

				// JSON.Net deserialization
				var parsed = JsonConvert.DeserializeObject<Dictionary<string, Category>>(json);

				foreach (var item in parsed) {
					item.Value.Id = item.Key;
				}
				return parsed.Values.ToArray();
            }
            catch (Exception ex)
            {
				Debug.WriteLine(ex.Message);
            }
            
            return result;
        }

		public async Task<bool> Post(Category instance)
		{
			if (Network.IsConnected == false)
			{
				return false;
			}
				
			try
			{
				var result = await Post("/Categories.json", instance).ConfigureAwait(false);

				return result != null && result.StatusCode == HttpStatusCode.OK;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}

			return false;
		}


		public async Task<bool> Delete(Category instance)
		{
			if (Network.IsConnected == false)
			{
				return false;
			}

			if (string.IsNullOrEmpty(instance.Id)) {
				return false;
			}

			try
			{
				var call = string.Format("/Categories/{0}/.json", instance.Id);
				var result = await Delete(call).ConfigureAwait(false);

				return result != null && result.StatusCode == HttpStatusCode.OK;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}

			return false;
		}
    }
}