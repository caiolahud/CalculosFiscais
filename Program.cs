using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculosFiscais.Impostos.ICMS;

namespace CalculosFiscais
{
    internal class Program
    {
        public static void Main()
        {
            Teste();
        }
    
        public static void Teste()
        {
            
            decimal precoDeVenda = 6062.34m;
            decimal descontoIncondicional = 0.00m;
            decimal valorDoFreteSeguro = 0.00m;
            decimal valorIPI = 0.00m;
            decimal despesasAcessorias = 0;
            decimal aliquotaDoICMS = 12.00m;
            Boolean contribuinteDoICMS = true;
            decimal mVA = 40.00m;
            decimal aliquotaDoICMSST = 18.00m;
            decimal percentualRed = 20.00m;

            decimal aliquotaInterna = 18.00m;
            decimal aliquotaInterestadual = 7.00m;

            BaseValorDoICMS baseValorICMS = new BaseValorDoICMS(precoDeVenda, valorDoFreteSeguro, despesasAcessorias, valorIPI, descontoIncondicional, aliquotaDoICMS, contribuinteDoICMS);

            var bcIcms = baseValorICMS.ObterBaseDoICMS();

            var vIcms = baseValorICMS.ObterValorDoICMS();

            BaseValorICMSST baseValorICMSST = new BaseValorICMSST(baseValorICMS, aliquotaDoICMSST, mVA);

            var vBcIcmsSt = baseValorICMSST.obterBaseICMSST();

            var vIcmsSt = baseValorICMSST.obterValorICMSST(vBcIcmsSt, vIcms);

            BaseValorICMSReducao baseReduzida = new BaseValorICMSReducao(baseValorICMS, percentualRed);
         
            var vIcmsRed = baseReduzida.ObterBaseICMSReduzida();
                

            BaseValorDifal baseVlDifal = new BaseValorDifal(baseValorICMS, aliquotaInterestadual, aliquotaInterna);
            bool difalPorFora = false;
            var baseDifal = baseVlDifal.ObterBaseDifal();
            var difal = baseVlDifal.ObterValorDifal(difalPorFora, baseDifal);
        }
    
    
    }
}
