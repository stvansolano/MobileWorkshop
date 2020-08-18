using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileWorkshop.Pages
{
    public partial class ListViewPage
    {
        public ListViewPage()
        {
            Items = new ObservableCollection<string>(new [] { "Item #1" });
            DeleteCommand = new Command<string>(DeleteItem);
            ClearCommand = new Command(ClearAll);
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

                CurrentItem.Focus();
            };
        }

        private void ClearAll()
        {
            Items.Clear();
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

        public ICommand ClearCommand { get; set; }
    }
}