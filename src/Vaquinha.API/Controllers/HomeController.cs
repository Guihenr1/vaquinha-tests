using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vaquinha.Domain.Interfaces.Service;
using Vaquinha.Domain.ViewModels;

namespace Vaquinha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : BaseController {
        private readonly IHomeInfoService _homeService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IHomeInfoService homeService) {
            _logger = logger;
            _homeService = homeService;
        }

        /// <summary>
        /// Dados da pagina inicial.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index() {
            var response = new HomeViewModel();

            try {
                response = await _homeService.RecuperarDadosIniciaisHomeAsync();
            } catch (Exception e) {
                return CreateServerErrorResponse(e);
            }

            return CreateResponse(response);
        }
    }
}