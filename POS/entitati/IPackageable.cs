﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public interface IPackageable
    {
        protected bool canAddToPackage(Pachet pachet);
    }
}
