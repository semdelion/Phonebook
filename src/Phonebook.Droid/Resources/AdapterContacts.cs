using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Phonebook.Droid.Resources
{
    class AdapterContacts : RecyclerView.Adapter
    {
        public event EventHandler<AdapterContactsClickEventArgs> ItemClick;
        public event EventHandler<AdapterContactsClickEventArgs> ItemLongClick;
        string[] items;

        public AdapterContacts(string[] data)
        {
            items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            //var id = Resource.Layout.__YOUR_ITEM_HERE;
            //itemView = LayoutInflater.From(parent.Context).
            //       Inflate(id, parent, false);

            var vh = new AdapterContactsViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as AdapterContactsViewHolder;
            //holder.TextView.Text = items[position];
        }

        public override int ItemCount => items.Length;

        void OnClick(AdapterContactsClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(AdapterContactsClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class AdapterContactsViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }


        public AdapterContactsViewHolder(View itemView, Action<AdapterContactsClickEventArgs> clickListener,
                            Action<AdapterContactsClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
            itemView.Click += (sender, e) => clickListener(new AdapterContactsClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new AdapterContactsClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class AdapterContactsClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}