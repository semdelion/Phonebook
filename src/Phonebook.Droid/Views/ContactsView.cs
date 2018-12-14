﻿using Android.Support.V4.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using Android.Support.V4.Widget;
using Phonebook.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using Android.Views;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;
using System.Collections.Generic;

namespace Phonebook.Droid.Views
{
    [Android.App.Activity(Label = "ContactsView")]
    public class ContactsView : MvxAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_contacts);
            
            var toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.ContactsViewToolbar);
            SetSupportActionBar(toolBar);
            //FragmentManager.

            var recyclerAdapter = new Phonebook.Droid.Resources.AdapterContacts((IMvxAndroidBindingContext)BindingContext);

            var set = this.CreateBindingSet<ContactsView, ContactsViewModel>();
            set.Bind(recyclerAdapter).For(x => x.CommandGetContacts).To(x => x.GettingContactsCommand);
            set.Apply();
            FindViewById<MvxRecyclerView>(Resource.Id.recyclerView).Adapter = recyclerAdapter;
        }
    }
}