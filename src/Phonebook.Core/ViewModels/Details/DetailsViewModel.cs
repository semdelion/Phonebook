using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Phonebook.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.ViewModels.Details
{
    public class DetailsViewModel : MvxViewModel<Contact>
    {
        #region Fields
        private ContactDetails _contact;
        #endregion

        #region Commands
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
        public DetailsViewModel(IMvxNavigationService navigationService/*, Contact ContactPar*/)
        {
            NavigationService = navigationService;
            //CurrentContact = new ContactDetails(ContactPar); // это ооооочень плохо выглядит. 
        }

        public override void Prepare(Contact parameter)
        {
            CurrentContact = new ContactDetails(parameter);
        }
        #endregion

        #region Private
        #endregion

        #region Protected
        #endregion

        #region Public
        #endregion
    }
}

