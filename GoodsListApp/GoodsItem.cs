using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Graphics;

namespace GoodsListApp
{
    class GoodsItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Color Color { get; set; }
        public int Rating { get; set; }
    }
}
