namespace Model
{
    public interface IShopModel
    {
        public abstract event EventHandler ItemsChanged;
        public abstract event EventHandler TransactionFailed;
        public abstract event EventHandler TransactionSucceeded;

        public List<IProductModel> BuyList { get; set; }    

        public void RemoveProducts();

        public List<IProductModel> GetGames();
    }
}