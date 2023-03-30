using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprinter.Core.Data
{
    public class BlueprintInfoRepository : XmlRepository<BlueprintInfo>
    {
        public BlueprintInfoRepository(string path) : base(path)
        {
        }

        public override BlueprintInfo Create(BlueprintInfo entity)
        {
            if (entity.Id == new Guid())
            {
                throw new Exception("Bpueprint ID already exist!");
            }

            Records.Add(new BlueprintInfo() { 
                Id = Guid.NewGuid() ,
                LastModified = DateTime.Now,
                Name = entity.Name ,
               Blueprint = entity.Blueprint
            });

            WriteFile();

            return entity;
        }

        public override int Delete(BlueprintInfo entity)
        {
            var record = Records.SingleOrDefault( r => r.Id == entity.Id);

            if (record == null) 
            {
                return 0;
            }

            Records.Remove(record);

            WriteFile();

            return 1;
        }

        public override int Update(BlueprintInfo entity)
        {
            var record = Records.SingleOrDefault(r => r.Id == entity.Id);

            if (record == null)
            {
                return 0;
            }

            record.LastModified = DateTime.Now;
            record.Name = entity.Name;
            record.Blueprint = entity.Blueprint;

            WriteFile();

            return 1;
        }
    }
}
