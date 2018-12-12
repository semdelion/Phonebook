using MvvmCross;
using MvvmCross.Droid.Support.V7.AppCompat;
using Phonebook.API.Service;
using Phonebook.Core;
using Xamarin.Android.Net;

namespace Phonebook.Droid
{
    public class Setup: MvxAppCompatSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(new AndroidClientHandler()));
            Mvx.IoCProvider.RegisterType<IMessage>(() => new MessageDroid());
        }
    }
}