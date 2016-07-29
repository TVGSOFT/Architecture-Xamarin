using System;

namespace Core.ViewModel
{
    public interface INavigationService : GalaSoft.MvvmLight.Views.INavigationService
    {

		void BeginInvokeOnUI(Action action);

    }
}
