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
        
        private UserDetails view;


        public void BindViewModel<TViewModel>(TViewModel viewModel)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate { GetDialog().DataContext = viewModel; });
            
        }

        public void Close()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate { GetDialog().Close(); });
        }

        public void Show()
        {
            Application.Current.Dispatcher.Invoke((Action) delegate { GetDialog().Show(); });
        }

        private UserDetails GetDialog()
        {
            if (view == null)
            {
                Application.Current.Dispatcher.Invoke((Action) delegate { view = new UserDetails(); });
                view.Closed += new EventHandler(view_Closed);
            }
            return view;
        }

        void view_Closed(object sender, EventArgs e)
        {
            view = null;
        }
    }
}
