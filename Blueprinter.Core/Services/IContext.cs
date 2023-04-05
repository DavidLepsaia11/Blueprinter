using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprinter.Core.Services
{
    public interface IContext
    {
        IEnumerable<BlueprintInfo> GetAllBlueprints();
    }
}
