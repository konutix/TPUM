using System;
using System.Collections.Generic;
using System.Text;

namespace Data.AbstractShopData
{
    public abstract class DataLayerAbstract
    {

        public abstract ShopData Load();

        public static DataLayerAbstract CreateDataLayer()
        {
            return new DataLayerImplementation();
        }

        #region Layer implementation

        private class DataLayerImplementation : DataLayerAbstract
        {
            public override ShopData Load()
            {
                IShopData iSD = new Loading();
                return iSD.loadShopData();
            }

            #endregion Layer implementation
        }
    }
}
