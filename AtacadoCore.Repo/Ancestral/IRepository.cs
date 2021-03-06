using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.Repo.Ancestral
{
    public interface IRepository<TDomain> where TDomain : class
    {
        IEnumerable<TDomain> Browse();

        IQueryable<TDomain> Browsable();

        TDomain Read(Expression<Func<TDomain, bool>> parameters);

        TDomain Edit(TDomain instance);

        TDomain Add(TDomain instance);

        TDomain Delete(TDomain instance);
    }
}
