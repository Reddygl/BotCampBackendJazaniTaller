using BotCampBackendJazaniTaller.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BotCampBackendJazaniTaller.Filters
{
    public class ValidationFilters : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorModelState = context.ModelState.Where(s => s.Value?.Errors.Count > 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage)).ToList();
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.Message = "Ingrese todos los campos requeridos";
                errorResponse.Errors = new List<ErrorValidationModel>();
                errorModelState.ForEach(error =>
                {
                    foreach (var mesagge in error.Value)
                    {
                        errorResponse.Errors.Add(new()
                        {
                            FieldName = error.Key,
                            Message = mesagge,
                        });
                    }
                });
                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }

            await next();
        }
    }
}
