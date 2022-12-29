using CalculosFiscais.Impostos.ICMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculosFiscasTestesUnit
{
    public class CalculoBaseValorICMSST
    {
        [Fact]
        public void CalcularBaseDoICMSST()
        {

            decimal precoDeVenda = 15000.00m;
            decimal valorDoFreteSeguro = 1000.00m;
            decimal despesasAcessorias = 0.00m;
            decimal valorIPI = 1500.00m;
            decimal descontoIncondicional = 500.00m;
            decimal aliquotaDoICMS = 12.00m;
            bool contribuinteDoICMS = true;
            decimal mVA = 40.00m;
            decimal aliquotaDoICMSST = 17.00m;


            BaseValorDoICMS baseICMS = new BaseValorDoICMS(precoDeVenda, valorDoFreteSeguro, despesasAcessorias
                , valorIPI, descontoIncondicional, aliquotaDoICMS, contribuinteDoICMS);

            var vBC = baseICMS.ObterBaseDoICMS();
            var vICMS = baseICMS.ObterValorDoICMS();

            BaseValorICMSST baseValorICMSST = new BaseValorICMSST(baseICMS,aliquotaDoICMSST, mVA);

            var vBCST = baseValorICMSST.obterBaseICMSST();
            Assert.True(vBCST.Equals(24500.00m));

        }

        [Fact]
        public void CalcularValorDoICMSST()
        {

            decimal precoDeVenda = 15000.00m;
            decimal valorDoFreteSeguro = 1000.00m;
            decimal despesasAcessorias = 0.00m;
            decimal valorIPI = 1500.00m;
            decimal descontoIncondicional = 500.00m;
            decimal aliquotaDoICMS = 12.00m;
            bool contribuinteDoICMS = true;
            decimal mVA = 40.00m;
            decimal aliquotaDoICMSST = 18.00m;


            BaseValorDoICMS baseICMS = new BaseValorDoICMS(precoDeVenda, valorDoFreteSeguro, despesasAcessorias
                , valorIPI, descontoIncondicional, aliquotaDoICMS, contribuinteDoICMS);

            var vBC = baseICMS.ObterBaseDoICMS();
            var vICMS = baseICMS.ObterValorDoICMS();

            BaseValorICMSST baseValorICMSST = new BaseValorICMSST(baseICMS, aliquotaDoICMSST, mVA);

            var vBCST = baseValorICMSST.obterBaseICMSST();
            var vICMSST = baseValorICMSST.obterValorICMSST(vBCST, vICMS);

            Assert.True(vICMSST.Equals(2550.00m));

        }
    }
}
