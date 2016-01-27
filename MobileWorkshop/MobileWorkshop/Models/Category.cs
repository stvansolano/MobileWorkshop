namespace Shared
{
    using System.Collections.Generic;

    public class Category
    {

		public Category ()
		{
			Articles = new Article[0];
		}

        public string Title { get; set; }

		public ICollection<Article> Articles { get; set; }
    }
}