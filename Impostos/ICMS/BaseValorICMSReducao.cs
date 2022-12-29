using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculosFiscais.Impostos.ICMS
{
    public class BaseValorICMSReducao : BaseValorDoICMS
    {

        public decimal PercentualReducao { get; set; }

        public BaseValorICMSReducao(BaseValorDoICMS baseValorDoICMS, decimal percentualReducao)
            : base() 
        {
            this.BaseDeCalculo = baseValorDoICMS.BaseDeCalculo;
            PercentualReducao = percentualReducao;
        }
        
        public decimal ObterBaseICMSReduzida()
        {
                                               
            if (BaseDeCalculo > 0.00m)
            {
                return Math.Round((BaseDeCalculo - (BaseDeCalculo * (PercentualReducao / 100))),2);
            } 
            else 
            {
                throw new ArgumentException("Base do ICMS não foi calculada.");
            }
            
            
        }

        public decimal ObterValorICMSReduzido(decimal baseReduzida)
        {
            
            if (baseReduzida > 0.00m)
            {
                return Math.Round(baseReduzida * (AliquotaDoICMS / 100),2);
            } 
            else 
            {
               throw new ArgumentException("Base do ICMS reduzida não foi calculada.");
            }

            
        }
    }
}
