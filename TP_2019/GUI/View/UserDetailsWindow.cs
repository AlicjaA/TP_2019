using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.View
{
    public class UserDetailsWindow : IBaseWindowInteract
    {





        #region Fields

        private UserDetails userDetailsWindow;

        #endregion

        #region Methods
        private UserDetails View { get => userDetailsWindow; set => userDetailsWindow = value; }

        private UserDetails GetNewView()
        {
            if (View == null)
            {
                Application.Current.Dispatcher.Invoke((Action)delegate { View = new UserDetails(); });
                View.Closed += new EventHandler(ClosingView);
            }
            return View;
        }

        public void BindViewModel<TViewModel>(TViewModel viewModel)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate { GetNewView().DataContext = viewModel; });

        }

        public void Close()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate { GetNewView().Close(); });
        }

        public void Show()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate { GetNewView().Show(); });
        }

        void ClosingView(object sender, EventArgs e)
        {
            View = null;
        }

        #endregion







    }
}
