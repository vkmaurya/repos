using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Library_System.DAL
{
    interface IAllRepository<T> where T : class
    {
        IEnumerable<T> GetModel();

        T GetModelById(int modelId);

        void InsertModel(T model);

        void DeleteModel(int modelID);

        void UpdateModel(T model);

        void Save();

    }
}
