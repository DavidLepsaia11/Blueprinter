using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprinter.Core.Data
{
    public class TemplateInfoRepository : XmlRepository<TemplateInfo>
    {
        public TemplateInfoRepository(string path) : base(path)
        {

        }

        public override TemplateInfo Create(TemplateInfo entity)
        {
            if (entity.Id == new Guid())
            {
                throw new Exception("Template ID already exist!");
            }

            var tempInfo = new TemplateInfo() 
            {
                Id = Guid.NewGuid(),
                LastModified = DateTime.Now,
                Content = entity.Content,
                Name = entity.Name,
                Shortcut = entity.Shortcut
            };

            Records.Add(tempInfo);

            WriteFile();

            return tempInfo;
        }

        public override int Delete(TemplateInfo entity)
        {
            var record = Records.SingleOrDefault(r => r.Id == entity.Id);

            if (record == null)
            {
                return 0;
            }

            Records.Remove(record);

            WriteFile();

            return 1;
        }

        public override int Update(TemplateInfo entity)
        {
            var record = Records.SingleOrDefault(r => r.Id == entity.Id);

            if (record == null)
            {
                return 0;
            }

            record.LastModified = DateTime.Now;
            record.Name = entity.Name;
            record.Shortcut = entity.Shortcut;
            record.Content = entity.Content;

            WriteFile();

            return 1;
        }
    }
}
