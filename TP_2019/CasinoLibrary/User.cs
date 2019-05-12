namespace CasinoDataModelLibrary
{
    public class User
    {

        private string iD;
        private string firstName;
        private string lastName;
        private string telephone;
        private int age;


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
                return age.Equals(otherUser.age) && firstName.Equals(otherUser.firstName) && lastName.Equals(otherUser.lastName) && telephone.Equals(otherUser.telephone);
            }
            else
            {
                return false;
            }
        }
    }
}
