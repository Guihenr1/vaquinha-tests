using Polly.Retry;

namespace Vaquinha.Service.Interfaces
{
    public interface IPollyService
    {
        AsyncRetryPolicy CriarPoliticaWaitAndRetryPara(string method);
    }
}