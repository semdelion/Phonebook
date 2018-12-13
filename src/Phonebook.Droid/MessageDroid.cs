using System;
using Android.App;
using MvvmCross;
using MvvmCross.Platforms.Android;
using Phonebook.Core;

namespace Phonebook.Droid
{
   class MessageDroid : IMessage
    {
        public Android.App.Activity CurrentActivity => Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
        public void Dialog(string message, Action buttonAction)
        {
           CurrentActivity.RunOnUiThread( () => new AlertDialog.Builder(CurrentActivity).SetTitle("Error").SetMessage(message)
                .SetPositiveButton("Refresh", (sender, e) => { buttonAction(); })
                .SetNegativeButton("Close", (s, e) => { }).Show());
        }
    }
}

