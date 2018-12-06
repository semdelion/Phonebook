﻿using MvvmCross;
using MvvmCross.Droid.Support.V7.AppCompat;
using Phonebook.API.Service;
using Xamarin.Android.Net;

namespace Phonebook.Droid
{
    public class Setup: MvxAppCompatSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(new AndroidClientHandler()));
        }
    }
}