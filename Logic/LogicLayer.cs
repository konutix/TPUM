using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class LogicLayer : ILogicLayer
    {
        private IDataLayer Data { get; }

        public LogicLayer(IDataLayer data)
        {
            Data = data;
            Data.DrawData();
        }

        public List<int> GetProductIds()
        {
            return Data.GetProductIds();
        }

        public void GetProductById(int id, out string name, out float price, out int quantity, out string platform, out string genre)
        {
            Data.GetProductById(id, out name, out price, out quantity, out platform, out genre);
        }
    }
}
