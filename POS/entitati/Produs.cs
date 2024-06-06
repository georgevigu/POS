namespace entitati
{
    public class Produs : ProdusAbstract
    {
        public Produs(int id, string? nume, string? codIntern, string? producator, int pret, string? categorie):base(id, nume, codIntern, pret, categorie)
        {
            this.Producator = producator;
        }
        public Produs() : base() { }
        public string? Producator { get; set; }
        public override string Descriere()
        {
            return "Produs: " + this.Nume + "[" + this.CodIntern + "] " + this.Producator;
        }
        public override string ToString()
        {
            return "Produs: " + base.ToString() + " " +this.Producator;
        }
        public override bool Comparare(ProdusAbstract s)
        {
            if(s is Produs)
            {
                Produs produs = (Produs)s;
                if (base.Comparare(s))
                {
                    if (this.Producator == produs.Producator)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Produs)
            {
                Produs prod = (Produs)obj;
                return base.Equals(prod);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool canAddToPackage(Pachet pachet)
        {
            if (pachet.nrProd >= Pachet.nrMaxProd)
            {
                return false;
            }
            return true;
        }
        public override void Save2XML(string filename)
        {
            throw new NotImplementedException();
        }
    }
}