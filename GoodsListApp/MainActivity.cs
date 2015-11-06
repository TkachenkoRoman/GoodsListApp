using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace GoodsListApp
{
    [Activity(Label = "GoodsListApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ListView listViewGoodsMain;
        private List<GoodsItem> GoodsItemsList;
        private GoodsItemsAdapter MyGoodsItemsAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);
            listViewGoodsMain = FindViewById<ListView>(Resource.Id.listViewGoodsMain);

            //Create an empty list of Service List
            GoodsItemsList = new List<GoodsItem>() {
                new GoodsItem()
                {
                    Id = 1,
                    Quantity = 1,
                    Name = "Пельмешки"
                },
                new GoodsItem()
                {
                    Id = 2,
                    Quantity = 1,
                    Name = "Макарохи"
                }
            };
            MyGoodsItemsAdapter = new GoodsItemsAdapter(this, GoodsItemsList);

            listViewGoodsMain.Adapter = MyGoodsItemsAdapter;
            var emptyText = FindViewById<TextView>(Resource.Id.textViewGoodsListEmpty);
            listViewGoodsMain.EmptyView = emptyText;

        }
    }
}

