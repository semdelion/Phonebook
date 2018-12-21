using System;
using Phonebook.Core;
using UIKit;
using MvvmCross;
using CoreFoundation;

namespace Phonebook.iOS
{
    public class MessageiOS : IMessage
    {
        public void Dialog(string message, Action buttonAction)
        {

            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                var controller = UIAlertController.Create("Error", message, UIAlertControllerStyle.Alert);
                var action = UIAlertAction.Create("Refresh", UIAlertActionStyle.Default, (handler) =>
                {
                    buttonAction();
                });
                controller.AddAction(action);
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(controller, true, null);
            });
        }
    }
}