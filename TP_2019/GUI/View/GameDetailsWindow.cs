using System;
using System.Windows;

namespace GUI.View
{
    public class GameDetailsWindow : IBaseWindowInteract
    {

        #region Fields

        private GameDetails gameDetailsWindow;

        #endregion

        #region Methods
        private GameDetails View { get => gameDetailsWindow; set => gameDetailsWindow = value; }

        private GameDetails GetNewView()
        {
            if (View == null)
            {
                Application.Current.Dispatcher.Invoke((Action)delegate { View = new GameDetails(); });
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
