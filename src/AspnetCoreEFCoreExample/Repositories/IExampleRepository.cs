using System.Collections.Generic;
using AspnetCoreEFCoreExample.Models;

namespace AspnetCoreEFCoreExample.Repositories
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