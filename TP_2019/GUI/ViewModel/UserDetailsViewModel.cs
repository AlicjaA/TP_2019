using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.ViewModel.Commands;
using CasinoData;
using CasinoDataModelLibrary;

namespace GUI.ViewModel
{

    public partial class MainPageViewModel
    {
            #region Fields

            private User selectedUser;

            #endregion

        #region CommandFields
        private AddCommand addUserCommand;
        private EditCommand editUserCommand;
        private DeleteCommand deleteUserCommand;



        #endregion

        #region CommandsMethods
        public AddCommand AddUserCommand
            {
                get
                {
                    if (addUserCommand == null)
                    {
                        addUserCommand = new AddCommand(e => AddUser());
                    }
                    return addUserCommand;
                }
            }

            public EditCommand EditUserCommand
            {
                get
                {
                    if (editUserCommand == null)
                    {
                        editUserCommand = new EditCommand(e => EditUser(selectedUser), e => selectedUser != null);
                    }
                    return editUserCommand;
                }
            }

            public DeleteCommand DeleteUserCommand
            {
                get
                {
                    if (DeleteUserCommand == null)
                    {
                        deleteUserCommand = new DeleteCommand(e => DeleteUser(selectedUser), e => selectedUser != null);
                    }
                    return DeleteUserCommand;
                }
            }


        #endregion








    }

}
