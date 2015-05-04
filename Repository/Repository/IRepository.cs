using System.Collections.Generic;

namespace Repository.Repository
{
    public interface IRepository<T> 
        where T: IInt32Id
    {
        IList<T> GetAll();
        T GetById(int id);
        void Save(T saveThis);
        void Delete(T deleteThis);
    }
}