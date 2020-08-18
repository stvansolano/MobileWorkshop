using System;
using System.Windows.Input;
using MobileWorkshop.Models;
using MobileWorkshop.Views;

namespace MobileWorkshop.ViewModels
{
	public class ItemDetailViewModel : BaseViewModel
	{
		public Item Item { get; set; }

		public ItemDetailViewModel(Item item = null)
		{
			Title = item?.Text;
			Item = item;

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
