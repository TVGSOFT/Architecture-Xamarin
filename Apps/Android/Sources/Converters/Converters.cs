using System;
using Android.Views;
using System.Collections.Generic;
using System.Linq;

namespace VideoManager.Sources
{
	public static class Converters
    {

		public static ViewStates BoolToVisibleOrInvisible(bool visibility)
			=> visibility ? ViewStates.Visible : ViewStates.Invisible;
		                              
        public static ViewStates BoolToVisibleOrGone(bool visibility)
        	=> visibility ? ViewStates.Visible : ViewStates.Gone;

        public static ViewStates InvertBoolToVisibleOrGone(bool visibility)
        	=> InvertBoolToBool(visibility) ? ViewStates.Visible : ViewStates.Gone;

		public static ViewStates ObjectToVisibleOrGone(object obj)
        	=> obj != null ? ViewStates.Visible : ViewStates.Gone;

        public static ViewStates ObjectToVisibleOrInvisible(object obj)
        	=> obj != null ? ViewStates.Visible : ViewStates.Invisible;

        public static ViewStates ArrayToVisibleOrGone<T>(IEnumerable<T> data)
        	=> data?.Count() > 0 ? ViewStates.Visible : ViewStates.Gone;

        public static bool ArrayToBool<T>(IEnumerable<T> data)
       		=> data?.Count() > 0;

        public static bool InvertArrayToBool<T>(IEnumerable<T> data)
        	=> !ArrayToBool(data);

		public static ViewStates InvertArrayToVisibleOrGone<T>(IEnumerable<T> data)
			=> ArrayToBool(data) ? ViewStates.Gone : ViewStates.Visible;

        public static bool InvertBoolToBool(bool value)
       		=> !value;

    }
}