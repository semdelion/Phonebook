using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core.ViewModels.Photo
{
    public class PhotoViewModel : MvxViewModel<string>
    {
        private string _photo;

        public string Photo
        {
            get { return _photo; }
            set { SetProperty(ref _photo, value); }
        }

        protected IMvxNavigationService NavigationService { get; }

        public override void Prepare(string parameter)
        {
            Photo = parameter;
        }

        public PhotoViewModel(IMvxNavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
