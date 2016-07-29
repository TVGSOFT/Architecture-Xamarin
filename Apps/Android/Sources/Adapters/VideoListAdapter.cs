using Android.Content;
using Core.ViewModel;
using VideoManager.Sources.Adapters.Abstracts;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Square.Picasso;
using System;
using VideoManager.Droid.Sources;
using VideoManager.Droid;

namespace VideoManager.Sources.Adapters
{
    public class VideoListAdapter : AbstractRecyclerViewAdapter
    {

        #region Properties

        private MainViewModel viewModel => App.Locator.MainViewModel;

        #endregion

        #region Constructors

        public VideoListAdapter(Context context) : base(context)
        {

        }

        #endregion

        #region Override Methods

        public override int ItemCount => viewModel.Videos?.Count() ?? 0;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(Context)
                                     .Inflate(Resource.Layout.layout_video_list_item, parent, false);
            var viewHolder = new ViewHolder(view);
            viewHolder.ImageView.RootView.Click += VideoItemClick;
            viewHolder.ImageButtonPlay.Click += PlayVideoClick;

            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var video = viewModel.Videos
                                 .ElementAt(position);

            var viewHolder = holder as ViewHolder;

            Picasso.With(Context)
                   .Load($"{viewModel.Category.Images}{video.Thumb}")
                   .Into(viewHolder.ImageView);

            viewHolder.TextViewTitle.Text = video.Title;
            viewHolder.TextViewStudio.Text = video.Studio;

            viewHolder.ImageView.RootView.Tag = position;
            viewHolder.ImageButtonPlay.Tag = position;
        }

        #endregion

        #region Actions

        private void VideoItemClick(object sender, EventArgs e)
        {
            var position = (int)(sender as View).Tag;

            if (IsValidPosition(position))
            {
                var video = viewModel.Videos
                                     .ElementAt(position);

                viewModel.SelectedVideo = video;
            }
        }

        private void PlayVideoClick(object sender, EventArgs e)
        {
            var position = (int)(sender as View).Tag;

            if (IsValidPosition(position))
            {
                var video = viewModel.Videos
                                     .ElementAt(position);

                viewModel.PlayCommand
                         .Execute(video);
            }
        }

        #endregion

        #region ViewHolder

        private class ViewHolder : RecyclerView.ViewHolder
        {

            #region Properties

            public AppCompatImageView ImageView { get; private set; }
            public AppCompatImageButton ImageButtonPlay { get; private set; }
            public AppCompatTextView TextViewTitle { get; private set; }
            public AppCompatTextView TextViewStudio { get; private set; }

            #endregion

            #region Constructors

            public ViewHolder(View itemView) : base(itemView)
            {
                ImageView = itemView.FindViewById<AppCompatImageView>(Resource.Id.iv_video);
                ImageButtonPlay = itemView.FindViewById<AppCompatImageButton>(Resource.Id.ib_play);
                TextViewTitle = itemView.FindViewById<AppCompatTextView>(Resource.Id.tv_title);
                TextViewStudio = itemView.FindViewById<AppCompatTextView>(Resource.Id.tv_studio);
            }

            #endregion

        }

        #endregion

    }
}