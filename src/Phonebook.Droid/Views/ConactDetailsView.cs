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
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Phonebook.Core.ViewModels;
using Phonebook.Core.ViewModels.Details;

namespace Phonebook.Droid.Views
{
    [MvxFragmentPresentation(ActivityHostViewModelType = typeof(ContactsViewModel),FragmentContentId = Resource.Id.content_frame, AddToBackStack = true)]
    [Register(nameof(ConactDetailsView))]
    public class ConactDetailsView : MvxFragment<DetailsViewModel>
    {
        public ConactDetailsView(){ }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.fragment_details, null);
           
        }
    }
}



