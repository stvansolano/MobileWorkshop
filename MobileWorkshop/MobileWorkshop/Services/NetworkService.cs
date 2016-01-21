namespace Shared
{
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using Connectivity.Plugin;

	public class NetworkService : INotifyPropertyChanged
	{
		private bool _isConnected;

		public NetworkService()
		{
			CrossConnectivity.Current.ConnectivityChanged += (sender, args) => {
				IsConnected = args.IsConnected;
			};

			IsConnected = CrossConnectivity.Current.IsConnected;
		}

		public  bool IsConnected
		{
			get { return _isConnected; }
			set
			{
				_isConnected = value;
				OnPropertyChanged();
			}
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