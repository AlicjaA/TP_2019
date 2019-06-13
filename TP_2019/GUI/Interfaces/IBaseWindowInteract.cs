using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI
{
    public interface IBaseWindowInteract
    {
        void BindViewModel<TViewModel>(TViewModel viewModel);

        void Show();

        void Close();
    }
}
