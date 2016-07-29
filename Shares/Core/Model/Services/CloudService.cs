
namespace Core.Model.Services
{
	public class CloudService
	{

		#region Properties

		protected CloudManager CloudManager { get; private set; }

		#endregion

		#region Constructors

		public CloudService(CloudManager cloudManager)
		{
			CloudManager = cloudManager;
		}

		#endregion

	}
}

