using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MobileWorkshop.Models;
using MobileWorkshop.Views;

namespace MobileWorkshop.ViewModels
{
	public class ItemsViewModel : BaseViewModel
	{
		public ObservableCollection<ItemDetailViewModel> Items { get; set; }
		public Command LoadItemsCommand { get; set; }
		public INavigation Navigation { get; private set; }

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

		async Task ExecuteLoadItemsCommand()
		{
			IsBusy = true;

			try
			{
				Items.Clear();
				var items = await DataStore.GetItemsAsync(true);
				foreach (var item in items)
				{
					Items.Add(new ItemDetailViewModel(Navigation, item));
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}