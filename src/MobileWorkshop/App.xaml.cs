using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileWorkshop.Services;
using MobileWorkshop.Views;
using System.Linq;

namespace MobileWorkshop
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockDataStore>();
			MainPage = new CustomShell();
		}
	}

	public class CustomShell : Shell
	{
		public CustomShell() => Build();
		public ItemsPage AllItems { get; set; } = new ItemsPage();
		public AboutPage About { get; set; } = new AboutPage();

		private void Build()
		{
			FlyoutBehavior = FlyoutBehavior.Flyout;

			FlyoutHeader = new HeaderView();

			AddFlyout("Home", AllItems, "My to-dos");
			AddFlyout("About", new AboutPage());

			AddTab("Done", new ContentPage { Content = new Label { Text = "Done!" } });

			CurrentItem = Items.First();
		}

		private void AddFlyout(string title, ContentPage page, string defaultTab = null)
		{
			defaultTab = defaultTab ?? title;

			var flyout = new FlyoutItem
			{
				Title = title,
				Items = {
					new Tab {
						Title = defaultTab,
						Items = {
							new ShellContent {
								ContentTemplate = new DataTemplate(() => page)
							}
						}
					}
				}
			};
			Items.Add(flyout);
		}

		private void AddTab(string title, ContentPage page)
		{
			var flyoutItem = Items.OfType<FlyoutItem>().FirstOrDefault();
			
			flyoutItem.Items.Add(
				new Tab
				{
					Title = title,
					Items = {
							new ShellContent {
								ContentTemplate = new DataTemplate(() => page)
							}
						}
				});
		}
	}
}
