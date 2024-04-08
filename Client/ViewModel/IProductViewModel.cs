using Model;
using System.ComponentModel;

namespace ViewModel
{
    public interface IProductViewModel : IProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Platform { get; set; }
        public string Genre { get; set; }
    }

    internal class ProductViewModel : IProductViewModel
       {
        internal ProductViewModel (int id, string name, float price, int quantity, string platform, string genre)
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

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}