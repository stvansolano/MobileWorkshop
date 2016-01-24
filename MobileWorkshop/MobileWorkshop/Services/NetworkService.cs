namespace Shared
{
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using Connectivity.Plugin;

	public class NetworkService : INotifyPropertyChanged
	{
		public NetworkService()
		{
			CrossConnectivity.Current.ConnectivityChanged += (sender, args) => {

                OnPropertyChanged("IsConnected");
			};
		}

		public  bool IsConnected
		{
			get { return CrossConnectivity.Current.IsConnected; }
		}

		public event PropertyChangedEventHandler PropertyChanged;

	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}