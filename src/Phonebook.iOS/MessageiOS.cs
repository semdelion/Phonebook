using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Phonebook.Core;
using UIKit;

class MessageiOS : IMessage
{
    public void Dialog(string message, Action buttonAction)
    {
        var alertController = UIAlertController.Create("Error", message, UIAlertControllerStyle.Alert);
        var action = UIAlertAction.Create("Refresh", UIAlertActionStyle.Default, (handler) => { buttonAction(); });
        alertController.AddAction(action);
        alertController.AddAction(UIAlertAction.Create("Close", UIAlertActionStyle.Cancel, (_) => { }));
        UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alertController, true, null);
    }
}
