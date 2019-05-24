using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    [DataContract()]
    [Serializable]
    public class User
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
            get => firstName;
            set => firstName = value;
        }

        [DataMember()]
        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        [DataMember()]
        public string Telephone
        {
            get => telephone;
            set => telephone = value;
        }

        [DataMember()]
        public int Age
        {
            get => age;
            set => age = value;
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
