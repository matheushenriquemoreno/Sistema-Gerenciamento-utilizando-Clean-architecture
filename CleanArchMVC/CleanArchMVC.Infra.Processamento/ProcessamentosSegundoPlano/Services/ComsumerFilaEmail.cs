using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Processamento.ProcessamentosSegundoPlano.Services
{
    public class ComsumerFilaEmail : BackgroundService
    {
        protected override Task Process()
        {
            Console.WriteLine("Processamento iniciado");
            return Task.CompletedTask;
        }
    }
}
