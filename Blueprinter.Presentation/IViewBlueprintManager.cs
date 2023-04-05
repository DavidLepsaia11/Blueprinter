using Blueprinter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprinter.Presentation
{
    public interface IViewBlueprintManager : IView<IViewBlueprintManagerPresenter>
    {
        IEnumerable<BlueprintInfo> Blueprints { get; set; }
    }
}
