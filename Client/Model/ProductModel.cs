using JetBrains.Annotations;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class ProductModel : IProductModel, INotifyPropertyChanged
    {
        public ProductModel() { }
        public ProductModel(int id, string name, float price, int quantity, string platform, string genre)
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
