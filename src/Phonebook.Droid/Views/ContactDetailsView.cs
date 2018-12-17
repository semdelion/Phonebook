using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Phonebook.Core.ViewModels;
using Phonebook.Core.ViewModels.Details;

namespace Phonebook.Droid.Views
{
    //[MvxFragmentPresentation(ActivityHostViewModelType = typeof(ContactsViewModel),FragmentContentId = Resource.Id.content_frame, AddToBackStack = true)]
    //[Register(nameof(ConactDetailsView))]
    [Android.App.Activity(Label = "ContactsView")]
    public class ContactDetailsView : MvxAppCompatActivity<DetailsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.fragment_details);
        }
    }
}



