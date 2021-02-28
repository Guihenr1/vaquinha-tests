using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vaquinha.Domain.Interfaces.Service;
using Vaquinha.Domain.ViewModels;

namespace Vaquinha.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class DoacoesController : BaseController {
        private readonly IDoacaoService _doacaoService;
        private readonly IDomainNotificationService _domainNotificationService;

        public DoacoesController(IDoacaoService doacaoService,
            IDomainNotificationService domainNotificationService) 
            : base(domainNotificationService) {
            _doacaoService = doacaoService;
            _domainNotificationService = domainNotificationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<DoadorViewModel> response = new List<DoadorViewModel>();

            try {
                response = await _doacaoService.RecuperarDoadoresAsync();
            }
            catch (Exception e)
            {
                return CreateServerErrorResponse(e);
            }

            return CreateResponse(response);
        }

        [HttpPost]
        public IActionResult Create(DoacaoViewModel model) {
            try
            {
                 _doacaoService.RealizarDoacaoAsync(model);
            }
            catch (Exception e)
            {
                return CreateServerErrorResponse(e);
            }

            if (PossuiErrosDominio()) {
                AdicionarErrosDominio();
                return CreateServerErrorResponse();
            }

            AdicionarNotificacaoOperacaoRealizadaComSucesso("Doação realizada com sucesso!<p>Obrigado por apoiar nossa causa :)</p>");
            return CreateResponse();
        }

        private bool PossuiErrosDominio() {
            return _domainNotificationService.PossuiErros;
        }
    }
}