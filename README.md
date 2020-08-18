
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
.
+-- _Views
|   +-- ItemsPage.xaml / .xaml.cs
|   +-- ItemdDetailPage.xaml / .xaml.cs
+-- _ViewModels
|   +-- ItemsViewModel.cs
|   +-- ItemdDetailViewModel.cs
+-- Models
|   +-- Item.cs
+-- Services
|   +-- MockDataStore.cs 
|   +-- IDataStore.cs (interface) 
+-- App.xaml / .xaml.cs
+-- AppShell.xaml / .xaml.cs

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
