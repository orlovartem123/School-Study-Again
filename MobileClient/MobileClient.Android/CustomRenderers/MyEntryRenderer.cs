using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using MobileClient.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(MyEntryRenderer))]
namespace MobileClient.Droid.CustomRenderers
{
    [System.Obsolete]
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            var color = Android.Graphics.Color.Black;

            if (App.Current.RequestedTheme == OSAppTheme.Dark)
                color = Android.Graphics.Color.WhiteSmoke;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                Control.BackgroundTintList = ColorStateList.ValueOf(color);
            else
                Control.Background.SetColorFilter(color, PorterDuff.Mode.SrcAtop);
        }
    }
}