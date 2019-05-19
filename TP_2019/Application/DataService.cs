using System;
using System.Collections.Generic;
using System.Linq;
using CasinoData;
using CasinoDataModelLibrary;

namespace Application
{
    class DataService
    {
        private DataRepository repository;

        public DataService()
        {
            throw new NotImplementedException();
        }

        public DataService(DataRepository repository)
        {
            this.repository = repository;
        }

        // print methods
        public string PrintGames(IEnumerable<Game> games)
        {
            string s = "";
            foreach (Game game in games)
            {
                s += game + "\n";
            }
            return s;
        }

        public string PrintUsers(IEnumerable<User> users)
        {
            string s = "";
            foreach (User user in users)
            {
                s += user + "\n";
            }
            return s;
        }

        public string PrintCurrentGames(IEnumerable<CurrentGame> currentGames)
        {
            string s = "";
            foreach (CurrentGame currentGame in currentGames)
            {
                s += currentGame + "\n";
            }
            return s;
        }

        public string PrintEvents(IEnumerable<Event> events)
        {
            string s = "";
            foreach (Event e in events)
            {
                s += e + "\n";
            }
            return s;
        }

        public string PrintAllBinded()
        {
            string s = "";

            IEnumerable<Event> events = this.repository.GetAllEvents();
            IEnumerable<Game> games = this.repository.GetAllGames();
            IEnumerable<CurrentGame> currentGames = this.repository.GetAllCurrentGames();
            IEnumerable<User> users = this.repository.GetAllUsers();

            foreach (User user in users)
            {
                s += user;
                s += "\nGra: \n\n";
                foreach (Event e in events)
                {
                    if (e.User == user)
                    {
                        s += e + "\n";
                    }
                }

                s += "\n---------------------------\n";
            }

            return s;
        }

        // add methods
        public void AddGame(Game game)
        {
            // check if given Game exists in repository
            if (!repository.GetAllGames().Contains(game)) repository.AddGame(game);
            else throw new ArgumentException("Object already exists. You are not allowed to add it second time.");
        }

        public void AddUser(User user)
        {
            // check if given User exists in repository
            if (!repository.GetAllUsers().Contains(user)) repository.AddUser(user);
            else throw new ArgumentException("Object already exists. You are not allowed to add it second time.");
        }

        public void AddCurrentGame(Game game, int howManyPayers, Double currentPrize, Double currentBet)
        {
            // check if given current game exists in repository
  
            if (repository.GetAllGames().Contains(game))
            {
                CurrentGame e = new CurrentGame()
                {
                    Game = game,
                    HowManyPlayers = howManyPayers,
                    CurrentPrize = currentPrize,
                    CurrentBet = currentBet,
                    StartGameTime = DateTimeOffset.Now
                };

                repository.AddCurrentGame(e);
            }
            else throw new ArgumentException("You are not allowed to add this current game.");
        }

        public void AddEvent(User user, CurrentGame currentGame)
        {
            // check if currentGame exists
            if (repository.GetAllUsers().Contains(user) && repository.GetAllCurrentGames().Contains(currentGame))
            {
                Event e = new Event()
                {
                    User = user,
                    CurrentGame = currentGame,
                    StartGameTime = DateTimeOffset.Now
                };

                repository.AddEvent(e);
            }
            else throw new InvalidOperationException(" You are not allowed to add this Event");
        }

        // method that ends given event/current game
        public void EndEvent(Event e)
        {
            // set return date to now
            e.EndGameTime = DateTimeOffset.Now;

        }

        public void EndCurrentGame(CurrentGame e)
        {
            // set return date to now
            e.EndGameTime = DateTimeOffset.Now;

        }

        // delete methods
        public void DeleteGame(Game game)
        {
            // check if given game exists in repository
            if (repository.GetAllGames().Contains(game)) repository.DeleteGame(game);
            else throw new ArgumentException("Operation failed, object not exist in database.");
        }

        public void DeleteUser(User user)
        {
            // check if given currentGame exists in repository
            if (repository.GetAllUsers().Contains(user)) repository.DeleteUser(user);
            else throw new ArgumentException("Operation failed, object not exist in database.");
        }

        public void DeleteCurrentGame(CurrentGame currentGame)
        {
            // check if given game state exists in repository
            if (repository.GetAllCurrentGames().Contains(currentGame)) repository.DeleteCurrentGame(currentGame);
            else throw new ArgumentException("Operation failed, object not exist in database.");
        }

        public void DeleteEvent(Event e)
        {
            // check if given event exists in the repository
            if (repository.GetAllEvents().Contains(e)) repository.DeleteEvent(e);
            else throw new ArgumentException("Operation failed, object not exist in database.");
        }

        // update methods
        public void UpdateGame(Game oldGame, Game newGame)
        {
            // check if old game exists in the repository
            if (repository.GetAllGames().Contains(oldGame))
            {
                repository.UpdateGame(oldGame, newGame);
            }
            else throw new ArgumentException("Operation failed, object not exist in database.");
        }

        public void UpdateUser(User oldUser, int age, string firstName, string lastName, string telephone)
        {
            // check if old currentGame exists in the repository
            if (repository.GetAllUsers().Contains(oldUser))
            {
                repository.UpdateUser(oldUser, age, firstName, lastName, telephone);
            }
            else throw new ArgumentException("Operation failed, object not exist in database.");
        }

        public void UpdateBookState(CurrentGame oldCurrentGame, CurrentGame newCurrentGame)
        {
            // check if old current game exists in the repository
            if (repository.GetAllCurrentGames().Contains(oldCurrentGame))
            {
                repository.UpdateCurrentGame(oldCurrentGame, newCurrentGame);
            }
            else throw new ArgumentException("Operation failed, object not exist in database.");
        }

        public void UpdateEvent(Event oldEvent, Event newEvent)
        {
            // check if old event exists in the repository
            if (repository.GetAllEvents().Contains(oldEvent))
            {
                repository.UpdateEvents(oldEvent, newEvent);
            }
            else throw new ArgumentException("Operation failed, object not exist in database.");
        }

        // filter and search methods

        // get all events for specified currentGame
        public IEnumerable<Event> EventsForUser(User user)
        {
            List<Event> events = new List<Event>();
            foreach (Event e in repository.GetAllEvents())
            {
                if (e.User.Equals(user)) events.Add(e);
            }
            return events;
        }

        // get all events that started after beginDate and ended before endDate
        public IEnumerable<Event> EventsBetweenDates(DateTimeOffset beginDate, DateTimeOffset endDate)
        {
            List<Event> events = new List<Event>();
            foreach (Event e in repository.GetAllEvents())
            {
                if (e.StartGameTime > beginDate && e.EndGameTime < endDate) events.Add(e);
            }
            return events;
        }

        // get all current games for specified game
        public IEnumerable<CurrentGame> CurrentGameForUser(CurrentGame currentGame)
        {
            List<CurrentGame> currentGames = new List<CurrentGame>();
            foreach (CurrentGame e in repository.GetAllCurrentGames())
            {
                if (e.Game.Equals(currentGame.Game)) currentGames.Add(e);
            }
            return currentGames;
        }

        // get all current games that started after beginDate and ended before endDate
        public IEnumerable<CurrentGame> CurrentGamesBetweenDates(DateTimeOffset beginDate, DateTimeOffset endDate)
        {
            List<CurrentGame> currentGames = new List<CurrentGame>();
            foreach (CurrentGame e in repository.GetAllCurrentGames())
            {
                if (e.StartGameTime > beginDate && e.EndGameTime < endDate) currentGames.Add(e);
            }
            return currentGames;
        }
    }
}
