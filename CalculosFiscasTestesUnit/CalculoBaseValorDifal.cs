using CalculosFiscais.Impostos.ICMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculosFiscasTestesUnit
{
    public class CalculoBaseValorDifal
    {
        [Fact]
        public void CalcularValorICMSContribuinte()
        {
            decimal precoDeVenda = 6062.34m;
            decimal valorDoFreteSeguro = 0.00m;
            decimal despesasAcessorias = 0.00m;
            decimal valorIPI = 0.00m;
            decimal descontoIncondicional = 0.00m;
            decimal aliquotaDoICMS = 18.00m;
            bool contribuinteDoICMS = true;
            decimal aliquotaInterestadual = 7.00m;
            decimal aliquotaInterna = 18.00m;

            BaseValorDoICMS baseValorICMS = new BaseValorDoICMS(precoDeVenda, valorDoFreteSeguro, despesasAcessorias, 
                valorIPI, descontoIncondicional, aliquotaDoICMS, contribuinteDoICMS);

            var vBC = baseValorICMS.ObterBaseDoICMS();
            
            var vICMS = baseValorICMS.ObterValorDoICMS();
            
            BaseValorDifal baseVlDifal = new BaseValorDifal(baseValorICMS, aliquotaInterestadual, aliquotaInterna);
            
            bool difalPorFora = false;
            
            var vBCDifal = baseVlDifal.ObterBaseDifal();
            
            var vICMSUFDest = baseVlDifal.ObterValorDifal(difalPorFora, vBCDifal);

            Assert.True(vICMSUFDest.Equals(813.24m));

        }
    }
}
