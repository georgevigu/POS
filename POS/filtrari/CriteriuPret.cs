using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filtrari
{
    public class CriteriuPret : ICriteriu
    {
        public int Pret { get; set; }
        public char Comparatie { get; set; }   
        public CriteriuPret(int pret, char comparatie)
        {
            this.Pret = pret;
            this.Comparatie = comparatie;
        }

        public bool IsIndeplinit(ProdusAbstract pa)
        {
            switch (Comparatie)
            {
                case '=':
                    return pa.Pret == Pret;
                case '<':
                    return pa.Pret < Pret;
                case '>':
                    return pa.Pret > Pret;
                default:
                    throw new ArgumentException("Operator de comparație nevalid.");
            }
        }
    }
}
