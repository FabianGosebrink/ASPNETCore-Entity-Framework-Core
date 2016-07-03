using System.Collections.Generic;
using AspnetCoreEF7Example.Models;

namespace AspnetCoreEF7Example.Repositories
{
    public interface IExampleRepository
    {
        IEnumerable<MyModel> GetAll();
        MyModel GetSingle(int id);
        MyModel Add(MyModel toAdd);
        MyModel Update(MyModel toUpdate);
        void Delete(MyModel toDelete);
        int Save();
    }
}