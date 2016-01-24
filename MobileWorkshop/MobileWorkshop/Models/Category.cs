namespace Shared
{
    using System.Collections.Generic;
	using Newtonsoft.Json;

    public class Category
    {
        public string Title { get; set; }

		public Article[] Articles { get; set; }
    }
}