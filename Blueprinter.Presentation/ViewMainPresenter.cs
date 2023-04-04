using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprinter.Presentation
{
    public class ViewMainPresenter : IViewMainPresenter
    {
        private readonly IViewMain _view;
        private readonly IApplicationController _appController;
        public IViewMain View 
        {
            get => _view;
        }

        public ViewMainPresenter(IViewMain view, IApplicationController appController )
        {
            _view = view;    
            _appController = appController;
            _view.Presenter = this;
        }

        public void RunBlueprintManager()
        {
            _appController.RunBlueprintManager();
        }
    }
}
