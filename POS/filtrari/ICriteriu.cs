using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace filtrari
{
    public interface ICriteriu
    {
        public bool IsIndeplinit(ProdusAbstract pa);
    }
}
