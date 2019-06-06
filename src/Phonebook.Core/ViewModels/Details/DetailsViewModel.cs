using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Phonebook.API.Models;
using Phonebook.Core.ViewModels.Photo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core.ViewModels.Details
{
    public class DetailsViewModel : MvxViewModel<Contact>
    {
        #region Fields
        private ContactDetails _contact;
        #endregion

        #region Commands
        private IMvxCommand _photoClick;
        public IMvxCommand PhotoClick => _photoClick ?? (_photoClick = new MvxAsyncCommand(NavigateToPhoto));
        #endregion

        #region Properties
        public ContactDetails CurrentContact
        {
            get { return _contact; }
            set { SetProperty(ref _contact, value);  }
        }
        #endregion

        #region Services
        protected IMvxNavigationService NavigationService { get; }

        #endregion

        #region Constructors
        public DetailsViewModel(IMvxNavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public override void Prepare(Contact parameter)
        {
            CurrentContact = new ContactDetails(parameter);
        }
        #endregion

        private Task<bool> NavigateToPhoto()
        {
            return NavigationService.Navigate<PhotoViewModel, string>(_contact.Photo);
        }
    }
}

