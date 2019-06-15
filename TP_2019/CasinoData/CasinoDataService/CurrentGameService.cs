using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;

namespace CasinoData
{
    public partial class CasinoDataService
    {
        public string PrintCurrentGame(ObservableCollection<CurrentGame> currentGame)
        {
            string currentGameString = "";

            for (int i = 0; i <= currentGame.Count; i++)
            {
                currentGameString += currentGame;

                if (i + 1 != currentGame.Count)
                {
                    currentGameString += ", ";
                }
            }

            return currentGameString;
        }

        public void AddCurrentGame(CurrentGame currentGame)
        {
            if (!casinoDataRepository.GetAllCurrentGame().Contains(currentGame))
            {
                casinoDataRepository.AddCurrentGame(currentGame);
            }
            else
            {
                throw new Exception("Current game alredy exists!");
            }
        }

        public bool DeleteCurrentGame(CurrentGame currentGame)
        {
            if (casinoDataRepository.GetAllCurrentGame().Contains(currentGame))
            {
                casinoDataRepository.DeleteCurrentGame(currentGame);
                return true;
            }
            else
            {
                throw new Exception("Current game does not exists!");
            }
        }

        public void UpdateCurrentGame(CurrentGame oldCurrentGame, CurrentGame newCurrentGame)
        {
            if (casinoDataRepository.GetAllCurrentGame().Contains(oldCurrentGame))
            {
                casinoDataRepository.UpdateCurrentGame(oldCurrentGame, newCurrentGame);
            }
            else
            {
                throw new Exception("Error! Can't update current game or does not exists!");
            }
        }

        public List<CurrentGame> CurrentGameBetweenDateTime(DateTime startGameTime, DateTime endGameTime)
        {
            List<CurrentGame> currentGamesList = new List<CurrentGame>();

            foreach (CurrentGame currentGame in casinoDataRepository.GetAllCurrentGame())
            {
                if (currentGame.StartGameTime >= startGameTime && currentGame.StartGameTime <= endGameTime)
                {
                    currentGamesList.Add(currentGame);
                }
            }

            return currentGamesList;
        }
    }
}
