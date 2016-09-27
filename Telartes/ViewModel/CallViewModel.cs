using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace  Telartes
{
	public class CallViewModel:ViewModelBase
	{
		public CallViewModel()//double baseValue)
		{
			// Initialize ICommand properties.
			OpenCallPageCommand = new Command(ExecuteOpenCallPage);
		}

		void ExecuteOpenCallPage()
		{

		}


		public ICommand OpenCallPageCommand { private set; get; }

	}
}


