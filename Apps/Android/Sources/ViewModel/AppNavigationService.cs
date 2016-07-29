using System;
using System.Collections.Generic;
using Android.Content;
using Core.ViewModel;
using Android.Support.V4.App;
using VideoManager.Droid.Sources.Activities.Abstracts;

namespace VideoManager.Droid.Sources.ViewModel
{
    /// <summary>
    /// Xamarin Android implementation of <see cref="INavigationService"/>.
    /// This implementation can be used in Xamarin Android applications (not Xamarin Forms).
    /// </summary>
    /// <remarks>For this navigation service to work properly, your Activities
    /// should derive from the <see cref="AbstractAppCompatActivity"/> class.</remarks>
    ////[ClassInfo(typeof(INavigationService))]
    public sealed class AppNavigationService : INavigationService
    {

        /// <summary>
        /// The key that is returned by the <see cref="CurrentPageKey"/> property
        /// when the current Activiy is the root activity.
        /// </summary>
        public const string RootPageKey = "-- ROOT --";

        private const string ParameterKeyName = "ParameterKey";

        private readonly Dictionary<string, Type> pagesByKey = new Dictionary<string, Type>();
        private readonly Dictionary<string, object> parametersByKey = new Dictionary<string, object>();

        /// <summary>
        /// The key corresponding to the currently displayed page.
        /// </summary>
        public string CurrentPageKey => AbstractAppCompatActivity.CurrentActivity.ActivityKey ?? RootPageKey;

        /// <summary>
        /// If possible, discards the current page and displays the previous page
        /// on the navigation stack.
        /// </summary>
        public void GoBack()
        {
            AbstractAppCompatActivity.GoBack();
        }

        /// <summary>
        /// Displays a new page corresponding to the given key. 
        /// Make sure to call the <see cref="Configure"/>
        /// method first.
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page
        /// that should be displayed.</param>
        /// <exception cref="ArgumentException">When this method is called for 
        /// a key that has not been configured earlier.</exception>
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        /// <summary>
        /// Displays a new page corresponding to the given key,
        /// and passes a parameter to the new page.
        /// Make sure to call the <see cref="Configure"/>
        /// method first.
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page
        /// that should be displayed.</param>
        /// <param name="parameter">The parameter that should be passed
        /// to the new page.</param>
        /// <exception cref="ArgumentException">When this method is called for 
        /// a key that has not been configured earlier.</exception>
        public void NavigateTo(string pageKey, object parameter)
        {
            if (AbstractAppCompatActivity.CurrentActivity == null)
            {
                throw new InvalidOperationException("No CurrentActivity found");
            }

            lock (pagesByKey)
            {
                if (!pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(
                        string.Format("No such page: {0}. Did you forget to call NavigationService.Configure?", pageKey),
                        "pageKey");
                }

                var intent = new Intent(AbstractAppCompatActivity.CurrentActivity, pagesByKey[pageKey]);

                if (parameter != null)
                {
                    lock (parametersByKey)
                    {
                        var guid = Guid.NewGuid().ToString();
                        parametersByKey.Add(guid, parameter);
                        intent.PutExtra(ParameterKeyName, guid);
                    }
                }

                ActivityCompat.StartActivity(AbstractAppCompatActivity.CurrentActivity, intent, null);
                AbstractAppCompatActivity.NextPageKey = pageKey;
            }
        }

        /// <summary>
        /// Adds a key/page pair to the navigation service.
        /// </summary>
        /// <remarks>For this navigation service to work properly, your Activities
        /// should derive from the <see cref="AbstractAppCompatActivity"/> class.</remarks>
        /// <param name="key">The key that will be used later
        /// in the <see cref="NavigateTo(string)"/> or <see cref="NavigateTo(string, object)"/> methods.</param>
        /// <param name="activityType">The type of the activity (page) corresponding to the key.</param>
        public AppNavigationService Configure(string key, Type activityType)
        {
            lock (pagesByKey)
            {
                if (pagesByKey.ContainsKey(key))
                {
                    pagesByKey[key] = activityType;
                }
                else
                {
                    pagesByKey.Add(key, activityType);
                }
            }

            return this;
        }

        /// <summary>
        /// Allows a caller to get the navigation parameter corresponding 
        /// to the Intent parameter.
        /// </summary>
        /// <param name="intent">The <see cref="Android.App.Activity.Intent"/> 
        /// of the navigated page.</param>
        /// <returns>The navigation parameter. If no parameter is found,
        /// returns null.</returns>
        public object GetAndRemoveParameter(Intent intent)
        {
            if (intent == null)
            {
                throw new ArgumentNullException("Intent", "This method must be called with a valid Activity intent");
            }

            var key = intent.GetStringExtra(ParameterKeyName);

            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            lock (parametersByKey)
            {
                if (parametersByKey.ContainsKey(key))
                {
                    return parametersByKey[key];
                }

                return null;
            }
        }

        /// <summary>
        /// Allows a caller to get the navigation parameter corresponding 
        /// to the Intent parameter.
        /// </summary>
        /// <typeparam name="T">The type of the retrieved parameter.</typeparam>
        /// <param name="intent">The <see cref="Android.App.Activity.Intent"/> 
        /// of the navigated page.</param>
        /// <returns>The navigation parameter casted to the proper type.
        /// If no parameter is found, returns default(T).</returns>
        public T GetAndRemoveParameter<T>(Intent intent)
        {
            return (T)GetAndRemoveParameter(intent);
        }

        /// <summary>
        /// Update data in UI thread.
        /// </summary>
        /// <param name="action"></param>
        public void BeginInvokeOnUI(Action action)
        {
            if (action == null)
            {
                return;
            }

            AbstractAppCompatActivity.CurrentActivity?
                                     .RunOnUiThread(action);
        }

    }
}