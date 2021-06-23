using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Helpers
{
    public interface IQueryManager<T> where T : class
    {

        IQueryable<T> Query();
        IQueryable<T> Query(Expression<Func<T, bool>> where);
    }
}
