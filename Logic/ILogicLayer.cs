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
        public static ILogicLayer CreateLogicLayer(IDataLayer data = default(IDataLayer))
        {
            return new LogicLayer(data == null ? IDataLayer.CreateDataLayer() : data);
        }

        public abstract List<int> GetProductIds();
        public abstract void GetProductById(int id, out string name, out float price, out int quantity, out string platform, out string genre);
    }
}
