namespace MobileWorkshop
{
	using Shared;

	public partial class CategoryPage
	{
		public CategoryPage (Category context)
		{
			InitializeComponent ();

			BindingContext = context;
		}
	}
}