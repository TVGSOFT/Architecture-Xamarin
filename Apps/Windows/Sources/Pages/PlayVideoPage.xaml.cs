using VideoManager.Sources.Pages.Abstracts;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VideoManager.Sources.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayVideoPage : AbstractPage
    {

        #region Constructors

        public PlayVideoPage() : base()
        {
            this.InitializeComponent();

            RegisterLoadData();
        }

        #endregion

    }
}
