using Android.Content;
using Android.Support.V7.Widget;

namespace VideoManager.Sources.Adapters.Abstracts
{
    public abstract class AbstractRecyclerViewAdapter : RecyclerView.Adapter
    {

        #region Properties

        protected Context Context { get; private set; }

        #endregion

        #region Constructors

        public AbstractRecyclerViewAdapter(Context context)
        {
            Context = context;
        }

        #endregion

        #region Protected Methods

        protected bool IsValidPosition(int position) => position >= 0 && position < ItemCount - 1;

        #endregion

    }
}