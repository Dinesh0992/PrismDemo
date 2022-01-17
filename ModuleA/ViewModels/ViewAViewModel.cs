using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleA.ViewModels
{
   public  class ViewAViewModel :BindableBase
    {
        private string _text="Hello from ViewAViewModel";

        public string Text
        { get { return _text; }
          set { SetProperty(ref _text, value); }
        }

        private bool _ChkClick=false;

        public bool ChkClick
        {
            get { return _ChkClick; }
            set { SetProperty(ref _ChkClick, value);
              //  one of the method to call CanClick method of button for change in chkClick checkbox status
                //ClickCommand.RaiseCanExecuteChanged(); 
            }
        }

        public DelegateCommand ClickCommand { get; private set; }

        public ViewAViewModel()
        {
            //using observable property 
             ClickCommand = new DelegateCommand(Click, CanClick)
                 .ObservesProperty(()=>ChkClick);

            // using ObservesCanExecute ,  for this CanClick method should be commented 
            //    ClickCommand = new DelegateCommand(Click).ObservesCanExecute(()=>ChkClick);
        }
        
        private bool CanClick()
        {
            return ChkClick;
        }
        

        private void Click()
        {
            Text ="You Clicked Me!..";
        }
    }
}
