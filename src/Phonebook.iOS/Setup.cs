﻿using System;
using System.Net.Http;
using MvvmCross;
using MvvmCross.Platforms.Ios.Core;
using Phonebook.API.Service;
using Phonebook.Core;

namespace Phonebook.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(new NSUrlSessionHandler()));
            Mvx.IoCProvider.RegisterType<IMessage>(() => new MessageiOS());
        }
    }
}
