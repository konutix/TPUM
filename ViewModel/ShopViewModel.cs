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
        public ShopViewModel() :this(ModelAbstractApi.CreateApi()) { }
        public ShopViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            games = new ObservableCollection<ProductModel>();
            foreach(ProductModel game in ModelLayer.ShopModel.GetGames())
            {
                Games.Add(game);
            }

            //ICommand ClickCommand =new RelayCommand


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



        private ObservableCollection<ProductModel> games;   
        private ModelAbstractApi ModelLayer;

    }
}
