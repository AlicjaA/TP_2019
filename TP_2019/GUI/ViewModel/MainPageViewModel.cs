
using System.Collections.ObjectModel;
using CasinoData;
using CasinoDataModelLibrary;
using GUI.Model;
using GUI.Providers;
using GUI.View;
using GUI.View.WindowsInteractions;

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
            CurrentGames = new ObservableCollection<CurrentGame>();
            Events = new ObservableCollection<Event>();
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

            foreach (CurrentGame currentGame in dataRepository.GetAllCurrentGame())
            {
                CurrentGames.Add(currentGame);
            }

            foreach (Event ev in dataRepository.GetAllEvents())
            {
                Events.Add(ev);
            }


            #endregion

            #region Providers
            UserProvider.RegisterServiceLocator(new UnityServiceLocator());
            UserProvider.Instance.Register<IBaseWindowInteract, UserDetailsWindow>();
            GameProvider.RegisterServiceLocator(new UnityServiceLocator());
            GameProvider.Instance.Register<IBaseWindowInteract, GameDetailsWindow>();
            CurrentGameProvider.RegisterServiceLocator(new UnityServiceLocator());
            CurrentGameProvider.Instance.Register<IBaseWindowInteract, CurrentGameDetailsWindow>();
            EventProvider.RegisterServiceLocator(new UnityServiceLocator());
            EventProvider.Instance.Register<IBaseWindowInteract, EventDetailsWindow>();

            #endregion

        }
    }
}
