using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileWorkshop.Pages
{
    public partial class ListViewPage
    {
        public ListViewPage()
        {
            Items = new ObservableCollection<string>(new string[] { "Item #1" });
            DeleteCommand = new Command<string>(DeleteItem);

            InitializeComponent();

            BindingContext = this;

            CurrentItem.Completed += (sender, args) =>
            {
                if (string.IsNullOrEmpty(CurrentItem.Text))
                {
                    return;
                }
                Items.Add(CurrentItem.Text);
                CurrentItem.Text = string.Empty;
            };
        }

        private void DeleteItem(string selectedItem)
        {
            if (string.IsNullOrEmpty(selectedItem))
            {
                return;
            }
            Items.Remove(selectedItem);
        }

        public ObservableCollection<string> Items { get; set; }
        public ICommand DeleteCommand { get; set; }
    }
}