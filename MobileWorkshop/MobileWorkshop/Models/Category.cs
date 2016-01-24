namespace Shared
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Category
    {
        public Category()
        {
            Title = "test";
        }

        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public IEnumerable<Article> Articles { get; set; }
    }
}