using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.repo
{
    interface IRepo<ID, T>
    {
        public void add(ID id, T elem);
        public void delete(ID id, T elem);
        public void update(T elem, ID id); //update using a specific criteria
        public List<T> getAll();
    }
}
