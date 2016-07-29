using Core.Abstracts.ViewModel;
using Core.Constants;
using Core.Model.Entities;
using Core.Model.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Views;
using Core.Messages;
using Core.Enums;

namespace Core.ViewModel
{
	public sealed class MainViewModel : AbstractViewModel
    {

        #region Properties

        private IVideoCloudService cloudService;

        private Category category;
        public Category Category
        {
            get
            {
                return category;
            }
            private set
            {
                Set(ref category, value);

                RaisePropertyChanged(() => Videos);
            }
        }

        public IEnumerable<Video> Videos => Category?.Videos;

        private bool isLoading = false;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                Set(ref isLoading, value);
            }
        }

        public Video SelectedVideo
        {
            set
            {
                if (value != null)
                {
                    var videoDetail = new VideoDetail.Builder()
                                                     .SetHls(Category.Hls)
                                                     .SetDash(Category.Dash)
                                                     .SetMp4(Category.Mp4)
                                                     .SetImages(Category.Images)
                                                     .SetVideo(value)
                                                     .Build();

					var message = new ViewModelMessage<VideoDetail>(videoDetail, ViewModelType.VideoDetail);
					MessengerInstance.Send(message);
                    NavigationService.NavigateTo(Constant.ViewKey.VideoDetailView);
                }
            }
        }

        #endregion

        #region Commands

        private RelayCommand refreshCommand;

        public RelayCommand RefreshCommand => refreshCommand ?? 
                                             (refreshCommand = new RelayCommand(LoadData, CanRefreshExcute));

        private RelayCommand<Video> playCommand;
        public RelayCommand<Video> PlayCommand => playCommand ??
                                                 (playCommand = new RelayCommand<Video>(PlayCommandExcute));

        #endregion

        #region Constructors

		public MainViewModel(INavigationService navigationService, IDialogService dialogService, IVideoCloudService cloudService) 
			: base(navigationService, dialogService)
        {
            Title = "Video";

            this.cloudService = cloudService;
        }

        #endregion

        #region Override Methods

        public override async void LoadData()
        {
            IsLoading = true;

			var response = await cloudService.GetVideos();

            IsLoading = false;

            Category = response?.Category?.FirstOrDefault();

            RefreshCommand.RaiseCanExecuteChanged();

			if (Category == null)
			{
				await DialogService.ShowMessage("No video found", "Notification");
			}
        }

        public override void UnLoadData()
        {
            Category = null;
        }

        #endregion

        #region Private Methods

        private bool CanRefreshExcute() => !IsLoading;

        private void PlayCommandExcute(Video video)
        {
            var videoDetail = new VideoDetail.Builder()
                                             .SetHls(Category.Hls)
                                             .SetDash(Category.Dash)
                                             .SetMp4(Category.Mp4)
                                             .SetImages(Category.Images)
                                             .SetVideo(video)
                                             .Build();

			var message = new ViewModelMessage<VideoDetail>(videoDetail, ViewModelType.PlayVideo);
			MessengerInstance.Send(message);
            NavigationService.NavigateTo(Constant.ViewKey.PlayVideoView);
        }

        #endregion

    }
}
