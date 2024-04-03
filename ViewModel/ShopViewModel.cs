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
            shopInst = ModelLayer.ShopModel;
            NotificationVisibility = "hidden";
            Start = 0;
            foreach (ProductModel game in ModelLayer.ShopModel.GetGames())
            {
                Games.Add(game);
            }

            BuyButtonClick = new RelayCommand(BuyButtonClickHandler);
            ProductButtonClick = new RelayCommand<int>(ProductButtonClickHandler);
            NotificationVisibilityTime = new RelayCommand(NotificationVisibilityHandler);

        }

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

        public ShopModel ShopInst
        {
            get
            {
                return shopInst;
            }
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
            foreach (ProductModel product in ModelLayer.ShopModel.GetGames())
            {
                Games.Add(product);
            }
        }

        private void ProductButtonClickHandler(int id)
        {
            ShopInst.BuyList.Add(Games.Where(d => d.ID == id).First());
            NotificationVisibility = "Hidden";
            Start = DateTime.Now.Second;
        }

        private ObservableCollection<ProductModel> games;
        private ShopModel shopInst;
        private string notificationVisibility;
        private int start;
        private ModelAbstractApi ModelLayer;

    }
}
