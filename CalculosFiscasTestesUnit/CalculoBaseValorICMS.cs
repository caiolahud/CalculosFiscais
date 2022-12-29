using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculosFiscais.Impostos.ICMS;

namespace CalculosFiscasTestesUnit
{
    public class CalculoBaseValorICMS
    {
        [Fact]
        public void CalcularBaseDoICMSContribuinte()
        {

            decimal precoDeVenda = 15000.00m;
            decimal valorDoFreteSeguro = 1000.00m;
            decimal despesasAcessorias = 0.00m;
            decimal valorIPI = 1500.00m;
            decimal descontoIncondicional = 500.00m;
            decimal aliquotaDoICMS = 12.00m;
            bool contribuinteDoICMS = true;

            BaseValorDoICMS baseICMS = new BaseValorDoICMS(precoDeVenda, valorDoFreteSeguro, despesasAcessorias
                ,valorIPI, descontoIncondicional, aliquotaDoICMS, contribuinteDoICMS);

            decimal vBC = baseICMS.ObterBaseDoICMS();
            Assert.True(vBC.Equals(15500.00m));


        }

        [Fact]
        public void CalcularValorICMSContribuinte()
        {
            decimal precoDeVenda = 5000.00m;
            decimal valorDoFreteSeguro = 300.00m;
            decimal despesasAcessorias = 0.00m;
            decimal valorIPI = 0.00m;
            decimal descontoIncondicional = 500.00m;
            decimal aliquotaDoICMS = 18.00m;
            bool contribuinteDoICMS = true;

            BaseValorDoICMS baseValorICMS = new BaseValorDoICMS(precoDeVenda, valorDoFreteSeguro, despesasAcessorias
                , valorIPI, descontoIncondicional, aliquotaDoICMS, contribuinteDoICMS);

            decimal vBC = baseValorICMS.ObterBaseDoICMS();
            decimal vICMS = baseValorICMS.ObterValorDoICMS();
            Assert.True(vICMS.Equals(864.00m));
        }

    }
}
