using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views.InputMethods;

namespace GoodsListApp
{
    [Activity(Label = "GoodsListApp", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.Light.NoActionBar")]
    public class MainActivity : Activity
    {
        private ListView listViewGoodsMain;
        private EditText editTextNewProduct;
        private List<GoodsItem> goodsItemsList;
        private GoodsItemsAdapter myGoodsItemsAdapter;

        private CheckBox checkBoxRed;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);

            setupParent(FindViewById<LinearLayout>(Resource.Id.mainLayout));
            listViewGoodsMain = FindViewById<ListView>(Resource.Id.listViewGoodsMain);
           
            goodsItemsList = new List<GoodsItem>(); 
            goodsItemsList.Add(new GoodsItem() { Id = 1, Quantity = 1, Name = "Пельмешки"});
            goodsItemsList.Add(new GoodsItem() { Id = 2, Quantity = 2, Name = "Сосисоны" });
             
            myGoodsItemsAdapter = new GoodsItemsAdapter(this, goodsItemsList);
            listViewGoodsMain.Adapter = myGoodsItemsAdapter;

            var emptyText = FindViewById<TextView>(Resource.Id.textViewGoodsListEmpty);
            listViewGoodsMain.EmptyView = emptyText;

            editTextNewProduct = FindViewById<EditText>(Resource.Id.EditTextNewProduct);
            editTextNewProduct.EditorAction += editTextNewProduct_EditorAction;
            editTextNewProduct.Click += editTextNewProduct_Click;

            checkBoxRed = FindViewById<CheckBox>(Resource.Id.checkBoxRed);
            checkBoxRed.Click += checkBoxRed_Click;

        }

        void checkBoxRed_Click(object sender, EventArgs e)
        {
            bool isChecked = checkBoxRed.Checked;
        }

        void editTextNewProduct_Click(object sender, EventArgs e)
        {
            bool hasFocus = editTextNewProduct.HasFocus;
            bool isFocused = editTextNewProduct.IsFocused;

        }

        void editTextNewProduct_EditorAction(object sender, TextView.EditorActionEventArgs e)
        {
            e.Handled = false;
            if (e.ActionId == ImeAction.Done)
            {
                string goodsName = editTextNewProduct.Text; // get new item from input
                goodsItemsList.Add(new GoodsItem() {Name = goodsName, Quantity = 1});

                myGoodsItemsAdapter = new GoodsItemsAdapter(this, goodsItemsList); // refresh list
                listViewGoodsMain.Adapter = myGoodsItemsAdapter;

                hideSoftKeyboard();

                editTextNewProduct.Text = ""; // clear the editBox

                e.Handled = true;
            }
        }

        // hide keyboard when clicking anywhere but EditText
        protected void setupParent(View view)
        {
            //Set up touch listener for non-text box and not checkbox views to hide keyboard.
            if (!(view.OnCheckIsTextEditor()) && view.GetType() != typeof (CheckBox)
                && view.Id != Resource.Id.colorsCheckBoxesLayout)
            {
                view.Touch += (sender, args) => { hideSoftKeyboard(); };
            }

            //If a layout container, iterate over children
            if (view.GetType().BaseType == typeof(ViewGroup))
            {
                for (int i = 0; i < ((ViewGroup) view).ChildCount; i++) {
                    View innerView = ((ViewGroup) view).GetChildAt(i);
                    setupParent(innerView);
                }
            }
        }

        private void hideSoftKeyboard() {
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, 0);
        }
    }
}

