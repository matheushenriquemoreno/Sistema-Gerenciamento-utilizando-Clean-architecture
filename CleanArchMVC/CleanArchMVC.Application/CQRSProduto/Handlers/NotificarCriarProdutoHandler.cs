using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Application.CQRSProduto.Commands;
using CleanArchMVC.Application.Interfaces.Fila;
using MediatR;

namespace CleanArchMVC.Application.CQRSProduto.Handlers
{
    internal class NotificarCriarProdutoHandler //: INotificationHandler<NotificarCriarProdutoNotification>
    {

        //private readonly IQueueEnvioEmail _filaEnvioEmail;

        //public NotificarCriarProdutoHandler(IQueueEnvioEmail filaEnvioEmail)
        //{
        //    _filaEnvioEmail = filaEnvioEmail;
        //}

        //public Task Handle(NotificarCriarProdutoNotification notification, CancellationToken cancellationToken)
        //{
        //    return Task.Run(() =>
        //    {
        //        _filaEnvioEmail.EnvioEmail(notification);
        //    });
        //}
    }
}
