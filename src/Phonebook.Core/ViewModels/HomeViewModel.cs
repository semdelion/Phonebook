using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;

namespace Phonebook.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private void ResetText()
        {
            
            Text = "Hello MvvmCross" + new Random().Next(100);
        }

        private string _text = "Hello MvvmCross";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }

}