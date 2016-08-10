using System;
using ObjCRuntime;

[assembly: LinkWith("libANSDK.a", LinkTarget = LinkTarget.i386 | LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.Arm64,
	ForceLoad = true, SmartLink=false, Frameworks="MediaPlayer CoreTelephony WebKit EventKitUI AdSupport MessageUI StoreKit QuartzCore CoreFoundation SystemConfiguration EventKit CoreGraphics UIKit")]