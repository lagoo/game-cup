using Application.Common.Interfaces;
using Application.Common.Models;
using Common.Extensions;
using Newtonsoft.Json;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Wrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class L3CompetitorsGameService : ICompetitorsGameService
    {
        private readonly string _remoteServiceBaseUrl = "Competidores?copa=games";
        private readonly HttpClient _httpClient;

        private static readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy =
            Policy.HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                  .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        private static readonly AsyncCircuitBreakerPolicy<HttpResponseMessage> _circuitBreakerPolicy =
            Policy.HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                  .CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));

        private readonly AsyncPolicyWrap<HttpResponseMessage> _resilientPolicy =
            _circuitBreakerPolicy.WrapAsync(_retryPolicy);

        public L3CompetitorsGameService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<CompetitorsGameDto>> GetAvailableGames()
        {
            if (_circuitBreakerPolicy.CircuitState == CircuitState.Open)
                throw new Exception("Serviço de lista de games está indisponivel!");

            var response = await _resilientPolicy.ExecuteAsync(() => _httpClient.GetAsync(_remoteServiceBaseUrl));

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<L3CompetitorsGameResponse>>(responseString);

            return result.Select(e => new CompetitorsGameDto()
            {
                Id = e.id,
                Title = e.titulo,
                Console = e.titulo.TextBetweenBrackets(),
                Grade = e.nota,
                Year = e.ano,
                ImageUrl = e.urlImagem
            }).ToList();
        }

        public async Task<IEnumerable<CompetitorsGameDto>> GetSelectedGames(IEnumerable<string> ids)
        {
            if (!ids.Any())
                throw new Exception("Lista de ids não pode ser vazia!");

            if (_circuitBreakerPolicy.CircuitState == CircuitState.Open)
                throw new Exception("Serviço de listagem dos games está indisponivel!");

            var response = await _resilientPolicy.ExecuteAsync(() => _httpClient.GetAsync(_remoteServiceBaseUrl));

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<L3CompetitorsGameResponse>>(responseString);

            return result.Where(e => ids.Contains(e.id))
                         .Select(e => new CompetitorsGameDto()
                         {
                             Id = e.id,
                             Title = e.titulo,
                             Console = e.titulo.TextBetweenBrackets(),
                             Grade = e.nota,
                             Year = e.ano,
                             ImageUrl = e.urlImagem
                         }).ToList();
        }
    }

    internal class L3CompetitorsGameResponse
    {
        public string id { get; set; }
        public string titulo { get; set; }
        public decimal nota { get; set; }
        public int ano { get; set; }
        public string urlImagem { get; set; }
    }
}
