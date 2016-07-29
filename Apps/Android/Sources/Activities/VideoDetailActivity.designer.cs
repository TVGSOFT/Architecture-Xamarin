using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using VideoManager.Droid.Sources.Activities.Abstracts;

namespace VideoManager.Droid.Sources.Activities
{
    public partial class VideoDetailActivity : AbstractAppCompatActivity
    {

        #region Properties

        public AppCompatImageView ImageView { get; private set; }
        public AppCompatImageButton ImageButtonPlay { get; private set; }
        public AppCompatTextView TextViewTitle { get; private set; }
        public AppCompatTextView TextViewSubTitle { get; private set; }

        #endregion

        protected override void InitializeUI()
        {
            SetContentView(Resource.Layout.activity_video_detail);

            ImageView = FindViewById<AppCompatImageView>(Resource.Id.iv_video);
            ImageButtonPlay = FindViewById<AppCompatImageButton>(Resource.Id.ib_play);
            TextViewTitle = FindViewById<AppCompatTextView>(Resource.Id.tv_title);
            TextViewSubTitle = FindViewById<AppCompatTextView>(Resource.Id.tv_subtitle);
        }

    }
}