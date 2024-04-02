using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Model
{
    public abstract class ModelAbstractApi
    {
        public abstract ShopModel ShopModel { get; }
        public static ModelAbstractApi CreateApi(ILogicLayer logicLayer = default(ILogicLayer))
        {
            return new ModelApi(logicLayer ?? ILogicLayer.CreateLogicLayer());
        }
        public abstract List<ProductModel> BuyList {get; }  

        //public abstract void RemoveProduct
    }

    internal class ModelApi : ModelAbstractApi
    {
        public ModelApi(ILogicLayer logicLayer)
        {
            this.logicLayer = logicLayer;
        }

        public override ShopModel ShopModel => new ShopModel(logicLayer);

        public override List<ProductModel> BuyList => new List<ProductModel>();

        //public override 

        private ILogicLayer logicLayer;

    }
}
