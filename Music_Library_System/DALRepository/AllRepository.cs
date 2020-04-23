using Music_Library_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Music_Library_System.DALRepository
{
    public class AllRepository<T> : IAllRepository<T> where T : class
    {
        private MusicModel1Db _context;
        private IDbSet<T> dbEntity;

        public AllRepository()
        {
            _context = new MusicModel1Db();
            dbEntity = _context.Set<T>();
        }
        //connection String 


        public void DeleteModel(int modelID)
        {
            T model = dbEntity.Find(modelID);
            dbEntity.Remove(model);
        }

        public IEnumerable<T> GetModel()
        {
            return dbEntity.ToList();
        }

        public T GetModelById(int modelId)
        {
            return dbEntity.Find(modelId);
        }

        public void InsertModel(T model)
        {
            dbEntity.Add(model);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateModel(T model)
        {
            _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }
    }
}