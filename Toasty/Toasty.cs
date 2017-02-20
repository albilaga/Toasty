using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;

namespace AndToasty
{
	public static class Toasty
	{
		private readonly static Color DEFAULT_TEXT_COLOR = Color.ParseColor("#FFFFFF");

		private readonly static Color ERROR_COLOR = Color.ParseColor("#D50000");
		private readonly static Color INFO_COLOR = Color.ParseColor("#3F51B5");
		private readonly static Color SUCCESS_COLOR = Color.ParseColor("#388E3C");
		private readonly static Color WARNING_COLOR = Color.ParseColor("#FFA900");

		private readonly static string TOAST_TYPEFACE = "sans-serif-condensed";

		public static Toast Normal(Context context, string message, ToastLength duration = ToastLength.Short)
		{
			return Normal(context, message, null, duration, false);
		}

		public static Toast Normal(Context context, string message, Drawable icon, ToastLength duration = ToastLength.Short, bool withIcon = true)
		{
			return Custom(context, message, icon, DEFAULT_TEXT_COLOR, duration, withIcon);
		}

		public static Toast Warning(Context context, string message, ToastLength duration = ToastLength.Short, bool withIcon = true)
		{
			return Custom(context, message, ToastyUtils.GetDrawable(context, Resource.Drawable.ic_error_outline_white_48dp), DEFAULT_TEXT_COLOR, WARNING_COLOR, duration, withIcon, true);
		}

		public static Toast Info(Context context, string message, ToastLength duration = ToastLength.Short, bool withIcon = true)
		{
			return Custom(context, message, ToastyUtils.GetDrawable(context, Resource.Drawable.ic_info_outline_white_48dp), DEFAULT_TEXT_COLOR, INFO_COLOR, duration, withIcon, true);
		}

		public static Toast Success(Context context, string message, ToastLength duration = ToastLength.Short, bool withIcon = true)
		{
			return Custom(context, message, ToastyUtils.GetDrawable(context, Resource.Drawable.ic_check_white_48dp), DEFAULT_TEXT_COLOR, SUCCESS_COLOR, duration, withIcon, true);
		}

		public static Toast Error(Context context, string message, ToastLength duration = ToastLength.Short, bool withIcon = true)
		{
			return Custom(context, message, ToastyUtils.GetDrawable(context, Resource.Drawable.ic_clear_white_48dp), DEFAULT_TEXT_COLOR, ERROR_COLOR, duration, withIcon, true);
		}

		public static Toast Custom(Context context, string message, Drawable icon, Color textColor, ToastLength duration, bool withIcon)
		{
			return Custom(context, message, icon, textColor, default(Color), duration, withIcon, false);
		}

		public static Toast Custom(Context context, string message, int iconRes, Color textColor, Color tintColor, ToastLength duration, bool withIcon, bool shouldTint)
		{
			return Custom(context, message, ToastyUtils.GetDrawable(context, iconRes), textColor, tintColor, duration, withIcon, shouldTint);
		}

		public static Toast Custom(Context context, string message, Drawable icon, Color textColor, Color tintColor, ToastLength duration, bool withIcon, bool shouldTint)
		{
			var toast = new Toast(context);
			var toastLayout = ((LayoutInflater)context.GetSystemService(Context.LayoutInflaterService)).Inflate(Resource.Layout.ToastLayout, null);
			var toastIcon = toastLayout.FindViewById<ImageView>(Resource.Id.ToastIcon);
			var toastTextView = toastLayout.FindViewById<TextView>(Resource.Id.ToastText);

			Drawable drawableFrame;
			if (shouldTint)
			{
				drawableFrame = ToastyUtils.Tint9PatchDrawableFrame(context, tintColor);
			}
			else
			{
				drawableFrame = ToastyUtils.GetDrawable(context, Resource.Drawable.toast_frame);
			}
			ToastyUtils.SetBackground(toastLayout, drawableFrame);

			if (withIcon)
			{
				if (icon == null)
				{
					throw new Exception("Avoid passing 'icon' as null if 'withIcon' is set to true");
				}
				ToastyUtils.SetBackground(toastIcon, icon);
			}
			else
			{
				toastIcon.Visibility = ViewStates.Gone;
			}

			toastTextView.SetTextColor(textColor);
			toastTextView.Text = message;
			toastTextView.SetTypeface(Typeface.Create(TOAST_TYPEFACE, TypefaceStyle.Normal), TypefaceStyle.Normal);

			toast.View = toastLayout;
			toast.Duration = duration;
			return toast;
		}
	}
}
