using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Repository;

namespace Repository.Mocks
{
    public class RepositoryMock<T>:
        IRepository<T> where T:IInt32Id
    {
        private int m_currentIdValue = 0;
        protected List<T> Items { get; set; }


        public RepositoryMock()
        {
            Items = new List<T>();
        }

        public void Save(T saveThis)
        {
            if(saveThis==null)
                throw new ArgumentException("saveThis","Argument can't be null");

            if (saveThis.Id == 0)
                saveThis.Id = ++m_currentIdValue;

            if(Items.Contains(saveThis)==false)
                Items.Add(saveThis);
        }

        public T GetById(int id)
        {
            return Items.FirstOrDefault(i => i.Id == id);
        }

        public IList<T> GetAll()
        {
            return Items;
        }

        public void Delete(T saveThis)
        {
            Items.Remove(saveThis);
        }
    }
}