using Core.Model.Responses;
using System.Threading.Tasks;

namespace Core.Model.Services
{
    public sealed class DesignVideoCloudService : IVideoCloudService
    {

        #region Constructors

        public DesignVideoCloudService()
        {
        }

        #endregion

        #region Implement Methods

        public Task<ResponseCategory> GetVideos()
        {
            return null;
        }

        #endregion

    }
}
