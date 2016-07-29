using Android.Content;
using Android.Graphics;
using System.Collections.Generic;

namespace Managers
{
    public sealed class FontManager
    {

        #region Properties

        private static IDictionary<string, Typeface> caches = new Dictionary<string, Typeface>();

        #endregion

        #region Constructors

        private FontManager()
        {

        }

        #endregion

        #region Public Methods

        public static Typeface CreateTypeface(Context context, string fontName)
        {
            Typeface typeface;
            if (caches.ContainsKey(fontName))
            {
                typeface = caches[fontName];
            }
            else
            {
                typeface = Typeface.CreateFromAsset(context.Assets, "Fonts/" + fontName);
                caches.Add(fontName, typeface);
            }
            return typeface;
        }

        #endregion

    }
}