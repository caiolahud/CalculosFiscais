using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalculosFiscais.Impostos.ICMS
{
    public class BaseValorICMSST : BaseValorDoICMS
    {
        public decimal AliquotaDoICMSST { get; set; }
        public decimal ValorDoICMSST { get; set; }
        public decimal MVA { get; set; }


        public BaseValorICMSST(BaseValorDoICMS baseValorICMS, decimal aliquotaDoICMSST, decimal mVA)
            : base()
        {
            this.PrecoDeVenda = baseValorICMS.PrecoDeVenda;
            this.ValorDoFreteSeguro = baseValorICMS.ValorDoFreteSeguro;
            this.ValorIPI =  baseValorICMS.ValorIPI;
            AliquotaDoICMSST = aliquotaDoICMSST;
            MVA = mVA;

        }

        public decimal obterBaseICMSST()
        {

            if (MVA <= 0.00m)
            {
                throw new ArgumentException("O percentual da Margem de Valor Agregado precisa ser maior que zero.");
            }

            return Math.Round((PrecoDeVenda + ValorDoFreteSeguro + ValorIPI) * (1 + MVA / 100), 2);

        }

        public decimal obterValorICMSST(decimal baseICMSST, decimal valorICMS)
        {
            if (baseICMSST <= 0.00m || valorICMS <= 0.00m)
            {
                throw new ArgumentException("A base de cálculo do ICMS ST não foi calculada, ou " +
                      "o valor do ICMS não foi calculado.");
            }

            return Math.Round(baseICMSST * (AliquotaDoICMSST / 100) - valorICMS, 2);

        }

    }
}
