using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprinter.Presentation
{
    public class ViewBlueprintManagerPresenter : IViewBlueprintManagerPresenter
    {
        private readonly IApplicationController _appController;
        private readonly IViewBlueprintManager _view;

        public IViewBlueprintManager View
        {
            get => _view;
        }

        public ViewBlueprintManagerPresenter(IViewBlueprintManager view, IApplicationController appController)
        {
            _view = view;
            _appController = appController;
            _view.Presenter = this;
        }

        public void Run()
        {
            _view.Blueprints = _appController.Context.GetAllBlueprints();
            _view.Run();
        }
    }
}
