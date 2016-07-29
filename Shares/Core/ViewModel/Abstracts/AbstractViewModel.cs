using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Core.Abstracts.ViewModel
{
    public abstract class AbstractViewModel : ViewModelBase
    {

        #region Properties

        protected Core.ViewModel.INavigationService NavigationService { get; private set; }
		protected IDialogService DialogService { get; private set; }

        public string Title { get; protected set; }

        public new bool IsInDesignMode
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region Commands

        private RelayCommand backCommand;

        public RelayCommand BackCommand => backCommand ??
                                          (backCommand = new RelayCommand(BackCommandExcute));

        #endregion

        #region Constructors

		protected AbstractViewModel(Core.ViewModel.INavigationService navigationService, IDialogService dialogService)
        {
            NavigationService = navigationService;
			DialogService = dialogService;
        }

        #endregion

        #region Public Methods

        public abstract void LoadData();

        public abstract void UnLoadData();

        #endregion

        #region Protected Methods

        protected virtual void BackCommandExcute()
        {
            NavigationService.GoBack();
        }

        #endregion

    }
}
