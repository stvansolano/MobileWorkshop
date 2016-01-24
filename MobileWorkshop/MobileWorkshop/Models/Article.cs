namespace Shared
{
	using Newtonsoft.Json;

    public class Article
    {
		[JsonProperty]
        public string Title { get; set; }

		[JsonProperty]
        public string Text { get; set; }
    }
}