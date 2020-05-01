using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravi.Learn.HealthCheck.Books.Dxos
{
    public interface IEntityDxo<in T, out U>
    {
        U MapTo(T t);
    }
}
