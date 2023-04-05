using Blueprinter.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprinter.Core.Services
{
    public class XmlContext : IContext
    {
        private readonly IRepository<BlueprintInfo> _blueprints;
        private readonly IRepository<TemplateInfo>  _templates;

        public XmlContext(string path)
        {
            var blueprintsPath = string.Format(@"{0}/blueprints.xml", path);
            var templatePath = string.Format(@"{0}/templates.xml", path);

            _blueprints = new BlueprintInfoRepository(blueprintsPath);
            _templates = new TemplateInfoRepository(templatePath);
        }

        public IEnumerable<BlueprintInfo> GetAllBlueprints()
        {
            return _blueprints.GetAll();
        }
    }
}
