using System.Collections.Generic;
using System.Linq;
using AspnetCoreEFCoreExample.Models;

namespace AspnetCoreEFCoreExample.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly DataBaseContext _ctx;

        public ExampleRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<MyModel> GetAll()
        {
            return _ctx.MyModels;
        }

        public MyModel GetSingle(int id)
        {
            return _ctx.MyModels.FirstOrDefault(x => x.Id == id);
        }

        public MyModel Add(MyModel toAdd)
        {
            _ctx.MyModels.Add(toAdd);
            return toAdd;
        }

        public MyModel Update(MyModel toUpdate)
        {
            _ctx.MyModels.Update(toUpdate);
            return toUpdate;
        }

        public void Delete(MyModel toDelete)
        {
            _ctx.MyModels.Remove(toDelete);
        }

        public int Save()
        {
            return _ctx.SaveChanges();
        }
    }
}
