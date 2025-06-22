using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Music.Core.Common;
using System.Text.Json;

namespace Music.API.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.ToDictionary(
                    x => x.Key,
                    x => x.Value.Errors.Select(error => error.ErrorMessage)).ToArray();

                var result = Result.Fail(400, "Dữ liệu không hợp lệ", JsonSerializer.Serialize(errors));
                context.Result = new BadRequestObjectResult(result);
            }
        }
    }
}
