using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Phonebook.Droid
{
    [Activity(Label = "SplashScreen"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenAppCompatActivity<Setup, Core.App>
    {
        public SplashScreen(): base(Resource.Layout.SplashScreen)
        {
        }
    }
    
}



