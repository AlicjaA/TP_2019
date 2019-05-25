using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    [DataContract()]
    [Serializable]
    public class User : INotifyPropertyChanged
    {

        private int id;
        private string firstName;
        private string lastName;
        private string telephone;
        private int age;

        [DataMember()]
        public int ID
        {
            get => id;
            set => id = value;
        }

        [DataMember()]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value;
                OnPropertyChanged("FirstName"); }
        }

        [DataMember()]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value;
                OnPropertyChanged("LastName"); }
        }

        [DataMember()]
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; 
                OnPropertyChanged("Telephone"); }
        }

        [DataMember()]
        public int Age
        {
            get { return age; }
            set { age = value;
                OnPropertyChanged("Age");}
        }
        
        public User() { }

        public User(int id, string firstName, string lastName, string telephone, int age)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.telephone = telephone;
            this.age = age;
        }


        public override string ToString()
        {
            string str = "Użytkownik " + id + "  " + firstName + " " + lastName + ", wiek " + age + ", numer telefonu " + telephone + "\n";
            return str;
        }
        public override bool Equals(object obj)
        {
            var otherUser = obj as User;
            return otherUser != null &&
                firstName.Equals(otherUser.firstName) && 
                lastName.Equals(otherUser.lastName) && 
                age.Equals(otherUser.age) && 
                telephone.Equals(otherUser.telephone);
           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        public override int GetHashCode()
        {
            var hashCode = 352033288;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(firstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(lastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(telephone);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(age);
            return hashCode;
        }

    }
}
