using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace AppNexusBindingsIOS
{
	// @protocol ANAdProtocol <NSObject>
	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface IANAdProtocol
	{
		// @required @property (readwrite, nonatomic, strong) NSString * placementId;
		[Abstract]
		[Export("placementId", ArgumentSemantic.Strong)]
		string PlacementId { get; set; }

		// @required @property (readonly, assign, nonatomic) NSInteger memberId;
		[Abstract]
		[Export("memberId")]
		nint MemberId { get; }

		// @required @property (readonly, nonatomic, strong) NSString * inventoryCode;
		[Abstract]
		[Export("inventoryCode", ArgumentSemantic.Strong)]
		string InventoryCode { get; }

		// @required @property (assign, readwrite, nonatomic) BOOL opensInNativeBrowser;
		[Abstract]
		[Export("opensInNativeBrowser")]
		bool OpensInNativeBrowser { get; set; }

		// @required @property (assign, readwrite, nonatomic) BOOL shouldServePublicServiceAnnouncements;
		[Abstract]
		[Export("shouldServePublicServiceAnnouncements")]
		bool ShouldServePublicServiceAnnouncements { get; set; }

		// @required @property (readwrite, nonatomic, strong) ANLocation * location;
		[Abstract]
		[Export("location", ArgumentSemantic.Strong)]
		ANLocation Location { get; set; }

		// @required @property (assign, readwrite, nonatomic) CGFloat reserve;
		[Abstract]
		[Export("reserve")]
		nfloat Reserve { get; set; }

		// @required @property (readwrite, nonatomic, strong) NSString * age;
		[Abstract]
		[Export("age", ArgumentSemantic.Strong)]
		string Age { get; set; }

		// @required @property (assign, readwrite, nonatomic) ANGender gender;
		[Abstract]
		[Export("gender", ArgumentSemantic.Assign)]
		ANGender Gender { get; set; }

		// @required @property (readwrite, nonatomic, strong) NSMutableDictionary * customKeywords;
		[Abstract]
		[Export("customKeywords", ArgumentSemantic.Strong)]
		NSMutableDictionary CustomKeywords { get; set; }

		// @required -(void)setLocationWithLatitude:(CGFloat)latitude longitude:(CGFloat)longitude timestamp:(NSDate *)timestamp horizontalAccuracy:(CGFloat)horizontalAccuracy;
		[Abstract]
		[Export("setLocationWithLatitude:longitude:timestamp:horizontalAccuracy:")]
		void SetLocationWithLatitude(nfloat latitude, nfloat longitude, NSDate timestamp, nfloat horizontalAccuracy);

		// @required -(void)setLocationWithLatitude:(CGFloat)latitude longitude:(CGFloat)longitude timestamp:(NSDate *)timestamp horizontalAccuracy:(CGFloat)horizontalAccuracy precision:(NSInteger)precision;
		[Abstract]
		[Export("setLocationWithLatitude:longitude:timestamp:horizontalAccuracy:precision:")]
		void SetLocationWithLatitude(nfloat latitude, nfloat longitude, NSDate timestamp, nfloat horizontalAccuracy, nint precision);

		// @required -(void)addCustomKeywordWithKey:(NSString *)key value:(NSString *)value;
		[Abstract]
		[Export("addCustomKeywordWithKey:value:")]
		void AddCustomKeywordWithKey(string key, string value);

		// @required -(void)removeCustomKeywordWithKey:(NSString *)key;
		[Abstract]
		[Export("removeCustomKeywordWithKey:")]
		void RemoveCustomKeywordWithKey(string key);

		// @required -(void)setInventoryCode:(NSString *)inventoryCode memberId:(NSInteger)memberID;
		[Abstract]
		[Export("setInventoryCode:memberId:")]
		void SetInventoryCode(string inventoryCode, nint memberID);

		// @required @property (assign, readwrite, nonatomic) BOOL landingPageLoadsInBackground;
		[Abstract]
		[Export("landingPageLoadsInBackground")]
		bool LandingPageLoadsInBackground { get; set; }
	}

	// @protocol ANAdDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface ANAdDelegate
	{
		// @optional -(void)adDidReceiveAd:(id<ANAdProtocol>)ad;
		[Export("adDidReceiveAd:")]
		void AdDidReceiveAd(IANAdProtocol ad);

		// @optional -(void)ad:(id<ANAdProtocol>)ad requestFailedWithError:(NSError *)error;
		[Export("ad:requestFailedWithError:")]
		void Ad(IANAdProtocol ad, NSError error);

		// @optional -(void)adWasClicked:(id<ANAdProtocol>)ad;
		[Export("adWasClicked:")]
		void AdWasClicked(IANAdProtocol ad);

		// @optional -(void)adWillClose:(id<ANAdProtocol>)ad;
		[Export("adWillClose:")]
		void AdWillClose(IANAdProtocol ad);

		// @optional -(void)adDidClose:(id<ANAdProtocol>)ad;
		[Export("adDidClose:")]
		void AdDidClose(IANAdProtocol ad);

		// @optional -(void)adWillPresent:(id<ANAdProtocol>)ad;
		[Export("adWillPresent:")]
		void AdWillPresent(IANAdProtocol ad);

		// @optional -(void)adDidPresent:(id<ANAdProtocol>)ad;
		[Export("adDidPresent:")]
		void AdDidPresent(IANAdProtocol ad);

		// @optional -(void)adWillLeaveApplication:(id<ANAdProtocol>)ad;
		[Export("adWillLeaveApplication:")]
		void AdWillLeaveApplication(IANAdProtocol ad);
	}

	// @protocol ANAppEventDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface IANAppEventDelegate
	{
		// @required -(void)ad:(id<ANAdProtocol>)ad didReceiveAppEvent:(NSString *)name withData:(NSString *)data;
		[Abstract]
		[Export("ad:didReceiveAppEvent:withData:")]
		void DidReceiveAppEvent(IANAdProtocol ad, string name, string data);
	}

	// @interface ANAdView : UIView <ANAdProtocol>
	[BaseType(typeof(UIView))]
	interface ANAdView : IANAdProtocol
	{
	}

	// @interface ANBannerAdView : ANAdView
	[BaseType(typeof(ANAdView))]
	interface ANBannerAdView
	{
		//[Wrap("WeakDelegate")]
		//ANBannerAdViewDelegate Delegate { get; set; }

		// @property (readwrite, nonatomic, weak) id<ANBannerAdViewDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Wrap("WeakAppEventDelegate")]
		IANAppEventDelegate AppEventDelegate { get; set; }

		// @property (readwrite, nonatomic, weak) id<ANAppEventDelegate> appEventDelegate;
		[NullAllowed, Export("appEventDelegate", ArgumentSemantic.Weak)]
		NSObject WeakAppEventDelegate { get; set; }

		// @property (readwrite, nonatomic, weak) UIViewController * rootViewController;
		[Export("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }

		// @property (assign, readwrite, nonatomic) CGSize adSize;
		[Export("adSize", ArgumentSemantic.Assign)]
		CGSize AdSize { get; set; }

		// @property (assign, readwrite, nonatomic) NSTimeInterval autoRefreshInterval;
		[Export("autoRefreshInterval")]
		double AutoRefreshInterval { get; set; }

		// @property (assign, readwrite, nonatomic) ANBannerViewAdTransitionType transitionType;
		[Export("transitionType", ArgumentSemantic.Assign)]
		ANBannerViewAdTransitionType TransitionType { get; set; }

		// @property (assign, readwrite, nonatomic) ANBannerViewAdTransitionDirection transitionDirection;
		[Export("transitionDirection", ArgumentSemantic.Assign)]
		ANBannerViewAdTransitionDirection TransitionDirection { get; set; }

		// @property (assign, readwrite, nonatomic) NSTimeInterval transitionDuration;
		[Export("transitionDuration")]
		double TransitionDuration { get; set; }

		// @property (assign, readwrite, nonatomic) ANBannerViewAdAlignment alignment;
		[Export("alignment", ArgumentSemantic.Assign)]
		ANBannerViewAdAlignment Alignment { get; set; }

		// -(instancetype)initWithFrame:(CGRect)frame placementId:(NSString *)placementId;
		[Export("initWithFrame:placementId:")]
		IntPtr Constructor(CGRect frame, string placementId);

		// -(instancetype)initWithFrame:(CGRect)frame placementId:(NSString *)placementId adSize:(CGSize)size;
		[Export("initWithFrame:placementId:adSize:")]
		IntPtr Constructor(CGRect frame, string placementId, CGSize size);

		// -(instancetype)initWithFrame:(CGRect)frame memberId:(NSInteger)memberId inventoryCode:(NSString *)inventoryCode;
		[Export("initWithFrame:memberId:inventoryCode:")]
		IntPtr Constructor(CGRect frame, nint memberId, string inventoryCode);

		// -(instancetype)initWithFrame:(CGRect)frame memberId:(NSInteger)memberId inventoryCode:(NSString *)inventoryCode adSize:(CGSize)size;
		[Export("initWithFrame:memberId:inventoryCode:adSize:")]
		IntPtr Constructor(CGRect frame, nint memberId, string inventoryCode, CGSize size);

		// +(ANBannerAdView *)adViewWithFrame:(CGRect)frame placementId:(NSString *)placementId;
		[Static]
		[Export("adViewWithFrame:placementId:")]
		ANBannerAdView AdViewWithFrame(CGRect frame, string placementId);

		// +(ANBannerAdView *)adViewWithFrame:(CGRect)frame placementId:(NSString *)placementId adSize:(CGSize)size;
		[Static]
		[Export("adViewWithFrame:placementId:adSize:")]
		ANBannerAdView AdViewWithFrame(CGRect frame, string placementId, CGSize size);

		// -(void)loadAd;
		[Export("loadAd")]
		void LoadAd();
	}

	// @protocol ANBannerAdViewDelegate <ANAdDelegate>
	[Model]
	[Protocol]
	interface ANBannerAdViewDelegate : ANAdDelegate
	{
	}

	// @interface ANLocation : NSObject
	[BaseType(typeof(NSObject))]
	interface ANLocation
	{
		// @property (assign, readwrite, nonatomic) CGFloat latitude;
		[Export("latitude")]
		nfloat Latitude { get; set; }

		// @property (assign, readwrite, nonatomic) CGFloat longitude;
		[Export("longitude")]
		nfloat Longitude { get; set; }

		// @property (readwrite, nonatomic, strong) NSDate * timestamp;
		[Export("timestamp", ArgumentSemantic.Strong)]
		NSDate Timestamp { get; set; }

		// @property (assign, readwrite, nonatomic) CGFloat horizontalAccuracy;
		[Export("horizontalAccuracy")]
		nfloat HorizontalAccuracy { get; set; }

		// @property (readonly, assign, nonatomic) NSInteger precision;
		[Export("precision")]
		nint Precision { get; }

		// +(ANLocation *)getLocationWithLatitude:(CGFloat)latitude longitude:(CGFloat)longitude timestamp:(NSDate *)timestamp horizontalAccuracy:(CGFloat)horizontalAccuracy;
		[Static]
		[Export("getLocationWithLatitude:longitude:timestamp:horizontalAccuracy:")]
		ANLocation GetLocationWithLatitude(nfloat latitude, nfloat longitude, NSDate timestamp, nfloat horizontalAccuracy);

		// +(ANLocation *)getLocationWithLatitude:(CGFloat)latitude longitude:(CGFloat)longitude timestamp:(NSDate *)timestamp horizontalAccuracy:(CGFloat)horizontalAccuracy precision:(NSInteger)precision;
		[Static]
		[Export("getLocationWithLatitude:longitude:timestamp:horizontalAccuracy:precision:")]
		ANLocation GetLocationWithLatitude(nfloat latitude, nfloat longitude, NSDate timestamp, nfloat horizontalAccuracy, nint precision);
	}

	// @interface ANTargetingParameters : NSObject
	[BaseType(typeof(NSObject))]
	interface ANTargetingParameters
	{
		// @property (readwrite, nonatomic, strong) NSDictionary * customKeywords;
		[Export("customKeywords", ArgumentSemantic.Strong)]
		NSDictionary CustomKeywords { get; set; }

		// @property (readwrite, nonatomic, strong) NSString * age;
		[Export("age", ArgumentSemantic.Strong)]
		string Age { get; set; }

		// @property (assign, readwrite, nonatomic) ANGender gender;
		[Export("gender", ArgumentSemantic.Assign)]
		ANGender Gender { get; set; }

		// @property (readwrite, nonatomic, strong) ANLocation * location;
		[Export("location", ArgumentSemantic.Strong)]
		ANLocation Location { get; set; }

		// @property (readwrite, nonatomic, strong) NSString * idforadvertising;
		[Export("idforadvertising", ArgumentSemantic.Strong)]
		string Idforadvertising { get; set; }
	}

	// @protocol ANCustomAdapterDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface IANCustomAdapterDelegate
	{
		// @required -(void)didFailToLoadAd:(ANAdResponseCode)errorCode;
		[Abstract]
		[Export("didFailToLoadAd:")]
		void DidFailToLoadAd(ANAdResponseCode errorCode);

		// @required -(void)adWasClicked;
		[Abstract]
		[Export("adWasClicked")]
		void AdWasClicked();

		// @required -(void)willPresentAd;
		[Abstract]
		[Export("willPresentAd")]
		void WillPresentAd();

		// @required -(void)didPresentAd;
		[Abstract]
		[Export("didPresentAd")]
		void DidPresentAd();

		// @required -(void)willCloseAd;
		[Abstract]
		[Export("willCloseAd")]
		void WillCloseAd();

		// @required -(void)didCloseAd;
		[Abstract]
		[Export("didCloseAd")]
		void DidCloseAd();

		// @required -(void)willLeaveApplication;
		[Abstract]
		[Export("willLeaveApplication")]
		void WillLeaveApplication();
	}

	// @protocol ANCustomAdapter <NSObject>
	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface IANCustomAdapter
	{
		[Wrap("WeakDelegate")]
		IANCustomAdapterDelegate Delegate { get; set; }

		// @required @property (readwrite, nonatomic, weak) id<ANCustomAdapterDelegate> delegate;
		[Abstract]
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	// @protocol ANCustomAdapterBanner <ANCustomAdapter>
	[Model]
	[Protocol]
	interface IANCustomAdapterBanner : IANCustomAdapter
	{
		// @required -(void)requestBannerAdWithSize:(CGSize)size rootViewController:(UIViewController *)rootViewController serverParameter:(NSString *)parameterString adUnitId:(NSString *)idString targetingParameters:(ANTargetingParameters *)targetingParameters;
		[Abstract]
		[Export("requestBannerAdWithSize:rootViewController:serverParameter:adUnitId:targetingParameters:")]
		void RootViewController(CGSize size, UIViewController rootViewController, string parameterString, 
		                        string idString, ANTargetingParameters targetingParameters);

		//[Wrap("WeakDelegate"), Abstract]
		//NSObject<ANCustomAdapterBannerDelegate, ANCustomAdapterDelegate> Delegate { get; set; }

		// @required @property (readwrite, nonatomic, weak) id<ANCustomAdapterBannerDelegate,ANCustomAdapterDelegate> delegate;
		//[Abstract]
		//[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		//NSObject WeakDelegate { get; set; }
	}

	// @protocol ANCustomAdapterInterstitial <ANCustomAdapter>
	[Model]
	[Protocol]

	interface IANCustomAdapterInterstitial : IANCustomAdapter
	{
		// @required -(void)requestInterstitialAdWithParameter:(NSString *)parameterString adUnitId:(NSString *)idString targetingParameters:(ANTargetingParameters *)targetingParameters;
		[Abstract]
		[Export("requestInterstitialAdWithParameter:adUnitId:targetingParameters:")]
		void RequestInterstitialAdWithParameter(string parameterString, string idString, ANTargetingParameters targetingParameters);

		// @required -(void)presentFromViewController:(UIViewController *)viewController;
		[Abstract]
		[Export("presentFromViewController:")]
		void PresentFromViewController(UIViewController viewController);

		// @required -(BOOL)isReady;
		[Abstract]
		[Export("isReady")]
		bool IsReady { get; }

		//[Wrap("WeakDelegate"), Abstract]
		//NSObject<ANCustomAdapterInterstitialDelegate, ANCustomAdapterDelegate> Delegate { get; set; }

		// @required @property (readwrite, nonatomic, weak) id<ANCustomAdapterInterstitialDelegate,ANCustomAdapterDelegate> delegate;
		//[Abstract]
		//[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		//NSObject WeakDelegate { get; set; }
	}

	// @protocol ANCustomAdapterBannerDelegate <ANCustomAdapterDelegate>
	[Model]
	[Protocol]
	interface IANCustomAdapterBannerDelegate : IANCustomAdapterDelegate
	{
		// @required -(void)didLoadBannerAd:(UIView *)view;
		[Abstract]
		[Export("didLoadBannerAd:")]
		void DidLoadBannerAd(UIView view);
	}

	// @protocol ANCustomAdapterInterstitialDelegate <ANCustomAdapterDelegate>
	[Model]
	[Protocol]
	interface IANCustomAdapterInterstitialDelegate : IANCustomAdapterDelegate
	{
		// @required -(void)didLoadInterstitialAd:(id<ANCustomAdapterInterstitial>)adapter;
		//[Abstract]
		//[Export("didLoadInterstitialAd:")]
		//void DidLoadInterstitialAd(IANCustomAdapterInterstitial adapter);

		// @required -(void)failedToDisplayAd;
		[Abstract]
		[Export("failedToDisplayAd")]
		void FailedToDisplayAd();
	}

	// @interface ANInterstitialAd : ANAdView
	[BaseType(typeof(ANAdView))]
	interface ANInterstitialAd
	{
		//[Wrap("WeakDelegate")]
		//IANInterstitialAdDelegate Delegate { get; set; }

		// @property (readwrite, nonatomic, weak) id<ANInterstitialAdDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Wrap("WeakAppEventDelegate")]
		IANAppEventDelegate AppEventDelegate { get; set; }

		// @property (readwrite, nonatomic, weak) id<ANAppEventDelegate> appEventDelegate;
		[NullAllowed, Export("appEventDelegate", ArgumentSemantic.Weak)]
		NSObject WeakAppEventDelegate { get; set; }

		// @property (readwrite, nonatomic, strong) UIColor * backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (getter = isOpaque, readwrite, nonatomic) BOOL opaque;
		[Export("opaque")]
		bool Opaque { [Bind("isOpaque")] get; set; }

		// @property (readonly, assign, nonatomic) BOOL isReady;
		[Export("isReady")]
		bool IsReady { get; }

		// @property (assign, readwrite, nonatomic) NSTimeInterval closeDelay;
		[Export("closeDelay")]
		double CloseDelay { get; set; }

		// @property (readwrite, nonatomic, strong) NSMutableSet * allowedAdSizes;
		[Export("allowedAdSizes", ArgumentSemantic.Strong)]
		NSMutableSet AllowedAdSizes { get; set; }

		// -(instancetype)initWithPlacementId:(NSString *)placementId;
		[Export("initWithPlacementId:")]
		IntPtr Constructor(string placementId);

		// -(instancetype)initWithMemberId:(NSInteger)memberId inventoryCode:(NSString *)inventoryCode;
		[Export("initWithMemberId:inventoryCode:")]
		IntPtr Constructor(nint memberId, string inventoryCode);

		// -(void)loadAd;
		[Export("loadAd")]
		void LoadAd();

		// -(void)displayAdFromViewController:(UIViewController *)controller;
		[Export("displayAdFromViewController:")]
		void DisplayAdFromViewController(UIViewController controller);
	}

	// @protocol ANInterstitialAdDelegate <ANAdDelegate>
	[Model]
	[Protocol]
	interface ANInterstitialAdDelegate : ANAdDelegate
	{
		// @optional -(void)adFailedToDisplay:(ANInterstitialAd *)ad;
		[Export("adFailedToDisplay:")]
		void AdFailedToDisplay(ANInterstitialAd ad);
	}

	// @interface ANLogManager : NSObject
	[BaseType(typeof(NSObject))]
	interface ANLogManager
	{
		// +(ANLogLevel)getANLogLevel;
		[Static]
		[Export("getANLogLevel")]

		ANLogLevel ANLogLevel { get; }

		// +(void)setANLogLevel:(ANLogLevel)level;
		[Static]
		[Export("setANLogLevel:")]
		void SetANLogLevel(ANLogLevel level);
	}

	// @protocol ANNativeAdDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface IANNativeAdDelegate
	{
		// @optional -(void)adWasClicked:(ANNativeAdResponse *)response;
		[Export("adWasClicked:")]
		void AdWasClicked(ANNativeAdResponse response);

		// @optional -(void)adWillPresent:(ANNativeAdResponse *)response;
		[Export("adWillPresent:")]
		void AdWillPresent(ANNativeAdResponse response);

		// @optional -(void)adDidPresent:(ANNativeAdResponse *)response;
		[Export("adDidPresent:")]
		void AdDidPresent(ANNativeAdResponse response);

		// @optional -(void)adWillClose:(ANNativeAdResponse *)response;
		[Export("adWillClose:")]
		void AdWillClose(ANNativeAdResponse response);

		// @optional -(void)adDidClose:(ANNativeAdResponse *)response;
		[Export("adDidClose:")]
		void AdDidClose(ANNativeAdResponse response);

		// @optional -(void)adWillLeaveApplication:(ANNativeAdResponse *)response;
		[Export("adWillLeaveApplication:")]
		void AdWillLeaveApplication(ANNativeAdResponse response);
	}

	// @protocol ANNativeAdTargetingProtocol <NSObject>
	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface IANNativeAdTargetingProtocol
	{
		// @required @property (readwrite, nonatomic, strong) NSString * placementId;
		[Abstract]
		[Export("placementId", ArgumentSemantic.Strong)]
		string PlacementId { get; set; }

		// @required @property (readonly, assign, nonatomic) NSInteger memberId;
		[Abstract]
		[Export("memberId")]
		nint MemberId { get; }

		// @required @property (readonly, nonatomic, strong) NSString * inventoryCode;
		[Abstract]
		[Export("inventoryCode", ArgumentSemantic.Strong)]
		string InventoryCode { get; }

		// @required @property (readwrite, nonatomic, strong) ANLocation * location;
		[Abstract]
		[Export("location", ArgumentSemantic.Strong)]
		ANLocation Location { get; set; }

		// @required @property (assign, readwrite, nonatomic) CGFloat reserve;
		[Abstract]
		[Export("reserve")]
		nfloat Reserve { get; set; }

		// @required @property (readwrite, nonatomic, strong) NSString * age;
		[Abstract]
		[Export("age", ArgumentSemantic.Strong)]
		string Age { get; set; }

		// @required @property (assign, readwrite, nonatomic) ANGender gender;
		[Abstract]
		[Export("gender", ArgumentSemantic.Assign)]
		ANGender Gender { get; set; }

		// @required @property (readwrite, nonatomic, strong) NSMutableDictionary * customKeywords;
		[Abstract]
		[Export("customKeywords", ArgumentSemantic.Strong)]
		NSMutableDictionary CustomKeywords { get; set; }

		// @required -(void)setLocationWithLatitude:(CGFloat)latitude longitude:(CGFloat)longitude timestamp:(NSDate *)timestamp horizontalAccuracy:(CGFloat)hAccuracy;
		[Abstract]
		[Export("setLocationWithLatitude:longitude:timestamp:horizontalAccuracy:")]
		void SetLocationWithLatitude(nfloat latitude, nfloat longitude, NSDate timestamp, nfloat hAccuracy);

		// @required -(void)setLocationWithLatitude:(CGFloat)latitude longitude:(CGFloat)longitude timestamp:(NSDate *)timestamp horizontalAccuracy:(CGFloat)hAccuracy precision:(NSInteger)precision;
		[Abstract]
		[Export("setLocationWithLatitude:longitude:timestamp:horizontalAccuracy:precision:")]
		void SetLocationWithLatitude(nfloat latitude, nfloat longitude, NSDate timestamp, nfloat hAccuracy, nint precision);

		// @required -(void)addCustomKeywordWithKey:(NSString *)key value:(NSString *)value;
		[Abstract]
		[Export("addCustomKeywordWithKey:value:")]
		void AddCustomKeywordWithKey(string key, string value);

		// @required -(void)removeCustomKeywordWithKey:(NSString *)key;
		[Abstract]
		[Export("removeCustomKeywordWithKey:")]
		void RemoveCustomKeywordWithKey(string key);

		// @required -(void)setInventoryCode:(NSString *)inventoryCode memberId:(NSInteger)memberId;
		[Abstract]
		[Export("setInventoryCode:memberId:")]
		void SetInventoryCode(string inventoryCode, nint memberId);
	}

	// @interface ANNativeAdStarRating : NSObject
	[BaseType(typeof(NSObject))]
	interface ANNativeAdStarRating
	{
		// -(instancetype)initWithValue:(CGFloat)value scale:(NSInteger)scale;
		[Export("initWithValue:scale:")]
		IntPtr Constructor(nfloat value, nint scale);

		// @property (readonly, assign, nonatomic) CGFloat value;
		[Export("value")]
		nfloat Value { get; }

		// @property (readonly, assign, nonatomic) NSInteger scale;
		[Export("scale")]
		nint Scale { get; }
	}

	// @interface ANNativeAdResponse : NSObject
	[BaseType(typeof(NSObject))]
	interface ANNativeAdResponse
	{
		// @property (readonly, nonatomic, strong) NSString * title;
		[Export("title", ArgumentSemantic.Strong)]
		string Title { get; }

		// @property (readonly, nonatomic, strong) NSString * body;
		[Export("body", ArgumentSemantic.Strong)]
		string Body { get; }

		// @property (readonly, nonatomic, strong) NSString * callToAction;
		[Export("callToAction", ArgumentSemantic.Strong)]
		string CallToAction { get; }

		// @property (readonly, nonatomic, strong) ANNativeAdStarRating * rating;
		[Export("rating", ArgumentSemantic.Strong)]
		ANNativeAdStarRating Rating { get; }

		// @property (readonly, nonatomic, strong) NSString * socialContext;
		[Export("socialContext", ArgumentSemantic.Strong)]
		string SocialContext { get; }

		// @property (readonly, nonatomic, strong) UIImage * iconImage;
		[Export("iconImage", ArgumentSemantic.Strong)]
		UIImage IconImage { get; }

		// @property (readonly, nonatomic, strong) UIImage * mainImage;
		[Export("mainImage", ArgumentSemantic.Strong)]
		UIImage MainImage { get; }

		// @property (readonly, nonatomic, strong) NSURL * mainImageURL;
		[Export("mainImageURL", ArgumentSemantic.Strong)]
		NSUrl MainImageURL { get; }

		// @property (readonly, nonatomic, strong) NSURL * iconImageURL;
		[Export("iconImageURL", ArgumentSemantic.Strong)]
		NSUrl IconImageURL { get; }

		// @property (readonly, nonatomic, strong) NSDictionary * customElements;
		[Export("customElements", ArgumentSemantic.Strong)]
		NSDictionary CustomElements { get; }

		// @property (readonly, assign, nonatomic) ANNativeAdNetworkCode networkCode;
		[Export("networkCode", ArgumentSemantic.Assign)]
		ANNativeAdNetworkCode NetworkCode { get; }

		// @property (readonly, getter = hasExpired, assign, nonatomic) BOOL expired;
		[Export("expired")]
		bool Expired { [Bind("hasExpired")] get; }

		[Wrap("WeakDelegate")]
		IANNativeAdDelegate Delegate { get; set; }

		// @property (readwrite, nonatomic, weak) id<ANNativeAdDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL opensInNativeBrowser;
		[Export("opensInNativeBrowser")]
		bool OpensInNativeBrowser { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL landingPageLoadsInBackground;
		[Export("landingPageLoadsInBackground")]
		bool LandingPageLoadsInBackground { get; set; }

		// -(BOOL)registerViewForTracking:(UIView *)view withRootViewController:(UIViewController *)rvc clickableViews:(NSArray *)views error:(NSError **)error;
		[Export("registerViewForTracking:withRootViewController:clickableViews:error:")]
		bool RegisterViewForTracking(UIView view, UIViewController rvc, NSObject[] views, out NSError error);
	}

	// @interface ANNativeAdRequest : NSObject <ANNativeAdTargetingProtocol>
	[BaseType(typeof(NSObject))]
	interface ANNativeAdRequest : IANNativeAdTargetingProtocol
	{
		// @property (assign, readwrite, nonatomic) BOOL shouldLoadIconImage;
		[Export("shouldLoadIconImage")]
		bool ShouldLoadIconImage { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL shouldLoadMainImage;
		[Export("shouldLoadMainImage")]
		bool ShouldLoadMainImage { get; set; }

		[Wrap("WeakDelegate")]
		IANNativeAdRequestDelegate Delegate { get; set; }

		// @property (readwrite, nonatomic, weak) id<ANNativeAdRequestDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)loadAd;
		[Export("loadAd")]
		void LoadAd();
	}

	// @protocol ANNativeAdRequestDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface IANNativeAdRequestDelegate
	{
		// @required -(void)adRequest:(ANNativeAdRequest *)request didReceiveResponse:(ANNativeAdResponse *)response;
		[Abstract]
		[Export("adRequest:didReceiveResponse:")]
		void DidReceiveResponse(ANNativeAdRequest request, ANNativeAdResponse response);

		// @required -(void)adRequest:(ANNativeAdRequest *)request didFailToLoadWithError:(NSError *)error;
		[Abstract]
		[Export("adRequest:didFailToLoadWithError:")]
		void DidFailToLoadWithError(ANNativeAdRequest request, NSError error);
	}

	// @interface ANNativeMediatedAdResponse : ANNativeAdResponse
	[BaseType(typeof(ANNativeAdResponse))]
	interface ANNativeMediatedAdResponse
	{
		// -(instancetype)initWithCustomAdapter:(id<ANNativeCustomAdapter>)adapter networkCode:(ANNativeAdNetworkCode)networkCode;
		[Export("initWithCustomAdapter:networkCode:")]
		IntPtr Constructor(IANNativeCustomAdapter adapter, ANNativeAdNetworkCode networkCode);

		// @property (readwrite, nonatomic, strong) NSString * title;
		[Export("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// @property (readwrite, nonatomic, strong) NSString * body;
		[Export("body", ArgumentSemantic.Strong)]
		string Body { get; set; }

		// @property (readwrite, nonatomic, strong) NSString * callToAction;
		[Export("callToAction", ArgumentSemantic.Strong)]
		string CallToAction { get; set; }

		// @property (readwrite, nonatomic, strong) ANNativeAdStarRating * rating;
		[Export("rating", ArgumentSemantic.Strong)]
		ANNativeAdStarRating Rating { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * mainImage;
		[Export("mainImage", ArgumentSemantic.Strong)]
		UIImage MainImage { get; set; }

		// @property (readwrite, nonatomic, strong) NSURL * mainImageURL;
		[Export("mainImageURL", ArgumentSemantic.Strong)]
		NSUrl MainImageURL { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * iconImage;
		[Export("iconImage", ArgumentSemantic.Strong)]
		UIImage IconImage { get; set; }

		// @property (readwrite, nonatomic, strong) NSURL * iconImageURL;
		[Export("iconImageURL", ArgumentSemantic.Strong)]
		NSUrl IconImageURL { get; set; }

		// @property (readwrite, nonatomic, strong) NSString * socialContext;
		[Export("socialContext", ArgumentSemantic.Strong)]
		string SocialContext { get; set; }

		// @property (readwrite, nonatomic, strong) NSDictionary * customElements;
		[Export("customElements", ArgumentSemantic.Strong)]
		NSDictionary CustomElements { get; set; }

		// @property (readonly, nonatomic, strong) id<ANNativeCustomAdapter> adapter;
		[Export("adapter", ArgumentSemantic.Strong)]
		IANNativeCustomAdapter Adapter { get; }
	}

	// @protocol ANNativeCustomAdapter <NSObject>
	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface IANNativeCustomAdapter
	{
		[Wrap("WeakRequestDelegate")]
		IANNativeCustomAdapterRequestDelegate RequestDelegate { get; set; }

		// @required @property (readwrite, nonatomic, weak) id<ANNativeCustomAdapterRequestDelegate> requestDelegate;
		[Abstract]
		[NullAllowed, Export("requestDelegate", ArgumentSemantic.Weak)]
		NSObject WeakRequestDelegate { get; set; }

		[Wrap("WeakNativeAdDelegate")]
		IANNativeCustomAdapterAdDelegate NativeAdDelegate { get; set; }

		// @required @property (readwrite, nonatomic, weak) id<ANNativeCustomAdapterAdDelegate> nativeAdDelegate;
		[Abstract]
		[NullAllowed, Export("nativeAdDelegate", ArgumentSemantic.Weak)]
		NSObject WeakNativeAdDelegate { get; set; }

		// @required @property (getter = hasExpired, assign, readwrite, nonatomic) BOOL expired;
		[Abstract]
		[Export("expired")]
		bool Expired { [Bind("hasExpired")] get; set; }

		// @required -(void)requestNativeAdWithServerParameter:(NSString *)parameterString adUnitId:(NSString *)adUnitId targetingParameters:(ANTargetingParameters *)targetingParameters;
		[Abstract]
		[Export("requestNativeAdWithServerParameter:adUnitId:targetingParameters:")]
		void RequestNativeAdWithServerParameter(string parameterString, string adUnitId, 
		                                        ANTargetingParameters targetingParameters);

		// @optional -(void)registerViewForImpressionTrackingAndClickHandling:(UIView *)view withRootViewController:(UIViewController *)rvc clickableViews:(NSArray *)clickableViews;
		[Export("registerViewForImpressionTrackingAndClickHandling:withRootViewController:clickableViews:")]
		void RegisterViewForImpressionTrackingAndClickHandling(UIView view, UIViewController rvc, NSObject[] clickableViews);

		// @optional -(void)registerViewForImpressionTracking:(UIView *)view;
		[Export("registerViewForImpressionTracking:")]
		void RegisterViewForImpressionTracking(UIView view);

		// @optional -(void)handleClickFromRootViewController:(UIViewController *)rvc;
		[Export("handleClickFromRootViewController:")]
		void HandleClickFromRootViewController(UIViewController rvc);

		// @optional -(void)unregisterViewFromTracking;
		[Export("unregisterViewFromTracking")]
		void UnregisterViewFromTracking();
	}

	// @protocol ANNativeCustomAdapterRequestDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface IANNativeCustomAdapterRequestDelegate
	{
		// @required -(void)didLoadNativeAd:(ANNativeMediatedAdResponse *)response;
		[Abstract]
		[Export("didLoadNativeAd:")]
		void DidLoadNativeAd(ANNativeMediatedAdResponse response);

		// @required -(void)didFailToLoadNativeAd:(ANAdResponseCode)errorCode;
		[Abstract]
		[Export("didFailToLoadNativeAd:")]
		void DidFailToLoadNativeAd(ANAdResponseCode errorCode);
	}

	// @protocol ANNativeCustomAdapterAdDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface IANNativeCustomAdapterAdDelegate
	{
		// @required -(void)adWasClicked;
		[Abstract]
		[Export("adWasClicked")]
		void AdWasClicked();

		// @required -(void)willPresentAd;
		[Abstract]
		[Export("willPresentAd")]
		void WillPresentAd();

		// @required -(void)didPresentAd;
		[Abstract]
		[Export("didPresentAd")]
		void DidPresentAd();

		// @required -(void)willCloseAd;
		[Abstract]
		[Export("willCloseAd")]
		void WillCloseAd();

		// @required -(void)didCloseAd;
		[Abstract]
		[Export("didCloseAd")]
		void DidCloseAd();

		// @required -(void)willLeaveApplication;
		[Abstract]
		[Export("willLeaveApplication")]
		void WillLeaveApplication();
	}
}
