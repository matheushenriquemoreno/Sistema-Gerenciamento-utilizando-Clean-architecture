using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Application.CQRSProduto.Commands;
using MediatR;

namespace CleanArchMVC.Application.CQRSProduto.Handlers
{
    internal class NotificarCriarProdutoHandler : INotificationHandler<NotificarCriarProdutoNotification>
    {
        public Task Handle(NotificarCriarProdutoNotification notification, CancellationToken cancellationToken)
        {

            return Task.Run(() =>
            {
                var dados = 20000;

                for (int i = 0; i <= dados; i++)
                {
                    Console.WriteLine("Count: " + i +"\n" + notification.dados);
                }
            });
        }
    }
}
