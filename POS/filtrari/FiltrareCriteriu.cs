using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace filtrari
{
    public class FiltrareCriteriu : IFiltrare
    {
        public IEnumerable<ProdusAbstract> Filtrare(IEnumerable<ProdusAbstract> elemente, ICriteriu criteriu)
        {
            foreach (var elem in elemente)
            {
                if (criteriu.IsIndeplinit(elem))
                {
                    yield return elem;
                }
            }
        }
    }
}
