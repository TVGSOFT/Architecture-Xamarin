using Core.Model.Responses;
using System.Threading.Tasks;

namespace Core.Model.Services
{
    public interface IVideoCloudService
    {
		
        Task<ResponseCategory> GetVideos();

    }
}
