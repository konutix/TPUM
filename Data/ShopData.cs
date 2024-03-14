using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Data
{
    public class ShopData
    {
        internal string shopName { get; set; }
        internal string homeTown { get; set; }
        internal string street { get; set; }
        internal int formed { get; set; }
        internal bool active { get; set; }
        internal Product[] products { get; set; }
    }

    internal class Product
    {
        internal string name { get; set; }
        internal float price { get; set; }
        internal int quantity { get; set; }
        internal string platform { get; set; }
        internal string[] genre { get; set; }
    }
}

