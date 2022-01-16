using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleA.ViewModels
{
   public  class ViewAViewModel :BindableBase
    {
        private string _title="Hello from ViewAViewModel";

        public string Title
        { get { return _title; }
          set { SetProperty(ref _title, value); }
        }
    }
}
