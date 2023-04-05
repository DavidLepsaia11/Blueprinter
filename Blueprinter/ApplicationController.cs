using Blueprinter.Core.Services;
using Blueprinter.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprinter
{
    public class ApplicationController : IApplicationController
    {
        private readonly IContext _context;

        public IContext Context 
        {
            get => _context;
        }

        public ApplicationController(IContext context)
        {
            _context = context;
        }



        public void RunBlueprintManager()
        {
            using (var view = new ViewBlueprintManager())
            {
               var presenter = new ViewBlueprintManagerPresenter(view, this);
                presenter.Run();
            }
        }
    }
}
