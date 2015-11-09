using Android.App;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodsListApp
{
    class GoodsItemsAdapter : BaseAdapter<GoodsItem>
    {
        protected Activity Context = null;
        protected List<GoodsItem> GoodsItemsList;

        public GoodsItemsAdapter(Activity context, IEnumerable<GoodsItem> goods)
        {
            Context = context;
            GoodsItemsList = goods.ToList();
        }

        public override GoodsItem this[int position]
        {
            get { return GoodsItemsList[position]; }
        }

        public override int Count
        {
            get { return GoodsItemsList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            GoodsViewHolder holder = null;
            var view = convertView;

            if (view == null)
            {
                //holder = new ServiceViewHolder();
                view = Context.LayoutInflater.Inflate(Resource.Layout.GoodsListItemTemplate, null);

                holder = new GoodsViewHolder();
                holder.Name = view.FindViewById<TextView>(Resource.Id.textViewName);
                //holder.Price = view.FindViewById<TextView>(Resource.Id.tvServicePrice);
                holder.Quantity = view.FindViewById<TextView>(Resource.Id.textViewQuantity);
                //holder.EditButton = view.FindViewById<ImageButton>(Resource.Id.buttonEditService);
                //holder.DeleteButton = view.FindViewById<ImageButton>(Resource.Id.buttonDeleteService);

                view.Tag = holder;
            }
            else
            {
                holder = view.Tag as GoodsViewHolder;
            }

            //Now the holder holds reference to our view objects, whether they are 
            //recycled or created new. 
            //Next we need to populate the views

            var tempGoodsItem = GoodsItemsList[position];
            //var tempServiceItem = new ServiceItem();
            holder.Name.Text = tempGoodsItem.Name;
            holder.Quantity.Text = tempGoodsItem.Quantity.ToString();

            //holder.DeleteButton.Click += (object sender, EventArgs e) =>
            //{
            //    GoodsItemsList.RemoveAt(position);
            //    NotifyDataSetChanged();
            //};
            //holder.EditButton.Click += (object sender, EventArgs e) =>
            //{
            //    //Todo - implement edit Service
            //};

            return view;
        }


        private class GoodsViewHolder : Java.Lang.Object
        {
            public TextView Name { get; set; }
            public TextView Price { get; set; }
            public TextView Quantity { get; set; }
            public ImageButton EditButton { get; set; }
            public ImageButton DeleteButton { get; set; }
        }

        public void Add(GoodsItem service)
        {
            GoodsItemsList.Add(service);
            this.NotifyDataSetChanged();
        }
    }
}
