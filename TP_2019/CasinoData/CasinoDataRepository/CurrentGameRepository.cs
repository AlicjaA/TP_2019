using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;

namespace CasinoData
{
    public partial class CasinoDataRepository
    {
        public void AddCurrentGame(CurrentGame currentGame)
        {
            dataContext.CurrentGames.Add(currentGame);
            dataContext.SaveChanges();
        }

        public CurrentGame GetCurrentGame(int id)
        {
            return dataContext.CurrentGames.FirstOrDefault(cgID => cgID.ID == id);
        }

        public IEnumerable<CurrentGame> GetAllCurrentGame()
        {
            return dataContext.CurrentGames;
        }

        public void UpdateCurrentGame(CurrentGame oldCurrentGame, CurrentGame newCurrentGame)
        {
            oldCurrentGame.Game = newCurrentGame.Game;
            oldCurrentGame.HowManyPlayers = newCurrentGame.HowManyPlayers;
            oldCurrentGame.CurrentPrize = newCurrentGame.CurrentPrize;
            oldCurrentGame.CurrentBet = newCurrentGame.CurrentBet;
            oldCurrentGame.StartGameTime = newCurrentGame.StartGameTime;
            oldCurrentGame.EndGameTime = newCurrentGame.EndGameTime;
            dataContext.SaveChanges();
        }

        


        public bool DeleteCurrentGame(CurrentGame currentGame)
        {
            dataContext.CurrentGames.Remove(currentGame);
            dataContext.SaveChanges();
            return true;
        }
    }
}
