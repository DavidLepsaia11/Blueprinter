using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprinter.Presentation
{
    public interface IViewMainPresenter
    {
        IViewMain View { get; }

        void RunBlueprintManager();
    }
}
