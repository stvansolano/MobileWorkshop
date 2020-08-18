using System.Windows.Input;
using MobileWorkshop.Models;
using Xamarin.Forms;

namespace MobileWorkshop.ViewModels
{
	public class ItemDetailViewModel : BaseViewModel
	{
		public Item Item { get; set; }

		public ItemDetailViewModel(INavigation navigation, Item item = null)
		{
			Title = item?.Text;
			Item = item;

			Text = item.Text;
			Description = item.Description;

			SaveCommand = new Xamarin.Forms.Command(async() => {

				Item.Description = Description;
				item.Text = Text;

				Xamarin.Forms.MessagingCenter.Send(this, "UpdateItem", Item);

				await navigation.PopAsync();
			});
		}

		private void Update(Item item)
		{
			Text = item.Text;
			Description = item.Description;
		}

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

		private ICommand _saveCommand;
		public ICommand SaveCommand
		{
			get => _saveCommand;
			set => SetProperty(ref _saveCommand, value);
		}
	}
}
