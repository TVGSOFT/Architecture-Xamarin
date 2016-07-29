using Core.Abstracts.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace VideoManager.Sources.Pages.Abstracts
{
    public abstract class AbstractPage : Page
    {

        #region Contructors

        public AbstractPage() : base()
        { 
        }

        #endregion

        #region Override Methods

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationCacheMode = NavigationCacheMode.Disabled;

                UnLoadData(null, null);
            }

            base.OnNavigatedFrom(e);
        }

        #endregion

        #region Protected Methods

        protected void RegisterLoadData()
        {
            Loaded += LoadData;
            Unloaded += UnLoadData;
        }

        protected virtual void LoadData(object sender, RoutedEventArgs e)
        {
            (DataContext as AbstractViewModel)?.LoadData();
        }

        protected virtual void UnLoadData(object sender, RoutedEventArgs e)
        {
            (DataContext as AbstractViewModel)?.UnLoadData();
        }

        #endregion

    }
}
