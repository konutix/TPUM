using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Model;


namespace ViewModel
{
    public class ShopViewModel : ViewModelBase
    {
        public ShopViewModel() : this(ModelAbstractApi.CreateApi()) { }
        public ShopViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = ModelAbstractApi.CreateApi();
            games = new ObservableCollection<ProductModel>();
            buyList = ModelLayer.BuyList;
            BuyList = new List<ProductModel>();
            foreach (ProductModel game in ModelLayer.ShopModel.GetGames())
            {
                games.Add(game);
            }

            BuyButtonClick = new RelayCommand(BuyButtonClickHandler);
            ProductButtonClick = new RelayCommand<int>(ProductButtonClickHandler);


        }

        public ICommand ProductButtonClick { get; set; }
        public ICommand BuyButtonClick { get; set; }



        public ObservableCollection<ProductModel> Games
        {
            get
            {
                return games;
            }
            set
            {
                if (value.Equals(games))
                    return;
                games = value;
                RaisePropertyChanged("Games");
            }
        }

        public List<ProductModel> BuyList
        {
            get
            {
                return buyList;
            }
            set
            {
                if (value.Equals(buyList))
                    return;
                buyList = value;
                RaisePropertyChanged("BuyList");
            }
        }

        private void BuyButtonClickHandler()
        {
            ModelLayer.ShopModel.RemoveProducts(BuyList);
            BuyList.Clear();
            Games.Clear();
            foreach (ProductModel product in ModelLayer.ShopModel.GetGames())
            {
                Games.Add(product);
            }
        }

        private void ProductButtonClickHandler(int id)
        {
            BuyList.Add(Games.Where(d => d.ID == id).First());
        }

        private ObservableCollection<ProductModel> games;
        private List<ProductModel> buyList;
        private ModelAbstractApi ModelLayer;

    }
}
