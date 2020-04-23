using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Library_System.DAL
{
    public class AllRepository<T> : IAllRepository<T> where T : class
    {
        //connection String 

        public void DeleteModel(int modelID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetModel()
        {
            throw new NotImplementedException();
        }

        public T GetModelById(int modelId)
        {
            throw new NotImplementedException();
        }

        public void InsertModel(T model)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateModel(T model)
        {
            throw new NotImplementedException();
        }
    }
}