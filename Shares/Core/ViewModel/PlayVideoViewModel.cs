using Core.Abstracts.ViewModel;
using Core.Model.Entities;
using System.Linq;
using Core.Messages;
using Core.Enums;

namespace Core.ViewModel
{
    public sealed class PlayVideoViewModel : AbstractViewModel
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

                if (videoDetail?.Video?.Sources?.LastOrDefault() != null)
                {
                    RaisePropertyChanged(() => VideoUrl);
                }
            }
        }

        public string VideoUrl => $"{VideoDetail.Mp4}{VideoDetail.Video.Sources.LastOrDefault().Url}";

        #endregion

        #region Constructors

        public PlayVideoViewModel(INavigationService navigationService) 
			: base(navigationService, null)
        {
			MessengerInstance.Register<ViewModelMessage<VideoDetail>>(this, HandleViewModelMessage);
        }

        #endregion

        #region Deconstructor

        ~PlayVideoViewModel()
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
			if (message.Type == ViewModelType.PlayVideo)
			{
				VideoDetail = message.Data;

				Title = VideoDetail?.Video?.Title;
			}
        }

        #endregion

    }
}

