using Core.Abstracts.ViewModel;
using Core.Constants;
using Core.Enums;
using Core.Messages;
using Core.Model.Entities;
using GalaSoft.MvvmLight.Command;

namespace Core.ViewModel
{
    public sealed class VideoDetailViewModel : AbstractViewModel
    {

        #region Properties

        private VideoDetail videoDetail;
        public VideoDetail VideoDetail
        {
            get
            {
                return videoDetail;
            }
            set
            {
                Set(ref videoDetail, value);

                if (videoDetail?.Video?.Thumb != null)
                {
                    RaisePropertyChanged(() => ThumbnailUrl);
                }
            }
        }

        public string ThumbnailUrl => $"{VideoDetail.Images}{VideoDetail.Video.Thumb}";

        #endregion

        #region Commands

        private RelayCommand playCommand;
        public RelayCommand PlayCommand => playCommand ??
                                          (playCommand = new RelayCommand(PlayCommandExcute));

        #endregion

        #region Constructors

		public VideoDetailViewModel(INavigationService navigationService)
			: base(navigationService, null)
        {
            MessengerInstance.Register<ViewModelMessage<VideoDetail>>(this, HandleViewModelMessage);
        }

        #endregion

        #region Deconstructor

        ~VideoDetailViewModel()
        {
            MessengerInstance.Unregister<ViewModelMessage<VideoDetail>>(this, HandleViewModelMessage);
        }

        #endregion

        #region Override Methods

        public override void LoadData()
        {
        }

        public override void UnLoadData()
        {
            VideoDetail = null;
        }

		#endregion

		#region Handle Messages

		private void HandleViewModelMessage(ViewModelMessage<VideoDetail> message)
		{
			if (message.Type == ViewModelType.VideoDetail)
			{
				VideoDetail = message.Data;

				Title = VideoDetail?.Video?.Title;
			}
		}

        #endregion

        #region Private Methods

        private void PlayCommandExcute()
        {
			var message = new ViewModelMessage<VideoDetail>(VideoDetail, ViewModelType.PlayVideo);
            MessengerInstance.Send(message);
            NavigationService.NavigateTo(Constant.ViewKey.PlayVideoView);
        }

        #endregion

    }
}
