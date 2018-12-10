using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Phonebook.API.Service;
using Phonebook.Core.ViewModels;

namespace Phonebook.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<IContactService, ContactService>();
            RegisterAppStart<ContactsViewModel>();
        }
    }
}


