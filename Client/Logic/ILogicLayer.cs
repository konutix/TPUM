using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ILogicLayer
    {
        public event EventHandler ItemsChanged;
        public event EventHandler TransactionFailed;
        public event EventHandler TransactionSucceeded;

        public static ILogicLayer CreateLogicLayer(IDataLayer data = default(IDataLayer))
        {
            return new LogicLayer(data == null ? IDataLayer.CreateDataLayer() : data);
        }

        public abstract void AddNewProduct(string name, float price, int quantity, string platform, string genre);
        public abstract void AddExistingProduct(int id, int quant);
        public abstract bool RemoveProduct(int id, int quant);
        public abstract List<int> GetProductIds();
        public abstract void GetProductById(int id, out string name, out float price, out int quantity, out string platform, out string genre);
        public abstract void ChangePrice(int id, float newPrice);
        public abstract void GetShopData(out string shopName, out string homeTown, out string street, out int formed, out bool active);
        public abstract void SetShopData(string shopName, string homeTown, string street, int formed, bool active);
    }
}
