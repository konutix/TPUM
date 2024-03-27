using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductModel : INotifyPropertyChanged
    {
        public ProductModel(string name, float price, int quantity, string platform, string genres)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.platform = platform;
            this.genre = genre;
        }

        public string name { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public string platform { get; set; }
        public string genre { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
