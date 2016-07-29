
namespace Core.Model.Entities
{
    public class VideoDetail
    {

        #region Properties

        public string Hls { get; set; }

        public string Dash { get; set; }

        public string Mp4 { get; set; }

        public string Images { get; set; }

        public Video Video { get; set; }

        #endregion

        #region Constructors

        private VideoDetail()
        {

        }

        #endregion

        #region Builder

        public class Builder : IBuilder<VideoDetail>
        {

			#region Properties

			private string hls;

			private string dash;

			private string mp4;

			private string images;

			private Video video;

            #endregion

            #region Constructors

            public Builder()
            {
                
            }

            #endregion

            public Builder SetHls(string hls)
            {
				this.hls = hls;
                return this;
            }

            public Builder SetDash(string dash)
            {
				this.dash = dash;
                return this;
            }

            public Builder SetMp4(string mp4)
            {
				this.mp4 = mp4;
                return this;
            }

            public Builder SetImages(string images)
            {
				this.images = images;
                return this;
            }

            public Builder SetVideo(Video video)
            {
				this.video = video;
                return this;
            }

            public VideoDetail Build()
            {
				var videoDetail = new VideoDetail();
				videoDetail.Hls = hls;
				videoDetail.Dash = dash;
				videoDetail.Mp4 = mp4;
				videoDetail.Images = images;
				videoDetail.Video = video;

                return videoDetail;
            }

        }

        #endregion

    }
}
