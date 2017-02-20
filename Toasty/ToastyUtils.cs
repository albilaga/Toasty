using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;

namespace AndToasty
{
	public static class ToastyUtils
	{
		public static Drawable Tint9PatchDrawableFrame(Context context, Color tintColor)
		{
			var toastDrawable = (NinePatchDrawable)GetDrawable(context, Resource.Drawable.toast_frame);
			toastDrawable.SetColorFilter(new PorterDuffColorFilter(tintColor, PorterDuff.Mode.SrcIn));
			return toastDrawable;
		}

		public static void SetBackground(View view, Drawable drawable)
		{
			if (Build.VERSION.SdkInt >= BuildVersionCodes.JellyBean)
			{
				view.Background = drawable;
			}
			else
			{
				view.SetBackgroundDrawable(drawable);
			}
		}

		public static Drawable GetDrawable(Context context, int resourceId)
		{
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			{
				return context.GetDrawable(resourceId);
			}
			else
			{
				return context.Resources.GetDrawable(resourceId);
			}
		}
	}
}
