using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SSC.Repositorio.Helpers
{

        public interface IQueryManager<T> where T : class
        {

            IQueryable<T> Where(Expression<Func<T, bool>> where);
        }
    
}
