using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
namespace Phonebook.Droid.Views
{
    [Activity(Label = "ContactsView")]
    public class ContactsView : MvxAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ContactsView);
        }
    }
}