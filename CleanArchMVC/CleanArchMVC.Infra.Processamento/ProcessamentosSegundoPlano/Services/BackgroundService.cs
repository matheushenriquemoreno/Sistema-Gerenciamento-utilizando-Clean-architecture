using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace CleanArchMVC.Infra.Processamento.ProcessamentosSegundoPlano.Services
{
    public abstract class BackgroundService : IHostedService
    {

        private Task _executingTask;
        private readonly CancellationTokenSource _stoppingCTS = new CancellationTokenSource();


        protected abstract Task Process();


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _executingTask = ExecuteAsync(_stoppingCTS.Token);

            if (_executingTask.IsCompleted)
            {
                return _executingTask;
            }

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            // Para a chamada sem iniciar
            if (_executingTask == null)
            {
                return;
            }
            try
            {
                // Sinaliza o cancelamento para o método
                _stoppingCTS.Cancel();
            }
            finally
            {
                // Aguarde ate que a tarefa termine ou que pare
                await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
            }
        }

        protected virtual async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                await Process();
                await Task.Delay(5000, stoppingToken);
            }
            while (!stoppingToken.IsCancellationRequested);
        }


    }
}
