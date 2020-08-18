
#  Mobile Workshop: Xamarin Intro

[Twitter: @stvansolano](https://twitter.com/stvansolano)

## Do you like it? Give a Star! :star:

If you like or are using this project to learn or start your own solution, please give it a star. I appreciate it!

## Required to be installed

- For Windows/Mac: [https://xamarin.com/download](https://xamarin.com/download)
- Or you can get it incorporated as part of Visual Studio 2015:  [VS 2015 Community Edition](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx)

## Getting started:

1. File -> New Project -> Shell Forms App (Xamarin.Forms Shell Template)

2. MobileWorkshop.Android project -> Right click -> Set as Startup project

> Optionally, MobileWorshop.iOS can be run as well

3. Hit Run!

## Exercises:

### 1. Understanding MVVM structure (MobileWorkshop.csproj)

```
MobileWorkshop
│
└───/Views
│   └───ItemsPage.xaml (xaml|cs)
│   └───ItemDetailPage.xaml (xaml|cs)
│       ...
│
└───/ViewModels
│   └───ItemsViewModel.cs
│   └───ItemdDetailViewModel.cs
│       ...
│
└───/Models
│   └───Item.cs
│   └───...
│
└───/Services
    │   MockDataStore.txt
    │   IDataStore.cs    
── App.xaml / .xaml.cs
── AppShell.xaml / .xaml.cs
```

1.1 Modifiy `ItemDetailPage.xaml` (View)

        <Button Text="Save" CornerRadius="10" BackgroundColor="Gold" TextColor="Black" Command="{Binding SaveCommand}" />

1.2 Modify `ItemsPage.xaml` (View)

       <CheckBox IsChecked="{Binding IsChecked}" />

1.3 Extend `ItemdDetailViewModel.cs` (ViewModel)


```
		private bool _isChecked;
		public bool IsChecked
		{
			get => _isChecked;
			set => SetProperty(ref _isChecked, value);
		}

		private string _text;
		public string Text
		{
			get => _text;
			set => SetProperty(ref _text, value);
		}

		private string _description;
		public string Description
		{
			get => _description;
			set => SetProperty(ref _description, value);
		}
```

> **Important:** Remember to set those properties!

### 2. Make the app reactive

2.1. Update the constructor of `ItemsViewModel.cs` (ViewModel)

```
public ItemsViewModel(INavigation navigation)
		{
			Title = "Browse";
			Items = new ObservableCollection<ItemDetailViewModel>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
			Navigation = navigation;

			MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
			{
				var newItem = item as Item;
				Items.Add(new ItemDetailViewModel(Navigation, item));
				await DataStore.AddItemAsync(newItem);
			});

			MessagingCenter.Subscribe<ItemDetailViewModel, Item>(this, "UpdateItem", async (obj, item) =>
			{
				var newItem = item as Item;

				await DataStore.UpdateItemAsync(newItem);
			});
		}
```
2.2. Add the `INavigation` property to the ItemsViewModel and the `SaveCommand` body in the `ItemsViewModel.cs` (ViewModel) class

			SaveCommand = new Xamarin.Forms.Command(async() => {

				Item.Description = Description;
				item.Text = Text;

				Xamarin.Forms.MessagingCenter.Send(this, "UpdateItem", Item);

				await navigation.PopAsync();
			});

	//Update method

		private void Update(Item item)
		{
			Text = item.Text;
			Description = item.Description;
		}


> **Important:** Complete missing compliation errors and update `OnItemSelected` casting!


### 3. Customizing the Shell

3.1. Add a new control (ContentView) called `HeaderView` (XAML+cs code)

3.2. Add a new `CustomShell.cs` class to the project

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
> **Important:** CustomShell references the HeaderView control


3.3. Change the App.xaml.cs to use `CustomShell` class instead of `AppShell` (default View)
