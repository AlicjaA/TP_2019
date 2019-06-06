using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{   
    [DataContract()]
    [Serializable]
    public class Game : INotifyPropertyChanged
    {
        private int id;
        private String title;
        private int maxPlayers;
        private int minPlayers;
        private Double maxPrize;
        private Double minBet;

        
        [DataMember()]
        public int ID 
        {
            get => id;
            set => id = value;
        }

        [DataMember()]
        public string Title 
        {
            get { return title; }
            set
            {
                title = value; 
                OnPropertyChanged("Title");
            }
        }

        [DataMember()]
        public double MaxPrize
        {
            get { return maxPrize; }
            set { maxPrize = value; 
                OnPropertyChanged("MaxPrize"); }
        }

        [DataMember()]
        public int MaxPlayers
        {
            get { return maxPlayers; }
            set { maxPlayers = value; 
                OnPropertyChanged("MaxPlayers"); }
        }

        [DataMember()]
        public int MinPlayers
        {
            get { return minPlayers; }
            set { minPlayers = value;
                OnPropertyChanged("MinPlayers"); }
        }

        [DataMember()]
        public double MinBet
        {
            get { return minBet; }
            set { minBet = value; 
                OnPropertyChanged("MinBet"); }
        }

        public Game() { }

        public Game(int id, string title, double maxPrize, double minBet, int maxPlayers, int minPlayers)
        {
            this.id = id;
            this.title = title;
            this.maxPrize = maxPrize;
            this.minBet = minBet;
            this.maxPlayers = maxPlayers;
            this.minPlayers = minPlayers;

        }

        public Game(int id, string title)
        {
            this.id = id;
            this.title = title;
        }

        public override string ToString()
        {
            string str = "Game: " + " ID " + id + "; Title " + title + "; Max prize: " + maxPrize + "; Min bet: " +
                         minBet + "; Max players: " + maxPlayers + "; Min players: " + minPlayers + "\n";
            return str;
        }

        public override bool Equals(object obj)
        {
            var otherGame = obj as Game;
            return otherGame != null &&
                   title.Equals(otherGame.title) &&
                   MaxPrize.Equals(otherGame.MaxPrize) && 
                   MinBet.Equals(otherGame.MinBet) &&
                   MaxPlayers.Equals(otherGame.MaxPlayers) && 
                   MinPlayers.Equals(otherGame.MinPlayers);
          
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        public override int GetHashCode()
        {
            var hashCode = 352033288;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(title);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(maxPrize);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(minBet);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(maxPlayers);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(minPlayers);
            return hashCode;
        }
        


    }
}