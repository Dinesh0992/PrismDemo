using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Prism.Mvvm;
using ModuleA.ViewModels;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // using View Discovery method to inject view onto  ContentRegion 
            _regionManager.RegisterViewWithRegion("ContentRegionViewControlA", typeof(ViewControlA));

            //View Injection method
            IRegion region = _regionManager.Regions["ContentRegion2"];
            var view1 = containerProvider.Resolve<ViewA>();
            region.Add(view1);
            
            var view2 = containerProvider.Resolve<ViewA>();
            view2.Content = new TextBlock()
            {
                Text = "Hello from View2",
                HorizontalAlignment=System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Stretch
            };

            region.Add(view2);
           // region.Activate(view2);
          //  region.Remove(view1);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //for custom viewmodelname  view locator register
         //   ViewModelLocationProvider.Register<ViewControlA, ViewControlAViewModel>();

            //FacoryMethod
            ViewModelLocationProvider.Register<ViewControlA>(() =>
            {
                return new ViewControlAViewModel() { Title = "Hello from Factory" };
            } 
            );
        }
    }
}
