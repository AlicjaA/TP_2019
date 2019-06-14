using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Interfaces;

namespace GUI.Providers
{
    public static class MessageBoxProvider
    {
        private static IMessage message;

        public static void MessageService(IMessage _message)
        {
            message = _message;
        }

        public static IMessage GetMessage()
        {
            return message;
        }
    }
}
