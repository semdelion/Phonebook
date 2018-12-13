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
        //public event EventHandler<AdapterContactsClickEventArgs> ItemClick;
        //public event EventHandler<AdapterContactsClickEventArgs> ItemLongClick;

        public ICommand CommandGetContacts { get; set; }
        public AdapterContacts(IMvxAndroidBindingContext bindingContext)
        : base(bindingContext)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
            var vh = new MvxRecyclerViewHolder(InflateViewForHolder(parent, viewType, itemBindingContext), itemBindingContext)
            {
                Click = ItemClick
            };
            return vh;
        }

        public override int GetItemViewType(int position) => ItemTemplateSelector.GetItemViewType(GetItem(position));

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);
            if (position >= ItemCount - 3 && CommandGetContacts.CanExecute(null))
                CommandGetContacts.Execute(null);
        }
    

        // Replace the contents of a view (invoked by the layout manager)
        //public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        //{
        //    var item = items[position];

        //    // Replace the contents of the view with that element
        //    var holder = viewHolder as AdapterContactsViewHolder;
        //    //holder.TextView.Text = items[position];
        //}

        //public override int ItemCount => items.Length;

        //void OnClick(AdapterContactsClickEventArgs args) => ItemClick?.Invoke(this, args);
        //void OnLongClick(AdapterContactsClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    //public class AdapterContactsViewHolder : RecyclerView.ViewHolder
    //{
    //    //public TextView TextView { get; set; }


    //    public AdapterContactsViewHolder(View itemView, Action<AdapterContactsClickEventArgs> clickListener,
    //                        Action<AdapterContactsClickEventArgs> longClickListener) : base(itemView)
    //    {
    //        //TextView = v;
    //        itemView.Click += (sender, e) => clickListener(new AdapterContactsClickEventArgs { View = itemView, Position = AdapterPosition });
    //        itemView.LongClick += (sender, e) => longClickListener(new AdapterContactsClickEventArgs { View = itemView, Position = AdapterPosition });
    //    }
    //}

    //public class AdapterContactsClickEventArgs : EventArgs
    //{
    //    public View View { get; set; }
    //    public int Position { get; set; }
    //}
}