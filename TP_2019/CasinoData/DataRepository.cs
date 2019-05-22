using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;

namespace CasinoData
{
    public class DataRepository
    {
        private DataFiller filler;
        private DataContext data;

        public DataRepository(DataFiller dataFiller)
        {
            this.filler = dataFiller;
        }


        public DataContext Data
        {
            set => data = value;
        }
/*
        public DataFiller Filler
        {
            set => filler = value;
        }
        */
        public void Fill()
        {
            filler.Fill(ref data);
        }

        // CRUD methods for games *****************************
        public void AddGame(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            data.games.Add(game.ID, game);
        }

        public Game GetGame(int id)
        {
            return data.games[id];
        }

        public IEnumerable<Game> GetAllGames()
        {
            return data.games.Values;
        }

        public void UpdateGame(Game oldGame, Game newGame)
        {
            var id = oldGame.ID;
            oldGame.ID = newGame.ID;
            oldGame.Title = newGame.Title;
            oldGame.MaxPrize = newGame.MaxPrize;
            oldGame.MinBet = newGame.MinBet;
            oldGame.MaxPlayers = newGame.MaxPlayers;
            oldGame.MinPlayers = newGame.MinPlayers;

            data.games.Remove(id);
            data.games.Add(oldGame.ID, oldGame);
        }
        public void DeleteGame(Game game)
        {
            data.games.Remove(game.ID);
        }


        // CRUD methods for users  *****************************
        public void AddUser(User user)
        {
            data.users.Add(user);
        }

        public User GetUser(int index)
        {
            return data.users[index];
        }

        public IEnumerable<User> GetAllUsers()
        {
            return data.users;
        }

        public void UpdateUser(User oldUser, User newUser)
        {
            oldUser.ID = newUser.ID;
            oldUser.FirstName = newUser.FirstName;
            oldUser.LastName = newUser.LastName;
            oldUser.Telephone = newUser.Telephone;
            oldUser.Age = newUser.Age;
        }

        public void DeleteUser(User user)
        {
            data.users.Remove(user);
        }

        // CRUD methods for currentGames  *****************************
        public void AddCurrentGame(CurrentGame currentGame)
        {
            data.currentGames.Add(currentGame);
        }

        public void UpdateCurrentGame(CurrentGame oldCurrentGame, CurrentGame newCurrentGame)
        {
            oldCurrentGame.Game = newCurrentGame.Game;
            oldCurrentGame.HowManyPlayers = newCurrentGame.HowManyPlayers;
            oldCurrentGame.CurrentPrize = newCurrentGame.CurrentPrize;
            oldCurrentGame.CurrentBet = newCurrentGame.CurrentBet;
            oldCurrentGame.StartGameTime = newCurrentGame.StartGameTime;
            oldCurrentGame.EndGameTime = newCurrentGame.EndGameTime;
        }

        public void DeleteCurrentGame(CurrentGame currentGame)
        {
            data.currentGames.Remove(currentGame);
        }
        
        public CurrentGame GetCurrentGame(int index)
        {
            return data.currentGames[index];
        }

        public IEnumerable<CurrentGame> GetAllCurrentGames()
        {
            return data.currentGames;
        }

        // CRUD methods for Event  *****************************
        public void AddEvent(Event event1)
        {
            data.events.Add(event1);
        }

        public void DeleteEvent(Event e)
        {
            data.events.Remove(e);
        }

        public void UpdateEvents(Event oldEvent, Event newEvent)
        {
            oldEvent.CurrentGame = newEvent.CurrentGame;
            oldEvent.User = newEvent.User;
            oldEvent.StartGameTime = newEvent.StartGameTime;
            oldEvent.EndGameTime = newEvent.EndGameTime;
        }
        
        public Event GetEvent(int index)
        {
            return data.events[index];
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return data.events;
        }

     
    }
}
