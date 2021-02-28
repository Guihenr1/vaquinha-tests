using System;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using Vaquinha.Domain.Configuration;
using Vaquinha.Service.Interfaces;

namespace Vaquinha.Service.Services
{
    public class PollyService : IPollyService {
        private GloballAppConfig _globallAppConfig;
        private readonly ILogger<PollyService> _logger;

        public PollyService(ILogger<PollyService> logger, GloballAppConfig globallAppConfig) {
            _logger = logger;
            _globallAppConfig = globallAppConfig;
        }

        public AsyncRetryPolicy CriarPoliticaWaitAndRetryPara(string method) {
            var policy = Policy.Handle<Exception>().WaitAndRetryAsync(_globallAppConfig.Polly.QuantidadeRetry,
                attempt => TimeSpan.FromSeconds(_globallAppConfig.Polly.TempoDeEsperaEmSegundos),
                (exception, calculatedWaitDuration) => {
                    _logger.LogError($"Erro ao acionar o metodo {method}. Total de tempo de retry até o momento: {calculatedWaitDuration}s");
                });

            return policy;
        }
    }
}