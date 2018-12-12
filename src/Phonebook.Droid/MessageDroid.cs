using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
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

