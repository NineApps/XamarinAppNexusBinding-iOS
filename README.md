AppNexus Binding for Xamarin IOS
===================

Based on and contains parts of AppNexus mobile SDK for iOS https://github.com/appnexus/mobile-sdk-ios

----------


Usage
-------------

Include the AppNexusBindingsIOS project in your project as a reference. 

App nexus communicates over HTTP (at least in the default settings we use) so you will need to ensure to configure app transport security to allow this [like this](https://developer.xamarin.com/guides/ios/platform_features/introduction_to_ios9/ats/).

```C#
using System;
using CoreGraphics;
using AppNexusBindingsIOS;
using UIKit;
```
To create a centered sample ad add some code to the ViewDidLoad of your ViewModel. 

```C#
public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			int adWidth = 300;
			int adHeight = 250;
			var adID = "1326299";


			var screenRect = UIScreen.MainScreen.Bounds;
			var originX = (screenRect.Size.Width / 2) - (adWidth / 2);
			var originY = (screenRect.Size.Height / 2) - (adHeight / 2);

			// We want to center our ad on the screen.
			var rect = new CGRect(originX, originY, adWidth, adHeight);
			var size = new CGSize(adWidth, adHeight);

			_banner = ANBannerAdView.AdViewWithFrame(rect, adID, size);

			_banner.RootViewController = this;
			_banner.WeakDelegate = this;
			View.AddSubview(_banner);

			_banner.ShouldServePublicServiceAnnouncements = true;
			_banner.LoadAd();
		}
```
