using System;
using CoreGraphics;
using AppNexusBindingsIOS;
using UIKit;

namespace appnexustest
{
	public partial class ViewController : UIViewController
	{
		private ANBannerAdView _banner;

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}



		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			int adWidth = 300;
			int adHeight = 250;
			var adID = "1326299";

			//CGRect screenRect = [[UIScreen mainScreen] bounds];
			//CGFloat originX = (screenRect.size.width / 2) - (adWidth / 2);
			//CGFloat originY = (screenRect.size.height / 2) - (adHeight / 2);

			// Needed for when we create our ad view.
			//CGRect rect = CGRectMake(originX, originY, adWidth, adHeight);
			//CGSize size = CGSizeMake(adWidth, adHeight);


			var screenRect = UIScreen.MainScreen.Bounds;
			var originX = (screenRect.Size.Width / 2) - (adWidth / 2);
			var originY = (screenRect.Size.Height / 2) - (adHeight / 2);
			// We want to center our ad on the screen.
			var rect = new CGRect(originX, originY, adWidth, adHeight);
			var size = new CGSize(adWidth, adHeight);

			//var m = new ();

			_banner = ANBannerAdView.AdViewWithFrame(rect, adID, size);
			//var banner2 = IANBannerAdView.AdViewWithFrame(rect, adID);
			//banner.rootViewController = self;
			//banner.delegate = self;
			//[self.view addSubview:banner];

			// Since this example is for testing, we'll turn on PSAs and verbose logging.
			//banner.shouldServePublicServiceAnnouncements = true;
			//[ANLogManager setANLogLevel:ANLogLevelDebug];

			// Load an ad.
			//[banner loadAd];

			//[self locationSetup];  // If you want to pass location...
			//self.banner = banner;

			_banner.RootViewController = this;
			_banner.WeakDelegate = this;
			View.AddSubview(_banner);

			_banner.ShouldServePublicServiceAnnouncements = true;
			_banner.LoadAd();



			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

