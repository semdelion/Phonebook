using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using System.Windows.Input;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace Phonebook.Droid.Resources
{
    class AdapterContacts : MvxRecyclerAdapter
    {
        public ICommand CommandGetContacts { get; set; }
        public AdapterContacts(IMvxAndroidBindingContext bindingContext) : base(bindingContext){}

        public override int GetItemViewType(int position) => ItemTemplateSelector.GetItemViewType(GetItem(position));

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);
            if (position >= ItemCount - 3 && CommandGetContacts.CanExecute(null))
                CommandGetContacts.Execute(null);
        }
    }
}