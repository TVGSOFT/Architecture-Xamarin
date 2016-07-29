using Android.Text;
using Android.Text.Style;
using Android.Util;
using Managers;
using System;
using VideoManager.Droid;

namespace Widgets
{
    public partial class AppTextView
    {

        #region Private Methods

        private void Initialize(IAttributeSet attrs)
        {
            if (attrs != null)
            {
				var typedArray = Context.ObtainStyledAttributes(attrs, Resource.Styleable.AppTextView);
                var fontName = typedArray.GetString(Resource.Styleable.AppTextView_fontName);
                var isUnderline = typedArray.GetBoolean(Resource.Styleable.AppTextView_isUnderLine, false);
                var isSelected = typedArray.GetBoolean(Resource.Styleable.AppTextView_isSelected, false);

                typedArray.Recycle();
                
                try
                {
                    Typeface = FontManager.CreateTypeface(Context, fontName);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }

                SetUnderLine(Text, isUnderline);
                Selected = isSelected;
            }
        }

        #endregion

        #region Public Methods

        public void SetUnderLine(string text, bool isUnderline)
        {
            if (isUnderline)
            {
                var spanString = new SpannableString(text);
                spanString.SetSpan(new UnderlineSpan(), 0, spanString.Length(), 0);
                TextFormatted = spanString;
            }
            else
            {
                Text = text;
            }
        }

        #endregion

    }
}