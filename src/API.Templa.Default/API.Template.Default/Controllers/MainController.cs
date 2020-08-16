using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Template.Default.Business.Interfaces;
using API.Template.Default.Business.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace API.Template.Default.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier _notifier;
        protected readonly ILogger _logger;

        protected MainController(INotifier notifier, ILogger logger)
        {
            _notifier = notifier;
            _logger = logger;
        }

        protected bool IsValidOperation()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidErrorModel(modelState);
            return CustomResponse();
        }

        protected void NotifyInvalidErrorModel(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyErrors(errorMsg);
            }
        }

        protected void NotifyErrors(string message)
        {
            _notifier.Handle(new Notification(message));
        }
    }
}
