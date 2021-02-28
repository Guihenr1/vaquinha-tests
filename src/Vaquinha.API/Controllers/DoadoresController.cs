using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vaquinha.Domain.Interfaces.Service;
using Vaquinha.Domain.ViewModels;

namespace Vaquinha.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class DoadoresController : BaseController {
        private readonly IDoacaoService _doacaoService;

        public DoadoresController(IDoacaoService doacaoService) {
            _doacaoService = doacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            IEnumerable<DoadorViewModel> response = new List<DoadorViewModel>();

            try {
                response = await _doacaoService.RecuperarDoadoresAsync();
            } catch (Exception e) {
                return CreateServerErrorResponse(e);
            }

            return CreateResponse(response);
        }
    }
}