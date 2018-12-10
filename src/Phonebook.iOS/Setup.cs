using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Foundation;
using MvvmCross;
using MvvmCross.Platforms.Ios.Core;
using Phonebook.API.Service;

namespace Phonebook.iOS
{
    public class Setup : MvxIosSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(new NSUrlSessionHandler()));
        }
    }
}