using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Solvberget.Core.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Solvberget.iOS
{
	public partial class BlogOverviewView : MvxTableViewController
    {
		public new BlogOverviewViewModel ViewModel
		{
			get
			{
				return base.ViewModel as BlogOverviewViewModel;
			}
		}

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
			
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            // Perform any additional setup after loading the view, typically from a nib.
			var source = new MvxStandardTableViewSource(TableView, UITableViewCellStyle.Subtitle, new NSString("TableViewCell"), "TitleText Title; DetailText Description", UITableViewCellAccessory.None);
			TableView.Source = source;

			var loadingIndicator = new LoadingOverlay(View.Frame);
			Add(loadingIndicator);
				
			var set = this.CreateBindingSet<BlogOverviewView, BlogOverviewViewModel>();
			set.Bind(source).To(vm => vm.Blogs);
			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ShowDetailsCommand);
			Title = ViewModel.Title;
			set.Bind(loadingIndicator).For("Visibility").To(vm => vm.IsLoading).WithConversion("Visibility");

			set.Apply();

			NavigationItem.HidesBackButton = true;

			TableView.ReloadData();
        }
    }
}

