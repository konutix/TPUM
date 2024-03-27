using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;

namespace Logic
{
    public abstract class LogicLayerFactory
    {
        public static ILogicLayer CreateLayer(IDataLayer? data = default(IDataLayer))
        {
            return new BusinessLogic(data == null ? IDataLayer.CreateDataLayer() : data);
        }

        private class BusinessLogic : ILogicLayer
        {
            public BusinessLogic(IDataLayer dataLayerAPI)
            {
                MyDataLayer = dataLayerAPI;
                MyDataLayer.DrawData();
            }

            private readonly IDataLayer MyDataLayer;

            public List<int> GetProductIds()
            {
                throw new NotImplementedException();
            }

            public void GetProductById(int id, out string name, out float price, out int quantity, out string platform, out string genre)
            {
                throw new NotImplementedException();
            }
        }
    }
}
