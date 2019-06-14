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
        public void AddGame(Game game)
        {
            dataContext.Games.Add(game);
            dataContext.SaveChanges();
        }

        public Game GetGame(int id)
        {
            return dataContext.Games.FirstOrDefault(gID => gID.ID == id);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return dataContext.Games;
        }

        public void UpdateGame(Game oldGame, Game newGame)
        {
            oldGame.Title = newGame.Title;
            oldGame.MaxPrize = newGame.MaxPrize;
            oldGame.MinBet = newGame.MinBet;
            oldGame.MaxPlayers = newGame.MaxPlayers;
            oldGame.MinPlayers = newGame.MinPlayers;
            dataContext.SaveChanges();
        }

        public bool DeleteGame(Game game)
        {
            dataContext.Games.Remove(game);
            dataContext.SaveChanges();
            return true;
        }
    }







}
    

