using System.Collections.Generic;

namespace CasinoDataModelLibrary
{
    public class User
    {

        private string iD;
        private string firstName;
        private string lastName;
        private string telephone;
        private int age;

        public User() { }

        public User(string iD, string firstName, string lastName, string telephone, int age)
        {
            this.iD = iD;
            this.firstName = firstName;
            this.lastName = lastName;
            this.telephone = telephone;
            this.age = age;
        }

        public string ID
        {
            get => iD;
            set => iD = value;
        }

        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public string Telephone
        {
            get => telephone;
            set => telephone = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            string str = "Użytkownik " + iD + "  " + firstName + " " + lastName + ", wiek " + age + ", numer telefonu " + telephone + "\n";
            return str;
        }
        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                var otherUser = (User)obj;
                return iD.Equals(otherUser.iD)  && firstName.Equals(otherUser.firstName) && lastName.Equals(otherUser.lastName) && age.Equals(otherUser.age) && telephone.Equals(otherUser.telephone);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            var hashCode = 352033288;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(iD);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(firstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(lastName);
            hashCode = hashCode * -1521134295 + age.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(telephone);
            return hashCode;
        }


    }
}
