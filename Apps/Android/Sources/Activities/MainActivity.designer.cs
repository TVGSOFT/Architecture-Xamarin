using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using VideoManager.Droid.Sources.Activities.Abstracts;

namespace VideoManager.Droid.Sources.Activities
{
    public partial class MainActivity : AbstractAppCompatActivity
    {

        #region Properties

        protected SwipeRefreshLayout SwipeRefreshLayout { get; private set; }
        protected RecyclerView RecyclerView { get; private set; }

        #endregion

        protected override void InitializeUI()
        {
            SetContentView(Resource.Layout.activity_main);

            SwipeRefreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.swipe_refresh_layout);
            RecyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view);
        }

    }
}