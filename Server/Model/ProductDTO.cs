﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace PresentationServer
{
    internal class ProductDTO
    {
        public ProductDTO(int id, string name, float price, int quantity, string platform, string genre)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Platform = platform;
            Genre = genre;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Platform { get; set; }
        public string Genre { get; set; }
    }
}
