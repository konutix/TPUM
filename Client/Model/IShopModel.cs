namespace Model
{
    public interface IShopModel
    {
        public List<IProductModel> BuyList { get; set; }    

        public void RemoveProducts();

        public List<IProductModel> GetGames();
    }
}