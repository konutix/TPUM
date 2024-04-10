namespace Model
{
    public interface IShopModel
    {
        public abstract event EventHandler ItemsChanged;

        public List<IProductModel> BuyList { get; set; }    

        public void RemoveProducts();

        public List<IProductModel> GetGames();
    }
}