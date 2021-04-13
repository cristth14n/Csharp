using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualCombustivelEscolher
{
    class Calculodepreco
    {
        public double precoEtanol, precoGasolina = 0;

        public double comparacao()
        {
            return precoEtanol / precoGasolina;
        }

    }
}
