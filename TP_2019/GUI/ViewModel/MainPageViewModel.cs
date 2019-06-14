using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CasinoData;
using CasinoDataModelLibrary;
using GUI.Model;
using GUI.Providers;
using GUI.View;

namespace GUI.ViewModel
{
    public partial class MainPageViewModel : Collective.ViewModel
    {
        public MainPageViewModel()
        {


            #region Fields
            IDbContext dbContext = new CasinoDataContext();
            CasinoDataModel.RegDataRepository(new CasinoDataRepository(dbContext));
            CasinoDataRepository dataRepository = CasinoDataModel.CasinoDataRepository;
            Users = new ObservableCollection<User>();
            Games = new ObservableCollection<Game>();
            #endregion

            #region LoadCollections
            foreach (User user in dataRepository.GetAllUsers())
            {
                Users.Add(user);
            }

            foreach (Game game in dataRepository.GetAllGames())
            {
                Games.Add(game);
            }


            #endregion

            #region Providers
            UserProvider.RegisterServiceLocator(new UnityServiceLocator());
            UserProvider.Instance.Register<IBaseWindowInteract, UserDetailsWindow>();
            GameProvider.RegisterServiceLocator(new UnityServiceLocator());
            GameProvider.Instance.Register<IBaseWindowInteract, GameDetailsWindow>();

            #endregion

        }
    }
}
