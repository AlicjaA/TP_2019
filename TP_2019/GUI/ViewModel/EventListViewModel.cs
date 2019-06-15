using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CasinoDataModelLibrary;
using GUI.Model;
using GUI.Providers;
using GUI.ViewModel.Commands;

namespace GUI.ViewModel
{
    public partial class MainPageViewModel : Collective.ViewModel
    {
        #region Fields
        private Event selectedEvent;
        private ObservableCollection<Event> evs;



        #endregion


        #region Getters&Setters


        public Event SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value;
                EditEventCommand.RaiseCanExecuteChanged();
                DeleteEventCommand.RaiseCanExecuteChanged();
                ShowEventCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<Event> Events
        {
            get => evs;
            set
            {
                evs = value;
                OnPropertyChanged("Events");
            }
        }


        #endregion


        #region CommandFields
        private BaseCommand addEventCommand;
        private DataChangeCommand editEventCommand;
        private DataChangeCommand deleteEventCommand;
        private DataChangeCommand showEventCommand;

        #endregion

        #region CommandsMethods

        public BaseCommand AddEventCommand
        {
            get
            {
                if (addEventCommand == null)
                {
                    addEventCommand = new BaseCommand(e =>
                                Task.Run(() => { AddEvent(); }), null
                            );
                }
                return addEventCommand;
            }
        }



        public DataChangeCommand EditEventCommand
        {
            get
            {
                if (editEventCommand == null)
                {
                    editEventCommand = new DataChangeCommand(e =>
                        Task.Run(() => { EditEvent(selectedEvent); })
                            , e => selectedEvent != null);
                }
                return editEventCommand;
            }
        }

        public DataChangeCommand ShowEventCommand
        {
            get
            {
                if (showEventCommand == null)
                {
                    showEventCommand = new DataChangeCommand(e =>
                                Task.Run(() => { ShowEvent(selectedEvent); }),
                            e => selectedEvent != null);
                }
                return showEventCommand;
            }
        }

        public DataChangeCommand DeleteEventCommand
        {
            get
            {
                if (deleteEventCommand == null)
                {
                    deleteEventCommand = new DataChangeCommand(e =>
                        Task.Run(() => { DeleteEvent(selectedEvent); })
                            , e => selectedEvent != null);
                }
                return deleteEventCommand;
            }
        }

        #endregion


        #region Actions

        public void AddEvent()
        {

            EventDetailsViewModel viewModel = new EventDetailsViewModel { Action = Collective.Action.ADD };
            IBaseWindowInteract window = EventProvider.Instance.Get<IBaseWindowInteract>();
            viewModel.SetCloseAction(e => window.Close());
            viewModel.SetAddAction(e => Events.Add((Event)e));
            window.BindViewModel(viewModel);
            window.Show();
        }





        public void EditEvent(Event ev)
        {
            EventDetailsViewModel viewModel = new EventDetailsViewModel(ev, ev.User,ev.CurrentGame) { Action = Collective.Action.EDIT };
            IBaseWindowInteract window = EventProvider.Instance.Get<IBaseWindowInteract>();
            int position = Events.IndexOf(ev);
            viewModel.SetEditAction(e => Events[position] = ev);
            viewModel.SetCloseAction(e => window.Close());
            window.BindViewModel(viewModel);
            window.Show();

        }

        public void DeleteEvent(Event ev)
        {
            CasinoData.CasinoDataRepository dataRepository = CasinoDataModel.CasinoDataRepository;
            Task.Run(() =>
            {
                dataRepository.DeleteEvents(ev);

            });

            Application.Current.Dispatcher.Invoke((Action)delegate { Events.Remove(ev); });
        }

        public void ShowEvent(Event ev)
        {
            EventDetailsViewModel viewModel = new EventDetailsViewModel(ev, ev.User, ev.CurrentGame) { Action = Collective.Action.SHOW };
            IBaseWindowInteract window = EventProvider.Instance.Get<IBaseWindowInteract>();
            viewModel.SetCloseAction(e => window.Close());
            window.BindViewModel(viewModel);
            window.Show();

        }

        #endregion
    }
}
