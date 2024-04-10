using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationServer
{
    internal class ShopDTO
    {
        public ShopDTO()
        {
            shopName = "empty";
            homeTown = "empty";
            street = "empty";
            formed = 0;
            active = false;
            products = new List<ProductDTO>();
        }

        public string shopName { get; set; }
        public string homeTown { get; set; }
        public string street { get; set; }
        public int formed { get; set; }
        public bool active { get; set; }
        public string lastTransaction { get; set; }
        public List<ProductDTO> products { get; set; }
    }
}
