using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchMVC.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error)
        {
        }

        public static void When(bool hasError, string error)
        {
            if(hasError)
                throw new DomainExceptionValidation(error);
        }


        public static void VerificaStringVazia(string valor, string erro)
        {
            if(string.IsNullOrEmpty(valor) || string.IsNullOrWhiteSpace(valor))
                throw new DomainExceptionValidation(erro);
        }
    }
}
