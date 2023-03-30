using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Blueprinter.Core.Data
{
    public abstract class XmlRepository<TEntity> : IRepository<TEntity>
    {
        protected readonly List<TEntity> Records;
        protected readonly string Path;


        public XmlRepository(string path)
        {
            Records = new List<TEntity>();
            Path = path;    
        } 

        protected virtual void WriteFile() 
        {
            var serializer = new XmlSerializer(Records.GetType());

            using (var writer = new StreamWriter(Path, false))
            {
                serializer.Serialize(writer, Records);  
            }
        }

        protected virtual void ReadFile() 
        { 
            var contents = string.Empty;

            if (File.Exists(Path))
            {
                contents = File.ReadAllText(Path);
            }

            if (string.IsNullOrWhiteSpace(contents))
            {
                return;
            }

            var serializer = new XmlSerializer(Records.GetType());

            using (var reader = new StringReader(contents))
            {
                List<TEntity> records = new List<TEntity>();
                var deserilizedData = serializer.Deserialize(reader);
                if (deserilizedData != null)
                {
                    records = (List<TEntity>)deserilizedData;
                }

                Records.Clear();
                Records.AddRange(records);
            }
        }

        protected virtual Predicate<TEntity> CreatePredicateFrom(Expression<Func<TEntity,bool>> expression) 
        {
            return new Predicate<TEntity>(expression.Compile());
        }

        public int Count => Records.Count;

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Records.Any(predicate.Compile());
        }

        public abstract TEntity Create(TEntity entity);

        public abstract int Delete(TEntity entity);

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var pred = CreatePredicateFrom(predicate);

            return Records.RemoveAll(pred);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            var pred = CreatePredicateFrom(predicate);

            return Records.Find(pred);  
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            var pred = CreatePredicateFrom(predicate);

            return Records.FindAll(pred);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Records.ToArray();
        }

        public abstract int Update(TEntity entity);
      
    }
}
