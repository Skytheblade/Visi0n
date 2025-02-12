using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace VModel_
{
    public interface IBaseDB
    {
        public Task<int> Insert(Entity e);
        //public abstract Task<int> Remove(Object o);
        //public abstract Task<int> Update(Object o);
    }
}
