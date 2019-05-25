using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;

namespace CasinoData
{
    public partial class CasinoDataService
    {
        public string PrintGame(Dictionary<int, Game> games)
        {
            string gameString = "";

            for (int i = 0; i <= games.Count; i++)
            {
                gameString += games.Keys.ElementAt(i);

                if (i + 1 != games.Count)
                {
                    gameString += ", ";
                }
            }
            return gameString;
        }

        public void AddGame(Game game)
        {
            if (!casinoDataRepository.GetAllGames().Contains(game))
            {
                casinoDataRepository.AddGame(game);
            }
            else
            {
                throw new Exception("Game alredy exists!");
            }
        }

        public void DeleteGame(Game game)
        {
            if (casinoDataRepository.GetAllGames().Contains(game))
            {
                casinoDataRepository.DeleteGame(game);
            }
            else
            {
                throw new Exception("Game does not exists!");
            }
        }

        public void UpdateGame(Game oldGame, Game newGame)
        {
            if (casinoDataRepository.GetAllGames().Contains(oldGame))
            {
                casinoDataRepository.UpdateGame(oldGame, newGame);
            }
            else
            {
                throw new Exception("Error! Can't update game or does not exists!");
            }
        }
    }
}
