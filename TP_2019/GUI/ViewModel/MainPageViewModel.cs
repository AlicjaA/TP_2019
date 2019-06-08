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
            CasinoData.CasinoDataRepository dataRepository = CasinoDataModel.CasinoDataRepository;
            Users = new ObservableCollection<User>();
            #endregion

            #region LoadCollections
            foreach (User client in dataRepository.GetAllUsers())
            {
                Users.Add(client);
            }


            #endregion

        }
    }
}
