namespace Shared
{
    using System.Collections.Generic;
	using Newtonsoft.Json;

    public class Category
    {
		public Category ()
		{
			Articles = new Article[0];
		}

		[JsonIgnore]
		public string Id { get; set; }

        public string Title { get; set; }

		public ICollection<Article> Articles { get; set; }
    }
}