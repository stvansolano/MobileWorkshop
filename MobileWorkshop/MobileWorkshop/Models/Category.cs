namespace Shared
{
    using System.Collections.Generic;
	using Newtonsoft.Json;

    public class Category
    {
        public string Title { get; set; }

		public IEnumerable<Article> Articles { get; set; }
    }
}