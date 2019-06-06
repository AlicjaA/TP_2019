using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CasinoDataModelLibrary;
using GUI.Annotations;

namespace GUI.ViewModel
{
    class UserListControl: Binding, INotifyPropertyChanged
    {
        private User user;
        public string FirstName
        {
            get => FirstName;
            set => FirstName = value;
        }

        public string LastName
        {
            get => LastName;
            set => LastName = value;
        }

        public string Telephone
        {
            get => Telephone;
            set => Telephone = value;
        }

        public UserListControl(User user)
        {
            this.user = user;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Telephone = user.Telephone;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
