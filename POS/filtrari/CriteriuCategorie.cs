using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filtrari
{
    public class CriteriuCategorie : ICriteriu
    {
        public string Categorie { get; set; }
        public CriteriuCategorie(string categorie) 
        { 
            this.Categorie = categorie;
        }

        public bool IsIndeplinit(ProdusAbstract pa)
        {
            return pa.Categorie.Equals(Categorie, StringComparison.OrdinalIgnoreCase);
        }
    }
}
