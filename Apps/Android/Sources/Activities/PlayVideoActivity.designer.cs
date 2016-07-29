using Android.Widget;
using VideoManager.Droid.Sources.Activities.Abstracts;

namespace VideoManager.Droid.Sources.Activities
{
    public partial class PlayVideoActivity : AbstractAppCompatActivity
    {

        #region Properties

        public VideoView VideoView { get; private set; }

        #endregion

        protected override void InitializeUI()
        {
            SetContentView(Resource.Layout.activity_play_video);

            VideoView = FindViewById<VideoView>(Resource.Id.video_view);
        }

    }
}