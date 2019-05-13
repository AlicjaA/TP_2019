using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;

namespace CasinoData
{
    public class ConstDataFiller : DataFiller
    {
        public override void Fill(ref DataContext context)
        {
            var user = context.user;
            var games = context.game;
            var events = context.events;
            var currentGame = context.currentGame;

            // create user object
            User user0 = new User()
            {
                ID = 000.ToString(),
                FirstName = "Admin",
                LastName = "Master",
                Telephone = "000000000"
            };
            User user1 = new User()
            {
                ID = 001.ToString(),
                FirstName = "AAAAAAA",
                LastName = "BBBBBBB",
                Telephone = "111111111"
            };
            User user2 = new User()
            {
                ID = 002.ToString(),
                FirstName = "CCCCCCC",
                LastName = "DDDDDDD",
                Telephone = "222222222"
            };
            User user3 = new User()
            {
                ID = 003.ToString(),
                FirstName = "EEEEEEE",
                LastName = "FFFFFFF",
                Telephone = "333333333"
            };
            // intialize user list
            user.Add(user0);
            user.Add(user1);
            user.Add(user2);
            user.Add(user3);

            // create game object
            Game game1 = new Game()
            {
                ID = 001,
                Name = "Poker",
                MaxPlayers = 10,
                MinPlayers = 2,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };

        throw new NotImplementedException();
        }
    }
}
