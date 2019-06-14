using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GUI.Interfaces;

namespace GUI.Collective
{
    class BaseMessageBox : IMessage
    {
        public MessageBoxResult Show(string message, string title, MessageBoxButton buttons, MessageBoxImage image)
        {
            return MessageBox.Show(message, title, buttons, image);
        }
    }
}
