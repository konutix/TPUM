using System;
using System.Collections.Generic;
using System.Text;
using Data.AbstractShopData;

namespace Logic.AbstractLayerInterface
{
    public abstract class LayerFactory
    {
       // public static BussinessLogic CreateLayer(DataLayerAbstract? data = default(DataLayerAbstract))
       // {
       //     return new BussinessLogic(data == null ? DataLayerAbstract.CreateDataLayer() : data);
       // }

        private class BussinessLogic
        {
            public BussinessLogic(DataLayerAbstract data)
            {
                myDataLayer = data;
                myDataLayer.Load();

            }
            private readonly DataLayerAbstract myDataLayer;
        }
    }
}
