using Core.Enums;

namespace Core.Messages
{
	public sealed class ViewModelMessage<T>
	{

		#region Properties

		public T Data { get; set; }

		public ViewModelType Type { get; set; }

		#endregion

		#region Constructors

		public ViewModelMessage()
		{
		}

		public ViewModelMessage(T data, ViewModelType type)
		{
			Data = data;
			Type = type;
		}

		#endregion

	}
}

