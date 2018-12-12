using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core
{
    public interface IMessage
    {
        void Dialog(string message, Action buttonAction);
    }
}
