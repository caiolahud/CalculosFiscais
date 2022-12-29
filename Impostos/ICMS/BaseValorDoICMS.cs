using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculosFiscais.Impostos.ICMS
{
    public class BaseValorDoICMS
    {
        public decimal PrecoDeVenda { get; set; }
        public decimal ValorDoFreteSeguro { get; set; }
        public decimal DespesasAcessorias { get; set; }
        public decimal ValorIPI { get; set; }
        public decimal DescontoIncondicional { get; set; }
        public decimal BaseDeCalculo { get; set; }
        public decimal AliquotaDoICMS { get; set; }
        public decimal ValorDoICMS { get; set; }
        //criar classe de cadastro do estabelecimento
        public bool ContribuinteDoICMS { get; set; }

        
        public BaseValorDoICMS() { }

        public BaseValorDoICMS(decimal precoDeVenda, decimal valorDoFreteSeguro, decimal despesasAcessorias, decimal valorIPI, decimal descontoIncondicional, decimal aliquotaDoICMS, bool contribuinteDoICMS)
        {
            PrecoDeVenda = precoDeVenda;
            ValorDoFreteSeguro = valorDoFreteSeguro;
            DespesasAcessorias = despesasAcessorias;
            ValorIPI = valorIPI;
            DescontoIncondicional = descontoIncondicional;
            AliquotaDoICMS = aliquotaDoICMS;
            ContribuinteDoICMS = contribuinteDoICMS;

        }

        public decimal ObterBaseDoICMS()
        {

            if (ContribuinteDoICMS)
            {
                return Math.Round(BaseDeCalculo = PrecoDeVenda + ValorDoFreteSeguro + DespesasAcessorias - DescontoIncondicional, 2); 
            }
            else
            {
                return Math.Round(BaseDeCalculo = PrecoDeVenda + ValorDoFreteSeguro + DespesasAcessorias + ValorIPI - DescontoIncondicional, 2);
            }


        }

        public decimal ObterValorDoICMS()
        {

            if (BaseDeCalculo > 0.00m)
            {
                return Math.Round(BaseDeCalculo * (AliquotaDoICMS / 100), 2);
            }
            else
            {
                throw new ArgumentException("Base do ICMS não foi calculada.");
            }

        }
    }
}
