using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Abstractions
{
    public interface IMyCloneable<T>
    {
        public T MyClone();
    }
}
