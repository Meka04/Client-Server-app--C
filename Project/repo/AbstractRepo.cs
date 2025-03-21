using log4net;
using Project.model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.repo
{
    public abstract class AbstractRepo<Id, T> : IRepo<Id, T>
    {
        private readonly IDictionary<Id, T> items;
        private static readonly ILog log = LogManager.GetLogger("AbstractRepo"); 

        public AbstractRepo() {
            log.Info("Creating abstract repo");
            items = new Dictionary<Id, T>();
        }
        public void add(Id id, T elem)
        {
            if (elem != null)
            {
                items.Add(id, elem);
             
                log.InfoFormat("Adding into repo id {0} with value {1}", id, elem);
            }
            else
                Console.WriteLine("Element cannot be null");
        }

        public void delete(Id id, T elem)
        {
            if (items.ContainsKey(id))
            {
                items.Remove(id);
                log.InfoFormat("Removing from repo element with id {0} and value {1}", id, elem);
            }
            else
                Console.WriteLine("Element not in list");
        }

        public List<T> getAll()
        {
            return items.Values.ToList();
        }

        public void update(T elem, Id id)
        {
            if (items.ContainsKey(id))
            {
                items.Add(id, elem);
                log.InfoFormat("Updated element with new id {0} and value {1}", id, elem);
            }
            else
                Console.WriteLine("Element not found");
        }
    }
}
