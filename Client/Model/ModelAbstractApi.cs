using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientLogic;

namespace Model
{
    public abstract class ModelAbstractApi
    {
        public abstract IShopModel ShopModel { get; }
        public static ModelAbstractApi CreateApi(ILogicLayer logicLayer = default(ILogicLayer))
        {
            return new ModelApi(logicLayer ?? ILogicLayer.CreateLogicLayer());
        }
    }

    internal class ModelApi : ModelAbstractApi
    {
        public ModelApi(ILogicLayer logicLayer)
        {
            this.logicLayer = logicLayer;
        }

        public override IShopModel ShopModel => new ShopModel(logicLayer);
        private ILogicLayer logicLayer;

    }
}
