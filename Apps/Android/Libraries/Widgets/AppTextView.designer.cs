using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using System;

namespace Widgets
{
    public partial class AppTextView : AppCompatTextView
    {

        #region Constructors

        public AppTextView(Context context): base(context)
        {
            Initialize(null);
        }

        public AppTextView(Context context, IAttributeSet attrs): base(context, attrs)
        {
            Initialize(attrs);
        }

        public AppTextView(Context context, IAttributeSet attrs, int defStyleAttr): base(context, attrs, defStyleAttr)
        {
            Initialize(attrs);
        }
        
        protected AppTextView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        #endregion

    }
}