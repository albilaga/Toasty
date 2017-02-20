using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using AndToasty;

namespace ToastySample
{
	[Activity(Label = "Toasty Sample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			FindViewById<Button>(Resource.Id.ButtonErrorToast).Click += delegate
			{
				Toasty.Error(this, "This is an error toast").Show();
			};

			FindViewById<Button>(Resource.Id.ButtonSuccessToast).Click += delegate
			{
				Toasty.Success(this, "Success").Show();
			};

			FindViewById<Button>(Resource.Id.ButtonInfoToast).Click += delegate
			{
				Toasty.Info(this, "Here is some info for you").Show();
			};
			FindViewById<Button>(Resource.Id.ButtonWarningToast).Click += delegate
			{
				Toasty.Warning(this, "Beware of the dog").Show();
			};
			FindViewById<Button>(Resource.Id.ButtonNormalToastWithoutIcon).Click += delegate
			{
				Toasty.Normal(this, "Normal toast without icon").Show();
			};
			FindViewById<Button>(Resource.Id.ButtonNormalToastWithIcon).Click += delegate
			{
				var icon = ToastyUtils.GetDrawable(this, Resource.Drawable.ic_pets_white_48dp);
				Toasty.Normal(this, "Normal toast with icon", icon).Show();
			};
		}
	}
}

