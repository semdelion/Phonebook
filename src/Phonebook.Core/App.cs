using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Phonebook.Core.ViewModels;

namespace Phonebook.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<HomeViewModel>();
        }
    }
}