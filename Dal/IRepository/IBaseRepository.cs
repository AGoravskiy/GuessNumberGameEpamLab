using Dal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.IRepository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        T Get(int id);

        void Save(T model);
    }
}
