using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculosFiscais.Impostos.ICMS
{
    public class BaseValorDifal : BaseValorDoICMS
    {

        public decimal AliquotaDifalInterestadual { get; set; }
        public decimal AliquotalDifalInterna { get; set; }

       
        public BaseValorDifal(BaseValorDoICMS baseValorDoICMS, decimal aliquotaDifalInterestadual, 
            decimal aliquotalDifalInterna) : base()
        {
            this.BaseDeCalculo = baseValorDoICMS.BaseDeCalculo;
            AliquotaDifalInterestadual = aliquotaDifalInterestadual;
            AliquotalDifalInterna = aliquotalDifalInterna;

        }

        public decimal ObterBaseDifal()
        {

            var baseDifal = BaseDeCalculo;

            return Math.Round(baseDifal, 2);
        }

        public decimal ObterValorDifal(bool difalPorFora, decimal baseDeCalculo)
        {
            if (difalPorFora)
            {
                return ObterValorDifalPorFora(baseDeCalculo);
                
            }
            else
            {
                return ObterValorDifalPorDentro(baseDeCalculo);
            }

        }


        private decimal ObterValorDifalPorFora(decimal baseDeCalculo)
        {
            return Math.Round(baseDeCalculo * ((AliquotalDifalInterna - AliquotaDifalInterestadual) / 100), 2);
        }

        private decimal ObterValorDifalPorDentro(decimal baseDeCalculo)
        {
            var icmsInterestadual = baseDeCalculo * (AliquotaDifalInterestadual / 100);
            //base de cálculo com exclusão do icms interestadual da op.
            var baseIcmsInterestadual = baseDeCalculo - icmsInterestadual;
            //base de cálculo com inclusão do ICMS interno da op.
            var baseIcmsInterno = baseIcmsInterestadual / (1 - (AliquotalDifalInterna / 100));

            var icmsInterno = baseIcmsInterno * (AliquotalDifalInterna / 100);

            return Math.Round(icmsInterno - icmsInterestadual, 2);


        }

    }
}
