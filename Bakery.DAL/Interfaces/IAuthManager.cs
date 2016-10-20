using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.DAL.Interfaces
{
    public interface IAuthManager<T> where T: class
    {
        T Find(Func<T, Boolean> predicate);

        bool Create(T elem);
        void Update(T elem);

    }
}
