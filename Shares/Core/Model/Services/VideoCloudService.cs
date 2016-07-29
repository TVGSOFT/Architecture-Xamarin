using System.Threading.Tasks;
using Core.Model.Responses;
using Core.Constants;

namespace Core.Model.Services
{
	public sealed class VideoCloudService : CloudService, IVideoCloudService
    {

        #region Constructors

		public VideoCloudService(CloudManager cloudManager)
			: base(cloudManager)
        {
        }

        #endregion

        #region Implement Methods

        public async Task<ResponseCategory> GetVideos()
        {
            var response = await CloudManager.GetAsync<ResponseCategory>(Constant.Method.GetVideos, null);
            return response;
        }

        #endregion

    }
}
