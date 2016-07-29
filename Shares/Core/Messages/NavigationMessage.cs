
namespace Core.Messages
{
	public sealed class NavigationMessage
	{

		#region Properties

		public string PageName { get; set; }

		#endregion

		#region Constructors

		public NavigationMessage(string pageName)
		{
			PageName = pageName;
		}

		#endregion

	}
}

