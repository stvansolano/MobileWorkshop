namespace Shared
{
    using System.Collections.Generic;

    public class Category
    {
        public string Title { get; set; }

		public IEnumerable<Article> Articles { get; set; }
    }
}