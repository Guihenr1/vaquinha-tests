using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Vaquinha.API.Models;
using Vaquinha.Domain.Interfaces.Service;

namespace Vaquinha.API.Controllers
{
    public class BaseController : ControllerBase {
        private readonly IDomainNotificationService _domainNotificationService;

        public BaseController(IDomainNotificationService domainNotificationService) {
            _domainNotificationService = domainNotificationService;
        }

        protected readonly string _requestId;
        protected string error;
        protected string sucess;

        public BaseController() {
            _requestId = Guid.NewGuid().ToString();
        }

        private IActionResult MakeResponse(IActionResult result) {
            Response.Headers.Add("X-Request-Id", _requestId);
            return result;
        }
        protected IActionResult CreateResponse<T>(T dto) {
            IActionResult response = Ok(dto);
            return MakeResponse(response);
        }
        protected IActionResult CreateResponse() {
            IActionResult response = Ok(sucess);
            return MakeResponse(response);
        }

        protected IActionResult CreateServerErrorResponse() {
            int status = HttpStatusCode.InternalServerError.GetHashCode();

            return MakeResponse(StatusCode(
                status,
                new ErrorResponse() {
                    Status = status,
                    Message = $"{_requestId} :: {error}"
                }
            ));
        }

        protected IActionResult CreateServerErrorResponse(Exception ex) {
            int status = HttpStatusCode.InternalServerError.GetHashCode();

            return MakeResponse(StatusCode(
                status,
                new ErrorResponse() {
                    Status = status,
                    Message = $"{_requestId} :: {ex.Message}"
                }
            ));
        }

        protected void AdicionarNotificacaoOperacaoRealizadaComSucesso(string mensagemSucesso = null) {
            sucess = mensagemSucesso ?? "Operação realizada com sucesso!";
        }

        protected void AdicionarErrosDominio() {
            var errorMessage = _domainNotificationService.PossuiErros
                ? _domainNotificationService.RecuperarErrosDominioFormatadoHtml()
                : null;

            if (!string.IsNullOrEmpty(errorMessage))
            {
                error = errorMessage;
            }
        }
    }
}