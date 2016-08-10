using System;
using ObjCRuntime;

namespace AppNexusBindingsIOS
{
	[Native]
	public enum ANAdResponseCode : long
	{
		DefaultCode = -1,
		AdResponseSuccessful = 0,
		AdResponseInvalidRequest,
		AdResponseUnableToFill,
		AdResponseMediatedSDKUnavailable,
		AdResponseNetworkError,
		AdResponseInternalError,
		AdResponseBadFormat = 100,
		AdResponseBadURL,
		AdResponseBadURLConnection,
		AdResponseNonViewResponse
	}

	[Native]
	public enum ANGender : ulong
	{
		Unknown,
		Male,
		Female
	}

	[Native]
	public enum ANNativeAdRegisterErrorCode : uint
	{
		InvalidView = 200,
		InvalidRootViewController,
		ExpiredResponse,
		BadAdapter,
		InternalError
	}

	[Native]
	public enum ANNativeAdNetworkCode : ulong
	{
		AppNexus = 0,
		MoPub,
		Facebook,
		InMobi,
		AdColony,
		Yahoo,
		Custom,
		AdMob
	}

	[Native]
	public enum ANBannerViewAdTransitionType : ulong
	{
		None = 0,
		Fade,
		Push,
		MoveIn,
		Reveal,
		Flip
	}

	[Native]
	public enum ANBannerViewAdTransitionDirection : ulong
	{
		Up = 0,
		Down,
		Left,
		Right,
		Random
	}

	[Native]
	public enum ANBannerViewAdAlignment : ulong
	{
		Center = 0,
		TopLeft,
		TopCenter,
		TopRight,
		CenterLeft,
		CenterRight,
		BottomLeft,
		BottomCenter,
		BottomRight
	}

	[Native]
	public enum ANLogLevel : ulong
	{
		All = 0,
		Trace = 10,
		Debug = 20,
		Info = 30,
		Warn = 40,
		Error = 50,
		Off = 60
	}
}
