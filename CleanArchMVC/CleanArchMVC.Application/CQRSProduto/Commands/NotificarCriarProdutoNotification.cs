using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchMVC.Application.CQRSProduto.Commands
{
    internal class NotificarCriarProdutoNotification : INotification
    {
        public string dados { get; set; }

        public NotificarCriarProdutoNotification(string dados)
        {
            this.dados = dados;
        }
    }
}
