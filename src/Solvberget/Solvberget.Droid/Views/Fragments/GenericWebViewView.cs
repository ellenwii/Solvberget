using Android.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Views;
using Solvberget.Core.ViewModels;

namespace Solvberget.Droid.Views.Fragments
{
    [Activity(Label = "Webside", Theme = "@style/MyTheme", Icon = "@android:color/transparent", ParentActivity = typeof(HomeView))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "solvberget.droid.views.HomeView")]
    public class GenericWebViewView : MvxActivity
    {
        private WebView _webView;

        protected override void OnViewModelSet()
        {
            Window.RequestFeature(WindowFeatures.Progress);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            base.OnViewModelSet();

            SetContentView(Resource.Layout.page_webview);

            
            var set = this.CreateBindingSet<GenericWebViewView, GenericWebViewViewModel>();
            set.Bind(ActionBar).For(v => v.Title).To(vm => vm.Title).Mode(MvxBindingMode.OneWay);
            set.Apply();


            _webView = FindViewById<WebView>(Resource.Id.webView);
            _webView.Settings.JavaScriptEnabled = true;
            _webView.Settings.SetSupportZoom(true);


            var progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            var webChromeClient = new ProgressUpdatingWebChromeClient(progressBar);
            var webViewClient = new ProgressHandlingWebViewClient(progressBar);
            _webView.SetWebViewClient(webViewClient);
            _webView.SetWebChromeClient(webChromeClient);
    
            _webView.LoadUrl(((GenericWebViewViewModel)(ViewModel)).Uri);
        }
    }
}