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
            games = new ObservableCollection<IProductViewModel>();

            shopInst = ModelLayer.ShopModel;
            NotificationVisibility = "hidden";
            Start = 0;
            foreach (IProductModel game in shopInst.GetGames())
            {
                Games.Add(new ProductViewModel(game.ID,
                                               game.Name,
                                               game.Price,
                                               game.Quantity,
                                               game.Platform,
                                               game.Genre));
            }

            BuyButtonClick = new RelayCommand(BuyButtonClickHandler);
            ProductButtonClick = new RelayCommand<int>(ProductButtonClickHandler);
            NotificationVisibilityTime = new RelayCommand(NotificationVisibilityHandler);

        }

        public ObservableCollection<IProductViewModel> Games
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

        public ShopModel ShopInst
        {
            get => (ShopModel)shopInst;
            set
            {
                if (value.Equals(shopInst))
                    return;
                shopInst = value;
                RaisePropertyChanged("ShopInst");
            }
        }
        public string NotificationVisibility
        {
            get
            {
                return notificationVisibility;
            }
            set
            {
                if (value.Equals(notificationVisibility))
                    return;
                notificationVisibility = value;
                RaisePropertyChanged("NotificationVisibility");
            }
        }

        public int Start
        {
            get
            {
                return start;
            }
            set
            {
                if (value.Equals(start))
                    return;
                start = value;
                RaisePropertyChanged("Start");
            }
        }

        public ICommand ProductButtonClick { get; set; }
        public ICommand BuyButtonClick { get; set; }
        public ICommand NotificationVisibilityTime { get; set; }

        private void NotificationVisibilityHandler()
        {
            NotificationVisibility = "Visible";
        }

        private void BuyButtonClickHandler()
        {
            ShopInst.RemoveProducts();
            ShopInst.BuyList.Clear();
            Games.Clear();
            foreach (IProductModel product in ModelLayer.ShopModel.GetGames())
            {
                Games.Add(new ProductViewModel(product.ID,
                                               product.Name,
                                               product.Price,
                                               product.Quantity,
                                               product.Platform,
                                               product.Genre));
            }
        }

        private void ProductButtonClickHandler(int id)
        {
            ShopInst.BuyList.Add((IProductModel)Games.Where(d => d.ID == id).First());
            NotificationVisibility = "Hidden";
            Start = DateTime.Now.Second;
        }

        private ObservableCollection<IProductViewModel> games;
        private ShopModel shopInst;
        private string notificationVisibility;
        private int start;
        private ModelAbstractApi ModelLayer;
    }
}
